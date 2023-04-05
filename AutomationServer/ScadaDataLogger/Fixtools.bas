Attribute VB_Name = "FIXTOOLS"
'
' FILE:  FIXTOOLS.BAS
'
' (C) Copyright 1995 INTELLUTION, INC.
' ALL RIGHTS RESERVED
'
' FIXTOOLS.BAS provides the function declarations and
' equates necessary to use the functions provided by
' FIXTOOLS.DLL.
' Within Visual Basic, add FIXTOOLS.BAS to your project.
'
'
'       WNT60   12/11/95 phw/ebj Added FixGetPath
'

Global Const HDA_MAX_SAMPLES = 5000     ' Max # of samples for any tag
Global Const HDA_MAX_TAGS_PER_GROUP = 8 ' Max # of tags per HDA group
Global Const HDA_NO_HANDLE = 0  ' Invalid handle used for initialization

Global Const NODE_NAME_SIZE = 9         ' FIX node name size
Global Const BIG_TAGSIZ = 33            ' FIX Tag size
Global Const FIELDSIZ = 20              ' FIX Field size
Global Const NTF_SIZE = NODE_NAME_SIZE + BIG_TAGSIZ + FIELDSIZ  ' FIX Ntf Size
Global Const MAX_FTK_NODES = 100        ' Max # of FIX nodes
Global Const MAX_DATE_LEN = 35          ' Max length for a date string
Global Const MAX_TIME_LEN = 9           ' Max length for a time string
Global Const MAX_DURATION_LEN = 12      ' Max length for a duration string

' Constants for FIX Security functions
Global Const LOGIN_NAMESIZE = 7         ' Security short Login name size
Global Const NAMESIZE = 31              ' Security long Login name size
Global Const GROUP_NAMESIZE = NAMESIZE  ' Security Group name size

' Constants for EXEType when registering task with FIX
Global Const FOREGROUND_TASK = 5        ' Foreground program
Global Const BACKGROUND_TASK = 10       ' Background program


'
' HDA Retrieval Modes
'
Global Const HDA_MODE_AVERAGE = 1   ' Average mode
Global Const HDA_MODE_HIGH = 2      ' High mode
Global Const HDA_MODE_LOW = 3       ' Low mode
Global Const HDA_MODE_SAMPLE = 4    ' Sample mode
Global Const HDA_MODE_RAW = 5       ' Raw mode


'
'  Define errors returned from Library
'  Note:  These MUST match the values in FIXTKERR.H.
'
Global Const FTK_OK = 11000             ' Operation Successful
Global Const FTK_MEMORY = 11001         ' Error allocating memory
Global Const FTK_BAD_HDAGROUP = 11002   ' Invalid HDAGROUP handle passed
Global Const FTK_BAD_HDANTF = 11003     ' Invalid HDANTF handle passed
Global Const FTK_BAD_DATE = 11004       ' Invalid Date entered, correct form is MM/DD/YY
Global Const FTK_BAD_TIME = 11005       ' Invalid Time entered, correct form is HH:MM:SS
Global Const FTK_RANGE = 11006          ' Index out of range
Global Const FTK_OPTION = 11007         ' Invalid retrieval mode entered
Global Const FTK_BADNTF = 11008         ' Invalid NTF format entered, expecting N:T.F or N:T
Global Const FTK_BAD_LENGTH = 11009     ' Passed string not large enough to hold value
Global Const FTK_GROUP_FULL = 11010     ' Maximum number of NTFs already added
Global Const FTK_BAD_MHANDLE = 11011    ' Invalid pointer passed
Global Const FTK_MORE_SAMPLES = 11012   ' More samples for duration
Global Const FTK_NO_NTFS = 11013        ' No NTFs defined in group
Global Const FTK_NODENAME_NOT_DEFINED = 11014   ' FIX Nodename is not defined
Global Const FTK_NOT_REGISTERED = 11015 ' Task is not registered
Global Const FTK_BAD_ORDER = 11016      ' Invalid FIX registration Order, valid range is 1-99
Global Const FTK_NO_MESSAGE = 11017     ' No message exists for error
Global Const FTK_FIX_NOT_RUNNING = 11018 ' FIX System not started!
Global Const FTK_BAD_NAME = 11019       ' Invalid program name
Global Const FTK_BAD_PATH = 11020       ' Invalid Path specified
Global Const FTK_BAD_NODENAME = 11022   ' Invalid nodename passed
Global Const FTK_NO_DATA = 11023        ' Data not read yet

