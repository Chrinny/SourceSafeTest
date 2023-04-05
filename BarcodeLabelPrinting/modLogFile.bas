Attribute VB_Name = "modLogFile"
Option Explicit

Dim datDay As Date
Dim datDayErr As Date
Dim datLastNewErrFile As Date
Dim datLastNewFile As Date
Dim CurrentMessageLogFile As String
Dim CurrentErrorMessageLogFile As String

Public ErrorMessage As String

Public LogFilePath As String
Public ErrorLogFilePath As String

'Private Const LogFilePath As String = App.Path  '"D:\Warehouse\Log\"
'Private Const ErrorLogFilePath As String = App.Path '"D:\Warehouse\Log\"

Private Const NewFileUnit As String = "d"           '"d" means make files daily
Private Const NewFileUnitQty As Integer = "1"       'number of new files per period
Private Const OldestFileUnit As String = "d"        '"d" for daily files
Private Const OldestFileUnitQty As Integer = 7      'number of file units to keep



Public Sub CloseLogNow()

    Close #1
    datLastNewFile = "1/1/1900"

End Sub


Public Sub MessageToLog(Message As String)

    Dim strFileName As String
    Dim datTimeNow As Date

    On Error GoTo WriteErr
    
    datTimeNow = Now()
    
    If datDay < CDate(Format(datTimeNow, "dd-mmm-yyyy")) Then
        
        datDay = CDate(Format(datTimeNow, "dd-mmm-yyyy"))
        Open LogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log" For Output As #1
        CurrentMessageLogFile = LogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log"
        datLastNewFile = datTimeNow
        StartupFlag = "1"
        
    ElseIf DateAdd(NewFileUnit, -NewFileUnitQty, datTimeNow) > datLastNewFile Then
    
        Open LogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log" For Output As #1
        CurrentMessageLogFile = LogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log"
        datLastNewFile = datTimeNow
        StartupFlag = "1"
        
    Else
    
        Open CurrentMessageLogFile For Append As #1
        
    End If
    
    strFileName = Dir(LogFilePath & "*.log")
    While strFileName <> ""
        If Left(strFileName, 14) < Format(DateAdd(OldestFileUnit, -OldestFileUnitQty, datTimeNow), "yyyymmddhhnnss") Then
            On Error Resume Next
            Kill LogFilePath & strFileName
        End If
        strFileName = Dir()
    Wend

    Message = Format(Now(), "dd-mmm hh:nn:ss") & " " & Message
    Print #1, Message
    Close #1
    Exit Sub

WriteErr:

    On Error Resume Next
    Close #1
    datLastNewFile = CDate("1/1/1900")
    Exit Sub

End Sub

Public Sub ErrorMessageToLog(Message As String)

    Dim strFileName As String
    Dim datTimeNow As Date

    On Error GoTo WriteErr
    
    datTimeNow = Now()
    
    If datDayErr < CDate(Format(datTimeNow, "dd-mmm-yyyy")) Then
        
        datDayErr = CDate(Format(datTimeNow, "dd-mmm-yyyy"))
        Open ErrorLogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log" For Output As #2
        CurrentErrorMessageLogFile = ErrorLogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log"
        datLastNewErrFile = datTimeNow
    
    ElseIf DateAdd(NewFileUnit, -NewFileUnitQty, datTimeNow) > datLastNewErrFile Then
    
        Open ErrorLogFilePath & Format(datTimeNow, "yyyymmddhhnnss") & ".log" For Output As #2
        CurrentErrorMessageLogFile = ErrorLogFilePath & "/" & Format(datTimeNow, "yyyymmddhhnnss") & ".log"
        datLastNewErrFile = datTimeNow
    
    Else
    
        Open CurrentErrorMessageLogFile For Append As #2
        
    End If
    
    strFileName = Dir(ErrorLogFilePath & "*.log")
    While strFileName <> ""
        If Left(strFileName, 14) < Format(DateAdd(OldestFileUnit, -OldestFileUnitQty, datTimeNow), "yyyymmddhhnnss") Then
            On Error Resume Next
            Kill ErrorLogFilePath & strFileName
        End If
        strFileName = Dir()
    Wend

    Message = Format(Now(), "dd-mmm hh:nn:ss") & " " & Message
    Print #2, Message
    Close #2
    Exit Sub

WriteErr:

    On Error Resume Next
    Close #2
    datLastNewErrFile = CDate("1/1/1900")
    Exit Sub

End Sub
