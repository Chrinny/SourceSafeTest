VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "PollData"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit
Private PollList() As PollItem
Private lngPollDataGroup As Long
Private intFixError As Integer
Private strFixError As String * 80

'############### table routines
Public Function BuildPollData() As Boolean
    On Error GoTo errTimes
    Dim iPollList As Integer
    Dim myTime As Date
    'read poll intervals
    DE1.rsTimeIntervals.Open
    iPollList = 0
    myTime = Now
    While Not DE1.rsTimeIntervals.EOF
        ReDim Preserve PollList(iPollList + 1)
        With PollList(iPollList)
            .intInterval = DE1.rsTimeIntervals.Fields("LogInterval").Value
            .dtmLastScan = CorrectTime(myTime, .intInterval)
            .dtmNextScan = .dtmLastScan
            .dtmNextScan = DateAdd("s", .intInterval, .dtmNextScan)
        End With
       iPollList = iPollList + 1
        DE1.rsTimeIntervals.MoveNext
    Wend
    DE1.rsTimeIntervals.Close
     
     'read poll blocks
     On Error GoTo ErrPollBlocks
    Dim iInterval As Integer
    For iInterval = 0 To UBound(PollList)
        DE1.dbo_APP_ChartWizard_Scada_TagList (PollList(iInterval).intInterval)
        Dim iTag As Integer
        iTag = 0
        While Not DE1.rsdbo_APP_ChartWizard_Scada_TagList.EOF
            ReDim Preserve PollList(iInterval).TagList(iTag + 1)
            With PollList(iInterval).TagList(iTag)
                .intTagID = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("TagID").Value
                .strTagName = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("Tag").Value
                .strNode = NodePart(.strTagName)
                .strField = FieldPart(.strTagName)
                .strTag = TagPart(.strTagName)
                .sngValue = -999
                .blnNewData = True
                
                If IsNull(DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("EngineeringUnitName").Value) Then
                    .strEngineeringUnits = ""
                Else
                    .strEngineeringUnits = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("EngineeringUnitName").Value
                End If
                If IsNull(DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("FactoryAreaName").Value) Then
                    .strFactoryAreaCode = ""
                Else
                    .strFactoryAreaCode = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("FactoryAreaName").Value
                End If
                .blnRecordOnlyOnChange = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("RecordOnlyOnChange").Value
                .sngDifferenceBeforeChangeIsRecorded = DE1.rsdbo_APP_ChartWizard_Scada_TagList.Fields("DifferenceBeforeChangeIsRecorded").Value
            End With
            iTag = iTag + 1
            DE1.rsdbo_APP_ChartWizard_Scada_TagList.MoveNext
        Wend
        DE1.rsdbo_APP_ChartWizard_Scada_TagList.Close
    Next iInterval
    BuildPollData = True
    GoTo exitsub
    
errTimes:
    TraceInfo ("BuildPollData - Error Reading Scan Times, " & err.Description)
    BuildPollData = False
    GoTo exitsub
ErrPollBlocks:
    TraceInfo ("BuildPollData - Error Reading Poll Blocks, " & err.Description)
    BuildPollData = False
    GoTo exitsub
exitsub:
End Function

Public Function LinkPollDataToFix() As Boolean
    On Error GoTo err
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
    
    Dim strName As String * 256
        
    If FixIsFixRunning() = False Then
        ' Raise the exception
        err.Raise vbObjectError + 512, "PollData.LinkPollData", "Fix Not Running"
    End If
    
    lngPollDataGroup = eda_define_group(1, 0)
    'define tags
    For iInterval = 0 To NoOfTimeIntervals - 1
        For iTag = 0 To NoOfTagsAtInterval(iInterval) - 1
            TagParts iInterval, _
                     iTag, _
                     strNode, _
                     strTag, _
                     strField, _
                     sngValue, _
                     strEngineeringUnits, _
                     strFactoryAreaCode, _
                     blnRecordOnlyOnChange, _
                     sngDifferenceBeforeChangeIsRecorded
            
            Dim lngHandle As Long
            lngHandle = eda_define_ntf(lngPollDataGroup, strNode, strTag, strField, 0)
            If lngHandle = -1 Then
                ' Raise the exception
                err.Raise vbObjectError + 513, "PollData.LinkPollData", "Invalid Handle"
            End If
            SetHandle iInterval, iTag, lngHandle
        Next iTag
    Next iInterval
    'check they all exist in fix
    eda_lookup lngPollDataGroup
    eda_wait lngPollDataGroup
    For iInterval = 0 To NoOfTimeIntervals - 1
        For iTag = 0 To NoOfTagsAtInterval(iInterval) - 1
            GetHandle iInterval, iTag, lngHandle
            intFixError = eda_get_error(lngPollDataGroup, lngHandle)
            If intFixError <> 0 Then
                ChangeStatus iInterval, iTag, "Error Tag Not Found"
           End If
        Next iTag
    Next iInterval
    
    LinkPollDataToFix = True
    Exit Function