'
' Define possible statuses returned from HdaGetData.
'
Global Const HDA_VAL_OK = 0
Global Const HDA_VAL_BAD = 1


'
' Define alarm codes returned from HdaGetData.
' If the alarm code includes IA_BAD, then the data is not valid.
' Additional alarm codes may be returned in the future.
' Note:  These MUST match the values in DMACSDBA.H, if that file is supplied.
'
Global Const IA_BAD = 128               ' Hex = 0x80 (the high bit of the byte is set)

Global Const AS_OK = 0                  ' no alarm - OK
Global Const AS_LOLO = 1                ' Low low alarm
Global Const AS_LO = 2                  ' Low alarm
Global Const AS_HI = 3                  ' High alarm
Global Const AS_HIHI = 4                ' High high alarm
Global Const AS_RATE = 5                ' Rate of change
Global Const AS_COS = 6                 ' Change of state
Global Const AS_CFN = 7                 ' Change from normal
Global Const AS_DEV = 8                 ' Deviation
Global Const AS_FLT = 9 + IA_BAD        ' Floating point error
Global Const AS_MANL = 10               ' special code for MANL/MAINT (for inputs)
Global Const AS_DSAB = 11               ' alarms disabled
Global Const AS_ERROR = 12              ' general block error
Global Const AS_ANY = 13                ' any block alarm
Global Const AS_NEW = 14                ' new block alarm
Global Const AS_TIME = 15               ' Timeout alarm
Global Const AS_SQL_LOG = 16            ' Not connected to database
Global Const AS_SQL_CMD = 17            ' SQL Cmd not found or invalid
Global Const AS_DATA_MATCH = 18         ' SQL cmd doesn't match data list
Global Const AS_FIELD_READ = 19         ' Error reading tag values
Global Const AS_FIELD_WRITE = 20        ' Error writing tag values
Global Const AS_IOF = 64 + IA_BAD       ' general I/O failure
Global Const AS_OCD = 65 + IA_BAD       ' open circuit
Global Const AS_URNG = 66               ' under range =clamped at 0
Global Const AS_ORNG = 67               ' over range =clamped at MAX
Global Const AS_RANG = 68 + IA_BAD      ' out of range =value unknown
Global Const AS_COMM = 69 + IA_BAD      ' Comm link failure.
Global Const AS_DEVICE = 70 + IA_BAD    ' Device failure.
Global Const AS_STATION = 71 + IA_BAD   ' Station Failure
Global Const AS_ACCESS = 72 + IA_BAD    ' Access denied =privledge.
Global Const AS_NODATA = 73 + IA_BAD    ' On poll but no data yet
Global Const AS_NOXDATA = 74 + IA_BAD   ' Exception item but no data yet

'
' ebj052695 FIX Paths configured in the SCU
' Use these for the PathID parameter when calling FixGetPath
'
Global Const BASPATH = "BASPATH"   ' Base Path
Global Const LOCPATH = "LOCPATH"   ' Local Path
Global Const PDBPATH = "PDBPATH"   ' Database Path
Global Const NLSPATH = "NLSPATH"   ' Language Path
Global Const PICPATH = "PICPATH"   ' Picture Path
Global Const FSTPATH = "FASTPATH"  ' Fast Path
Global Const APPPATH = "APPPATH"   ' Application Path
Global Const HTCPATH = "HTRPATH"   ' Historical Path
Global Const HTRDATA = "HTRDATA"   ' Historical Data Path
Global Const ALMPATH = "ALMPATH"   ' Alarms Path
Global Const RCMPATH = "RCMPATH"   ' Master Recipe Path
Global Const RCCPATH = "RCCPATH"   ' Control Recipe Path

'
'  Declarations for functions provided by FIXTOOLS.DLL
'

