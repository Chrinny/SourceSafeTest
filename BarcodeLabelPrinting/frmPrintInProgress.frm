VERSION 5.00
Object = "{648A5603-2C6E-101B-82B6-000000000014}#1.1#0"; "MSCOMM32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmPrintInProgress 
   BackColor       =   &H00000080&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Label printing now !!"
   ClientHeight    =   3690
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5685
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   12
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3690
   ScaleWidth      =   5685
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.ProgressBar pbrPrintProgress 
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   720
      Width           =   5295
      _ExtentX        =   9340
      _ExtentY        =   661
      _Version        =   393216
      Appearance      =   1
   End
   Begin VB.TextBox txtPrintStatus 
      Height          =   1575
      Left            =   360
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   1800
      Width           =   4935
   End
   Begin MSCommLib.MSComm comPrinter 
      Left            =   4560
      Top             =   1200
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      CommPort        =   2
      DTREnable       =   -1  'True
   End
   Begin VB.Timer tmrPrintCountDown 
      Interval        =   200
      Left            =   3960
      Top             =   1200
   End
   Begin VB.Label lblPrintStatus 
      BackColor       =   &H00000080&
      Caption         =   "Printer Status:"
      ForeColor       =   &H00FFFFC0&
      Height          =   375
      Left            =   360
      TabIndex        =   1
      Top             =   1320
      Width           =   1815
   End
   Begin VB.Label lblPrintTimer 
      BackColor       =   &H00000080&
      Caption         =   "The print will be complete in "
      ForeColor       =   &H00FFFFC0&
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   5295
   End
End
Attribute VB_Name = "frmPrintInProgress"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    Dim intCounter As Integer
    Const conPrintTime As Integer = 40      'increments are 0.2 seconds
    Dim strPrintArray(300) As String
    

Private Sub Form_Activate()
    Select Case frmBarCodeSpec.cboPrinterType.Text
    Case "Avery"
        PrintAveryLabel (Val(frmBarCodeSpec.cboQuantity.Text))
    Case "Zebra"
        PrintZebraLabel (Val(frmBarCodeSpec.cboQuantity.Text))
    Case Else
        MsgBox "No printer defined"
    End Select
End Sub

Private Sub Form_Load()
    Dim strPrinterFile As String

    Me.Caption = "LabelPrintingNow"
    lblPrintStatus.Caption = "PrinterStatus"
    lblPrintTimer.Caption = "Label Print Will Complete In " & intCounter / 5 & " " & "Seconds"
    txtPrintStatus.Text = "PrintInProgress"
        
    intCounter = conPrintTime
    pbrPrintProgress.Max = conPrintTime
    txtPrintStatus.ForeColor = vbBlack
    txtPrintStatus.BackColor = vbGreen

End Sub

Private Sub tmrPrintCountDown_Timer()
'    PrintLabel
    intCounter = intCounter - 1
    lblPrintTimer.Caption = "Label Print Will Complete In " & intCounter / 5 & " " & "Seconds"
    pbrPrintProgress.Value = conPrintTime - intCounter
'    txtPrintStatus.Text = "Failure message would appear here"
    txtPrintStatus.ForeColor = vbYellow
    txtPrintStatus.BackColor = vbRed
    If intCounter = 1 Then
'        txtPrintStatus.Text = "Failure message would appear here"
        txtPrintStatus.ForeColor = vbYellow
        txtPrintStatus.BackColor = vbRed
    End If
    If intCounter = 0 Then Unload Me
    DoEvents
End Sub