err:
    TraceInfo "PollData.LinkPollDataToFix " & err.Description & " " & strNode & " " & strTag & " " & strField
    LinkPollDataToFix = False
End Function

Public Function UnLinkPollDataFromFix() As Boolean
    On Error GoTo err
    eda_delete_group lngPollDataGroup
    UnLinkPollDataFromFix = True
    Exit Function
err:
    TraceInfo "PollData.UnLinkPollDataFromFix " & err.Description
    UnLinkPollDataFromFix = False
End Function

'Called from Poll_Timer
Public Function IsPollRequired() As Boolean
    On Error GoTo err
    Dim iInterval As Integer
    Dim dtmNow As Date
    dtmNow = Now
    For iInterval = 0 To NoOfTimeIntervals - 1
        If PollList(iInterval).dtmNextScan < dtmNow Then
            IsPollRequired = True
            Exit Function
        End If
    Next iInterval
    IsPollRequired = False
    Exit Function
err:
    TraceInfo "PollData.PollTimer " & err.Description
    IsPollRequired = False
End Function

'called from Poll_Timer
Public Function PollNewData()
    Dim iInterval As Integer
    Dim iTag As Integer
    Dim dtmNow As Date
    Dim fValue As Single
    Dim lngHandle As Long
    Dim theTime As Date
    
    On Error GoTo err
    dtmNow = Now
    eda_read lngPollDataGroup
    eda_wait lngPollDataGroup
    
    For iInterval = 0 To NoOfTimeIntervals - 1
        theTime = PollList(iInterval).dtmNextScan
        'Update all groups if ready
        If PollList(iInterval).dtmNextScan < dtmNow Then
            'Update each tag in group
            DE1.CN1.BeginTrans
            On Error GoTo err1
            For iTag = 0 To NoOfTagsAtInterval(iInterval) - 1
                GetHandle iInterval, iTag, lngHandle
                intFixError = eda_get_float(lngPollDataGroup, lngHandle, fValue)
                If intFixError <> 0 Then
                    Call NlsGetText(intFixError, strFixError, 79)
                    ChangeStatus iInterval, iTag, strFixError
                Else
                    'Check to see if this tag is only recorded when it changes
                    'and if so, if the change has been large enough
                    ChangeStatus iInterval, iTag, ""
                    If PollList(iInterval).TagList(iTag).blnRecordOnlyOnChange = True Then
                        'get last value for this tag from db and compare with margin
                         If Abs(fValue - PollList(iInterval).TagList(iTag).sngValue) >= PollList(iInterval).TagList(iTag).sngDifferenceBeforeChangeIsRecorded Then
                            'the latest value is either + or - the last value +/- the margin for notice factor
                            AddNewData iInterval, iTag, fValue
                            LogNewData iInterval, iTag, theTime
                        End If
                    Else
                        TraceInfo ("Add Data for tag " & iTag & " of " & fValue)
                        AddNewData iInterval, iTag, fValue
                        LogNewData iInterval, iTag, theTime
                    End If
                End If
             Next iTag
            'Update group scanned time
            With PollList(iInterval)
                .dtmLastScan = theTime
                .dtmNextScan = DateAdd("s", .intInterval, .dtmNextScan)
            End With
            DE1.CN1.CommitTrans
            On Error GoTo err
        End If
    Next iInterval
    Exit Function
err:
    TraceInfo "PollData.PollNewData " & err.Description
    Exit Function
err1:
    TraceInfo "PollData.PollNewData " & err.Description & " Interval,Tag=" & CStr(iInterval) & "," & CStr(iTag)
    DE1.CN1.RollbackTrans
