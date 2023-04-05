using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using System.Threading;

using NDI.SLIKDA.Interop;

using Cvb;
using CVBImage = Cvb.Image;

using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;
using System.Runtime.InteropServices;
using Pilkngton.ProjectPaint.PaintSupport;
//using NationalInstruments.Net;
//using NationalInstruments.Analysis;
//using System.IO.Ports;

namespace Pilkngton.ProjectPaint.PaintApp
{

    /// <summary>
    /// Main Application form   
    /// </summary>
    public partial class frmMain : Form
    {
    #region VARIABLES SECTION
        #region DEFAULTS, LIMITS & CONSTANTS
        private int BaseERRNUM = 10000; //next available +20
        private int FeintBaseERRNUM = 1000;
        private int OPCBaseERRNUM = 2000;
        private int BlobBaseERRNUM = 3000;
        private int NiDaqBaseERRNUM = 4000;
        private int CamCommBaseERRNUM = 5000;
        private int InspMapBaseERRNUM = 6000;
        private int AlarmBaseERRNUM = 7000;
        private int EventLogBaseERRNUM = 8000;
        private int FaulStatsBaseERRNUM = 9000;

        private const int MaxErrorsPerList = 200;
        private int ErrorsPerCurrentPlate = 0;
        #endregion
        #region CONFIGURATION
//        private bool PASSWORDENABLED = false;
        private bool NIDAQENABLED = true;
//        private bool CAMCOMMSENABLED = true;
        private bool OPCENABLED = false;
        private const bool TILESENABLED = true;
        private const bool GRAPHDRAWINGENABLED = true;
        private const bool TRACEENABLED = true;
        private const bool ONLY_ONE_CAMERA = true;
        private int MinimumFaultPosition = 0;
    #endregion
        /// <summary>
        /// STATE VARS: these variables are used to share current state information e.g are we quiting the program
        /// </summary>
        #region STATE VARS
        ///<summary>state variable indicating the intention to quit once the current scan is complete </summary>
        private bool QuitAfterScanComplete = false;
        ///<summary>state variable indicating used to determine that the user really wants you to quit regardles of where you are in the scan because he's pressed the quit button twice </summary>
        private bool QuitRequestedOnce = false;
        private bool Quitting = false;
        ///<summary>state variable indicating the the password was correctly supplied or not </summary>
        private bool PasswordSupplied = false;
        private bool OverloadCam1 = false, OverloadCam2 = false;
        private Led[] ledArrayCam1;
        private Led[] ledArrayCam2;
        private bool Cam1Stream = false, Cam2Stream = false;
        private bool Cam1FeintStream = false, Cam2FeintStream = false;
        private int lightFailCount = 0;
        private bool Feint1Charged = false, Feint2Charged = false;
        #endregion

        #region OPC
        private int ServerRegistrationAction = -1;//0 to register, 1 to unregister, 2 to re-register, -1 to disable
        private PaintSupport.OpcServer myOpcServer;
        #endregion

        #region MY IMAGE PROCESSING OBJECTS
        private BlobProcessor blob1, blob2;
        private FeintStreamDetector Feint1, Feint2;
        private CameraComms cam1Comm, cam2Comm;
//        private CVBImage.TDRect selectedROI;
        public DateTime T1,T2;
        public TimeSpan Telapsed;
        public int /*MaxNumBlobs = 100000, MaxNumBlobsSorted = 20,*/ Threshold = 195, LineFrequency = 1000;

        public const bool SORTDESCENDING = true, SORTASCENDING = false, DARKFIELD = true, LIGHTFIELD = false;
        public bool FIELD_DarkOrLight;
        public AxCVDISPLAYLib.AxCVdisplay[] TileArray1;
        public AxCVDISPLAYLib.AxCVdisplay[] TileArray2;
        private const bool SAVETILES = true, DONTSAVETILES = false;
        #endregion

        #region THREADS and My Objects
        public object SynchLockObject1 = new object();
        private EventLogThread EventLogThreadObj;
        private Alarm myAlarm;
        private NIDaq myNIDaq;
        private InspectionMap myInspectionMap;
        private FaultStats myFaultStats;
        #endregion

        #region INVOKE DELEGATES
        /// <summary>
        ///NOTE: IT IS UNSAFE TO WRITE TO THE UI WITH ANY THREAD OTHER THAN THE THREAD IT WAS CREATED
        ///THESE DELEGATES ARE INVOKED (PUT IN THE MESSAGE QUEUE) TO RUN UI OPS ON THE UI THREAD
        ///ADD NEW DELEGATES FOR NEW PARAMS
        /// </summary>
        ///<summary>General delegate used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate();
        ///<summary>General delegate that takes a string, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_Str(string Str);
        ///<summary>General delegate that takes a string, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_Int_Str(int ErrorNum, string Str);
        ///<summary>General delegate that takes a ref bool, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_refBool(ref bool Val);
        ///<summary>General delegate that takes a bool, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_Bool(bool Val);
        ///<summary>General delegate that takes 1 int, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_Int(int Val1);
        ///<summary>General delegate that takes 2 ints, used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate_Int_Int(int Val1, int Val2);
        public delegate void RunOnUIThreadDelegate_Int_Int_Int(int Val1, int Val2, int Val3);
        public delegate void RunOnUIThreadDelegate_Int_Int_Int_Bool(int Val1, int Val2, int Val3,bool Val4);
        public delegate void RunOnUIThreadDelegate_refInt_refInt_Int(ref int Val1, ref int Val2, int Val3);

#endregion
    #endregion
        #region Initialisation and Error Reporting
        /// <summary>
        /// Constructor creates and starts the event log thread and some of my objects
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            OPCENABLED = Properties.Settings.Default.APP_EnableOPC;
            FIELD_DarkOrLight = !Properties.Settings.Default.Image_BlobLightFieldNotDark;
            ledArrayCam1 = new Led[6] { ledT11, ledT12, ledT13, ledT14, ledT15, ledT16 };
            ledArrayCam2 = new Led[6] { ledT21, ledT22, ledT23, ledT24, ledT25, ledT26 };
            
            EventLogThreadObj = new EventLogThread(EventLogBaseERRNUM, reportError);//create an event log object
            EventLogThreadObj.StartThreadProc();

            myInspectionMap = new InspectionMap(InspMapBaseERRNUM, reportError);
            myFaultStats = new FaultStats(FaulStatsBaseERRNUM, reportError);

