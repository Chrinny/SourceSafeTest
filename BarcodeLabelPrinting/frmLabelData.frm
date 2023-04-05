VERSION 5.00
Begin VB.Form frmBarCodeSpec 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Bar Code Label Data"
   ClientHeight    =   7785
   ClientLeft      =   150
   ClientTop       =   435
   ClientWidth     =   7695
   ControlBox      =   0   'False
   Enabled         =   0   'False
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
   ScaleHeight     =   7785
   ScaleWidth      =   7695
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame fraPackingEquipment 
      Caption         =   "Label caption"
      ForeColor       =   &H00800000&
      Height          =   2775
      Left            =   0
      TabIndex        =   8
      Top             =   3840
      Width           =   7695
      Begin VB.ComboBox cboQuantity 
         Enabled         =   0   'False
         Height          =   405
         Left            =   3360
         Style           =   2  'Dropdown List
         TabIndex        =   28
         Top             =   2160
         Width           =   855
      End
      Begin VB.CheckBox chkMultipleLabels 
         Caption         =   "to I.D."
         Enabled         =   0   'False
         Height          =   285
         Left            =   4800
         TabIndex        =   27
         Top             =   1080
         Width           =   1095
      End
      Begin VB.ComboBox cboStillageOrigin 
         Enabled         =   0   'False
         Height          =   405
         Left            =   3360
         TabIndex        =   26
         Top             =   1440
         Width           =   855
      End
      Begin VB.ComboBox cboStillageType 
         Enabled         =   0   'False
         Height          =   405
         Left            =   3360
         TabIndex        =   25
         Top             =   480
         Width           =   855
      End
      Begin VB.TextBox txtBarCodeLabel 
         BackColor       =   &H80000004&
         Enabled         =   0   'False
         Height          =   405
         Left            =   4920
         TabIndex        =   24
         Top             =   240
         Width           =   2655
      End
      Begin VB.TextBox txtLastID 
         BackColor       =   &H80000004&
         BeginProperty DataFormat 
            Type            =   0
            Format          =   "0000"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2057
            SubFormatType   =   0
         EndProperty
         Enabled         =   0   'False
         Height          =   405
         Left            =   5880
         MouseIcon       =   "frmLabelData.frx":0000
         MousePointer    =   99  'Custom
         TabIndex        =   19
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txtFirstID 
         BeginProperty DataFormat 
            Type            =   0
            Format          =   "0000"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2057
            SubFormatType   =   0
         EndProperty
         Enabled         =   0   'False
         Height          =   405
         Left            =   3360
         MouseIcon       =   "frmLabelData.frx":030A
         MousePointer    =   99  'Custom
         TabIndex        =   9
         Top             =   960
         Width           =   1335
      End
      Begin VB.Label lblNumberOfLabels 
         Alignment       =   1  'Right Justify
         Caption         =   "Quantity of each label"
         Enabled         =   0   'False
         Height          =   255
         Left            =   120
         TabIndex        =   23
         Top             =   2280
         Width           =   3135
      End
      Begin VB.Label lblFrom 
         Alignment       =   1  'Right Justify
         Caption         =   "From"
         Enabled         =   0   'False
         Height          =   255
         Left            =   2040
         TabIndex        =   20
         Top             =   1080
         Width           =   735
      End
      Begin VB.Label lblType 
         Alignment       =   1  'Right Justify
         Caption         =   "Stillage Type"
         Enabled         =   0   'False
         Height          =   375
         Left            =   1680
         TabIndex        =   12
         Top             =   600
         Width           =   1575
      End
      Begin VB.Label lblID 
         Alignment       =   1  'Right Justify
         Caption         =   "I.D."
         Enabled         =   0   'False
         Height          =   255
         Left            =   2760
         TabIndex        =   11
         Top             =   1080
         Width           =   495
      End
      Begin VB.Label lblOrigin 
         Alignment       =   1  'Right Justify
         Caption         =   "Stillage Origin"
         Enabled         =   0   'False
         Height          =   375
         Left            =   840
         TabIndex        =   10
         Top             =   1560
         Width           =   2415
      End
   End
   Begin VB.Frame fraActionButtons 
      Height          =   735
      Left            =   1680
      TabIndex        =   4
      Top             =   6840
      Width           =   4455
      Begin VB.CommandButton cmdOkay 
         Default         =   -1  'True
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   675
         Left            =   120
         MouseIcon       =   "frmLabelData.frx":0614
         MousePointer    =   99  'Custom
         Picture         =   "frmLabelData.frx":091E
         Style           =   1  'Graphical
         TabIndex        =   6
         ToolTipText     =   "Click to print label."
         Top             =   0
         Width           =   1695
      End
      Begin VB.CommandButton cmdCancel 
         Cancel          =   -1  'True
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   675
         Left            =   2760
         MouseIcon       =   "frmLabelData.frx":2580
         MousePointer    =   99  'Custom
         Picture         =   "frmLabelData.frx":288A
         Style           =   1  'Graphical
         TabIndex        =   5
         ToolTipText     =   "Cancel this operation"
         Top             =   0
         Width           =   1575
      End
   End
   Begin VB.Frame fraPackDetails 
      Caption         =   "Options"
      ForeColor       =   &H00800000&
      Height          =   3735
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   7695
      Begin VB.ComboBox cboPrinterType 
         Height          =   405
         Left            =   3360
         Style           =   2  'Dropdown List
         TabIndex        =   22
         Top             =   1080
         Width           =   1695
      End
      Begin VB.ComboBox cboLabelType 
         Height          =   405
         Left            =   3360
         Style           =   2  'Dropdown List
         TabIndex        =   21
         Top             =   600
         Width           =   1695
      End
      Begin VB.TextBox txtTextWidth 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0.0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2057
            SubFormatType   =   1
         EndProperty
         Height          =   420
         Left            =   3360
         TabIndex        =   15
         Text            =   "5"
         Top             =   2520
         Width           =   1095
      End
      Begin VB.ComboBox cboBarcodeFormat 
         Height          =   405
         ItemData        =   "frmLabelData.frx":44EC
         Left            =   3360
         List            =   "frmLabelData.frx":44EE
         Style           =   2  'Dropdown List
         TabIndex        =   14
         Top             =   1560
         Width           =   2175
      End
      Begin VB.TextBox txtTextHeight 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0.0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2057
            SubFormatType   =   1
         EndProperty
         Height          =   420
         Left            =   3360
         TabIndex        =   0
         Text            =   "30"
         Top             =   2040
         Width           =   1095
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "Label Type"
         Height          =   255
         Left            =   120
         TabIndex        =   18
         Top             =   720
         Width           =   3135
      End
      Begin VB.Label lblVersion 
         Caption         =   "Version"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   5760
         TabIndex        =   17
         Top             =   240
         Width           =   1815
      End
      Begin VB.Label lblTextWidth 
         Alignment       =   1  'Right Justify
         Caption         =   "Barcode width (1..16)"
         Height          =   255
         Left            =   120
         TabIndex        =   16
         Top             =   2640
         Width           =   3135
      End
      Begin VB.Label lblFormat 
         Alignment       =   1  'Right Justify
         Caption         =   "Bar Code Format"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   1680
         Width           =   3135
      End
      Begin VB.Label lblPrinterType 
         Alignment       =   1  'Right Justify
         Caption         =   "Printer Type"
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   1200
         Width           =   3135
      End
      Begin VB.Label Label3 
         Caption         =   "m.m."
         Height          =   255
         Left            =   4560
         TabIndex        =   3
         Top             =   2160
         Width           =   735
      End
      Begin VB.Label lblTextHeight 
         Alignment       =   1  'Right Justify
         Caption         =   "Barcode height"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   2160
         Width           =   3135
      End
   End