End Function

Private Sub AddNewData(ByVal iInterval As Integer, ByVal iTag As Integer, ByVal sngValue As Single)
    On Error GoTo err
    With PollList(iInterval).TagList(iTag)
        .sngValue = sngValue
        .strStatusText = ""
        .blnNewData = True
    End With
    Exit Sub
err:
    TraceInfo "PollData.AddNewData " & err.Description
End Sub

Private Sub LogNewData(ByVal iInterval As Integer, ByVal iTag As Integer, ByVal dtmNow As Date)
    On Error GoTo err
    With PollList(iInterval).TagList(iTag)
        DE1.dbo_APP_ChartWizard_Scada_UpdateTagData dtmNow, .intTagID, .sngValue
    End With
    Exit Sub
err:
    TraceInfo "PollData.LogNewData " & err.Description
End Sub

Private Sub ChangeStatus(ByVal iInterval As Integer, ByVal iTag As Integer, ByVal strStatusStr As String)
    On Error GoTo err
    With PollList(iInterval).TagList(iTag)
        If .strStatusText <> strStatusStr Then
            .strStatusText = strStatusStr
            .blnNewData = True
        End If
    End With
    Exit Sub
err:
    TraceInfo "PollData.ChangeStatus " & err.Description
End Sub

'################### tag routines
'called from update chart
Public Function IsNewData(ByVal iInterval As Integer, ByVal iTag As Integer) As Boolean
    On Error GoTo err
    IsNewData = PollList(iInterval).TagList(iTag).blnNewData
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.IsNewData", "Failed"
    IsNewData = False
End Function

'called from update chart & draw chart
Public Function ResetNewData(ByVal iInterval As Integer, ByVal iTag As Integer) As Boolean
    On Error GoTo err
    PollList(iInterval).TagList(iTag).blnNewData = False
    ResetNewData = True
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.ResetNewData", "Failed"
    ResetNewData = False
End Function

'called from update chart
Public Function TagLogData(ByVal iInterval As Integer, ByVal iTag As Integer, intTagID As Integer, sngTagValue As Single, dtmLastReadDate As Date, strStatus As String) As Boolean
    On Error GoTo err
    With PollList(iInterval).TagList(iTag)
        intTagID = .intTagID
        sngTagValue = .sngValue
        dtmLastReadDate = PollList(iInterval).dtmLastScan
        strStatus = .strStatusText
    End With
    TagLogData = True
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TagLogData", "Failed"
    TagLogData = False
End Function

'called from link poll data to fix
Private Function SetHandle(ByVal iInterval As Integer, ByVal iTag As Integer, ByVal lngHandle As Long) As Boolean
    On Error GoTo err
    PollList(iInterval).TagList(iTag).lngTagHandle = lngHandle
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.SetHandle", "Failed"
    SetHandle = False
End Function

'called from link poll data to fix
Private Function GetHandle(ByVal iInterval As Integer, ByVal iTag As Integer, lngHandle As Long) As Boolean
    On Error GoTo err
    lngHandle = PollList(iInterval).TagList(iTag).lngTagHandle
    GetHandle = True
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.GetHandle", "Failed"
    GetHandle = False
End Function

'called from link to fix and draw chart
Public Function TagParts(ByVal iInterval As Integer, _
                         ByVal iTag As Integer, _
                         strNode As String, _
                         strTag As String, _
                         strField As String, _
                         sngValue As Single, _
                         strEngineeringUnits As String, _
                         strFactoryAreaCode As String, _
                         blnRecordOnlyOnChange As Boolean, _
                         sngDifferenceBeforeChangeIsRecorded As Single) As Boolean
                         
    On Error GoTo err
    With PollList(iInterval).TagList(iTag)
        strNode = .strNode
        strTag = .strTag
        strField = .strField
        sngValue = .sngValue
        strEngineeringUnits = .strEngineeringUnits
        strFactoryAreaCode = .strFactoryAreaCode
        blnRecordOnlyOnChange = .blnRecordOnlyOnChange
        sngDifferenceBeforeChangeIsRecorded = .sngDifferenceBeforeChangeIsRecorded
    End With
    TagParts = True
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TagParts", "Failed"
    TagParts = False
End Function

