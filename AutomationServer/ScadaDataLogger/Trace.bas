Attribute VB_Name = "Trace"
Option Explicit
Public conTraceFlag As Integer

Sub TraceInfo(str As String)
If conTraceFlag = 1 Then
    'immediate window
    Debug.Print str
ElseIf conTraceFlag = 2 Then
    'Application Log
    App.LogEvent str, vbLogEventTypeInformation
ElseIf conTraceFlag = 3 Then
    'log file (overwrite)
    App.LogEvent Now & " " & str, vbLogEventTypeInformation
ElseIf conTraceFlag = 4 Then
    'log file (append)
    App.LogEvent Now & " " & str, vbLogEventTypeInformation
Else
    'no logging
End If
End Sub

Sub TraceInitialise()
If conTraceFlag = 1 Then
    'immediate window
ElseIf conTraceFlag = 2 Then
    'Application Log
    App.StartLogging "", vbLogToNT
ElseIf conTraceFlag = 3 Then
    'Log file (overwrite)
    On Error Resume Next
    Kill App.path & "\" & App.EXEName & ".log"
    App.StartLogging App.path & "\" & App.EXEName & ".log", vbLogToFile
ElseIf conTraceFlag = 4 Then
    'Log file (append)
    App.StartLogging App.path & "\" & App.EXEName & ".log", vbLogToFile
Else
    'no logging
End If
End Sub