End
Attribute VB_Name = "frmBarCodeSpec"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim LoopCount As Integer
Dim strSQLStatement As String
Dim ExitStatus As Integer
Dim GoodsIssueGlassSource As String
Dim GoodsIssueGlassSourceText As String
Dim GoodsIssueSourceBatchNumber As String


Private Sub cboLabelType_Click()
    lblFrom.Enabled = True
    lblID.Enabled = True
    lblID.Enabled = True
    lblNumberOfLabels.Enabled = True
    lblType.Enabled = True
    lblOrigin.Enabled = True
'    chkMultipleLabels.Enabled = True
    cboStillageType.Enabled = True
    cboStillageOrigin.Enabled = True
    txtFirstID.Enabled = True
    txtLastID.Enabled = True
    txtFirstID.Enabled = True
    txtLastID.Enabled = True
    cboQuantity.Enabled = True
    
    cboStillageType.Text = ""
    cboStillageOrigin.Text = ""
    txtFirstID = ""
    txtLastID = ""
'    chkMultipleLabels.Value = 0
    
    Select Case cboLabelType.Text
    Case "Stillage"
        txtTextHeight = "30"
        Select Case cboPrinterType.Text
        Case "Avery"
            txtTextWidth.Text = "5"
        Case "Zebra"
            txtTextWidth.Text = "5"
        End Select
        lblType.Visible = True
        cboStillageType.Visible = True
        lblOrigin.Visible = True
        cboStillageOrigin.Visible = True
