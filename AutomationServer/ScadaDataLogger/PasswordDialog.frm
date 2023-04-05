VERSION 5.00
Begin VB.Form PasswordDialog 
   BorderStyle     =   3  'Fixed Dialog
   ClientHeight    =   1590
   ClientLeft      =   2760
   ClientTop       =   3465
   ClientWidth     =   3600
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1590
   ScaleWidth      =   3600
   ShowInTaskbar   =   0   'False
   Begin VB.TextBox txtPassword 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   120
      PasswordChar    =   "*"
      TabIndex        =   1
      Top             =   600
      Width           =   3375
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "OK"
      Height          =   375
      Left            =   960
      TabIndex        =   0
      Top             =   1080
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Enter Passord To Shutdown SCADA Logging"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   120
      Width           =   3375
   End
End
Attribute VB_Name = "PasswordDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Private Sub OKButton_Click()
    If txtPassword = SCADA1.gblPassword Then
        SCADA1.gblOKToExit = True
    End If
    Unload Me
End Sub