Private Sub PrintAveryLabel(Optional LabelPart As Integer = 1)
    Dim i As Integer                ' Loop Counter for print commands
    Dim iLabels As Integer                ' Loop Counter for print commands
    Dim intPrintCount As Integer    ' Total number of print command strings
    Dim strHeight As String         'Barcode text height
    Dim strWidth As String         'Barcode text width
    Dim strTab As String       'Start tab location for print
    Dim lblCount As Integer
    
    
    strHeight = Val(frmBarCodeSpec.txtTextHeight.Text) - 1
    strWidth = frmBarCodeSpec.txtTextWidth.Text
    strTab = 10 + Val(frmBarCodeSpec.txtTextHeight.Text)
    
    '''''''''''''''
    '   SAP label printer control text
    '   ==============================
    '        Avery EASYPLUG command summary:
    '           #Mn/n   Magnification factor
    '           #YTnnn  Text Field Definition
    '
    For lblCount = 65 To 68
'    lblCount = 4
        i = 0
        strPrintArray(i) = "#!A1"   'Activate printer interface
        i = i + 1
        strPrintArray(i) = "#!CF"   'Clear format
        
        '#IM = Material Information
        '   #IMN = Continuous without gaps, #IMN70/90 = 70mm wide, 90mm long
        '   #IMS = With Gap
        '#PO0 = no gap offest
        '#ER = end of run
        '#N0 = american national character set
        i = i + 1
        strPrintArray(i) = "#!A1#IMN70/95#ERN0///0.00"
        i = i + 1
        strPrintArray(i) = "#G"
        
'        i = i + 1                 'Label Text
'            strPrintArray(i) = "#T047.0#J105.3#M1/1#YT109/3NM///"
'        i = i + 1
'        strPrintArray(i) = frmBarCodeSpec.txtBarCodeLabel.Text
    
        'Label text in Bar-code format
        '=============================
        i = i + 1           'Position
                            '#Tnn    Tab to Horizontal tab position
                            '#Jnn    Justify to Vertical print position
        strPrintArray(i) = "#T40#J20" & _
        "#YB013" & _
        "/1M" & _
        "/" & strHeight & _
        "/" & strWidth & _
        "///"
        strPrintArray(i) = strPrintArray(i) & Format(lblCount, "00") & frmBarCodeSpec.txtBarCodeLabel.Text      'Text
        
'        i = i + 1
'        strPrintArray(i) = "#T500#J20" & _
'        "#YB013" & _
'        "/1M" & _
'        "/" & strHeight & _
'        "/" & strWidth & _
'        "///"
'        strPrintArray(i) = strPrintArray(i) & Format(lblCount, "00") & frmBarCodeSpec.txtBarCodeLabel.Text      'Text
            
        Debug.Print strPrintArray(i)
        i = i + 1
        strPrintArray(i) = "#G"                                     'Terminate command
        
        i = i + 1
        strPrintArray(i) = "#Q1"        'Print and cut each label individually
'        strPrintArray(i) = "#Q" & frmBarCodeSpec.cboQuantity.Text        'Print Quantity
        i = i + 1
        strPrintArray(i) = "#G"         'Terminate the command
        i = i + 1
        strPrintArray(i) = "#CIM"       'Cut
        i = i + 1
        strPrintArray(i) = "#!P1"       'De-activate printer interface
        intPrintCount = i
    
    '   SAP label printer control
    '   =========================
    
    '    comPrinter.PortOpen = True
    '    For i = 0 To intPrintCount
    '        comPrinter.Output = strPrintArray(i)
    '    Next i
    '    comPrinter.PortOpen = False
        For iLabels = 1 To LabelPart
            For i = 0 To intPrintCount
    '           If i = 33 Then Stop
                Printer.Print strPrintArray(i)
            Next i
        Next iLabels
    Next lblCount
        Printer.EndDoc
    Call MessageToLog(frmBarCodeSpec.cboQuantity & " " & frmBarCodeSpec.cboBarcodeFormat.Text & " BarCode(s) Printed. Caption:" & frmBarCodeSpec.txtBarCodeLabel & ", Height:" & frmBarCodeSpec.txtTextHeight & ", Bar width:" & frmBarCodeSpec.txtTextWidth)
    
End Sub

Private Sub PrintZebraLabel(Optional LabelPart As Integer = 1)
    Dim i As Integer                'Loop Counter for print commands
    Dim intPrintCount As Integer    'Total number of print command strings
    Dim strHeight As String         'Barcode text height
    
    strHeight = frmBarCodeSpec.txtTextHeight.Text * 10
    
    '^XA=start new label
    i = i + 1               'Clear bitmap
    strPrintArray(i) = "^XA^EF^XZ"
    i = i + 1               'Clear bitmap
    strPrintArray(i) = "^XA^MCY^XZ"
        '^LH000=Label home=0
        '^LL2875=length=2875 dots.
        '       Length depends upon printhead: 6,8,12 or 24 dot/mm
        'default orientation normal
        'default no reverse print
    i = i + 1               ', ,
    'strPrintArray(i) = "^XA^LH000,000^LL2875^FS"
    strPrintArray(i) = "^XA^LH000,000^LL600^FS"
    
        '^FO265,150^A0R
        '^A=alphanumeric 0=font R=rotate 90
        'char height
        '67=char width
'    i = i + 1               'Alphanumeric Number
'    strPrintArray(i) = "^FO265,150^A0R," & _
'        strHeight & _
'        ",67^FD" & _
'         frmBarCodeSpec.txtBarCodeLabel.Text & "^FS"

    If frmBarCodeSpec.cboBarcodeFormat.Text = "Code 39" Then
        i = i + 1               'Code 39 Barcode Number
            '^F050,150=start print position
            '^B3=Code39 barcode
            'R=90rotation,N=No Mod43 check
            'barcode height
            'Y=print interpretation line,N=no interpretation line
            'Y=print interpretation line above code,N=no upper interpretation line
            '^FD=start text field
            '^FS=end text field
        strPrintArray(i) = "^FO50,150" & _
            "^B3R," & _
            "N," & _
            strHeight & "," & _
            "Y," & _
            "N" & _
            "^FD" & _
            frmBarCodeSpec.txtBarCodeLabel.Text & _
            "^FS"
        
    ElseIf frmBarCodeSpec.cboBarcodeFormat.Text = "Code 128" Then
        i = i + 1               'Code 128 Barcode Number
            '^F050,150=start print position
            '^BC=Code 128 barcode, R=90rotation,N=Normal
            'barcode height in dots
            'Y=print interpretation line,N=no upper interpretation line
            '^FD=start text field
            '^FS=end text field
        strPrintArray(i) = "^FO50,150" & _
            "^BCR," & _
            strHeight & "," & _
            "Y," & _
            "N" & _
            "^FD" & _
            frmBarCodeSpec.txtBarCodeLabel.Text & _
            "^FS"
    
    End If
    
    i = i + 1               'Comment description here
    strPrintArray(i) = "^PQ1^MCN^XZ"
    intPrintCount = i

    
    For i = 0 To intPrintCount
        Printer.Print strPrintArray(i)
    Next i
    Printer.EndDoc
End Sub