'        chkMultipleLabels.Visible = True
        lblFrom.Visible = True
        txtLastID.Visible = True
        txtLastID.Enabled = False
        cboQuantity.Text = 2
    Case "Rack"
        txtTextHeight = "30"
        Select Case cboPrinterType.Text
        Case "Avery"
            txtTextWidth.Text = "5"
        Case "Zebra"
            txtTextWidth.Text = "5"
        End Select
        lblType.Visible = False
        cboStillageType.Visible = False
        lblOrigin.Visible = False
        cboStillageOrigin.Visible = False
'        chkMultipleLabels.Visible = True
        lblFrom.Visible = True
        txtLastID.Visible = True
        txtLastID.Enabled = False
        cboQuantity.Text = 1
    Case "Other"
        lblType.Visible = False
        lblOrigin.Visible = False
        cboStillageType.Visible = False
        cboStillageOrigin.Visible = False
'        chkMultipleLabels.Visible = False
        lblFrom.Visible = False
        txtLastID.Visible = False
        txtLastID.Enabled = False
        cboQuantity.Text = 1
    End Select
End Sub

Private Sub cboPrinterType_Click()
    If cboPrinterType.Text = "Avery" Then
        txtTextWidth.Enabled = True
        lblTextWidth.Enabled = True
    Else
        txtTextWidth.Enabled = False
        lblTextWidth.Enabled = False
    End If
End Sub

Private Sub cboStillageOrigin_Change()
    txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
End Sub

Private Sub cboStillageOrigin_Click()
    txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
End Sub

Private Sub cboStillageType_Change()
    txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
End Sub

Private Sub cboStillageType_Click()
    txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
End Sub

Private Sub chkMultipleLabels_Click()
    If chkMultipleLabels.Value = 1 Then
        txtLastID.Enabled = True
        txtLastID.BackColor = vbWhite
        txtLastID.SetFocus
    Else
        txtLastID.Enabled = False
        txtLastID.BackColor = &H80000004
        txtLastID.Text = ""
    End If
End Sub

Private Sub cmdCancel_Click()
    Dim response As Integer
    Dim strSQL As String
    
    response = frmConfirm.CancelStatus("Are You Sure", "Close Printing Operation")
    If response = vbYes Then
        Unload Me
        Call MessageToLog("BarCode Label print closed" & vbNewLine)
    End If
End Sub

Private Sub cmdOkay_Click()
    Dim errStatus, errMsgString As String
    Dim psPrintStatus As Boolean
    Dim response As Integer
    Dim strStillageNumber As String
    Dim strSQL As String
    Dim rstProdnOrder As ADODB.Recordset
    Dim varBookmark As Variant
    
