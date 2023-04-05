VERSION 5.00
Begin {C0E45035-5775-11D0-B388-00A0C9055D8E} DE1 
   ClientHeight    =   11160
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   10830
   _ExtentX        =   19103
   _ExtentY        =   19685
   FolderFlags     =   1
   TypeLibGuid     =   "{46CADB2D-4D0F-11D4-A60C-00C06C284058}"
   TypeInfoGuid    =   "{46CADB2E-4D0F-11D4-A60C-00C06C284058}"
   TypeInfoCookie  =   0
   Version         =   4
   NumConnections  =   1
   BeginProperty Connection1 
      ConnectionName  =   "CN1"
      ConnDispId      =   1001
      SourceOfData    =   3
      ConnectionSource=   $"DE1.dsx":0000
      Expanded        =   -1  'True
      IsSQL           =   -1  'True
      QuoteChar       =   34
      SeparatorChar   =   46
   EndProperty
   NumRecordsets   =   4
   BeginProperty Recordset1 
      CommandName     =   "TimeIntervals"
      CommDispId      =   1013
      RsDispId        =   1066
      CommandText     =   "SELECT DISTINCT LogInterval FROM APP_ChartWizardTags ORDER BY LogInterval"
      ActiveConnectionName=   "CN1"
      CommandType     =   1
      Expanded        =   -1  'True
      IsRSReturning   =   -1  'True
      NumFields       =   1
      BeginProperty Field1 
         Precision       =   5
         Size            =   2
         Scale           =   0
         Type            =   2
         Name            =   "LogInterval"
         Caption         =   "LogInterval"
      EndProperty
      NumGroups       =   0
      ParamCount      =   0
      RelationCount   =   0
      AggregateCount  =   0
   EndProperty
   BeginProperty Recordset2 
      CommandName     =   "dbo_APP_ChartWizard_Scada_GetLastValue"
      CommDispId      =   1078
      RsDispId        =   -1
      CommandText     =   "dbo.APP_ChartWizard_Scada_GetLastValue"
      ActiveConnectionName=   "CN1"
      CallSyntax      =   "{? = CALL dbo.APP_ChartWizard_Scada_GetLastValue( ?) }"
      NumFields       =   0
      NumGroups       =   0
      ParamCount      =   2
      BeginProperty P1 
         RealName        =   "RETURN_VALUE"
         Direction       =   4
         Precision       =   10
         Scale           =   0
         Size            =   0
         DataType        =   3
         HostType        =   3
         Required        =   0   'False
      EndProperty
      BeginProperty P2 
         RealName        =   "@TagId"
         Direction       =   1
         Precision       =   5
         Scale           =   0
         Size            =   0
         DataType        =   2
         HostType        =   2
         Required        =   -1  'True
      EndProperty
      RelationCount   =   0
      AggregateCount  =   0
   EndProperty
   BeginProperty Recordset3 
      CommandName     =   "dbo_APP_ChartWizard_Scada_TagList"
      CommDispId      =   1083
      RsDispId        =   1086
      CommandText     =   "dbo.APP_ChartWizard_Scada_TagList"
      ActiveConnectionName=   "CN1"
      CallSyntax      =   "{? = CALL dbo.APP_ChartWizard_Scada_TagList( ?) }"
      Expanded        =   -1  'True
      IsRSReturning   =   -1  'True
      NumFields       =   7
      BeginProperty Field1 
         Precision       =   0
         Size            =   255
         Scale           =   0
         Type            =   202
         Name            =   "Tag"
         Caption         =   "Tag"
      EndProperty
      BeginProperty Field2 
         Precision       =   5
         Size            =   2
         Scale           =   0
         Type            =   2
         Name            =   "LogInterval"
         Caption         =   "LogInterval"
      EndProperty
      BeginProperty Field3 
         Precision       =   5
         Size            =   2
         Scale           =   0
         Type            =   2
         Name            =   "TagID"
         Caption         =   "TagID"
      EndProperty
      BeginProperty Field4 
         Precision       =   0
         Size            =   2
         Scale           =   0
         Type            =   11
         Name            =   "RecordOnlyOnChange"
         Caption         =   "RecordOnlyOnChange"
      EndProperty
      BeginProperty Field5 
         Precision       =   15
         Size            =   8
         Scale           =   0
         Type            =   5
         Name            =   "DifferenceBeforeChangeIsRecorded"
         Caption         =   "DifferenceBeforeChangeIsRecorded"
      EndProperty
      BeginProperty Field6 
         Precision       =   0
         Size            =   20
         Scale           =   0
         Type            =   129
         Name            =   "FactoryAreaName"
         Caption         =   "FactoryAreaName"
      EndProperty
      BeginProperty Field7 
         Precision       =   0
         Size            =   15
         Scale           =   0
         Type            =   129
         Name            =   "EngineeringUnitName"
         Caption         =   "EngineeringUnitName"
      EndProperty
      NumGroups       =   0
      ParamCount      =   2
      BeginProperty P1 
         RealName        =   "RETURN_VALUE"
         Direction       =   4
         Precision       =   10
         Scale           =   0
         Size            =   0
         DataType        =   3
         HostType        =   3
         Required        =   0   'False
      EndProperty
      BeginProperty P2 
         RealName        =   "@LogInterval"
         Direction       =   1
         Precision       =   10
         Scale           =   0
         Size            =   0
         DataType        =   3
         HostType        =   3
         Required        =   -1  'True
      EndProperty
      RelationCount   =   0
      AggregateCount  =   0
   EndProperty
   BeginProperty Recordset4 
      CommandName     =   "dbo_APP_ChartWizard_Scada_UpdateTagData"
      CommDispId      =   1100
      RsDispId        =   -1
      CommandText     =   "dbo.APP_ChartWizard_Scada_UpdateTagData"
      ActiveConnectionName=   "CN1"
      CallSyntax      =   "{? = CALL dbo.APP_ChartWizard_Scada_UpdateTagData( ?, ?, ?) }"
      NumFields       =   0
      NumGroups       =   0
      ParamCount      =   4
      BeginProperty P1 
         RealName        =   "@RETURN_VALUE"
         UserName        =   "RETURN_VALUE"
         Direction       =   4
         Precision       =   10
         Scale           =   0
         Size            =   0
         DataType        =   3
         HostType        =   3
         Required        =   0   'False
      EndProperty
      BeginProperty P2 
         RealName        =   "@TimeStamp"
         Direction       =   1
         Precision       =   0
         Scale           =   0
         Size            =   0
         DataType        =   135
         HostType        =   7
         Required        =   -1  'True
      EndProperty
      BeginProperty P3 
         RealName        =   "@TagID"
         Direction       =   1
         Precision       =   5
         Scale           =   0
         Size            =   0
         DataType        =   2
         HostType        =   2
         Required        =   -1  'True
      EndProperty
      BeginProperty P4 
         RealName        =   "@TheValue"
         Direction       =   1
         Precision       =   7
         Scale           =   0
         Size            =   0
         DataType        =   4
         HostType        =   4
         Required        =   -1  'True
      EndProperty
      RelationCount   =   0
      AggregateCount  =   0
   EndProperty
End
Attribute VB_Name = "DE1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub DataEnvironment_Initialize()
    On Error GoTo err
    Dim str As String
    Open App.path & "\asconnection.udl" For Input As #1
    Input #1, str
    Input #1, str
    Input #1, str
    Me.CN1.ConnectionString = str
    Me.CN1.Properties("Prompt") = adPromptNever
    Exit Sub
err:
    err.Raise err.number, "DataEnvironment", ".UDL File Error " & err.Description
End Sub