' Get info for the currently logged in user
Declare Function FixGetCurrentUser Lib "fixtools.dll" Alias "FixGetCurrentUser@24" (ByVal LoginName As String, ByVal MaxLoginLen As Integer, ByVal FullName As String, ByVal MaxFullLen As Integer, ByVal GroupName As String, ByVal MaxGroupLen As Integer) As Integer

' Get the node name of this node
Declare Function FixGetMyname Lib "fixtools.dll" Alias "FixGetMyName@8" (ByVal MyName As String, ByVal MaxSize As Long) As Long

' Get the path associated with PathID    ebj052695
Declare Function FixGetPath Lib "fixtools.dll" Alias "FixGetPath@12" (ByVal PathID As String, ByVal path As String, ByVal MaxLength As Integer)

' Find out whether FIX is currently running
Declare Function FixIsFixRunning Lib "fixtools.dll" Alias "FixIsFixRunning@0" () As Long

' Remove the application from FIX's task list
Declare Function FixTaskDeregister Lib "fixtools.dll" Alias "FixTaskDeregister@8" (ByVal hWnd As Long, ByVal EXEName As String) As Long

' Register the application with FIX
Declare Function FixTaskRegister Lib "fixtools.dll" Alias "FixTaskRegister@12" (ByVal hWnd As Long, ByVal Order As Long, ByVal EXEName As String) As Long

' Add an NTF to an HDA Group
Declare Function HdaAddNtf Lib "fixtools.dll" Alias "HdaAddNtf@12" (ByVal hg As Long, ht As Long, ByVal ntf As String) As Long

' Create an HDA group
Declare Function HdaDefineGroup Lib "fixtools.dll" Alias "HdaDefineGroup@4" (hg As Long) As Long

' Destroy an HDA group
Declare Function HdaDeleteGroup Lib "fixtools.dll" Alias "HdaDeleteGroup@4" (ByVal hg As Long) As Long

' Remove an NTF from an HDA group
Declare Function HdaDeleteNtf Lib "fixtools.dll" Alias "HdaDeleteNtf@8" (ByVal hg As Long, ByVal ht As Long) As Long

' Get next node from Enumeration result
Declare Function HdaEnumGetNode Lib "fixtools.dll" Alias "HdaEnumGetNode@16" (ByVal hg As Long, ByVal number As Long, ByVal Node As String, ByVal Length As Long) As Long

' Get Next NTF from Enumeration result
Declare Function HdaEnumGetNtf Lib "fixtools.dll" Alias "HdaEnumGetNtf@16" (ByVal hg As Long, ByVal number As Long, ByVal ntf As String, ByVal Length As Long) As Long

' Enumerate nodes
Declare Function HdaEnumNodes Lib "fixtools.dll" Alias "HdaEnumNodes@8" (ByVal hg As Long, Count As Long) As Long

' Enumerate NTF's
Declare Function HdaEnumNtfs Lib "fixtools.dll" Alias "HdaEnumNtfs@12" (ByVal hg As Long, ByVal Node As String, Count As Long) As Long

' Get the value, time, status, and alarm for data read from the HTRDATA file
Declare Function HdaGetData Lib "fixtools.dll" Alias "HdaGetData@32" (ByVal hg As Long, ByVal ht As Long, ByVal StartSample As Long, ByVal NumSamples As Long, values As Single, times As Long, statuses As Long, alarms As Long) As Long

' Get the duration time for this HDA group
Declare Function HdaGetDuration Lib "fixtools.dll" Alias "HdaGetDuration@12" (ByVal hg As Long, ByVal StartTime As String, ByVal TLength As Long) As Long

' Get the interval time for this HDA group
Declare Function HdaGetInterval Lib "fixtools.dll" Alias "HdaGetInterval@12" (ByVal hg As Long, ByVal IntervalTime As String, ByVal TLength As Long) As Long

' Get the mode for this HDA group
Declare Function HdaGetMode Lib "fixtools.dll" Alias "HdaGetMode@12" (ByVal hg As Long, ByVal ht As Long, Mode As Long) As Long

