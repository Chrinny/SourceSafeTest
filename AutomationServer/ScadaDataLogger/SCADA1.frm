VERSION 5.00
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form SCADA1 
   Caption         =   "SCADA Loops"
   ClientHeight    =   9255
   ClientLeft      =   60
   ClientTop       =   525
   ClientWidth     =   15240
   ControlBox      =   0   'False
   Icon            =   "SCADA1.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   9255
   ScaleWidth      =   15240
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame1 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BorderStyle     =   0  'None
      Caption         =   "Frame1"
      ForeColor       =   &H80000008&
      Height          =   135
      Left            =   11160
      TabIndex        =   1
      Top             =   9240
      Width           =   135
   End
   Begin VB.Timer StartupDelayTimer 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   840
      Top             =   4440
   End
   Begin VB.Timer PollTimer 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   840
      Top             =   2880
   End
   Begin MSFlexGridLib.MSFlexGrid MSFlexGrid1 
      Height          =   9255
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   15255
      _ExtentX        =   26908
      _ExtentY        =   16325
      _Version        =   393216
      AllowUserResizing=   1
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Menu mPopupSys 
      Caption         =   "&SysTray"
      Visible         =   0   'False
      Begin VB.Menu mPopStart 
         Caption         =   "&Start"
      End
      Begin VB.Menu mpopStop 
         Caption         =   "S&top"
      End
      Begin VB.Menu mPopHide 
         Caption         =   "&Hide"
      End
      Begin VB.Menu mPopRestore 
         Caption         =   "&Restore"
      End
      Begin VB.Menu mPopExit 
         Caption         =   "&Exit"
      End
   End
End
Attribute VB_Name = "SCADA1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Scada Logging Application

' On start: reads a list of tags to log from DB
' On timer: reads all tags, logs & displays changes to DB
'
' Trace is 1 = debug, 2 = App Log, 3 = file(overwrite), 4 = file (append)
'
' Revision history:
' 1.5.0 Added command-line parameter for quick startup, fixed compilation under XP for Win2k3 server

Option Explicit
Dim myPollData As PollData
Dim conStartMinimizedFlag As Boolean
Dim conStartDelayCounter As Integer
Dim StartDelayCounter As Integer

Public gblOKToExit As Boolean
Public gblPassword As String


Sub SetIcon(icon As Integer)
    Me.icon = LoadResPicture(icon, vbResIcon)
    nid.hIcon = Me.icon
    If Not Shell_NotifyIcon(NIM_MODIFY, nid) Then
           Shell_NotifyIcon NIM_ADD, nid
    End If
End Sub

Private Sub Form_Load()
    On Error GoTo err:
    
    conTraceFlag = GetSetting(App.EXEName, "Startup", "TraceFlag", 3)
    '#####conTraceFlag = 1
    conStartMinimizedFlag = GetSetting(App.EXEName, "Startup", "StartMinimizedFlag", 0)
    '######conStartMinimizedFlag = True
    conStartDelayCounter = GetSetting(App.EXEName, "Startup", "MinsStartDelay", 2)
    gblPassword = GetSetting(App.EXEName, "Startup", "Password", "CARROT")
    
    SaveSetting App.EXEName, "Startup", "TraceFlag", conTraceFlag
    SaveSetting App.EXEName, "Startup", "StartMinimizedFlag", conStartMinimizedFlag
    SaveSetting App.EXEName, "Startup", "MinsStartDelay", conStartDelayCounter
    SaveSetting App.EXEName, "Startup", "Password", gblPassword
    
    Me.Caption = Me.Caption & " (Ver " & App.Major & "." & App.Minor & ")"
    
    TraceInitialise

    'New addition to 1.5: specifying a command-line argument of "/q" starts us up in quick mode
                                                                    '(ie. 0 mins start delay).
    If InStr(Command$, "/q") Then
        StartDelayCounter = 0
    Else
        StartDelayCounter = conStartDelayCounter
        'StartDelayCounter = 0
    End If

    StartupDelayTimer.Enabled = True
    
    TraceInfo "ScadaDataService:Form Load Complete"
    Exit Sub
err:
    TraceInfo err.Description & vbCr & " " & err.Source
    MsgBox "Fatal Error has been logged - OK to Shutdown"
    End
End Sub

Private Sub Frame1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'this procedure receives the callbacks from the System Tray icon.
    Dim Result As Long
    Dim Msg As Long
    'the value of X will vary depending upon the scalemode setting
    If Me.ScaleMode = vbPixels Then
        Msg = X
    Else
        Msg = X / Screen.TwipsPerPixelX
    End If
    Select Case Msg
    Case WM_LBUTTONUP        '514 restore form window
        Me.WindowState = vbNormal
        Result = SetForegroundWindow(Me.hWnd)
        Me.Show
    Case WM_LBUTTONDBLCLK    '515 restore form window
        Me.WindowState = vbNormal
        Result = SetForegroundWindow(Me.hWnd)
        Me.Show
    Case WM_RBUTTONUP        '517 display popup menu
        Result = SetForegroundWindow(Me.hWnd)
        Me.PopupMenu Me.mPopupSys
    End Select
