Attribute VB_Name = "Types"
Option Explicit

Public Type TagData
    strTagName As String
    strNode As String
    strField As String
    
    strTag As String
    intTagID As Integer
    
    lngTagHandle As Long
    sngValue As Single
    blnNewData As Boolean
    strStatusText As String
    
    strEngineeringUnits As String
    strFactoryAreaCode As String
    blnRecordOnlyOnChange As Boolean
    sngDifferenceBeforeChangeIsRecorded As Single
    
End Type

Public Type PollItem
    intInterval As Integer
    dtmNextScan As Date
    dtmLastScan As Date
    TagList() As TagData
End Type



