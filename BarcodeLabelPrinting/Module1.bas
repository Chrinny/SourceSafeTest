Attribute VB_Name = "Module1"

Option Explicit

    Private Declare Function GetComputerName& Lib "kernel32" Alias "GetComputerNameA" (ByVal lpbuffer As String, nsize As Long)
    Public sComputerName As String
    Const nCompNameLength As Long = 20
    Public sSoftwareVersion As String
    
    Public StartupFlag As String
    Public NumberOfTakeOffDevices As Integer        'Count of available TakeOffDevices
    Public LabelCreationInProcess As String         'Label Status for pack being processed
    Public CurrentPackCount As Integer
    Public CurrentBatchNumber As String
    Public CurrentCustomerRelease As String         'Remembered value to be printed on label
    Public CurrentInterleavant As String            'Remembered value to be printed on label
    Public CurrentInterleavantType As String
    Public DefaultInterleavantType As String
    Public CurrentStillageType As String
    Public CurrentStillageTypeText As String
    Public CurrentStillageID As String
    Public CurrentStillageOrigin As String
    Public DefaultStillageOrigin   As String
    Public CurrentPlantIdentifier As String
    Public CurrentPlantName As String
    Public CurrentPlantLocation As String
    Public CurrentWorkCentre As String
    Public DefaultWorkCentre As String
    Public CurrentSlot As String
    Public CurrentCuttingPattern As String
    Public CurrentArrangement As String
    Public CurrentCaseSizeText As String
    Public CurrentCustomerPartNumber As String
    Public CurrentComment1 As String
    Public CurrentComment2 As String
    Public CurrentComment3 As String
    Public CurrentLabelType As String
    Public CurrentLanguage As String
    Public LabelPrefix As String
    Public PrintInterleavant As Boolean
    Public NoManualIfAutoLabels As Boolean
    Public HideTinSideLabelData As Boolean
    Public HideRolledGlassLabelData As Boolean
    Public HideGlassBandsLabelData As Boolean
    Public HidePackFramedLabelData As Boolean
    Public LabelDataFormTop As Integer
    Public LabelDataFormLeft As Integer
    Public CurrentMakeNumber As Integer
    Public ApplicationPath As String
    Public blnSAPDeviceNameExists As Boolean        'Flag to indicate SAP Device Name alias found in database

    Public Enum enumPrintStatus
        psPrintValidationFAILED = 0
        psprintrel = 1
        psPrintTECO = 2
    End Enum

Public Sub Main()
    Dim errStatus As String
    Dim RC As Long      'Return code from function call
    Dim SystemLocationName As String
    Dim strSQL As String
    Dim strFilePath As String
    Dim n As Integer
    Dim sTemp As String
    Dim strFileName As String
    
    On Error GoTo Errhandler
    If App.PrevInstance Then
        frmMessage.subFormLoad "BarCode Label Printing System", "Already Running", "StartUp Failure"
    Else
        ApplicationPath = App.Path

        strFileName = Dir(ApplicationPath & "\offline\managementinformationpackslipprinting.exe")
        If strFileName <> "" Then Shell ApplicationPath & "\offline\managementinformationpackslipprinting.exe"

        LogFilePath = App.Path & "\"
        ErrorLogFilePath = App.Path & "\"
    
        sComputerName = String$(nCompNameLength, 0)  'Set null string
        RC = GetComputerName&(sComputerName, nCompNameLength)
        If RC = 0 Then
            sComputerName = "UNKNOWN"
        Else
            sTemp = ""
            n = 1
            Do While (sTemp <> Chr(0)) And (n < nCompNameLength)
                sTemp = Mid(sComputerName, n, 1)
                n = n + 1
            Loop
            sComputerName = Mid(sComputerName, 1, n - 2)
        End If
        sSoftwareVersion = App.Major & "." & App.Minor & "." & App.Revision
        Call MessageToLog("BarCode Printing: " & sComputerName & " Version: " & sSoftwareVersion & " started")
            
        DoEvents
        frmBarCodeSpec.Show
    End If
Finish:
    Exit Sub
    
Errhandler:
    Select Case errStatus
        Case ""
        Case "NoFile"
                frmMessage.subFormLoad "File" & " " & "NotFound", "SystemLocationName.txt", "StartUpFailure"
                Call MessageToLog("Startup failure, SystemLocationName.txt file not found.")
        Case "NoName"
                frmMessage.subFormLoad "File" & " " & "ReadError", "CannotReadMISSystemName", "StartUpFailure"
                Call MessageToLog("Startup failure, Cannot read MIS System name from SystemLocationName.txt file.")
        Case "NoSysConfig"
                frmMessage.subFormLoad "ReadError", "SystemConfiguration", "StartUpFailure"
                Call MessageToLog("Startup failure, System Configuration not found: " & Err.Description)
        Case "NoPlantCodes"
                frmMessage.subFormLoad "ReadError", "SystemConfiguration" & ", PlantCodes", "StartUpFailure"
                Call MessageToLog("Startup failure, Plant Codes not found: " & Err.Description)
        Case "InvalidDatabase"
            strSQL = Err.Description
                frmMessage.subFormLoad "UnableToConnectToDatabase" & " " & UCase(SystemLocationName), , "StartUpFailure"
                Call MessageToLog("Start-up Failure: Unable to connect to " & UCase(SystemLocationName) & " Database")
        Case "BlokCode"
                frmMessage.subFormLoad "BlockingCodes", Err.Description, "StartUpFailure"
                Call MessageToLog("Start-up Failure: Blocking Codes not found" & Err.Description)
        Case "ColrCoat"
                frmMessage.subFormLoad "ColourCoatings", Err.Description, "StartUpFailure"
                Call MessageToLog("Start-up Failure: ColourCoatings not found" & Err.Description)
        Case "StillTyp"
                frmMessage.subFormLoad "StillageType", Err.Description, "StartUpFailure"
                Call MessageToLog("Start-up Failure: Stillage Types not found" & Err.Description)
        Case "Intrlvnt"
                frmMessage.subFormLoad "Interleavant", Err.Description, "StartUpFailure"
                Call MessageToLog("Start-up Failure: Interleavants not found" & Err.Description)
        Case Else
                frmMessage.subFormLoad "ReadError", Err.Description, "StartUpFailure"
                Call MessageToLog("Start-up Failure: Unknown Error" & Err.Description)
    End Select
    GoTo Finish
End Sub

Function Pause(Seconds As Integer)

    Dim datTimeNow As Date
    
    datTimeNow = Now()
    While Now() < DateAdd("s", 1, datTimeNow)
        DoEvents
    Wend
    
End Function