'    Call MessageToLog("Print request for " & cboquantity.Text & " labels, Label " & txtBarCodeLabel.Text)
    
    On Error GoTo Errhandler
    errStatus = "Validte"
    Me.MousePointer = 11
    psPrintStatus = PrintValidationStatus()
    If psPrintStatus = True Then
        frmPrintInProgress.Show vbModal
'        If optAvery.Value Then
'            Call frmPrintInProgress.pr
'        ElseIf optZebra.Value Then
'            Call frmPrintInProgress.PrintZebraLabel(Val(cboquantity.Text))
'        End If
    Else
        Call MessageToLog("Failed label validation")
    End If      'Printcheck
    Me.MousePointer = 0
    Exit Sub
Errhandler:
    Select Case errStatus
    Case "Confrm"
        errMsgString = "Unable to confirm label was printed correctly - " & Err.Description
        modLogFile.ErrorMessageToLog errMsgString
    Case Else
        frmMessage.subFormLoad "UnknownProblem" & " " & Err.Description, "CheckNetworkConnection", "PrintLabel_"
        errMsgString = "errStatus = " & errStatus & " - Unknown problem in Print Label Command - " & Err.Description
        modLogFile.ErrorMessageToLog errMsgString
    End Select
End Sub

Private Sub Form_Load()
    Dim sqlString As String
    
    lblVersion.Caption = "Version: " & App.Major & "." & App.Minor & "." & App.Revision
    fraActionButtons.BorderStyle = 0
    cboBarcodeFormat.AddItem "Code 128"              'Alphanumeric
    cboBarcodeFormat.AddItem "Code 39"               'Alphanumeric
'    cboBarcodeFormat.AddItem "CODABLK"              'Two dimensional
'    cboBarcodeFormat.AddItem "ANSI Codabar"         'Numeric only
'    cboBarcodeFormat.AddItem "Data Matrix"          'Two dimensional
'    cboBarcodeFormat.AddItem "Code11"               'Numeric only
'    cboBarcodeFormat.AddItem "Code49"               'Two dimensional
'    cboBarcodeFormat.AddItem "Code93"               'Alphanumeric
'    cboBarcodeFormat.AddItem "EAN-8"                'Retail labelling
'    cboBarcodeFormat.AddItem "EAN-13"               'Retail labelling
'    cboBarcodeFormat.AddItem "EAN-128"               'Retail labelling
'    cboBarcodeFormat.AddItem "Industrial 2 of 5"    'Numeric only
'    cboBarcodeFormat.AddItem "Interleaved 2 of 5"   'Numeric only
'    cboBarcodeFormat.AddItem "LOGMARS"              'Alphanumeric
'    cboBarcodeFormat.AddItem "MSI"                  'Numeric only
'    cboBarcodeFormat.AddItem "PDF417"
'    cboBarcodeFormat.AddItem "UPS Maxicode"         'Two dimensional
'    cboBarcodeFormat.AddItem "Plessey"              'Numeric only
'    cboBarcodeFormat.AddItem "PostNet"              'Numeric only
'    cboBarcodeFormat.AddItem "Standard 2 of 5"      'Numeric only
'    cboBarcodeFormat.AddItem "UPC-A"                'Retail labelling
'    cboBarcodeFormat.AddItem "UPC-E"
'    cboBarcodeFormat.AddItem "UPC/EAN Extensions"   'Retail labelling
'    cboBarcodeFormat.AddItem "Micro-PDF417"         'Two dimensional
'    cboBarcodeFormat.AddItem "QR Code"              'Two dimensional
    
    cboLabelType.AddItem "Stillage"
    cboLabelType.AddItem "Rack"
    cboLabelType.AddItem "Other"
    
    cboPrinterType.AddItem "Avery"
    cboPrinterType.AddItem "Zebra"
    
    cboStillageType.AddItem ""
    cboStillageType.AddItem "AJ"
    cboStillageType.AddItem "LJ"