' Get the NTF associated with the ntf handle
Declare Function HdaGetNtf Lib "fixtools.dll" Alias "HdaGetNtf@16" (ByVal hg As Long, ByVal ht As Long, ByVal NodeTagField As String, ByVal Length As Long) As Long

' Get the number of samples for this HDA group
Declare Function HdaGetNumSamples Lib "fixtools.dll" Alias "HdaGetNumSamples@12" (ByVal hg As Long, ByVal ht As Long, NumSamples As Long) As Long

' Get Path for HDA group
Declare Function HdaGetPath Lib "fixtools.dll" Alias "HdaGetPath@12" (ByVal hg As Long, ByVal path As String, ByVal MaxLen As Long) As Long

' Get Start time from the HDA GRoup
Declare Function HdaGetStart Lib "fixtools.dll" Alias "HdaGetStart@20" (ByVal hg As Long, ByVal StartDate As String, ByVal DLength As Long, ByVal StartTime As String, ByVal TLength As Long) As Long

' Get the number of NTF's in the HDA group
Declare Function HdaNtfCount Lib "fixtools.dll" Alias "HdaNtfCount@8" (ByVal hg As Long, Count As Long) As Long

' Read the actual HTR collected data
Declare Function HdaRead Lib "fixtools.dll" Alias "HdaRead@8" (ByVal hg As Long, ByVal Reserved As Long) As Long

' Set the duration time for the HDA group
Declare Function HdaSetDuration Lib "fixtools.dll" Alias "HdaSetDuration@8" (ByVal hg As Long, ByVal TimeStr As String) As Long

' Set the interval time for the HDA group
Declare Function HdaSetInterval Lib "fixtools.dll" Alias "HdaSetInterval@8" (ByVal hg As Long, ByVal TimeStr As String) As Long

' Set the Mode for the HDA group
Declare Function HdaSetMode Lib "fixtools.dll" Alias "HdaSetMode@12" (ByVal hg As Long, ByVal ht As Long, ByVal Mode As Long) As Long

' Set the Path for the HDA group
Declare Function HdaSetPath Lib "fixtools.dll" Alias "HdaSetPath@8" (ByVal hg As Long, ByVal path As String) As Long

' Set the start time for the HDA group
Declare Function HdaSetStart Lib "fixtools.dll" Alias "HdaSetStart@12" (ByVal hg As Long, ByVal DateStr As String, ByVal TimeStr As String) As Long

' Translate an error number returned from FIXTOOLS to a string
Declare Function NlsGetText Lib "fixtools.dll" Alias "NlsGetText@12" (ByVal ErrCode As Long, ByVal MsgString As String, ByVal MaxLength As Long) As Long

' Add # of seconds (as an integer) to the time/date strings passed
Declare Function TimAddSeconds Lib "fixtools.dll" Alias "TimAddSeconds@20" (ByVal DateStr As String, ByVal MaxDateLen As Long, ByVal TimeStr As String, ByVal MaxTimeLen As Long, ByVal Seconds As Long) As Long

' Convert integers to time/date strings
Declare Function TimIntegersToString Lib "fixtools.dll" Alias "TimIntegersToString@40" (ByVal yr As Long, ByVal mon As Long, ByVal dy As Long, ByVal Hr As Long, ByVal Min As Long, ByVal Sec As Long, ByVal DateStr As String, ByVal MaxDateLen As Long, ByVal TimeStr As String, MaxTimeLen As Long) As Long

' Convert Time and Date strings to integers
Declare Function TimStringToIntegers Lib "fixtools.dll" Alias "TimStringToIntegers@32" (ByVal DateStr As String, ByVal TimeStr As String, yr As Long, mon As Long, dy As Long, Hr As Long, Min As Long, Sec As Long) As Long

' RemoveNul removes a NUL in the string if one exists
'
Function RemoveNul(dt As String) As String
    
    Dim NulPos%
    Dim d$

    NulPos = InStr(1, dt, Chr(0), 0)
    If NulPos > 0 Then
        d = Left$(dt, NulPos - 1)
    Else
        d = dt
    End If
    RemoveNul = d

End Function

