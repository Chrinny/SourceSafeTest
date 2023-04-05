VERSION 5.00
Begin VB.Form frmConfirm 
   BackColor       =   &H00808000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Caption"
   ClientHeight    =   1725
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4530
   ControlBox      =   0   'False
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1725
   ScaleWidth      =   4530
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdCancel 
      Cancel          =   -1  'True
      Height          =   675
      Left            =   2400
      MouseIcon       =   "frmConfirm.frx":0000
      MousePointer    =   99  'Custom
      Picture         =   "frmConfirm.frx":030A
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   840
      Width           =   1755
   End
   Begin VB.CommandButton cmdOkay 
      Default         =   -1  'True
      Height          =   675
      Left            =   360
      MouseIcon       =   "frmConfirm.frx":23A4
      MousePointer    =   99  'Custom
      Picture         =   "frmConfirm.frx":26AE
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   840
      Width           =   1755
   End
   Begin VB.Label lblWarning 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BackColor       =   &H00808000&
      Caption         =   "Warning"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   285
      Left            =   720
      TabIndex        =   2
      Top             =   240
      Width           =   3630
      WordWrap        =   -1  'True
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   120
      Picture         =   "frmConfirm.frx":55D0
      Top             =   120
      Width           =   480
   End
End
Attribute VB_Name = "frmConfirm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim response As Integer


Private Sub cmdCancel_Click()
    response = vbNo
    Unload Me
End Sub

Private Sub cmdOkay_Click()
    response = vbYes
    Unload Me
End Sub

Public Function CancelStatus(strWarning As String, Optional strCaption As String = "") As Integer
    Me.Caption = UCase(strCaption)
    Me.lblWarning.Caption = strWarning
    Me.Show vbModal
    CancelStatus = response
End Function

Public Sub subFormLoad(strWarning As String, Optional strCaption As String = "")
    Me.Caption = UCase(strCaption)
    Me.lblWarning.Caption = strWarning
    cmdOkay.Top = lblWarning.Height + cmdOkay.Height + 200
    cmdCancel.Top = cmdOkay.Top
    Me.ScaleHeight = cmdOkay.Top + cmdOkay.Height + 200
    Me.Show vbModal
End Sub