'    cboStillageType.AddItem "LJ"
    
    cboStillageOrigin.AddItem ""
    cboStillageOrigin.AddItem "DE"
    cboStillageOrigin.AddItem "FR"
    cboStillageOrigin.AddItem "GB"
'    cboStillageOrigin.AddItem "FR"
'    cboStillageOrigin.AddItem "FR"
'    cboStillageOrigin.AddItem "FR"
'    cboStillageOrigin.AddItem "FR"
'    cboStillageOrigin.AddItem "FR"
    
    cboQuantity.AddItem "1"
    cboQuantity.AddItem "2"
    cboQuantity.AddItem "3"
    cboQuantity.AddItem "4"
    
    Me.Enabled = True
    End Sub

Public Function PrintValidationStatus() As Boolean    'Check for valid data in record before printing label
    Dim strWarning As String
    Dim strReason As String
    Dim blnOKSoFar As Boolean
    
    blnOKSoFar = True
    strWarning = ""
    strReason = ""
    
    If blnOKSoFar Then
        If cboPrinterType.Text <> "Avery" And cboPrinterType.Text <> "Zebra" Then
            blnOKSoFar = False
            strWarning = "Printer Type"
            strReason = "Select a printer type"
        End If
    End If
    
    Select Case cboLabelType.Text
    Case "Stillage"
        If blnOKSoFar Then
            If Len(txtFirstID.Text) > 8 Then
                blnOKSoFar = False
                strWarning = "Label"
                strReason = "Too many characters, only 8 characters are allowed"
            End If
    
            If blnOKSoFar Then
                If Len(txtFirstID.Text) = 0 Then
                    blnOKSoFar = False
                    strWarning = "Label"
                    strReason = "Enter some data to print"
                End If
            End If
        End If
    Case "Rack"
            If blnOKSoFar Then
                If Len(txtFirstID.Text) = 0 Then
                    blnOKSoFar = False
                    strWarning = "Label"
                    strReason = "Enter data to print"
                End If
            End If
    Case "Other"
            If blnOKSoFar Then
                If Len(txtFirstID.Text) = 0 Then
                    blnOKSoFar = False
                    strWarning = "Label"
                    strReason = "Enter some data to print"
                End If
            End If
    End Select

    If blnOKSoFar Then
        Select Case cboPrinterType
        Case "Avery"
            If Val(txtTextWidth.Text) < 1 Or Val(txtTextWidth.Text) > 16 Then
                blnOKSoFar = False
                strWarning = "Barcode width"
                strReason = "Only values 1 to 16 are allowed"
            End If
        Case "Zebra"
'            If Val(txtTextWidth.Text) < 1 Or Val(txtTextWidth.Text) > 16 Then
'                blnOKSoFar = False
'                strWarning = "Barcode width"
'                strReason = "Only values 1 to 16 are allowed"
'            End If
        End Select
    End If

    If blnOKSoFar Then
        If Val(cboQuantity.Text) < 1 Or Val(cboQuantity.Text) > 4 Then
            blnOKSoFar = False
            strWarning = "Number of Labels"
            strReason = "Only 1 to 4 labels are allowed"
        End If
    End If
    
    If blnOKSoFar Then
        If chkMultipleLabels.Value = 1 And Len(txtLastID.Text) = 0 Then
                    blnOKSoFar = False
                    strWarning = "Label"
                    strReason = "Enter final value in range to print"
        End If
    End If
    
    If Not blnOKSoFar Then
        frmMessage.subFormLoad strWarning, strReason, "Label"
    End If
    
    PrintValidationStatus = blnOKSoFar
End Function

Private Sub txtFirstID_LostFocus()
    If cboLabelType.Text = "Stillage" Then
        txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
    Else
        txtBarCodeLabel.Text = cboStillageType.Text & txtFirstID & cboStillageOrigin.Text
    End If
End Sub