Public Function TagID(ByVal iInterval As Integer, ByVal iTag As Integer) As Integer
    On Error GoTo err
    TagID = PollList(iInterval).TagList(iTag).intTagID
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TagID", "Failed"
    TagID = 0
End Function

Public Function TagName(ByVal iInterval As Integer, ByVal iTag As Integer) As String
    On Error GoTo err
    TagName = PollList(iInterval).TagList(iTag).strTagName
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TagName", "Failed"
    TagName = ""
End Function

' ################## Interval Routines
Public Function TimeInterval(ByVal iInterval As Integer) As Integer
    On Error GoTo err
    TimeInterval = PollList(iInterval).intInterval
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TimeInterval", "Failed"
    TimeInterval = 0
End Function

Public Function NoOfTagsAtInterval(ByVal iInterval As Integer) As Integer
    On Error GoTo err
    NoOfTagsAtInterval = UBound(PollList(iInterval).TagList)
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.NoOfTagsAtInterval", "Failed"
    NoOfTagsAtInterval = 0
End Function

Public Function TimeOfLastRead(ByVal iInterval As Integer) As Date
    On Error GoTo err
    TimeOfLastRead = PollList(iInterval).dtmLastScan
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TimeOfLastRead", "Failed"
    TimeOfLastRead = Now
End Function

Public Function NoOfTimeIntervals() As Integer
    On Error GoTo err
    NoOfTimeIntervals = UBound(PollList)
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.NoOfTimeIntervals", "Failed"
    NoOfTimeIntervals = 0
End Function

Private Function NodePart(strDB As String) As String
    On Error GoTo err
'#If conNetworkTags = 1 Then
    Dim PosColon As Integer
    PosColon = InStr(1, strDB, ":")
    NodePart = Trim(Left(strDB, PosColon - 1))
'#Else
'    NodePart = "FIX"
'#End If
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.NodePart", "Failed"
    NodePart = ""
End Function

Private Function FieldPart(strDB As String) As String
    On Error GoTo err
'#If conNetworkTags = 1 Then
    Dim strRev As String
    Dim PosDot As Integer
    strRev = StrReverse(strDB)
    PosDot = InStr(1, strRev, ".")
    FieldPart = Right(strDB, PosDot - 1)
    'If FieldPart <> "F_CV" Then
     '   If FieldPart = "F_HL_OP" Or FieldPart = "F_LL_OP" Or FieldPart = "F_OP" Or FieldPart = "F_PV" Or FieldPart = "F_SP" Then
      '      FieldPart = "F_CV"
       ' End If
    'End If
'#Else
'    FieldPart = "F_CV"
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.FieldPart", "Failed"
    FieldPart = ""
End Function
Private Function TagPart(strDB As String) As String
    On Error GoTo err
'#If conNetworkTags = 1 Then
    Dim PosColon As Integer
    Dim strRev As String
    Dim PosDot As Integer
    PosColon = InStr(1, strDB, ":")
    strRev = StrReverse(strDB)
    PosDot = InStr(1, strRev, ".")
    TagPart = Mid(strDB, PosColon + 1, Len(strDB) - PosColon - PosDot)
'#Else
'    TagPart = strDB
'#End If
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.TagPart", "Failed"
    TagPart = ""
End Function

Private Function CorrectTime(myTime As Date, interval As Integer) As Date
    On Error GoTo err
    Dim ahour As Long
    Dim aminute As Long
    Dim asecond As Long
    Dim thesecond As Long
    Dim secsleft As Long

    ahour = Hour(myTime)
    aminute = Minute(myTime)
    asecond = Second(myTime)
    thesecond = ((ahour * 3600) + (aminute * 60) + asecond)
    While (thesecond Mod interval) <> 0
        thesecond = thesecond + 1
    Wend

    secsleft = thesecond
    ahour = Int(secsleft / 3600)
    secsleft = secsleft - (ahour * 3600)
    aminute = Int(secsleft / 60)
    secsleft = secsleft - (aminute * 60)
    asecond = secsleft
    CorrectTime = TimeSerial(ahour, aminute, asecond) + _
        DateSerial(Year(myTime), Month(myTime), Day(myTime))
    Exit Function
err:
    err.Raise vbObjectError + 514, "PollData.CorrectTime", "Failed"
    CorrectTime = Now
End Function

