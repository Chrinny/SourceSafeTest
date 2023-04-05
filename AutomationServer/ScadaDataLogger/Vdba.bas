Attribute VB_Name = "VDBA"

' functions specific to VB (not standard eda fcns)
'
Declare Sub eda_version Lib "vdba.dll" (ByVal V$)
Declare Sub eda_get1_ascii Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, ByVal V$)
Declare Function eda_set1_ascii% Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, ByVal V$)

'
' Quick convenience functions for single item access (not very efficient)
'
Declare Function eda_get_one_ascii% Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, ByVal V$)
Declare Function eda_set_one_ascii% Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, ByVal V$, ByVal Key&)
Declare Function eda_get_one_float% Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, V!)
Declare Function eda_set_one_float% Lib "vdba.dll" (ByVal n$, ByVal t$, ByVal f$, V!, ByVal Key&)
'
' Alarm Message Functions
'
Declare Sub eda_send_msg Lib "vdba.dll" (ByVal atyper%, ByVal adi%, ByVal Msg$)
Declare Function eda_fetch_alarm% Lib "vdba.dll" (ByVal Q%, ByVal Text$, ByVal Node$, ByVal Tag$, ByRef AlmDate%, ByRef Other%)

' Obsolete function.  Use NlsGetError
' Declare Sub vda_get_error_text Lib "vdba.dll" (ByVal err%, ByVal Msg$, ByVal MaxLen%)
'

'
' Note define_group returns a long
'
Declare Function eda_define_group& Lib "vdba.dll" (ByVal Count%, ByVal Detect%)
Declare Sub eda_delete_group Lib "vdba.dll" (ByVal Handle&)
'
' You should always pass 0 for vsp
Declare Function eda_define_ntf& Lib "vdba.dll" (ByVal Handle&, ByVal enode$, ByVal etag$, ByVal efield$, ByVal vsp&)
Declare Sub eda_delete_ntf Lib "vdba.dll" (ByVal Handle&, ByVal ntf&)
'
Declare Sub eda_lookup Lib "vdba.dll" (ByVal Handle&)
Declare Sub eda_set_key Lib "vdba.dll" (ByVal Handle&, ByVal Key&)
Declare Sub eda_read Lib "vdba.dll" (ByVal Handle&)
Declare Sub eda_write Lib "vdba.dll" (ByVal Handle&)
Declare Function eda_write1% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&)
Declare Sub eda_wait Lib "vdba.dll" (ByVal Handle&)
Declare Function eda_query_wait% Lib "vdba.dll" (ByVal Handle&)
'
Declare Function eda_get_error% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&)
Declare Function eda_get_ascii% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&, ByVal Value$, ByVal MaxLen%)
Declare Function eda_set_ascii% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&, ByVal Value$)

' note pointer to float is passed
Declare Function eda_get_float% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&, Value!)
Declare Function eda_set_float% Lib "vdba.dll" (ByVal Handle&, ByVal ntf&, Value!)

' Obsolete functions.  Use Fixtools FixTaskRegister and FixTaskDeregister
' Declare Sub vda_register Lib "vdba.dll" (ByVal hWnd&, ByVal ord%, ByVal Value$)
' Declare Sub vda_deregister Lib "vdba.dll" (ByVal hWnd&)

' Obsolete function.  Use Fixtools FixGetMyName
' Declare Function eda_get_myname% Lib "vdba.dll" (ByVal Value$)

Declare Function eda_query_item_size Lib "vdba.dll" (ByVal GroupHandle As Long, ByVal TagHandle As Long) As Long
Declare Function eda_get_pdb_name% Lib "vdba.dll" (ByVal Value$, ByVal V$, ByVal MaxSize As Integer)
Declare Function eda_save_database% Lib "vdba.dll" (ByVal Value$, ByVal V$)
Declare Function eda_reload_database% Lib "vdba.dll" (ByVal Value$, ByVal V$)

Declare Function eda_add_block% Lib "vdba.dll" (ByVal Node$, ByVal Tag$, ByVal Typ%)
Declare Function eda_type_to_index% Lib "vdba.dll" (ByVal Node$, ByVal Typ$)
Declare Function eda_delete_block% Lib "vdba.dll" (ByVal Node$, ByVal Tag$)

' Obsolete function:  Use FixGetCurrentUser
' Declare Function eda_logged_in% Lib "vdba.dll" (ByVal lname$, ByVal sname$)

Global Const TYP_F = &H1              ' file typer
Global Const TYP_H = &H4                  ' history window typer
Global Const TYP_P = &H8                  ' printer typer
Global Const TYP_N = &H10                 ' network typer
Global Const TYP_NALL = &H1F              ' all alarm typers + network

Rem possible 'quenum' values
Rem for use with eda_fetch_alarm()

Global Const TYP_GET_U1 = &H40            ' User alarm queue1
Global Const TYP_GET_U2 = &H60            ' User alarm queue2


Rem possible 'adi' field values
Rem for use with eda_send_msg and eda_fetch_alarm

Global Const ADI_A = &H1          ' bit for alarm destination A
Global Const ADI_B = &H2          ' bit for alarm destination B
Global Const ADI_C = &H4          ' bit for alarm destination C
Global Const ADI_D = &H8          ' bit for alarm destination D
Global Const ADI_E = &H10         ' bit for alarm destination E
Global Const ADI_F = &H20         ' bit for alarm destination F
Global Const ADI_G = &H40         ' bit for alarm destination G
Global Const ADI_H = &H80         ' bit for alarm destination H
Global Const ADI_I = &H100        ' bit for alarm destination I
Global Const ADI_J = &H200        ' bit for alarm destination J
Global Const ADI_K = &H400        ' bit for alarm destination K
Global Const ADI_L = &H800        ' bit for alarm destination L
Global Const ADI_M = &H1000       ' bit for alarm destination M
Global Const ADI_N = &H2000       ' bit for alarm destination N
Global Const ADI_O = &H4000       ' bit for alarm destination O
Global Const ADI_P = &H8000       ' bit for alarm destination P

Rem possible 'timeflag' field values

Global Const EALM_DATE = 1
Global Const EALM_TIME = 2
Global Const EALM_TENTHS = 4
Global Const FILEPATHSIZ = 64
Global Const KEY_CONFIGURE_BLOCK = &H8000DBBB