End Sub

Private Sub Form_Resize()
    'this is necessary to assure that the minimized window is hidden
    If Me.WindowState = vbMinimized Then Me.Hide
End Sub

Private Sub Form_Unload(Cancel As Integer)
    'this removes the icon from the system tray
    On Error Resume Next
    DE1.CN1.Close
    PollTimer.Enabled = False
    myPollData.UnLinkPollDataFromFix
    Set myPollData = Nothing
    Shell_NotifyIcon NIM_DELETE, nid
    TraceInfo "ScadaDataService:UnLoad"
End Sub

Private Function InitializeChart() As Boolean
    On Error GoTo err
    MSFlexGrid1.Cols = 10
    MSFlexGrid1.FormatString = "Int.|TagID   |FullTagName                                                          |Value          |Time                           |Status                                                       |EngUnits |AreaCode |RecOnDiff|RecDiff"
    InitializeChart = True
    Exit Function
err:
    TraceInfo "InitializeChart:" & err.Description
    InitializeChart = False
End Function

Private Function DrawChart(ByRef thePollData As PollData) As Boolean
    Dim intRow As Integer
    
    Dim iInterval As Integer
    Dim iTag As Integer
    Dim strNode As String
    Dim strTag As String
    Dim strField As String
    Dim sngValue As Single
    Dim strEngineeringUnits As String
    Dim strFactoryAreaCode As String
    Dim blnRecordOnlyOnChange As Boolean
    Dim sngDifferenceBeforeChangeIsRecorded As Single
    
    On Error GoTo err
    intRow = 1
    For iInterval = 0 To thePollData.NoOfTimeIntervals - 1
        For iTag = 0 To thePollData.NoOfTagsAtInterval(iInterval) - 1
            MSFlexGrid1.AddItem ""
            MSFlexGrid1.TextMatrix(intRow, 0) = thePollData.TimeInterval(iInterval)
            MSFlexGrid1.TextMatrix(intRow, 1) = thePollData.TagID(iInterval, iTag)
            MSFlexGrid1.TextMatrix(intRow, 2) = thePollData.TagName(iInterval, iTag)
            
            
            thePollData.TagParts iInterval, _
                                 iTag, _
                                 strNode, _
                                 strTag, _
                                 strField, _
                                 sngValue, _
                                 strEngineeringUnits, _
                                 strFactoryAreaCode, _
                                 blnRecordOnlyOnChange, _
                                 sngDifferenceBeforeChangeIsRecorded
                                 
            MSFlexGrid1.TextMatrix(intRow, 3) = sngValue
            MSFlexGrid1.TextMatrix(intRow, 4) = thePollData.TimeOfLastRead(iInterval)
            MSFlexGrid1.TextMatrix(intRow, 6) = strEngineeringUnits
            MSFlexGrid1.TextMatrix(intRow, 7) = strFactoryAreaCode
            MSFlexGrid1.TextMatrix(intRow, 8) = blnRecordOnlyOnChange
            MSFlexGrid1.TextMatrix(intRow, 9) = sngDifferenceBeforeChangeIsRecorded
           
            thePollData.ResetNewData iInterval, iTag
            intRow = intRow + 1
        Next iTag
    Next iInterval
    DrawChart = True
    Exit Function
err:
    TraceInfo "DrawChart:" & err.Description
    DrawChart = False
End Function

Private Sub mPopExit_Click()
   'called when user clicks the popup menu Exit command
   gblOKToExit = False
   Load PasswordDialog
   PasswordDialog.Show vbModal, Me
   If gblOKToExit Then
      Unload Me
    End If
End Sub

Private Sub mPopRestore_Click()
    'called when the user clicks the popup menu Restore command
    mPopStart.Enabled = True
    mpopStop.Enabled = True
    mPopExit.Enabled = True
    mPopRestore.Enabled = False
    mPopHide.Enabled = True
    Me.WindowState = vbNormal
    SetForegroundWindow Me.hWnd
    Me.Show
End Sub

Private Sub mPopHide_Click()
    'called when the user clicks the popup menu Hide command
    mPopStart.Enabled = False
    mpopStop.Enabled = False
    mPopExit.Enabled = False
    mPopRestore.Enabled = True
    mPopHide.Enabled = False
    Me.WindowState = vbMinimized
    Me.Hide