            myAlarm = new Alarm(AlarmBaseERRNUM, reportError);
            if (NIDAQENABLED)
            {
                myNIDaq = new NIDaq(NiDaqBaseERRNUM, reportError);
            }

        }
        /// <summary>
        /// Perform operations that require the form to be visible like the UI initialisation 
        /// I have also put the OPC creation here to delay connections till the app is up and running.
        /// and and Image Processing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Load(Properties.Settings.Default.GUI_LogoFile);
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 5, " ERROR: frmMain.SetupIP: problem loading the logo picture" + except.ToString());
            }
            propertyGridMySettings.SelectedObject = Properties.Settings.Default;//bind the property grid to the application settings

            if (OPCENABLED)
            {
                //myOpcServer = new PaintSupport.OpcServer(OPCBaseERRNUM, reportError,opcServerControl);
                ServerRegistrationAction = Properties.Settings.Default.OPC_ServerRegistrationAction;
                if (ServerRegistrationAction >= 0)
                    myOpcServer.ModifyRegistration(ServerRegistrationAction);
                myOpcServer.Start();
            }
            SetupIP();
            setupUI();
            reportError(BaseERRNUM + 0, " INFORMATION: frmMain.Form1_Load: Paint Inspection System Started");

        }
 

		/// <summary>
		/// all error reporting calls this function that invokes reporting to the on screen error list 
		/// and puts the error into an event log queue to be handle by the EventLog thread.
		/// The error number is passed to the Alarm object which checks if the condition raises or clears an alarm.
		/// <seealso cref="reportErrorToUserAndEventLog"/>
		/// run on the multiple Threads 
		/// </summary>
		/// <param name="Str"></param>
		public void reportError(int ErrorNum,string Str)
		{
			try
			{
                if (lstErrorLog.InvokeRequired)
                    lstErrorLog.BeginInvoke(new RunOnUIThreadDelegate_Int_Str(reportErrorToUserAndEventLog), new object[] { ErrorNum, Str });
                else
                    reportErrorToUserAndEventLog(ErrorNum, Str);
			}
			catch(Exception except)
			{
				MessageBox.Show(Str);
			}
		}
		
		/// <summary>
		/// Puts the error into an event log queue to be handle by the EventLog thread.
		/// The error number is extracted from the fromt of the error string and 
		/// passed to the Alarm object which checks if the condition raises or clears an alarm (red or green light on).
		/// invoked to run on the Form's Thread 
		/// </summary>
		/// <param name="Str"></param>
		public void reportErrorToUserAndEventLog(int ErrCode, string Str)
		{
			if(!Quitting) //don't try reporting errors when quitting as any errors will be due to accessing disposed objects etc
			{
				char[] separator = {(char)32};
				string[] subStrings = Str.Split(separator,6); //get the Error code from the begining
				//uint ErrCode;
				int ID= -1;
				try
				{
					//ErrCode = uint.Parse(subStrings[0]);
					int status = -1;//pass in status to see if it's changed
					bool AlarmChanged = false;
					bool retval = myAlarm.CheckList(out AlarmChanged,ref status,(uint)ErrCode,ID);
                    //if(status != -1 && myPlcProcessor.EnabledFlag) //report a change in status to the plc
                    //    myPlcProcessor.myPLC.ChangeStatus(status);
					if(AlarmChanged && NIDAQENABLED)//if the status has changed the light may need changing so call anyway
						myNIDaq.SetStatus(retval);
				}
				catch(Exception except)
				{
					//if we fail to get a vlaid number don't try and process it - ignore
				}

				int startofstr = -1 , searchLength = Str.Length;
				if(searchLength > 100)
					searchLength = 100;

				startofstr = Str.IndexOf("#DONT TRUNCATE#",0,searchLength); //use this to inserted string to override the string truncate and print the entire error msg

				string errStr;
				if(startofstr != -1 &&Str.Length > 500)			//truncate the string to 500 chars to stop it overflowing the event log
					errStr = Str.Substring(0,500);
				else
					errStr = Str;

				string StampedErrStr = "";
				try
				{
					//##					StampedErrStr = DateTime.Now.ToString() + " : " + errStr;
					StampedErrStr = DateTime.Now.ToString() + " : " + errStr;
					EventLogThreadObj.WriteToLog(StampedErrStr); //write message to the event log
				}
				catch(Exception)
				{
					int z;
					z = 0;
				}

				startofstr = -1; //reset the search
				startofstr =errStr.IndexOf("INFORMATION",0,searchLength); //dont put information strings in the status box
				if(startofstr == -1)	//1			
					txtInfo.Text = StampedErrStr;				  //write message to textbox

				lstErrorLog.Items.Insert(0,StampedErrStr);  //write message to the listbox
				ErrorsPerCurrentPlate++;


				if(lstErrorLog.Items.Count >MaxErrorsPerList)
					lstErrorLog.Items.RemoveAt(lstErrorLog.Items.Count-1);
			}
		}

        /// <summary>
        /// setup image processing hardware
        /// </summary>
        private void SetupIP()
        {
            try
            {
                if (Properties.Settings.Default.Camera_CommsEnabled)
                    try
                    {
                        //enable the comm port connections to the camera and set the camera line rate etc
                        cam1Comm = new CameraComms(CamCommBaseERRNUM, reportError, cam1ComPort);

                        cam2Comm = new CameraComms(CamCommBaseERRNUM, reportError, cam2ComPort);

                        //cam1Comm.SetLineFreq(LineFrequency);
                        //cam2Comm.SetLineFreq(LineFrequency);
                    }
                    catch(Exception except)
                    {
                        reportError(BaseERRNUM + 19, " ERROR: frmMain.SetupIP: problem configuring imaging system" + except.ToString());
                    }   
                //cameras 
                //Most of the grabber and camera details are controlled through the image and not the grabber object?! The Image loads the vin file that describes the 
                //frame grabber. The vin file expects the GigE cameras to be referenced in the C:\ProgramData\STEMMER IMAGING\Common Vision Blox\Drivers\GenICam.ini

                CVimage1.LoadImage("%CVB%\\Drivers\\GenICam.vin"); //Load the vin file to initialise the axCVimage
                CVgrabber1.Image = CVimage1.Image;    // init the grabber with the image
                CVgrabber1.CamPort = 1; //change the port THIS CHANGES THE UNDERLYING IMAGE!  (PORT 0 MUST BE DONE LAST!)
                CVimage1.Image = CVgrabber1.Image;// SO WE HAVE TO COPY THE NEW IMAGE REFERENCE BACK TO THE axCVimage
                CVdisplay1.Image = CVimage1.Image;
                CVimage1.Snap();
                CVdisplay1.Refresh();

                CVimage2.LoadImage("%CVB%\\Drivers\\GenICam.vin");//("C:\\Program Files\\Common Vision Blox\\Drivers\\CVX64CLiPro.vin");
                //the port property of the control doesn't work, so this call is required to point to the second camera
                //I assume that this next call causes the ccf file X64CLiPro_01.ccf to be used
                //if(!ONLY_ONE_CAMERA)
                //Cvb.Driver.ICameraSelect.SetCamPort(CVimage2.Image, 1, 100);

                //CVgrabber2.Image = CVimage2.Image;    // grab image
                CVdisplay2.Image = CVimage2.Image;    // display image
                //CVgrabber2.CamPort = 0;    PORT 0 IS THE DEFAULT SO NOT NECESSARY TO EXPLICITLY POINT TO IT AND WE ONLY NEED THE DRIVER REF TO SET THE PORT
                CVimage2.Snap();
                CVdisplay2.Refresh();
                if (CVgrabber1.CanPingPong || Driver.IGrab2.CanGrab2(Cvb.Image.ToCvbIMG(CVgrabber1.Image)))
                {
                    Cvb.Utilities.SetGlobalPingPongEnabled(true);//set entry in the registry
                    CVimage1.PingPongEnabled = true;
                    CVimage2.PingPongEnabled = true;
                }
                //setup blob detection and start grabbing images2
                TileArray1 = new AxCVDISPLAYLib.AxCVdisplay[6] { CVdisplayTile11, CVdisplayTile12, CVdisplayTile13, CVdisplayTile14, CVdisplayTile15, CVdisplayTile16 };

                T1 = DateTime.Now;
                CVimage1.Grab = true;

                blob1 = new BlobProcessor(BlobBaseERRNUM, reportError, CVimage1);
                if(Properties.Settings.Default.APP_EnableFeintProcessing)
                    Feint1 = new FeintStreamDetector(FeintBaseERRNUM, reportError, Properties.Settings.Default.Image_FeintStreamNumFrames, Properties.Settings.Default.Camera_WidthPixels, myInspectionMap.PixPermmCam1);

                blob1.ConfigureDetection(Properties.Settings.Default.Image_MaxNumBlobs, Properties.Settings.Default.Image_MaxBlobsSorted, Properties.Settings.Default.Image_BlobMinAreaPixels, SORTDESCENDING, Threshold, FIELD_DarkOrLight);
                blob1.ConfigureTiles(TileArray1.Length, TileArray1, DONTSAVETILES);
                //this seems to limits the number of blobs to 100?!
                TileArray2 = new AxCVDISPLAYLib.AxCVdisplay[6] { CVdisplayTile21, CVdisplayTile22, CVdisplayTile23, CVdisplayTile24, CVdisplayTile25, CVdisplayTile26 };

                T2 = DateTime.Now;
                CVimage2.Grab = true;

                blob2 = new BlobProcessor(BlobBaseERRNUM, reportError, CVimage2);
                if (Properties.Settings.Default.APP_EnableFeintProcessing) 
                    Feint2 = new FeintStreamDetector(FeintBaseERRNUM, reportError, Properties.Settings.Default.Image_FeintStreamNumFrames, Properties.Settings.Default.Camera_WidthPixels, myInspectionMap.PixPermmCam2);

                blob2.Error += new BlobProcessor.ErrorEventHandler(reportError);
                blob2.ConfigureDetection(Properties.Settings.Default.Image_MaxNumBlobs, Properties.Settings.Default.Image_MaxBlobsSorted, Properties.Settings.Default.Image_BlobMinAreaPixels, SORTDESCENDING, Threshold, FIELD_DarkOrLight);
                blob2.ConfigureTiles(TileArray2.Length, TileArray2, DONTSAVETILES);                                                                                        //this seems to limits the number of blobs to 100?!
                if (Properties.Settings.Default.Camera_CommsEnabled)
                {
                    cam1Comm.SetLineFreq(Properties.Settings.Default.Camera_LineRate_Hz);
                    cam2Comm.SetLineFreq(Properties.Settings.Default.Camera_LineRate_Hz);
                    cam1Comm.SetAnalogGain(Properties.Settings.Default.Camera1_AnalogGainSetting);
                    cam2Comm.SetAnalogGain(Properties.Settings.Default.Camera1_AnalogGainSetting);
                }
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 5, " ERROR: frmMain.SetupIP: problem configuring imaging system" + except.ToString());
            }
        }
        /// <summary>
        /// setup user interface
        /// </summary>
        private void setupUI()
        {
            //initialise the threshold slider etc.
            Threshold = Properties.Settings.Default.Image_Threshold;
            slideThreshold.Value = Properties.Settings.Default.Image_Threshold;
            slideOverload.Value = Properties.Settings.Default.Image_OverloadFactor;
            graph1GreyScaleCursor.YPosition = Properties.Settings.Default.Image_Threshold;
            graph2GreyScaleCursor.YPosition = Properties.Settings.Default.Image_Threshold;
            //set the rolling map stream point size so that the points just overlap
            graphFaultMapstreams.PointSize = new System.Drawing.Size(23 * myFaultStats.BinnIntervalMins, 15);
            graphFaultMapFeints.PointSize = new System.Drawing.Size(23 * myFaultStats.BinnIntervalMins, 8);
            int gain1 = Properties.Settings.Default.Camera1_AnalogGainSetting;
            if (Properties.Settings.Default.Camera_CommsEnabled)
            {
                switch (gain1)
                {
                    case (0):
                        rdoCam1Gain0.Checked = true;
                        break;
                    case (1):
                        rdoCam1Gain1.Checked = true;
                        break;
                    case (2):
                        rdoCam1Gain2.Checked = true;
                        break;
                    case (4):
                        rdoCam1Gain3.Checked = true;
                        break;
                    case (6):
                        rdoCam1Gain4.Checked = true;
                        break;
                    case (8):
                        rdoCam1Gain5.Checked = true;
                        break;
                    case (10):
                        rdoCam1Gain6.Checked = true;
                        break;
                }
                int gain2 = Properties.Settings.Default.Camera2_AnalogGainSetting;
                switch (gain2)
                {
                    case (0):
                        rdoCam2Gain0.Checked = true;
                        break;
                    case (1):
                        rdoCam2Gain1.Checked = true;
                        break;
                    case (2):
                        rdoCam2Gain2.Checked = true;
                        break;
                    case (4):
                        rdoCam2Gain3.Checked = true;
                        break;
                    case (6):
                        rdoCam2Gain4.Checked = true;
                        break;
                    case (8):
                        rdoCam2Gain5.Checked = true;
                        break;
                    case (10):
                        rdoCam1Gain6.Checked = true;
                        break;
                }
                int freq = Properties.Settings.Default.Camera_LineRate_Hz;
                switch (freq)
                {
                    case (2000):
                        rdoCamFreq2kHz.Checked = true;
                        break;
                    case (1500):
                        rdoCamFreq1_5kHz.Checked = true;
                        break;
                    case (1000):
                        rdoCamFreq1kHz.Checked = true;
                        break;
                    case (750):
                        rdoCamFreq750Hz.Checked = true;
                        break;
                    case (500):
                        rdoCamFreq500Hz.Checked = true;
                        break;
                    case (350):
                        rdoCamFreq350Hz.Checked = true;
                        break;
                    default:
                        rdoCamFreq1kHz.Checked = true;
                        break;
                }
            }
            else
            {
                grpCam1Gain.Enabled = false;
                grpCam2Gain.Enabled = false;
                grpCamFreq.Enabled = false;
            }
            spinCam1Right.Value = Properties.Settings.Default.Image_Blob1EndPix;
            spinCam1Left.Value = Properties.Settings.Default.Image_Blob1StartPix;
            spinCam2Right.Value = Properties.Settings.Default.Image_Blob2EndPix;
            spinCam2Left.Value = Properties.Settings.Default.Image_Blob2StartPix;
            switch (Properties.Settings.Default.Report_ImageSaveFlags)
            {
                case (1):
                    rdoImageSaveTiles.Checked = true;
                    break;
                case (2):
                    rdoImageSaveFrames.Checked = true;
                    break;
                default:
                    rdoImageSaveNone.Checked = true;
                    break;
            }
        }
        #endregion
        #region Shutdown tidy up
        /// <summary>
        /// tidy up before exiting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save(); //save the settings file
            tidyUpBeforeQuit();
        }

        private void tidyUpBeforeQuit()
        {
            Quitting = true;
//            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.Camera_CommsEnabled)
                try
                {
                    cam1Comm.Close();
                    cam2Comm.Close();
                }
                catch (Exception except)
                {
                    reportError(BaseERRNUM + 1, " WARNING: frmMain.tidyUpBeforeQuit: Failed close the comm port(s) " + (char)13 + except.ToString());
                }
            if (NIDAQENABLED)
                try
                {
                    myNIDaq.ClearAndStopOutputs();
                    //				digitalReadTask.Dispose();
                    myNIDaq.Dispose();
                }
                catch (Exception except)
                {
                    reportError(BaseERRNUM + 2, " WARNING: frmMain.tidyUpBeforeQuit: Failed to dispose National Instruments task " + (char)13 + except.ToString());
                }
            if (OPCENABLED)
                try
                {
                    myOpcServer.Stop();
                }
                catch (Exception except)
                {
                    reportError(BaseERRNUM + 3, " WARNING: frmMain.tidyUpBeforeQuit: Failed to dispose National Instruments task " + (char)13 + except.ToString());
                }

            try
            {
                closeDownIP();
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 4, " WARNING: frmMain.tidyUpBeforeQuit: Failed to dispose National Instruments task " + (char)13 + except.ToString());
            }

            if (!EventLogThreadObj.StopThreadProc(1000))
                MessageBox.Show("WARNING: frmMain.tidyUpBeforeQuit: A 1s timeout expired waiting for the Event Log thread to exit, it will now be forcibly closed"); ;

        }

        /// <summary>
        /// close down image processing hardware
        /// </summary>
        private void closeDownIP()
        {
            try
            {
                CVimage1.Grab = false;
                CVimage2.Grab = false;
                CVgrabber1.Dispose();
                CVgrabber2.Dispose();
                CVdisplay1.Dispose();
                CVdisplay2.Dispose();
                CVimage1.Dispose();
                CVimage2.Dispose();
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 6, " ERROR: frmMain.closeDownIP: problem closing down imaging system" + (char)13 + except.ToString());
            }
        }
        #endregion
        #region OPC callback
        /// <summary>
        /// Callback when OPC client connects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void opcServer_OnClientConnect(object sender, NDI.SLIKDA.Interop.SLIKServer.OnClientConnectEventArgs eventArgs)
        {
            ledOPCconect.Value = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void opcServerControl_OnClientDisconnect(object sender, SLIKServer.OnClientDisconnectEventArgs eventArgs)
        {
            ledOPCconect.Value = false;
        }
        /// <summary>
        /// Callback when OPC client reads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void opcServer_OnRead(object sender, NDI.SLIKDA.Interop.SLIKServer.OnReadEventArgs eventArgs)
        {

        }
        #endregion
        #region Reporting and Graph Drawing
        /// <summary>
        /// draw the rolling map of the blips and streams
        /// the graph is rotated through 90degrees i.e. the x values are up the side and the y values along the bottom
        /// </summary>
        private void DrawMap()
        {
            try
            {
                myFaultStats.GetPlotData(1);
                graphFaultMap.PlotYXMultiple(myFaultStats.xplot, myFaultStats.yplots,DataOrientation.DataInRows);
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 7, " ERROR: frmMain.DrawMap: problem drawing map " + (char)13 + except.ToString());
            }
        }
        /// <summary>
        /// draws a scope trace of the camera's output for the top line of the current frame
        /// </summary>
        /// <param name="Camera">which camera to draw</param>
        private void DrawGraph(int Camera)
        {
            int i = 0;
            double[] camPlot = new double[Properties.Settings.Default.Camera_WidthPixels];
            try
            {
                if (Camera == InspectionMap.Camera1)
                {
                    blob1.getLineFromImage(0,ref camPlot);
                    if (!Feint1Charged || !Properties.Settings.Default.APP_EnableFeintProcessing)//!Properties.Settings.Default.Report_FeintStreams)
                        graph1.PlotY(camPlot);
                    else
                    {
                        double[,] plotData = new double[3,Properties.Settings.Default.Camera_WidthPixels];
                       // graph1.DefaultDataOrientation = DataOrientation.DataInColumns;
                        for (i = 0; i < Properties.Settings.Default.Camera_WidthPixels; i++)
                        {
                            plotData[0,i] = camPlot[i];
                            plotData[1,i] = Feint1.LineAverageY[i];
                            if (i >= Feint1.Left && i <= Feint1.Right)
                                plotData[2, i] = Feint1.FilteredY[i - Feint1.Left] + Properties.Settings.Default.Image_FeintStreamOffsetThreshold;
                            else
                                plotData[2, i] = 0.0;
                        }
                        graph1.PlotYMultiple(plotData);
                    }
                }
                else
                {
                    blob2.getLineFromImage(0,ref camPlot);
                    if (!Feint2Charged || !Properties.Settings.Default.APP_EnableFeintProcessing)//!Properties.Settings.Default.Report_FeintStreams)
                        graph2.PlotY(camPlot);
                    else
                    {
                        double[,] plotData = new double[3,Properties.Settings.Default.Camera_WidthPixels];
                        //graph2.DefaultDataOrientation = DataOrientation.DataInColumns;
                        for (i = 0; i < Properties.Settings.Default.Camera_WidthPixels; i++)
                        {
                            plotData[0,i] = camPlot[i];
                            plotData[1,i] = Feint2.LineAverageY[i];
                            if (i >= Feint2.Left && i <= Feint2.Right)
                                plotData[2,i] = Feint2.FilteredY[i - Feint2.Left] + Properties.Settings.Default.Image_FeintStreamOffsetThreshold;
                            else
                                plotData[2, i] = 0.0;
                        }
                        graph2.PlotYMultiple(plotData);
                    }
                }
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 8," ERROR: frmMain.DrawGraph: problem drawing graph " + (char)13 + except.ToString());
            }
        }
        /// <summary>
        /// updates the blip and stream count labels
        /// </summary>
        /// <param name="blips"></param>
        /// <param name="streams"></param>
        private void reportBlobsLocal(int camera, int blips,int streams)
        {
            lock (SynchLockObject1)
            {
                try
                {
                    if(NIDAQENABLED) 
                        setPLCLeds();
                    if (camera == InspectionMap.Camera1)
                    {
                        lblBlipsCurrent1.Text = blips.ToString();
                        lblStreamsCurrent1.Text = streams.ToString();
                    }
                    else
                    {
                        lblBlipsCurrent2.Text = blips.ToString();
                        lblStreamsCurrent2.Text = streams.ToString();
                    }
                    if (OverloadCam1||OverloadCam2)
                        lblFaultPos.Text = "XXXX";
                    else
                        lblFaultPos.Text = MinimumFaultPosition.ToString();
                    lblBlipsTotal1.Text = (int.Parse(lblBlipsTotal1.Text) + blips).ToString();
                    lblStreamsTotal1.Text = (int.Parse(lblStreamsTotal1.Text) + streams).ToString();
                }
                catch (Exception except)
                {
                    reportError(BaseERRNUM + 9, " ERROR: reportBlobsLocal: problem reporting " + (char)13 + except.ToString());
                }
            }
        }
        private void setPLCLeds()
        {
            ledPLCBlip.Value = myNIDaq.DOBits[myNIDaq.BlipBit];
            ledPLCStream.Value = myNIDaq.DOBits[myNIDaq.StreamBit];
            ledPLCStatus.Value = !myNIDaq.DOBits[myNIDaq.StatusBit];//Status is ACTIVE LOW!
            ledPLCFeintStream.Value = myNIDaq.DOBits[myNIDaq.FeintStreamBit];
        }
        /// <summary>
        /// If there are any blips pulse the blip digital output on, if any streams, turn the stream digital output on
        /// if neither camera has seen a stream turn the stream digital output on.
        /// If forceDigOut is true i.e. there has been a blip but it is connected to the top so it has already been
        /// accounted for in the stats, then turn the blip digital output on.
        /// </summary>
        /// <param name="Camera">which camera the stats belong to </param>
        /// <param name="blips">the number of blips</param>
        /// <param name="streams">the number of streams</param>
        /// <param name="FeintstreamPos">the position of the first feint stream from the left, will be set to -1 if feint streams disabled</param>
        /// <param name="forceDigOut">used for blips touching the top that have already been included in stats but we want the DO to fire</param>
        private void reportBlobsRemote(int Camera, int blips, int streams,int FeintstreamPos, int forceDigOut)
        {
            lock (SynchLockObject1) //lock the NIDAQ and OPC objects as they can potentially be accessed from 2 different threads
            {                       //Although with INVOKE they should both be run on the UI thread?!
                try
                {
                    if (NIDAQENABLED)
                    {
                        if (blips > 0 || (forceDigOut&1)==1)
                        {
                            BlobProcessor blobProc = (Camera == InspectionMap.Camera1)? blob1 : blob2;// init the ref to the appropriate blobProcessor
                            int x,y,dx,dy;
                            Blob.GetBoundingBox(blobProc.blob, 0, out x, out y, out dx, out dy);//get the position of the first blob i.e. the closest to the edge
                            MinimumFaultPosition = myInspectionMap.getPosition_mm(Camera,x);
                            if (OverloadCam1 || OverloadCam2)//if were in Overload set the position to all ones
                                myNIDaq.TurnStreamOnReportPos(4095);
                            else 
                                myNIDaq.TurnBlipOnReportPos(MinimumFaultPosition);//get the mm position from the camera and pixel position and report it along with the blip
                        }
                        if (streams > 0 || (forceDigOut & 2) == 2)
                        {
                            if (Camera == InspectionMap.Camera1)
                                Cam1Stream = true;
                            else
                                Cam2Stream = true;
                            BlobProcessor blobProc = (Camera == InspectionMap.Camera1) ? blob1 : blob2;// init the ref to the appropriate blobProcessor
                            int x, y, dx, dy;
                            Blob.GetBoundingBox(blobProc.blob, 0, out x, out y, out dx, out dy);//get the position of the first blob i.e. the closest to the edge
                            MinimumFaultPosition = myInspectionMap.getPosition_mm(Camera, x);
                            if (OverloadCam1 || OverloadCam2)//if were in Overload set the position to all ones
                                myNIDaq.TurnStreamOnReportPos(4095);
                            else
                                myNIDaq.TurnStreamOnReportPos(MinimumFaultPosition);
                        }
                        else
                        {
                            if (Camera == InspectionMap.Camera1)
                                Cam1Stream = false;
                            else
                                Cam2Stream = false;
                            if(!Cam1Stream && !Cam2Stream)
                                myNIDaq.TurnStreamOff(); //only turn streams off if niether cameras are reporting a stream

                        }

                        if (streams <= 0)//if we have a stream ignore the Feint stream
                            if(FeintstreamPos != -1)
                            {
                                if (Camera == InspectionMap.Camera1)
                                    Cam1FeintStream = true;
                                else
                                    Cam1FeintStream = true;
                                MinimumFaultPosition = myInspectionMap.getPosition_mm(Camera, FeintstreamPos);
                                myNIDaq.TurnFeintStreamOnReportPos(MinimumFaultPosition);
                            }
                            else
                            {
                                if (Camera == InspectionMap.Camera1)
                                    Cam1FeintStream = false;
                                else
                                    Cam1FeintStream = false;
                                if (!Cam1Stream && !Cam2Stream)
                                    myNIDaq.TurnFeintStreamOff(); //only turn streams off if niether cameras are reporting a stream
                            }

                    }
                    if (OPCENABLED)
                    {
                        if (blips > 0)//only update if the tag has changed
                            myOpcServer.WriteBlipsTotalToTag(myFaultStats.getTotalBlips(1), myFaultStats.getBlipsBySize(1, 0), myFaultStats.getBlipsBySize(1, 1),
                                myFaultStats.getBlipsBySize(1,2), myFaultStats.getBlipsBySize(1,3),myFaultStats.getTotalBlips(8), myFaultStats.getTotalBlips(24));
                        if (streams > 0)//only update if the tag has changed
                            myOpcServer.WriteStreamsTotalToTag((int)myFaultStats.getTotalStreamTimeS(1), (int)myFaultStats.getStreamTimeBySize(1,0),
                                (int)myFaultStats.getStreamTimeBySize(1,1),(int)myFaultStats.getStreamTimeBySize(1,2),(int)myFaultStats.getStreamTimeBySize(1,3),
                                (int)myFaultStats.getTotalStreamTimeS(8), (int)myFaultStats.getTotalStreamTimeS(24));
                    }
                }
                catch (Exception except)
                {
                    reportError(BaseERRNUM + 10, " ERROR: reportBlobsRemote: problem reporting " + (char)13 + except.ToString());
                }
            }
        }
        #endregion
        #region Main processing callbacks and functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVimage1_ImageSnaped(object sender, EventArgs e)
        {
            Invoke(new RunOnUIThreadDelegate_Int(ProcessCamera), new object[] { InspectionMap.Camera1 });
        }
        private void CVimage2_ImageSnaped(object sender, EventArgs e)
        {
            Invoke(new RunOnUIThreadDelegate_Int(ProcessCamera), new object[] { InspectionMap.Camera2 });
        }
        /// <summary>
        /// The main processing for the camera is done here.
        /// Firstly a prediction is made if the blob processor is likely to get overloaded by counting the percentage pixels 
        /// above the threshold at the top middle and bottom lines of the image.
        /// If overload is not predicted, the blobs are processed in turn as follows:
        /// If the blob touches the top and the bottom of the image it is classified as a stream and the stream count is incremented
        /// If not the blob is a blip. If it is connected to the top or is camera2 and connected to the side then it will have already
        /// been entered into the statistics in the previous/adjacent frame so the blip counter is not incremented but the DigOutput is fired
        /// The fault stats are updated for blips and streams.
        /// If enabled the faults image tiles are extracted from the image and displayed.
        /// 
        /// </summary>
        /// <param name="Camera"></param>
        private void ProcessCamera(int Camera)
        {
            int x = 0, y = 0, dx = 0, dy = 0; Telapsed = DateTime.Now - T1; //##	
            int camBorderMask;
            bool regenerateMap = false, ZoneIsWhite = false, notused;
            int forceDigOut = 0;
            double frameTime_mS = (1000F / Properties.Settings.Default.Camera_LineRate_Hz) * Properties.Settings.Default.Camera_FrameHeightPixels;
            int MapUpdateFramePeriod = (int)((Properties.Settings.Default.Report_MapUpdateSeconds * (1000F / frameTime_mS)) + 0.5);
            if (int.Parse(lblFrameCount1.Text) % MapUpdateFramePeriod == 0)
                regenerateMap = true;
            if (Telapsed.Milliseconds > (frameTime_mS * 1.2) && Properties.Settings.Default.Image_CalbackTimeMsgEnable)
                reportError(BaseERRNUM + 12, " WARNING: frmMain.CVimage1_ImageSnaped: Camera " + Camera.ToString() + " time between calbacks = " + Telapsed.Milliseconds.ToString() + "for thread " + Thread.CurrentThread.GetHashCode() + (char)13);

            int blips = 0, streams = 0, blobs = 0, FeintstreamPos = -1;
            //predict if the blob processor is likely to get overloaded by counting the percentage pixels above the threshold at the top middle and bottom of the image
            if (Camera == InspectionMap.Camera1)
            {
                if(FIELD_DarkOrLight)//only check for overload with dark field
                    OverloadCam1 = blob1.predictOverload(Threshold,Properties.Settings.Default.Image_OverloadFactor,0,0,out notused);
                if(!OverloadCam1)
                    blobs = blob1.Process(Threshold);
                if (FIELD_DarkOrLight && blobs == -1)//only check for overload with dark field
                    OverloadCam1 = true;
                if (Properties.Settings.Default.APP_EnableFeintProcessing)
                {
                    Feint1Charged = Feint1.AddNewLine(ref blob1.CompositeLine);
                    if (Feint1Charged)
                        FeintstreamPos = Feint1.FilterAndCheck(Properties.Settings.Default.Image_FeintStreamOffsetThreshold);
                }
            }
            else
            {
                if (FIELD_DarkOrLight)//only check for overload with dark field
                    OverloadCam2 = blob2.predictOverload(Threshold, Properties.Settings.Default.Image_OverloadFactor,0,Properties.Settings.Default.Image_Blob2EndPix,out ZoneIsWhite);
                if (!OverloadCam1) 
                    blobs = blob2.Process(Threshold);
                if (FIELD_DarkOrLight && blobs == -1)//only check for overload with dark field
                    OverloadCam2 = true;
                if (Properties.Settings.Default.APP_EnableFeintProcessing)
                {
                    Feint2Charged = Feint2.AddNewLine(ref blob2.CompositeLine);
                    if (Feint2Charged)// I USE A SEPERATE MECHANISM TO DETECT FEINT STREAMS SO I ONLY REPORT THE FIRST FROM THE LEFT
                        FeintstreamPos = Feint2.FilterAndCheck(Properties.Settings.Default.Image_FeintStreamOffsetThreshold);
                }
                if (Properties.Settings.Default.Alarm_Cam2LightFailEnable)
                    CheckLightFailed(ZoneIsWhite);
                    
            }
            if (Properties.Settings.Default.APP_EnableFeintProcessing && FeintstreamPos != -1)//UPDATE THE FEINT STREAM STATS
            {
                myFaultStats.updateFeints(myInspectionMap.getZoneMask(Camera, FeintstreamPos), 1);//WE ONLY REPORT THE FIRST FEINT FROM THE LEFT OF MINIMUM WIDTH
            }
            //display the tile images and get the counts of blips and streams for the current frame
            if (Camera == InspectionMap.Camera1 && !OverloadCam1 || Camera == InspectionMap.Camera2 && !OverloadCam2)
            {
                ledOverload.Value = false;
                for (int i = 0; i < blobs; i++)
                {
                    try
                    {
                        if (Camera == InspectionMap.Camera1) /*Foundation.FBlobGetBoundingBox*/ Blob.GetBoundingBox(blob1.blob, i, out x, out y, out dx, out dy);
                        else /*Foundation.FBlobGetBoundingBox*/ Blob.GetBoundingBox(blob2.blob, i, out x, out y, out dx, out dy);
                        //Trace.WriteLineIf(TRACEENABLED, "blob at XZone: X : Y " + myInspectionMap.getZoneMask(Camera, x,dx).ToString() + ":" + x.ToString() + ":" + y.ToString());
                    }
                    catch (Exception except)
                    {
                        reportError(BaseERRNUM + 13, " ERROR: BlobProcessor.Process:  problem getting bounding box for blob " + (char)13 + except.ToString());
                    }
                    if (((Camera == InspectionMap.Camera1) && ((camBorderMask = BlobProcessor.streamMask & blob1.getBorderMask(x, dx, y, dy)) != BlobProcessor.streamMask)) ||
                        ((Camera == InspectionMap.Camera2) && ((camBorderMask = BlobProcessor.streamMask & blob2.getBorderMask(x, dx, y, dy)) != BlobProcessor.streamMask)))
                    {//it is a blip so check if it is connected to the top or is cam2 and connected to the side if so don't include it stats
                        if ((Camera == InspectionMap.Camera2 && ((camBorderMask & BlobProcessor.leftMask) == BlobProcessor.leftMask)) ||
                        (camBorderMask & BlobProcessor.topMask) == BlobProcessor.topMask)
                        {
                            //ledOPCconect.Value = true;
                            if (blips == 0) forceDigOut = 1;//force the blip bit
                        }
                        else
                        {
                            //ledOPCconect.Value = false;
                            blips++;
                        }
                        if(Properties.Settings.Default.Report_BlipStartOnly)
                            myFaultStats.updateBlips(myInspectionMap.getZoneMask(Camera, x), dx * dy);
                        else
                            myFaultStats.updateBlips(myInspectionMap.getZoneMask(Camera, x, dx), dx * dy);
                    }
                    else
                    {
                        streams++;
                        myFaultStats.updateStreams(myInspectionMap.getZoneMask(Camera, x, dx),dy);
                    }
                    if (TILESENABLED)
                        try
                        {
                            int index, previndex;
                            if (Camera == InspectionMap.Camera1)
                            {
                                blob1.DisplayTile(i, x, y, dx, dy, out index, out previndex);
                                ledArrayCam1[previndex].Value = false;//.ForeColor = Color.Gray;
                                ledArrayCam1[index].Value = true;
                            }
                            else
                            {
                                blob2.DisplayTile(i, x, y, dx, dy, out index, out previndex);
                                ledArrayCam2[previndex].Value = false;
                                ledArrayCam2[index].Value = true;
                            }
                        }
                        catch (Exception except)
                        {
                            reportError(BaseERRNUM + 14, " ERROR: BlobProcessor.Process: problem invoking DisplayTile " + (char)13 + except.ToString());
                        }
                        
                }
                if (blobs > 0)
                {
                    if ((Properties.Settings.Default.Report_ImageSaveFlags & 14) > 0)//if save frames or save next frame
                        if (Camera == InspectionMap.Camera1) CVdisplay1.SaveImage(Properties.Settings.Default.Report_ImageDir + DateTime.Now.ToString("yyyyMMdd HH.mm.ss") + " Camera1 Frame.jpg");
                        else CVdisplay2.SaveImage(Properties.Settings.Default.Report_ImageDir + DateTime.Now.ToString("yyyyMMdd HH.mm.ss") + " Camera2 Frame.jpg");
                    if ((Camera == InspectionMap.Camera1) && (Properties.Settings.Default.Report_ImageSaveFlags & 4) > 0)
                    {
                        //Properties.Settings.Default.Report_ImageSaveFlags &= ~4;//and the ones complement to clear the bit
                        //if((Properties.Settings.Default.Report_ImageSaveFlags & 12) ==0)//if both frames saved reset the checkbox
                        //    rdoImageSaveNone.Checked = true;
                        Properties.Settings.Default.Report_ImageSaveFlags = 0;//and the ones complement to clear the bit
                        rdoImageSaveNone.Checked = true;
                    }
                    if ((Camera == InspectionMap.Camera2) && (Properties.Settings.Default.Report_ImageSaveFlags & 8) > 0)
                    {
                        //Properties.Settings.Default.Report_ImageSaveFlags &= ~8;//and the ones complement to clear the bit
                        //if ((Properties.Settings.Default.Report_ImageSaveFlags & 12) == 0)//if both frames saved reset the checkbox
                        //    rdoImageSaveNone.Checked = true;
                        Properties.Settings.Default.Report_ImageSaveFlags = 0;//and the ones complement to clear the bit
                        rdoImageSaveNone.Checked = true;
                    }
                }
            }
            else
            {
                ledOverload.Value = true;
                myFaultStats.updateOverload(true);
                forceDigOut = 3;//force the blip and stream bits to indicate overload
            }

            reportBlobsRemote(Camera, blips, streams, FeintstreamPos, forceDigOut);
            try
            {
                Invoke(new RunOnUIThreadDelegate_Int_Int_Int_Bool(DisplayCameraResults), new object[] { Camera, blips, streams, regenerateMap });
            }
            catch (Exception except)
            {
                reportError(BaseERRNUM + 15, " WARNING: frmMain.CVimage1_ImageSnaped: problem invoking DisplayCamera1Results " + (char)13 + except.ToString());
            }
            if (Camera == InspectionMap.Camera1) T1 = DateTime.Now;
            else T2 = DateTime.Now;
        }

        private void DisplayCameraResults(int Camera, int blips, int streams, bool regenerateMap)
        {
            if (Camera == InspectionMap.Camera1)
            {
                if (GRAPHDRAWINGENABLED && tabMain.SelectedTab == tabMainCamera) //only display the graph if someone is looking at it
                    DrawGraph(InspectionMap.Camera1);
                CVdisplay1.Lock();
                CVdisplay1.Refresh();
                CVdisplay1.Unlock();
                reportBlobsLocal(Camera,blips, streams);
                int cnt = (int.Parse(lblFrameCount1.Text) + 1);
                lblFrameCount1.Text = cnt.ToString();
                if(regenerateMap)
                    DrawMap();
            }
            else
            {
                if (GRAPHDRAWINGENABLED && tabMain.SelectedTab == tabMainCamera) //only display the graph if someone is looking at it
                    DrawGraph(InspectionMap.Camera2);
                CVdisplay2.Lock();
                CVdisplay2.Refresh();
                CVdisplay2.Unlock();
                reportBlobsLocal(Camera,blips, streams);
                int cnt = (int.Parse(lblFrameCount2.Text) + 1);
                lblFrameCount2.Text = cnt.ToString();
                if (regenerateMap) 
                    DrawMap();
            }
        }
        #endregion
        #region Misc
        private void SetThreshold(int newThreshold)
        {
            graph1GreyScaleCursor.YPosition = newThreshold;
            graph2GreyScaleCursor.YPosition = newThreshold;
            Threshold = newThreshold;
            Properties.Settings.Default.Image_Threshold = newThreshold;
        }

        private void CheckLightFailed(bool OK)
        {
            if (!OK)
            {
                if (++lightFailCount >= Properties.Settings.Default.Alarm_Cam2LightFailedCount)
                {
                    reportError(BaseERRNUM + 11, " ERROR: lightFailed: the light is no longer fully visible at the edge of the field " + (char)13 );
                }
            }
            else if (lightFailCount >= Properties.Settings.Default.Alarm_Cam2LightFailedCount)//was failed already but now ok
            {
                lightFailCount = 0;//reset the count
                reportError(BaseERRNUM + 18, " INFORMATION: lightFailed: the problem with the light not being visible at the edge of the field has been rectified" + (char)13 );
            }
        }
        #endregion
        #region Comm port callbacks
        /// <summary>
        /// Send replies from the camera to the error log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cam1ComPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!Quitting)
                    reportError(BaseERRNUM + 16, " INFORMATION: cam1ComPort_DataReceived " + cam1ComPort.ReadLine());
            }
            catch(Exception except)
            {
            
            }
        }
        /// <summary>
        /// Send replies from the camera to the error log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cam2ComPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!Quitting)
                    reportError(BaseERRNUM + 17, " INFORMATION: cam2ComPort_DataReceived " + cam2ComPort.ReadLine());
            }
            catch(Exception except)
            {
            
            }
        }
        #endregion
        #region UI Events
        private void cmdScan_Click(object sender, EventArgs e)
        {
            if (cmdScan.Text == "Start")
            {
                T1 = DateTime.Now;
                CVimage1.Grab = true;
                T2 = DateTime.Now;
                CVimage2.Grab = true;
                cmdScan.Text = "Stop";
                cmdScan.BackColor = Color.Red;
            }
            else
            {
                CVimage1.Grab = false;
                CVimage2.Grab = false; 
                cmdScan.Text = "Start";
                cmdScan.BackColor = Color.GreenYellow;
            }
        }

        private void cmdErrLogClear_Click(object sender, EventArgs e)
        {
            myAlarm.ClearAll(); //clear alarms
            //myNIDaq.TurnGreenLightOn();//turn the red light off
            while (lstErrorLog.Items.Count > 0)
                lstErrorLog.Items.RemoveAt(0); //every time you call Remove the list changes so keep deleting at pos 0
            txtInfo.Text = "";
        }

        private void slideThreshold_MouseUp(object sender, MouseEventArgs e)
        {
            SetThreshold((int)slideThreshold.Value);
        }

        private void tabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            DialogResult ButtonPressed;
            if (((tabMain.SelectedTab == tabMainCamera) || (tabMain.SelectedTab == tabMainConfig)) && (!PasswordSupplied && Properties.Settings.Default.System_PasswordEnabled))
            {
                using (frmPassword dlg = new frmPassword())
                {
                    ButtonPressed = dlg.ShowDialog();
                    if ((ButtonPressed == DialogResult.OK) && (dlg.Password == Properties.Settings.Default.System_Password))
                    {
                        PasswordSupplied = true;
                    }
                    else
                    {
                        tabMain.SelectedTab = tabMainResults;
                    }
                }
            }
            else
                PasswordSupplied = false;
        }
        private void slideOverload_MouseUp(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Image_OverloadFactor = (double)slideOverload.Value;

        }
        private void SetCamerFreq(int Freq)
        {
            if (Properties.Settings.Default.Camera_CommsEnabled)
            {
                cam1Comm.SetLineFreq(Freq);
                cam2Comm.SetLineFreq(Freq);
                Properties.Settings.Default.Camera_LineRate_Hz = Freq;
            }
        }
        private void rdoCamFreq2kHz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 2000) SetCamerFreq(2000);
        }
        private void rdoCamFreq1_5kHz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 1500) SetCamerFreq(1500);
        }
        private void rdoCamFreq1kHz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 1000) SetCamerFreq(1000);
        }
        private void rdoCamFreq750Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 750) SetCamerFreq(750);
        }
        private void rdoCamFreq500Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 500) SetCamerFreq(500);
        }
        private void rdoCamFreq350Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera_LineRate_Hz != 350) SetCamerFreq(350);
        } 
        //private void rdoCamFreq100Hz_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (Properties.Settings.Default.Camera_LineRate_Hz != 100) SetCamerFreq(100);
        //}
        private void SetCameraGain(int Camera,int Gain)
        {
            if(Properties.Settings.Default.Camera_CommsEnabled)
                if (Camera == 1)
                {
                    cam1Comm.SetAnalogGain(Gain);
                    Properties.Settings.Default.Camera1_AnalogGainSetting = Gain;
                }
                else
                {
                    cam2Comm.SetAnalogGain(Gain);
                    Properties.Settings.Default.Camera2_AnalogGainSetting = Gain;
                }
        }
        private void rdoCam1Gain0_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 0)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 0;
                SetCameraGain(1, 0);
            }
        }
        private void rdoCam1Gain1_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 1)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 1;
                SetCameraGain(1, 1);
            }
        }
        private void rdoCam1Gain2_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 2)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 2;
                SetCameraGain(1, 2);
            }
        }
        private void rdoCam1Gain3_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 4)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 4;
                SetCameraGain(1, 4);
            }
        }
        private void rdoCam1Gain4_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 6)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 6;
                SetCameraGain(1, 6);
            }
        }
        private void rdoCam1Gain5_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 8)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 8;
                SetCameraGain(1, 8);
            }
        }
        private void rdoCam1Gain6_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera1_AnalogGainSetting != 10)
            {
                Properties.Settings.Default.Camera1_AnalogGainSetting = 10;
                SetCameraGain(1, 10);
            }
        }

        private void rdoCam2Gain0_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 0)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 0;
                SetCameraGain(2, 0);
            }
        }

        private void rdoCam2Gain1_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 1)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 1;
                SetCameraGain(2, 1);
            }
        }

        private void rdoCam2Gain2_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 2)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 2;
                SetCameraGain(2, 2);
            }
        }

        private void rdoCam2Gain3_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 4)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 4;
                SetCameraGain(2, 4);
            }
        }

        private void rdoCam2Gain4_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 6)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 6;
                SetCameraGain(2, 6);
            }
        }

        private void rdoCam2Gain5_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 8)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 8;
                SetCameraGain(2, 8);
            }
        }

        private void rdoCam2Gain6_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Camera2_AnalogGainSetting != 10)
            {
                Properties.Settings.Default.Camera2_AnalogGainSetting = 10;
                SetCameraGain(2, 10);
            }
        }

        private void spinCam1Left_BeforeChangeValue(object sender, BeforeChangeNumericValueEventArgs e)
        {
            if (e.NewValue >= spinCam1Right.Value)
                e.Cancel = true;
            else
            {
                graph1PixelCursorLeft.XPosition = e.NewValue;
                blob1.setHorizontalROI((int)e.NewValue, (int)spinCam1Right.Value);
                if (Properties.Settings.Default.APP_EnableFeintProcessing) 
                    Feint1.setHorizontalROI((int)e.NewValue, (int)spinCam1Right.Value);
                Properties.Settings.Default.Image_Blob1StartPix = (int)e.NewValue;
            }
        }

        private void spinCam1Right_BeforeChangeValue(object sender, BeforeChangeNumericValueEventArgs e)
        {
            if (e.NewValue <= spinCam1Left.Value)
                e.Cancel = true;
            else
            {
                graph1PixelCursorRight.XPosition = e.NewValue;
                blob1.setHorizontalROI((int)spinCam1Left.Value, (int)e.NewValue);
                if (Properties.Settings.Default.APP_EnableFeintProcessing) 
                    Feint1.setHorizontalROI((int)spinCam1Left.Value, (int)e.NewValue);
                Properties.Settings.Default.Image_Blob1EndPix = (int)e.NewValue;
            }
        }

        private void spinCam2Left_BeforeChangeValue(object sender, BeforeChangeNumericValueEventArgs e)
        {
            if (e.NewValue >= spinCam2Right.Value)
                e.Cancel = true;
            else
            {
                graph2PixelCursorLeft.XPosition = e.NewValue;
                blob2.setHorizontalROI((int)e.NewValue, (int)spinCam2Right.Value);
                if (Properties.Settings.Default.APP_EnableFeintProcessing) 
                    Feint2.setHorizontalROI((int)e.NewValue, (int)spinCam2Right.Value);
                Properties.Settings.Default.Image_Blob2StartPix = (int)e.NewValue;
            }
        }

        private void spinCam2Right_BeforeChangeValue(object sender, BeforeChangeNumericValueEventArgs e)
        {
            if (e.NewValue <= spinCam2Left.Value)
                e.Cancel = true;
            else
            {
                graph2PixelCursorRight.XPosition = e.NewValue;
                blob2.setHorizontalROI((int)spinCam2Left.Value, (int)e.NewValue);
                if (Properties.Settings.Default.APP_EnableFeintProcessing) 
                    Feint2.setHorizontalROI((int)spinCam2Left.Value, (int)e.NewValue);
                Properties.Settings.Default.Image_Blob2EndPix = (int)e.NewValue;
            }
        }
 
        private void rdoImageSaveNone_CheckedChanged(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Report_ImageSaveFlags != 0)
                Properties.Settings.Default.Report_ImageSaveFlags = 0;
            blob1.saveTileImages = false;
            blob2.saveTileImages = false;
        }

        private void rdoImageSaveTiles_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Report_ImageSaveFlags != 1)
            {
                Properties.Settings.Default.Report_ImageSaveFlags = 1;
                blob1.saveTileImages = true;
                blob2.saveTileImages = true;
            }
        }

        private void rdoImageSaveFrames_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Report_ImageSaveFlags != 2) 
                Properties.Settings.Default.Report_ImageSaveFlags = 2;
            blob1.saveTileImages = false;
            blob2.saveTileImages = false;
        }

        private void rdoImageSaveNext1_CheckedChanged(object sender, EventArgs e)
        {//with save next from camera 1 use val 4
            if (Properties.Settings.Default.Report_ImageSaveFlags != 4) 
                Properties.Settings.Default.Report_ImageSaveFlags = 4;
            blob1.saveTileImages = false;
            blob2.saveTileImages = false;
        }

        private void rdoImageSaveNext2_CheckedChanged(object sender, EventArgs e)
        {//with save next from camera 2 use val 8
            if (Properties.Settings.Default.Report_ImageSaveFlags != 8)
                Properties.Settings.Default.Report_ImageSaveFlags = 8;
            blob1.saveTileImages = false;
            blob2.saveTileImages = false;
        }

        #endregion


    }
}