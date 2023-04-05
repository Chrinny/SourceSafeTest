VERSION 5.00
Begin VB.Form frmMessage 
   BackColor       =   &H00808000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "System Message"
   ClientHeight    =   1890
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5115
   ControlBox      =   0   'False
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1890
   ScaleWidth      =   5115
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdOkay 
      Default         =   -1  'True
      Height          =   556
      Left            =   1680
      MouseIcon       =   "frmMessage.frx":0000
      MousePointer    =   99  'Custom
      Picture         =   "frmMessage.frx":030A
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   1200
      Width           =   1575
   End
   Begin VB.Label lblReason 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BackColor       =   &H00808000&
      Caption         =   "Reason Message"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   615
      Left            =   840
      TabIndex        =   2
      Top             =   600
      Width           =   3435
      WordWrap        =   -1  'True
   End
   Begin VB.Image imgExcl 
      Height          =   480
      Left            =   240
      Picture         =   "frmMessage.frx":322C
      Top             =   120
      Width           =   480
   End
   Begin VB.Label lblWarning 
      AutoSize        =   -1  'True
      BackColor       =   &H00808000&
      Caption         =   "Warning Message"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   285
      Left            =   840
      TabIndex        =   0
      Top             =   120
      Width           =   4125
      WordWrap        =   -1  'True
   End
End
Attribute VB_Name = "frmMessage"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdOkay_Click()
    Unload Me
End Sub

Public Sub subFormLoad(strWarning As String, Optional strReason As String = "", Optional strCaption As String = "")
    Me.Scale
    Me.Caption = UCase(strCaption)
    lblWarning.Caption = strWarning
    lblReason.Caption = strReason
    lblReason.Top = lblWarning.Top + lblWarning.Height + 300
    cmdOkay.Top = lblReason.Top + lblReason.Height + 300
    Me.Height = cmdOkay.Top + cmdOkay.Height + 800
    Me.Show vbModal
End Sub