End Sub

Private Sub mPopStart_Click()
    'called when the user clicks the popup menu Start command
    PollTimer.Enabled = True
    TraceInfo "ScadaDataService:Started "
    SetIcon (101)
End Sub

Private Sub mPopStop_Click()
    'called when the user clicks the popup menu Stop command
   gblOKToExit = False
   Load PasswordDialog
   PasswordDialog.Show vbModal, Me
   If gblOKToExit Then
        TraceInfo "ScadaDataService:Stopped "
        SetIcon (104)
        PollTimer.Enabled = False
   End If
End Sub

Private Sub PollTimer_Timer()
    On err GoTo err
    If myPollData.IsPollRequired Then
       myPollData.PollNewData
       UpdateChart myPollData
   End If
   Exit Sub
err:
    TraceInfo "PollTimer:" & err.Description & vbCr & err.Sourc
End Sub

Private Sub UpdateChart(ByRef thePollData As PollData)
    Dim intRow As Integer
    Dim iInterval As Integer
    Dim iTag As Integer
    On Error GoTo err
    intRow = 1
    For iInterval = 0 To thePollData.NoOfTimeIntervals - 1
        For iTag = 0 To thePollData.NoOfTagsAtInterval(iInterval) - 1
            If thePollData.IsNewData(iInterval, iTag) Then
                Dim dtmLastUpdateDate As Date
                Dim sngValue As Single
                Dim intTagID As Integer
                Dim strStatus As String
                thePollData.TagLogData iInterval, iTag, intTagID, sngValue, dtmLastUpdateDate, strStatus
                MSFlexGrid1.TextMatrix(intRow, 3) = sngValue
                MSFlexGrid1.TextMatrix(intRow, 4) = dtmLastUpdateDate
                MSFlexGrid1.TextMatrix(intRow, 5) = strStatus
                thePollData.ResetNewData iInterval, iTag
            End If
            intRow = intRow + 1
        Next iTag
    Next iInterval
    Exit Sub
err:
    TraceInfo "UpdateChart: " & err.Description & vbCr & err.number
End Sub

Private Sub StartupDelayTimer_Timer()
    On Error GoTo err
    StartupDelayTimer.interval = 60000
    If StartDelayCounter > 0 Then
        StartDelayCounter = StartDelayCounter - 1
        TraceInfo "Start=" & StartDelayCounter
        Exit Sub
    End If
    
    DE1.CN1.Open
     
    If FixIsFixRunning() = False Then
        ' Raise the exception
        TraceInfo "Fix Not Running at all"
        err.Raise vbObjectError + 512, "PollData.LinkPollData", "Fix Not Running Yet"
    End If
    TraceInfo "Fix Running"

    'the form must be fully visible before calling Shell_NotifyIcon
    Me.Show
    Me.Refresh
    With nid
        .cbSize = Len(nid)
        .hWnd = Frame1.hWnd
        .uId = vbNull
        .uFlags = NIF_ICON Or NIF_TIP Or NIF_MESSAGE
        .uCallBackMessage = WM_MOUSEMOVE
        .hIcon = Me.icon
        .szTip = "Scada Data Logging" & vbNullChar
    End With
    Shell_NotifyIcon NIM_ADD, nid


    On Error GoTo err1
    Set myPollData = New PollData
    TraceInfo "Build Poll Data"

    If myPollData.BuildPollData Then
        If InitializeChart Then
            If DrawChart(myPollData) Then
                TraceInfo "Link Poll Data"

                If myPollData.LinkPollDataToFix Then
                    With PollTimer
                        .interval = 1000
                        .Enabled = True
                    End With
                    TraceInfo "Scada Data Logging:Load Complete"
                    Shell_NotifyIcon NIM_ADD, nid
                Else
                    err.Raise 1, "Form Load", "Failed to Link To FIX"
                End If
            Else
                err.Raise 1, "Form Load", "Failed to Draw Chart"
            End If
        Else
            err.Raise 1, "Form Load", "Failed to Initialize Chart"
        End If
    Else
        err.Raise 1, "Form_Load", "Failed to build poll data"
    End If
    StartupDelayTimer.Enabled = False
    If conStartMinimizedFlag Then
        mPopHide_Click
        'Me.WindowState = vbMinimized
        'Me.Hide
    End If

    Exit Sub
err:
    TraceInfo err.Description
    On Error Resume Next
    If DE1.CN1.State <> adStateClosed Then
        DE1.CN1.Close
    End If
    err.Clear
    'try again
    Exit Sub
err1:
    TraceInfo err.Description & vbCr & " " & err.Source
    MsgBox "Fatal Error has been logged - OK to Shutdown"
    Unload Me
    End
End Sub
