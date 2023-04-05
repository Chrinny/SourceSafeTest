namespace Pilkngton.ProjectPaint.PaintApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cam1ComPort = new System.IO.Ports.SerialPort(this.components);
            this.cam2ComPort = new System.IO.Ports.SerialPort(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMainResults = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.graphFaultMap = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.graphFaultMapstreams = new NationalInstruments.UI.ScatterPlot();
            this.graphFaultMapxAxis = new NationalInstruments.UI.XAxis();
            this.graphFaultMapyAxis = new NationalInstruments.UI.YAxis();
            this.graphFaultMapblips = new NationalInstruments.UI.ScatterPlot();
            this.graphFaultMapoverload = new NationalInstruments.UI.ScatterPlot();
            this.graphFaultMapFeints = new NationalInstruments.UI.ScatterPlot();
            this.lblStreams2 = new System.Windows.Forms.Label();
            this.lblStreamsTotal2 = new System.Windows.Forms.Label();
            this.lblBlipsTotal2 = new System.Windows.Forms.Label();
            this.lblBlips2 = new System.Windows.Forms.Label();
            this.tabMainCamera = new System.Windows.Forms.TabPage();
            this.grpCam2Gain = new System.Windows.Forms.GroupBox();
            this.rdoCam2Gain6 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain5 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain4 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain3 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain2 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain1 = new System.Windows.Forms.RadioButton();
            this.rdoCam2Gain0 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStreamsCurrent2 = new System.Windows.Forms.Label();
            this.lblBlipsCurrent2 = new System.Windows.Forms.Label();
            this.lblBlipsCurrent1 = new System.Windows.Forms.Label();
            this.lblStreamsCurrent1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFrameCount1 = new System.Windows.Forms.Label();
            this.lblFrameCount2 = new System.Windows.Forms.Label();
            this.grpCam2ROI = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.spinCam2Left = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.spinCam2Right = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.grpCam1ROI = new System.Windows.Forms.GroupBox();
            this.spinCam1Left = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.spinCam1Right = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpCam1Gain = new System.Windows.Forms.GroupBox();
            this.rdoCam1Gain6 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain5 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain4 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain3 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain2 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain1 = new System.Windows.Forms.RadioButton();
            this.rdoCam1Gain0 = new System.Windows.Forms.RadioButton();
            this.grpCamFreq = new System.Windows.Forms.GroupBox();
            this.rdoCamFreq350Hz = new System.Windows.Forms.RadioButton();
            this.rdoCamFreq500Hz = new System.Windows.Forms.RadioButton();
            this.rdoCamFreq750Hz = new System.Windows.Forms.RadioButton();
            this.rdoCamFreq1kHz = new System.Windows.Forms.RadioButton();
            this.rdoCamFreq1_5kHz = new System.Windows.Forms.RadioButton();
            this.rdoCamFreq2kHz = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.slideOverload = new NationalInstruments.UI.WindowsForms.Slide();
            this.slideThreshold = new NationalInstruments.UI.WindowsForms.Slide();
            this.graph2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.graph2GreyScaleCursor = new NationalInstruments.UI.XYCursor();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.graph2PixelCursorRight = new NationalInstruments.UI.XYCursor();
            this.graph2PixelCursorLeft = new NationalInstruments.UI.XYCursor();
            this.waveformPlot4 = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot6 = new NationalInstruments.UI.WaveformPlot();
            this.graph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.graph1GreyScaleCursor = new NationalInstruments.UI.XYCursor();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.graph1PixelCursorRight = new NationalInstruments.UI.XYCursor();
            this.graph1PixelCursorLeft = new NationalInstruments.UI.XYCursor();
            this.waveformPlot3 = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot5 = new NationalInstruments.UI.WaveformPlot();
            this.tabMainConfig = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoImageSaveNext2 = new System.Windows.Forms.RadioButton();
            this.rdoImageSaveNext1 = new System.Windows.Forms.RadioButton();
            this.rdoImageSaveFrames = new System.Windows.Forms.RadioButton();
            this.rdoImageSaveTiles = new System.Windows.Forms.RadioButton();
            this.rdoImageSaveNone = new System.Windows.Forms.RadioButton();
            this.propertyGridMySettings = new System.Windows.Forms.PropertyGrid();
            this.tabMainLog = new System.Windows.Forms.TabPage();
            this.cmdErrLogClear = new System.Windows.Forms.Button();
            this.lstErrorLog = new System.Windows.Forms.CheckedListBox();
            this.cmdScan = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.CVimage2 = new AxCVIMAGELib.AxCVimage();
            this.CVdisplay2 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVgrabber2 = new AxCVGRABBERLib.AxCVgrabber();
            this.CVimage1 = new AxCVIMAGELib.AxCVimage();
            this.CVgrabber1 = new AxCVGRABBERLib.AxCVgrabber();
            this.CVdisplay1 = new AxCVDISPLAYLib.AxCVdisplay();
            this.ledOverload = new NationalInstruments.UI.WindowsForms.Led();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStreamsTotal1 = new System.Windows.Forms.Label();
            this.lblBlipsTotal1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CVdisplayTile12 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile13 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile14 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile15 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile16 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile21 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile22 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile23 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile24 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile25 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile26 = new AxCVDISPLAYLib.AxCVdisplay();
            this.CVdisplayTile11 = new AxCVDISPLAYLib.AxCVdisplay();
            this.ledT11 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT12 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT13 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT14 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT15 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT16 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT21 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT22 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT23 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT24 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT25 = new NationalInstruments.UI.WindowsForms.Led();
            this.ledT26 = new NationalInstruments.UI.WindowsForms.Led();
            this.label20 = new System.Windows.Forms.Label();
            this.lblFaultPos = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.ledPLCStatus = new NationalInstruments.UI.WindowsForms.Led();
            this.ledPLCFeintStream = new NationalInstruments.UI.WindowsForms.Led();
            this.ledPLCStream = new NationalInstruments.UI.WindowsForms.Led();
            this.ledPLCBlip = new NationalInstruments.UI.WindowsForms.Led();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ledOPCconect = new NationalInstruments.UI.WindowsForms.Led();
            this.tabMain.SuspendLayout();
            this.tabMainResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphFaultMap)).BeginInit();
            this.tabMainCamera.SuspendLayout();
            this.grpCam2Gain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpCam2ROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam2Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam2Right)).BeginInit();
            this.grpCam1ROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam1Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam1Right)).BeginInit();
            this.grpCam1Gain.SuspendLayout();
            this.grpCamFreq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slideOverload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2GreyScaleCursor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2PixelCursorRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2PixelCursorLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1GreyScaleCursor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1PixelCursorRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1PixelCursorLeft)).BeginInit();
            this.tabMainConfig.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabMainLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CVimage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVgrabber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVimage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVgrabber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledOverload)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT26)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCFeintStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCBlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledOPCconect)).BeginInit();
            this.SuspendLayout();
            // 
            // cam1ComPort
            // 
            this.cam1ComPort.PortName = "COM4";
            this.cam1ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.cam1ComPort_DataReceived);
            // 
            // cam2ComPort
            // 
            this.cam2ComPort.PortName = "COM5";
            this.cam2ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.cam2ComPort_DataReceived);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMainResults);
            this.tabMain.Controls.Add(this.tabMainCamera);
            this.tabMain.Controls.Add(this.tabMainConfig);
            this.tabMain.Controls.Add(this.tabMainLog);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(5, 285);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1175, 618);
            this.tabMain.TabIndex = 39;
            this.tabMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabMain_Selecting);
            // 
            // tabMainResults
            // 
            this.tabMainResults.Controls.Add(this.label25);
            this.tabMainResults.Controls.Add(this.pictureBox6);
            this.tabMainResults.Controls.Add(this.label19);
            this.tabMainResults.Controls.Add(this.pictureBox5);
            this.tabMainResults.Controls.Add(this.label18);
            this.tabMainResults.Controls.Add(this.pictureBox4);
            this.tabMainResults.Controls.Add(this.label17);
            this.tabMainResults.Controls.Add(this.pictureBox3);
            this.tabMainResults.Controls.Add(this.label16);
            this.tabMainResults.Controls.Add(this.graphFaultMap);
            this.tabMainResults.Controls.Add(this.lblStreams2);
            this.tabMainResults.Controls.Add(this.lblStreamsTotal2);
            this.tabMainResults.Controls.Add(this.lblBlipsTotal2);
            this.tabMainResults.Controls.Add(this.lblBlips2);
            this.tabMainResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMainResults.Location = new System.Drawing.Point(4, 25);
            this.tabMainResults.Name = "tabMainResults";
            this.tabMainResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainResults.Size = new System.Drawing.Size(1167, 589);
            this.tabMainResults.TabIndex = 0;
            this.tabMainResults.Text = "Results";
            this.tabMainResults.ToolTipText = "Main output of the program";
            this.tabMainResults.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default, "APP_EnableFeintProcessing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(680, 539);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 17);
            this.label25.TabIndex = 99;
            this.label25.Text = "Feint Streams";
            this.label25.Visible = global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default.APP_EnableFeintProcessing;
            // 
            // pictureBox6
            // 
            this.pictureBox6.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default, "APP_EnableFeintProcessing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureBox6.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.feint;
            this.pictureBox6.Location = new System.Drawing.Point(790, 531);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(27, 32);
            this.pictureBox6.TabIndex = 98;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default.APP_EnableFeintProcessing;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(536, 539);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 97;
            this.label19.Text = "Overload";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.overload;
            this.pictureBox5.Location = new System.Drawing.Point(612, 532);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 32);
            this.pictureBox5.TabIndex = 96;
            this.pictureBox5.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(368, 539);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 17);
            this.label18.TabIndex = 95;
            this.label18.Text = "Streams";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.stream;
            this.pictureBox4.Location = new System.Drawing.Point(438, 532);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 32);
            this.pictureBox4.TabIndex = 94;
            this.pictureBox4.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(216, 539);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 17);
            this.label17.TabIndex = 93;
            this.label17.Text = "Blips";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.blip;
            this.pictureBox3.Location = new System.Drawing.Point(264, 531);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 32);
            this.pictureBox3.TabIndex = 92;
            this.pictureBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 539);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 17);
            this.label16.TabIndex = 91;
            this.label16.Text = "Rolling Map Fault Key:";
            // 
            // graphFaultMap
            // 
            this.graphFaultMap.Location = new System.Drawing.Point(18, 11);
            this.graphFaultMap.Name = "graphFaultMap";
            this.graphFaultMap.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.graphFaultMapstreams,
            this.graphFaultMapblips,
            this.graphFaultMapoverload,
            this.graphFaultMapFeints});
            this.graphFaultMap.Size = new System.Drawing.Size(1136, 519);
            this.graphFaultMap.TabIndex = 71;
            this.graphFaultMap.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.graphFaultMapxAxis});
            this.graphFaultMap.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.graphFaultMapyAxis});
            // 
            // graphFaultMapstreams
            // 
            this.graphFaultMapstreams.LineStyle = NationalInstruments.UI.LineStyle.None;
            this.graphFaultMapstreams.PointSize = new System.Drawing.Size(23, 15);
            this.graphFaultMapstreams.PointStyle = NationalInstruments.UI.PointStyle.SolidSquare;
            this.graphFaultMapstreams.XAxis = this.graphFaultMapxAxis;
            this.graphFaultMapstreams.YAxis = this.graphFaultMapyAxis;
            // 
            // graphFaultMapxAxis
            // 
            this.graphFaultMapxAxis.Caption = "Time (minutes)";
            this.graphFaultMapxAxis.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.graphFaultMapxAxis.Range = new NationalInstruments.UI.Range(0D, 240D);
            // 
            // graphFaultMapyAxis
            // 
            this.graphFaultMapyAxis.AutoSpacing = false;
            this.graphFaultMapyAxis.Caption = "Zone";
            this.graphFaultMapyAxis.Inverted = true;
            this.graphFaultMapyAxis.MajorDivisions.Interval = 1D;
            this.graphFaultMapyAxis.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.graphFaultMapyAxis.Range = new NationalInstruments.UI.Range(0D, 16D);
            // 
            // graphFaultMapblips
            // 
            this.graphFaultMapblips.LineStyle = NationalInstruments.UI.LineStyle.None;
            this.graphFaultMapblips.PointColor = System.Drawing.Color.LawnGreen;
            this.graphFaultMapblips.PointSize = new System.Drawing.Size(13, 10);
            this.graphFaultMapblips.PointStyle = NationalInstruments.UI.PointStyle.SolidCircle;
            this.graphFaultMapblips.XAxis = this.graphFaultMapxAxis;
            this.graphFaultMapblips.YAxis = this.graphFaultMapyAxis;
            // 
            // graphFaultMapoverload
            // 
            this.graphFaultMapoverload.LineStyle = NationalInstruments.UI.LineStyle.None;
            this.graphFaultMapoverload.PointColor = System.Drawing.Color.OrangeRed;
            this.graphFaultMapoverload.PointSize = new System.Drawing.Size(23, 29);
            this.graphFaultMapoverload.PointStyle = NationalInstruments.UI.PointStyle.SolidSquare;
            this.graphFaultMapoverload.XAxis = this.graphFaultMapxAxis;
            this.graphFaultMapoverload.YAxis = this.graphFaultMapyAxis;
            // 
            // graphFaultMapFeints
            // 
            this.graphFaultMapFeints.LineStyle = NationalInstruments.UI.LineStyle.None;
            this.graphFaultMapFeints.PointColor = System.Drawing.Color.LightYellow;
            this.graphFaultMapFeints.PointSize = new System.Drawing.Size(23, 8);
            this.graphFaultMapFeints.PointStyle = NationalInstruments.UI.PointStyle.SolidSquare;
            this.graphFaultMapFeints.XAxis = this.graphFaultMapxAxis;
            this.graphFaultMapFeints.YAxis = this.graphFaultMapyAxis;
            // 
            // lblStreams2
            // 
            this.lblStreams2.AutoSize = true;
            this.lblStreams2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStreams2.Location = new System.Drawing.Point(267, 66);
            this.lblStreams2.Name = "lblStreams2";
            this.lblStreams2.Size = new System.Drawing.Size(0, 17);
            this.lblStreams2.TabIndex = 56;
            // 
            // lblStreamsTotal2
            // 
            this.lblStreamsTotal2.AutoSize = true;
            this.lblStreamsTotal2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStreamsTotal2.Location = new System.Drawing.Point(287, 66);
            this.lblStreamsTotal2.Name = "lblStreamsTotal2";
            this.lblStreamsTotal2.Size = new System.Drawing.Size(0, 17);
            this.lblStreamsTotal2.TabIndex = 54;
            // 
            // lblBlipsTotal2
            // 
            this.lblBlipsTotal2.AutoSize = true;
            this.lblBlipsTotal2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlipsTotal2.Location = new System.Drawing.Point(223, 66);
            this.lblBlipsTotal2.Name = "lblBlipsTotal2";
            this.lblBlipsTotal2.Size = new System.Drawing.Size(0, 17);
            this.lblBlipsTotal2.TabIndex = 52;
            // 
            // lblBlips2
            // 
            this.lblBlips2.AutoSize = true;
            this.lblBlips2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlips2.Location = new System.Drawing.Point(204, 66);
            this.lblBlips2.Name = "lblBlips2";
            this.lblBlips2.Size = new System.Drawing.Size(0, 17);
            this.lblBlips2.TabIndex = 46;
            // 
            // tabMainCamera
            // 
            this.tabMainCamera.Controls.Add(this.grpCam2Gain);
            this.tabMainCamera.Controls.Add(this.groupBox3);
            this.tabMainCamera.Controls.Add(this.groupBox1);
            this.tabMainCamera.Controls.Add(this.grpCam2ROI);
            this.tabMainCamera.Controls.Add(this.grpCam1ROI);
            this.tabMainCamera.Controls.Add(this.grpCam1Gain);
            this.tabMainCamera.Controls.Add(this.grpCamFreq);
            this.tabMainCamera.Controls.Add(this.label7);
            this.tabMainCamera.Controls.Add(this.slideOverload);
            this.tabMainCamera.Controls.Add(this.slideThreshold);
            this.tabMainCamera.Controls.Add(this.graph2);
            this.tabMainCamera.Controls.Add(this.graph1);
            this.tabMainCamera.Location = new System.Drawing.Point(4, 25);
            this.tabMainCamera.Name = "tabMainCamera";
            this.tabMainCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainCamera.Size = new System.Drawing.Size(1167, 589);
            this.tabMainCamera.TabIndex = 1;
            this.tabMainCamera.Text = "Camera Setup";
            this.tabMainCamera.ToolTipText = "Camera Setup Parameters";
            this.tabMainCamera.UseVisualStyleBackColor = true;
            // 
            // grpCam2Gain
            // 
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain6);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain5);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain4);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain3);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain2);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain1);
            this.grpCam2Gain.Controls.Add(this.rdoCam2Gain0);
            this.grpCam2Gain.Location = new System.Drawing.Point(427, 345);
            this.grpCam2Gain.Name = "grpCam2Gain";
            this.grpCam2Gain.Size = new System.Drawing.Size(134, 216);
            this.grpCam2Gain.TabIndex = 56;
            this.grpCam2Gain.TabStop = false;
            this.grpCam2Gain.Text = "Camera 2 Gain";
            // 
            // rdoCam2Gain6
            // 
            this.rdoCam2Gain6.AutoSize = true;
            this.rdoCam2Gain6.Location = new System.Drawing.Point(29, 184);
            this.rdoCam2Gain6.Name = "rdoCam2Gain6";
            this.rdoCam2Gain6.Size = new System.Drawing.Size(59, 21);
            this.rdoCam2Gain6.TabIndex = 6;
            this.rdoCam2Gain6.TabStop = true;
            this.rdoCam2Gain6.Text = "10dB";
            this.rdoCam2Gain6.UseVisualStyleBackColor = true;
            this.rdoCam2Gain6.CheckedChanged += new System.EventHandler(this.rdoCam2Gain6_CheckedChanged);
            // 
            // rdoCam2Gain5
            // 
            this.rdoCam2Gain5.AutoSize = true;
            this.rdoCam2Gain5.Location = new System.Drawing.Point(29, 157);
            this.rdoCam2Gain5.Name = "rdoCam2Gain5";
            this.rdoCam2Gain5.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain5.TabIndex = 5;
            this.rdoCam2Gain5.TabStop = true;
            this.rdoCam2Gain5.Text = "8dB";
            this.rdoCam2Gain5.UseVisualStyleBackColor = true;
            this.rdoCam2Gain5.CheckedChanged += new System.EventHandler(this.rdoCam2Gain5_CheckedChanged);
            // 
            // rdoCam2Gain4
            // 
            this.rdoCam2Gain4.AutoSize = true;
            this.rdoCam2Gain4.Location = new System.Drawing.Point(29, 130);
            this.rdoCam2Gain4.Name = "rdoCam2Gain4";
            this.rdoCam2Gain4.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain4.TabIndex = 4;
            this.rdoCam2Gain4.TabStop = true;
            this.rdoCam2Gain4.Text = "6dB";
            this.rdoCam2Gain4.UseVisualStyleBackColor = true;
            this.rdoCam2Gain4.CheckedChanged += new System.EventHandler(this.rdoCam2Gain4_CheckedChanged);
            // 
            // rdoCam2Gain3
            // 
            this.rdoCam2Gain3.AutoSize = true;
            this.rdoCam2Gain3.Location = new System.Drawing.Point(29, 103);
            this.rdoCam2Gain3.Name = "rdoCam2Gain3";
            this.rdoCam2Gain3.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain3.TabIndex = 3;
            this.rdoCam2Gain3.TabStop = true;
            this.rdoCam2Gain3.Text = "4dB";
            this.rdoCam2Gain3.UseVisualStyleBackColor = true;
            this.rdoCam2Gain3.CheckedChanged += new System.EventHandler(this.rdoCam2Gain3_CheckedChanged);
            // 
            // rdoCam2Gain2
            // 
            this.rdoCam2Gain2.AutoSize = true;
            this.rdoCam2Gain2.Location = new System.Drawing.Point(29, 76);
            this.rdoCam2Gain2.Name = "rdoCam2Gain2";
            this.rdoCam2Gain2.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain2.TabIndex = 2;
            this.rdoCam2Gain2.TabStop = true;
            this.rdoCam2Gain2.Text = "2dB";
            this.rdoCam2Gain2.UseVisualStyleBackColor = true;
            this.rdoCam2Gain2.CheckedChanged += new System.EventHandler(this.rdoCam2Gain2_CheckedChanged);
            // 
            // rdoCam2Gain1
            // 
            this.rdoCam2Gain1.AutoSize = true;
            this.rdoCam2Gain1.Location = new System.Drawing.Point(29, 49);
            this.rdoCam2Gain1.Name = "rdoCam2Gain1";
            this.rdoCam2Gain1.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain1.TabIndex = 1;
            this.rdoCam2Gain1.TabStop = true;
            this.rdoCam2Gain1.Text = "1dB";
            this.rdoCam2Gain1.UseVisualStyleBackColor = true;
            this.rdoCam2Gain1.CheckedChanged += new System.EventHandler(this.rdoCam2Gain1_CheckedChanged);
            // 
            // rdoCam2Gain0
            // 
            this.rdoCam2Gain0.AutoSize = true;
            this.rdoCam2Gain0.Location = new System.Drawing.Point(29, 22);
            this.rdoCam2Gain0.Name = "rdoCam2Gain0";
            this.rdoCam2Gain0.Size = new System.Drawing.Size(51, 21);
            this.rdoCam2Gain0.TabIndex = 0;
            this.rdoCam2Gain0.TabStop = true;
            this.rdoCam2Gain0.Text = "0dB";
            this.rdoCam2Gain0.UseVisualStyleBackColor = true;
            this.rdoCam2Gain0.CheckedChanged += new System.EventHandler(this.rdoCam2Gain0_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblStreamsCurrent2);
            this.groupBox3.Controls.Add(this.lblBlipsCurrent2);
            this.groupBox3.Controls.Add(this.lblBlipsCurrent1);
            this.groupBox3.Controls.Add(this.lblStreamsCurrent1);
            this.groupBox3.Location = new System.Drawing.Point(610, 435);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 126);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Faults";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 17);
            this.label15.TabIndex = 63;
            this.label15.Text = "Streams Camera1:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 17);
            this.label14.TabIndex = 62;
            this.label14.Text = "Streams Camera1:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 17);
            this.label13.TabIndex = 61;
            this.label13.Text = "Blips Camera2:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = "Blips Camera1:";
            // 
            // lblStreamsCurrent2
            // 
            this.lblStreamsCurrent2.AutoSize = true;
            this.lblStreamsCurrent2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblStreamsCurrent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamsCurrent2.Location = new System.Drawing.Point(137, 100);
            this.lblStreamsCurrent2.Name = "lblStreamsCurrent2";
            this.lblStreamsCurrent2.Size = new System.Drawing.Size(16, 17);
            this.lblStreamsCurrent2.TabIndex = 59;
            this.lblStreamsCurrent2.Text = "0";
            // 
            // lblBlipsCurrent2
            // 
            this.lblBlipsCurrent2.AutoSize = true;
            this.lblBlipsCurrent2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBlipsCurrent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlipsCurrent2.Location = new System.Drawing.Point(137, 50);
            this.lblBlipsCurrent2.Name = "lblBlipsCurrent2";
            this.lblBlipsCurrent2.Size = new System.Drawing.Size(16, 17);
            this.lblBlipsCurrent2.TabIndex = 58;
            this.lblBlipsCurrent2.Text = "0";
            // 
            // lblBlipsCurrent1
            // 
            this.lblBlipsCurrent1.AutoSize = true;
            this.lblBlipsCurrent1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBlipsCurrent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlipsCurrent1.Location = new System.Drawing.Point(137, 25);
            this.lblBlipsCurrent1.Name = "lblBlipsCurrent1";
            this.lblBlipsCurrent1.Size = new System.Drawing.Size(16, 17);
            this.lblBlipsCurrent1.TabIndex = 56;
            this.lblBlipsCurrent1.Text = "0";
            // 
            // lblStreamsCurrent1
            // 
            this.lblStreamsCurrent1.AutoSize = true;
            this.lblStreamsCurrent1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblStreamsCurrent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamsCurrent1.Location = new System.Drawing.Point(137, 75);
            this.lblStreamsCurrent1.Name = "lblStreamsCurrent1";
            this.lblStreamsCurrent1.Size = new System.Drawing.Size(16, 17);
            this.lblStreamsCurrent1.TabIndex = 57;
            this.lblStreamsCurrent1.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblFrameCount1);
            this.groupBox1.Controls.Add(this.lblFrameCount2);
            this.groupBox1.Location = new System.Drawing.Point(610, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 84);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frames Captured";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Camera1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "Camera2:";
            // 
            // lblFrameCount1
            // 
            this.lblFrameCount1.AutoSize = true;
            this.lblFrameCount1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFrameCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameCount1.Location = new System.Drawing.Point(77, 24);
            this.lblFrameCount1.Name = "lblFrameCount1";
            this.lblFrameCount1.Size = new System.Drawing.Size(16, 17);
            this.lblFrameCount1.TabIndex = 50;
            this.lblFrameCount1.Text = "0";
            // 
            // lblFrameCount2
            // 
            this.lblFrameCount2.AutoSize = true;
            this.lblFrameCount2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFrameCount2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameCount2.Location = new System.Drawing.Point(77, 53);
            this.lblFrameCount2.Name = "lblFrameCount2";
            this.lblFrameCount2.Size = new System.Drawing.Size(16, 17);
            this.lblFrameCount2.TabIndex = 51;
            this.lblFrameCount2.Text = "0";
            // 
            // grpCam2ROI
            // 
            this.grpCam2ROI.Controls.Add(this.label10);
            this.grpCam2ROI.Controls.Add(this.spinCam2Left);
            this.grpCam2ROI.Controls.Add(this.label11);
            this.grpCam2ROI.Controls.Add(this.spinCam2Right);
            this.grpCam2ROI.Location = new System.Drawing.Point(610, 249);
            this.grpCam2ROI.Name = "grpCam2ROI";
            this.grpCam2ROI.Size = new System.Drawing.Size(557, 78);
            this.grpCam2ROI.TabIndex = 30;
            this.grpCam2ROI.TabStop = false;
            this.grpCam2ROI.Text = "Camera 2 ROI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(460, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Right Pixel (red)";
            // 
            // spinCam2Left
            // 
            this.spinCam2Left.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.spinCam2Left.Location = new System.Drawing.Point(20, 40);
            this.spinCam2Left.Name = "spinCam2Left";
            this.spinCam2Left.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.spinCam2Left.Range = new NationalInstruments.UI.Range(0D, 2047D);
            this.spinCam2Left.Size = new System.Drawing.Size(60, 23);
            this.spinCam2Left.TabIndex = 28;
            this.spinCam2Left.BeforeChangeValue += new NationalInstruments.UI.BeforeChangeNumericValueEventHandler(this.spinCam2Left_BeforeChangeValue);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Left Pixel (yellow)";
            // 
            // spinCam2Right
            // 
            this.spinCam2Right.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.spinCam2Right.Location = new System.Drawing.Point(474, 40);
            this.spinCam2Right.Name = "spinCam2Right";
            this.spinCam2Right.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.spinCam2Right.Range = new NationalInstruments.UI.Range(0D, 2047D);
            this.spinCam2Right.Size = new System.Drawing.Size(60, 23);
            this.spinCam2Right.TabIndex = 27;
            this.spinCam2Right.BeforeChangeValue += new NationalInstruments.UI.BeforeChangeNumericValueEventHandler(this.spinCam2Right_BeforeChangeValue);
            // 
            // grpCam1ROI
            // 
            this.grpCam1ROI.Controls.Add(this.spinCam1Left);
            this.grpCam1ROI.Controls.Add(this.spinCam1Right);
            this.grpCam1ROI.Controls.Add(this.label9);
            this.grpCam1ROI.Controls.Add(this.label8);
            this.grpCam1ROI.Location = new System.Drawing.Point(1, 249);
            this.grpCam1ROI.Name = "grpCam1ROI";
            this.grpCam1ROI.Size = new System.Drawing.Size(560, 78);
            this.grpCam1ROI.TabIndex = 29;
            this.grpCam1ROI.TabStop = false;
            this.grpCam1ROI.Text = "Camera 1 ROI";
            // 
            // spinCam1Left
            // 
            this.spinCam1Left.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.spinCam1Left.Location = new System.Drawing.Point(16, 40);
            this.spinCam1Left.Name = "spinCam1Left";
            this.spinCam1Left.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.spinCam1Left.Range = new NationalInstruments.UI.Range(0D, 2047D);
            this.spinCam1Left.Size = new System.Drawing.Size(60, 23);
            this.spinCam1Left.TabIndex = 28;
            this.spinCam1Left.BeforeChangeValue += new NationalInstruments.UI.BeforeChangeNumericValueEventHandler(this.spinCam1Left_BeforeChangeValue);
            // 
            // spinCam1Right
            // 
            this.spinCam1Right.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.spinCam1Right.Location = new System.Drawing.Point(477, 40);
            this.spinCam1Right.Name = "spinCam1Right";
            this.spinCam1Right.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.spinCam1Right.Range = new NationalInstruments.UI.Range(0D, 2047D);
            this.spinCam1Right.Size = new System.Drawing.Size(60, 23);
            this.spinCam1Right.TabIndex = 27;
            this.spinCam1Right.BeforeChangeValue += new NationalInstruments.UI.BeforeChangeNumericValueEventHandler(this.spinCam1Right_BeforeChangeValue);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(464, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Right Pixel (red)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Left Pixel (yellow)";
            // 
            // grpCam1Gain
            // 
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain6);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain5);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain4);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain3);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain2);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain1);
            this.grpCam1Gain.Controls.Add(this.rdoCam1Gain0);
            this.grpCam1Gain.Location = new System.Drawing.Point(286, 345);
            this.grpCam1Gain.Name = "grpCam1Gain";
            this.grpCam1Gain.Size = new System.Drawing.Size(135, 216);
            this.grpCam1Gain.TabIndex = 26;
            this.grpCam1Gain.TabStop = false;
            this.grpCam1Gain.Text = "Camera 1 Gain";
            // 
            // rdoCam1Gain6
            // 
            this.rdoCam1Gain6.AutoSize = true;
            this.rdoCam1Gain6.Location = new System.Drawing.Point(29, 184);
            this.rdoCam1Gain6.Name = "rdoCam1Gain6";
            this.rdoCam1Gain6.Size = new System.Drawing.Size(59, 21);
            this.rdoCam1Gain6.TabIndex = 6;
            this.rdoCam1Gain6.TabStop = true;
            this.rdoCam1Gain6.Text = "10dB";
            this.rdoCam1Gain6.UseVisualStyleBackColor = true;
            this.rdoCam1Gain6.CheckedChanged += new System.EventHandler(this.rdoCam1Gain6_CheckedChanged);
            // 
            // rdoCam1Gain5
            // 
            this.rdoCam1Gain5.AutoSize = true;
            this.rdoCam1Gain5.Location = new System.Drawing.Point(29, 157);
            this.rdoCam1Gain5.Name = "rdoCam1Gain5";
            this.rdoCam1Gain5.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain5.TabIndex = 5;
            this.rdoCam1Gain5.TabStop = true;
            this.rdoCam1Gain5.Text = "8dB";
            this.rdoCam1Gain5.UseVisualStyleBackColor = true;
            this.rdoCam1Gain5.CheckedChanged += new System.EventHandler(this.rdoCam1Gain5_CheckedChanged);
            // 
            // rdoCam1Gain4
            // 
            this.rdoCam1Gain4.AutoSize = true;
            this.rdoCam1Gain4.Location = new System.Drawing.Point(29, 130);
            this.rdoCam1Gain4.Name = "rdoCam1Gain4";
            this.rdoCam1Gain4.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain4.TabIndex = 4;
            this.rdoCam1Gain4.TabStop = true;
            this.rdoCam1Gain4.Text = "6dB";
            this.rdoCam1Gain4.UseVisualStyleBackColor = true;
            this.rdoCam1Gain4.CheckedChanged += new System.EventHandler(this.rdoCam1Gain4_CheckedChanged);
            // 
            // rdoCam1Gain3
            // 
            this.rdoCam1Gain3.AutoSize = true;
            this.rdoCam1Gain3.Location = new System.Drawing.Point(29, 103);
            this.rdoCam1Gain3.Name = "rdoCam1Gain3";
            this.rdoCam1Gain3.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain3.TabIndex = 3;
            this.rdoCam1Gain3.TabStop = true;
            this.rdoCam1Gain3.Text = "4dB";
            this.rdoCam1Gain3.UseVisualStyleBackColor = true;
            this.rdoCam1Gain3.CheckedChanged += new System.EventHandler(this.rdoCam1Gain3_CheckedChanged);
            // 
            // rdoCam1Gain2
            // 
            this.rdoCam1Gain2.AutoSize = true;
            this.rdoCam1Gain2.Location = new System.Drawing.Point(29, 76);
            this.rdoCam1Gain2.Name = "rdoCam1Gain2";
            this.rdoCam1Gain2.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain2.TabIndex = 2;
            this.rdoCam1Gain2.TabStop = true;
            this.rdoCam1Gain2.Text = "2dB";
            this.rdoCam1Gain2.UseVisualStyleBackColor = true;
            this.rdoCam1Gain2.CheckedChanged += new System.EventHandler(this.rdoCam1Gain2_CheckedChanged);
            // 
            // rdoCam1Gain1
            // 
            this.rdoCam1Gain1.AutoSize = true;
            this.rdoCam1Gain1.Location = new System.Drawing.Point(29, 49);
            this.rdoCam1Gain1.Name = "rdoCam1Gain1";
            this.rdoCam1Gain1.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain1.TabIndex = 1;
            this.rdoCam1Gain1.TabStop = true;
            this.rdoCam1Gain1.Text = "1dB";
            this.rdoCam1Gain1.UseVisualStyleBackColor = true;
            this.rdoCam1Gain1.CheckedChanged += new System.EventHandler(this.rdoCam1Gain1_CheckedChanged);
            // 
            // rdoCam1Gain0
            // 
            this.rdoCam1Gain0.AutoSize = true;
            this.rdoCam1Gain0.Location = new System.Drawing.Point(29, 22);
            this.rdoCam1Gain0.Name = "rdoCam1Gain0";
            this.rdoCam1Gain0.Size = new System.Drawing.Size(51, 21);
            this.rdoCam1Gain0.TabIndex = 0;
            this.rdoCam1Gain0.TabStop = true;
            this.rdoCam1Gain0.Text = "0dB";
            this.rdoCam1Gain0.UseVisualStyleBackColor = true;
            this.rdoCam1Gain0.CheckedChanged += new System.EventHandler(this.rdoCam1Gain0_CheckedChanged);
            // 
            // grpCamFreq
            // 
            this.grpCamFreq.Controls.Add(this.rdoCamFreq350Hz);
            this.grpCamFreq.Controls.Add(this.rdoCamFreq500Hz);
            this.grpCamFreq.Controls.Add(this.rdoCamFreq750Hz);
            this.grpCamFreq.Controls.Add(this.rdoCamFreq1kHz);
            this.grpCamFreq.Controls.Add(this.rdoCamFreq1_5kHz);
            this.grpCamFreq.Controls.Add(this.rdoCamFreq2kHz);
            this.grpCamFreq.Location = new System.Drawing.Point(163, 345);
            this.grpCamFreq.Name = "grpCamFreq";
            this.grpCamFreq.Size = new System.Drawing.Size(117, 216);
            this.grpCamFreq.TabIndex = 25;
            this.grpCamFreq.TabStop = false;
            this.grpCamFreq.Text = "Camera Freq";
            // 
            // rdoCamFreq350Hz
            // 
            this.rdoCamFreq350Hz.AutoSize = true;
            this.rdoCamFreq350Hz.Location = new System.Drawing.Point(27, 183);
            this.rdoCamFreq350Hz.Name = "rdoCamFreq350Hz";
            this.rdoCamFreq350Hz.Size = new System.Drawing.Size(67, 21);
            this.rdoCamFreq350Hz.TabIndex = 5;
            this.rdoCamFreq350Hz.TabStop = true;
            this.rdoCamFreq350Hz.Text = "350Hz";
            this.rdoCamFreq350Hz.UseVisualStyleBackColor = true;
            this.rdoCamFreq350Hz.CheckedChanged += new System.EventHandler(this.rdoCamFreq350Hz_CheckedChanged);
            // 
            // rdoCamFreq500Hz
            // 
            this.rdoCamFreq500Hz.AutoSize = true;
            this.rdoCamFreq500Hz.Location = new System.Drawing.Point(27, 151);
            this.rdoCamFreq500Hz.Name = "rdoCamFreq500Hz";
            this.rdoCamFreq500Hz.Size = new System.Drawing.Size(67, 21);
            this.rdoCamFreq500Hz.TabIndex = 4;
            this.rdoCamFreq500Hz.TabStop = true;
            this.rdoCamFreq500Hz.Text = "500Hz";
            this.rdoCamFreq500Hz.UseVisualStyleBackColor = true;
            this.rdoCamFreq500Hz.CheckedChanged += new System.EventHandler(this.rdoCamFreq500Hz_CheckedChanged);
            // 
            // rdoCamFreq750Hz
            // 
            this.rdoCamFreq750Hz.AutoSize = true;
            this.rdoCamFreq750Hz.Location = new System.Drawing.Point(27, 119);
            this.rdoCamFreq750Hz.Name = "rdoCamFreq750Hz";
            this.rdoCamFreq750Hz.Size = new System.Drawing.Size(67, 21);
            this.rdoCamFreq750Hz.TabIndex = 3;
            this.rdoCamFreq750Hz.TabStop = true;
            this.rdoCamFreq750Hz.Text = "750Hz";
            this.rdoCamFreq750Hz.UseVisualStyleBackColor = true;
            this.rdoCamFreq750Hz.CheckedChanged += new System.EventHandler(this.rdoCamFreq750Hz_CheckedChanged);
            // 
            // rdoCamFreq1kHz
            // 
            this.rdoCamFreq1kHz.AutoSize = true;
            this.rdoCamFreq1kHz.Location = new System.Drawing.Point(27, 87);
            this.rdoCamFreq1kHz.Name = "rdoCamFreq1kHz";
            this.rdoCamFreq1kHz.Size = new System.Drawing.Size(58, 21);
            this.rdoCamFreq1kHz.TabIndex = 2;
            this.rdoCamFreq1kHz.TabStop = true;
            this.rdoCamFreq1kHz.Text = "1kHz";
            this.rdoCamFreq1kHz.UseVisualStyleBackColor = true;
            this.rdoCamFreq1kHz.CheckedChanged += new System.EventHandler(this.rdoCamFreq1kHz_CheckedChanged);
            // 
            // rdoCamFreq1_5kHz
            // 
            this.rdoCamFreq1_5kHz.AutoSize = true;
            this.rdoCamFreq1_5kHz.Location = new System.Drawing.Point(27, 55);
            this.rdoCamFreq1_5kHz.Name = "rdoCamFreq1_5kHz";
            this.rdoCamFreq1_5kHz.Size = new System.Drawing.Size(70, 21);
            this.rdoCamFreq1_5kHz.TabIndex = 1;
            this.rdoCamFreq1_5kHz.TabStop = true;
            this.rdoCamFreq1_5kHz.Text = "1.5kHz";
            this.rdoCamFreq1_5kHz.UseVisualStyleBackColor = true;
            this.rdoCamFreq1_5kHz.CheckedChanged += new System.EventHandler(this.rdoCamFreq1_5kHz_CheckedChanged);
            // 
            // rdoCamFreq2kHz
            // 
            this.rdoCamFreq2kHz.AutoSize = true;
            this.rdoCamFreq2kHz.Location = new System.Drawing.Point(27, 23);
            this.rdoCamFreq2kHz.Name = "rdoCamFreq2kHz";
            this.rdoCamFreq2kHz.Size = new System.Drawing.Size(58, 21);
            this.rdoCamFreq2kHz.TabIndex = 0;
            this.rdoCamFreq2kHz.TabStop = true;
            this.rdoCamFreq2kHz.Text = "2kHz";
            this.rdoCamFreq2kHz.UseVisualStyleBackColor = true;
            this.rdoCamFreq2kHz.CheckedChanged += new System.EventHandler(this.rdoCamFreq2kHz_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Overload Factor";
            // 
            // slideOverload
            // 
            this.slideOverload.Location = new System.Drawing.Point(32, 365);
            this.slideOverload.Name = "slideOverload";
            this.slideOverload.Range = new NationalInstruments.UI.Range(0.01D, 0.5D);
            this.slideOverload.ScaleBaseLineVisible = true;
            this.slideOverload.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            this.slideOverload.Size = new System.Drawing.Size(61, 205);
            this.slideOverload.SlideStyle = NationalInstruments.UI.SlideStyle.SunkenWithGrip;
            this.slideOverload.TabIndex = 23;
            this.slideOverload.Value = 0.01D;
            this.slideOverload.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slideOverload_MouseUp);
            // 
            // slideThreshold
            // 
            this.slideThreshold.Location = new System.Drawing.Point(556, 1);
            this.slideThreshold.Name = "slideThreshold";
            this.slideThreshold.Range = new NationalInstruments.UI.Range(0D, 255D);
            this.slideThreshold.Size = new System.Drawing.Size(54, 235);
            this.slideThreshold.TabIndex = 22;
            this.slideThreshold.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slideThreshold_MouseUp);
            // 
            // graph2
            // 
            this.graph2.Border = NationalInstruments.UI.Border.None;
            this.graph2.CaptionVisible = false;
            this.graph2.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.graph2GreyScaleCursor,
            this.graph2PixelCursorRight,
            this.graph2PixelCursorLeft});
            this.graph2.Location = new System.Drawing.Point(610, 14);
            this.graph2.Name = "graph2";
            this.graph2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2,
            this.waveformPlot4,
            this.waveformPlot6});
            this.graph2.Size = new System.Drawing.Size(568, 229);
            this.graph2.TabIndex = 21;
            this.graph2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.graph2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // graph2GreyScaleCursor
            // 
            this.graph2GreyScaleCursor.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowY;
            this.graph2GreyScaleCursor.LabelVisible = true;
            this.graph2GreyScaleCursor.LabelXFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "G5");
            this.graph2GreyScaleCursor.LabelYFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph2GreyScaleCursor.Plot = this.waveformPlot2;
            this.graph2GreyScaleCursor.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph2GreyScaleCursor.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            this.graph2GreyScaleCursor.VerticalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.XAxis = this.xAxis2;
            this.waveformPlot2.YAxis = this.yAxis2;
            // 
            // xAxis2
            // 
            this.xAxis2.MajorDivisions.Interval = 256D;
            this.xAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.xAxis2.Range = new NationalInstruments.UI.Range(0D, 2047D);
            // 
            // yAxis2
            // 
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis2.Range = new NationalInstruments.UI.Range(0D, 255D);
            this.yAxis2.Visible = false;
            // 
            // graph2PixelCursorRight
            // 
            this.graph2PixelCursorRight.Color = System.Drawing.Color.Crimson;
            this.graph2PixelCursorRight.HorizontalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            this.graph2PixelCursorRight.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowX;
            this.graph2PixelCursorRight.LabelVisible = true;
            this.graph2PixelCursorRight.LabelXFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph2PixelCursorRight.Plot = this.waveformPlot2;
            this.graph2PixelCursorRight.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph2PixelCursorRight.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            // 
            // graph2PixelCursorLeft
            // 
            this.graph2PixelCursorLeft.Color = System.Drawing.Color.Yellow;
            this.graph2PixelCursorLeft.HorizontalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            this.graph2PixelCursorLeft.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowX;
            this.graph2PixelCursorLeft.LabelVisible = true;
            this.graph2PixelCursorLeft.LabelXFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph2PixelCursorLeft.Plot = this.waveformPlot2;
            this.graph2PixelCursorLeft.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph2PixelCursorLeft.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            // 
            // waveformPlot4
            // 
            this.waveformPlot4.LineColor = System.Drawing.Color.Gold;
            this.waveformPlot4.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot4.XAxis = this.xAxis2;
            this.waveformPlot4.YAxis = this.yAxis2;
            // 
            // waveformPlot6
            // 
            this.waveformPlot6.LineColor = System.Drawing.Color.Red;
            this.waveformPlot6.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot6.XAxis = this.xAxis2;
            this.waveformPlot6.YAxis = this.yAxis2;
            // 
            // graph1
            // 
            this.graph1.Border = NationalInstruments.UI.Border.None;
            this.graph1.CaptionVisible = false;
            this.graph1.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.graph1GreyScaleCursor,
            this.graph1PixelCursorRight,
            this.graph1PixelCursorLeft});
            this.graph1.Location = new System.Drawing.Point(-13, 14);
            this.graph1.Name = "graph1";
            this.graph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1,
            this.waveformPlot3,
            this.waveformPlot5});
            this.graph1.Size = new System.Drawing.Size(574, 229);
            this.graph1.TabIndex = 20;
            this.graph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.graph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // graph1GreyScaleCursor
            // 
            this.graph1GreyScaleCursor.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowY;
            this.graph1GreyScaleCursor.LabelVisible = true;
            this.graph1GreyScaleCursor.LabelYFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph1GreyScaleCursor.Plot = this.waveformPlot1;
            this.graph1GreyScaleCursor.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph1GreyScaleCursor.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            this.graph1GreyScaleCursor.VerticalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.MajorDivisions.Interval = 256D;
            this.xAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.xAxis1.Range = new NationalInstruments.UI.Range(0D, 2047D);
            // 
            // yAxis1
            // 
            this.yAxis1.CaptionVisible = false;
            this.yAxis1.MajorDivisions.Interval = 64D;
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 255D);
            this.yAxis1.Visible = false;
            // 
            // graph1PixelCursorRight
            // 
            this.graph1PixelCursorRight.Color = System.Drawing.Color.Crimson;
            this.graph1PixelCursorRight.HorizontalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            this.graph1PixelCursorRight.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowX;
            this.graph1PixelCursorRight.LabelVisible = true;
            this.graph1PixelCursorRight.LabelXFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph1PixelCursorRight.Plot = this.waveformPlot1;
            this.graph1PixelCursorRight.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph1PixelCursorRight.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            // 
            // graph1PixelCursorLeft
            // 
            this.graph1PixelCursorLeft.Color = System.Drawing.Color.Yellow;
            this.graph1PixelCursorLeft.HorizontalCrosshairMode = NationalInstruments.UI.CursorCrosshairMode.None;
            this.graph1PixelCursorLeft.LabelDisplay = NationalInstruments.UI.XYCursorLabelDisplay.ShowX;
            this.graph1PixelCursorLeft.LabelVisible = true;
            this.graph1PixelCursorLeft.LabelXFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.graph1PixelCursorLeft.Plot = this.waveformPlot1;
            this.graph1PixelCursorLeft.PointStyle = NationalInstruments.UI.PointStyle.None;
            this.graph1PixelCursorLeft.SnapMode = NationalInstruments.UI.CursorSnapMode.Fixed;
            // 
            // waveformPlot3
            // 
            this.waveformPlot3.LineColor = System.Drawing.Color.Gold;
            this.waveformPlot3.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot3.XAxis = this.xAxis1;
            this.waveformPlot3.YAxis = this.yAxis1;
            // 
            // waveformPlot5
            // 
            this.waveformPlot5.LineColor = System.Drawing.Color.Red;
            this.waveformPlot5.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot5.XAxis = this.xAxis1;
            this.waveformPlot5.YAxis = this.yAxis1;
            // 
            // tabMainConfig
            // 
            this.tabMainConfig.Controls.Add(this.groupBox4);
            this.tabMainConfig.Controls.Add(this.propertyGridMySettings);
            this.tabMainConfig.Location = new System.Drawing.Point(4, 25);
            this.tabMainConfig.Name = "tabMainConfig";
            this.tabMainConfig.Size = new System.Drawing.Size(1167, 589);
            this.tabMainConfig.TabIndex = 2;
            this.tabMainConfig.Text = "Configuration";
            this.tabMainConfig.ToolTipText = "All the application configuration parameters";
            this.tabMainConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoImageSaveNext2);
            this.groupBox4.Controls.Add(this.rdoImageSaveNext1);
            this.groupBox4.Controls.Add(this.rdoImageSaveFrames);
            this.groupBox4.Controls.Add(this.rdoImageSaveTiles);
            this.groupBox4.Controls.Add(this.rdoImageSaveNone);
            this.groupBox4.Location = new System.Drawing.Point(498, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 159);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image Saving";
            // 
            // rdoImageSaveNext2
            // 
            this.rdoImageSaveNext2.AutoSize = true;
            this.rdoImageSaveNext2.Location = new System.Drawing.Point(6, 132);
            this.rdoImageSaveNext2.Name = "rdoImageSaveNext2";
            this.rdoImageSaveNext2.Size = new System.Drawing.Size(151, 21);
            this.rdoImageSaveNext2.TabIndex = 4;
            this.rdoImageSaveNext2.TabStop = true;
            this.rdoImageSaveNext2.Text = "Next from Camera 2";
            this.rdoImageSaveNext2.UseVisualStyleBackColor = true;
            this.rdoImageSaveNext2.CheckedChanged += new System.EventHandler(this.rdoImageSaveNext2_CheckedChanged);
            // 
            // rdoImageSaveNext1
            // 
            this.rdoImageSaveNext1.AutoSize = true;
            this.rdoImageSaveNext1.Location = new System.Drawing.Point(6, 107);
            this.rdoImageSaveNext1.Name = "rdoImageSaveNext1";
            this.rdoImageSaveNext1.Size = new System.Drawing.Size(151, 21);
            this.rdoImageSaveNext1.TabIndex = 3;
            this.rdoImageSaveNext1.TabStop = true;
            this.rdoImageSaveNext1.Text = "Next from Camera 1";
            this.rdoImageSaveNext1.UseVisualStyleBackColor = true;
            this.rdoImageSaveNext1.CheckedChanged += new System.EventHandler(this.rdoImageSaveNext1_CheckedChanged);
            // 
            // rdoImageSaveFrames
            // 
            this.rdoImageSaveFrames.AutoSize = true;
            this.rdoImageSaveFrames.Location = new System.Drawing.Point(6, 80);
            this.rdoImageSaveFrames.Name = "rdoImageSaveFrames";
            this.rdoImageSaveFrames.Size = new System.Drawing.Size(73, 21);
            this.rdoImageSaveFrames.TabIndex = 2;
            this.rdoImageSaveFrames.TabStop = true;
            this.rdoImageSaveFrames.Text = "Frames";
            this.rdoImageSaveFrames.UseVisualStyleBackColor = true;
            this.rdoImageSaveFrames.CheckedChanged += new System.EventHandler(this.rdoImageSaveFrames_CheckedChanged);
            // 
            // rdoImageSaveTiles
            // 
            this.rdoImageSaveTiles.AutoSize = true;
            this.rdoImageSaveTiles.Enabled = false;
            this.rdoImageSaveTiles.Location = new System.Drawing.Point(6, 53);
            this.rdoImageSaveTiles.Name = "rdoImageSaveTiles";
            this.rdoImageSaveTiles.Size = new System.Drawing.Size(56, 21);
            this.rdoImageSaveTiles.TabIndex = 1;
            this.rdoImageSaveTiles.TabStop = true;
            this.rdoImageSaveTiles.Text = "Tiles";
            this.rdoImageSaveTiles.UseVisualStyleBackColor = true;
            this.rdoImageSaveTiles.CheckedChanged += new System.EventHandler(this.rdoImageSaveTiles_CheckedChanged);
            // 
            // rdoImageSaveNone
            // 
            this.rdoImageSaveNone.AutoSize = true;
            this.rdoImageSaveNone.Location = new System.Drawing.Point(6, 26);
            this.rdoImageSaveNone.Name = "rdoImageSaveNone";
            this.rdoImageSaveNone.Size = new System.Drawing.Size(60, 21);
            this.rdoImageSaveNone.TabIndex = 0;
            this.rdoImageSaveNone.TabStop = true;
            this.rdoImageSaveNone.Text = "None";
            this.rdoImageSaveNone.UseVisualStyleBackColor = true;
            this.rdoImageSaveNone.CheckedChanged += new System.EventHandler(this.rdoImageSaveNone_CheckedChanged);
            // 
            // propertyGridMySettings
            // 
            this.propertyGridMySettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.propertyGridMySettings.Location = new System.Drawing.Point(26, 14);
            this.propertyGridMySettings.Name = "propertyGridMySettings";
            this.propertyGridMySettings.Size = new System.Drawing.Size(466, 547);
            this.propertyGridMySettings.TabIndex = 0;
            // 
            // tabMainLog
            // 
            this.tabMainLog.Controls.Add(this.cmdErrLogClear);
            this.tabMainLog.Controls.Add(this.lstErrorLog);
            this.tabMainLog.Location = new System.Drawing.Point(4, 25);
            this.tabMainLog.Name = "tabMainLog";
            this.tabMainLog.Size = new System.Drawing.Size(1167, 589);
            this.tabMainLog.TabIndex = 3;
            this.tabMainLog.Text = "Message Log";
            this.tabMainLog.ToolTipText = "Program Messages also stored in the event log";
            this.tabMainLog.UseVisualStyleBackColor = true;
            // 
            // cmdErrLogClear
            // 
            this.cmdErrLogClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdErrLogClear.Location = new System.Drawing.Point(1050, 530);
            this.cmdErrLogClear.Name = "cmdErrLogClear";
            this.cmdErrLogClear.Size = new System.Drawing.Size(84, 42);
            this.cmdErrLogClear.TabIndex = 1;
            this.cmdErrLogClear.Text = "Clear";
            this.cmdErrLogClear.UseVisualStyleBackColor = true;
            this.cmdErrLogClear.Click += new System.EventHandler(this.cmdErrLogClear_Click);
            // 
            // lstErrorLog
            // 
            this.lstErrorLog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstErrorLog.FormattingEnabled = true;
            this.lstErrorLog.Location = new System.Drawing.Point(11, 16);
            this.lstErrorLog.Name = "lstErrorLog";
            this.lstErrorLog.Size = new System.Drawing.Size(1123, 508);
            this.lstErrorLog.TabIndex = 0;
            // 
            // cmdScan
            // 
            this.cmdScan.BackColor = System.Drawing.Color.Red;
            this.cmdScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScan.Location = new System.Drawing.Point(1105, 159);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(75, 32);
            this.cmdScan.TabIndex = 40;
            this.cmdScan.Text = "Stop";
            this.cmdScan.UseVisualStyleBackColor = false;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(5, 914);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(1174, 20);
            this.txtInfo.TabIndex = 41;
            // 
            // CVimage2
            // 
            this.CVimage2.Enabled = true;
            this.CVimage2.Location = new System.Drawing.Point(5, 145);
            this.CVimage2.Name = "CVimage2";
            this.CVimage2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVimage2.OcxState")));
            this.CVimage2.Size = new System.Drawing.Size(32, 32);
            this.CVimage2.TabIndex = 12;
            this.CVimage2.ImageSnaped += new System.EventHandler(this.CVimage2_ImageSnaped);
            // 
            // CVdisplay2
            // 
            this.CVdisplay2.Location = new System.Drawing.Point(633, 5);
            this.CVdisplay2.Name = "CVdisplay2";
            this.CVdisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplay2.OcxState")));
            this.CVdisplay2.Size = new System.Drawing.Size(547, 150);
            this.CVdisplay2.TabIndex = 11;
            // 
            // CVgrabber2
            // 
            this.CVgrabber2.Enabled = true;
            this.CVgrabber2.Location = new System.Drawing.Point(5, 111);
            this.CVgrabber2.Name = "CVgrabber2";
            this.CVgrabber2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVgrabber2.OcxState")));
            this.CVgrabber2.Size = new System.Drawing.Size(32, 32);
            this.CVgrabber2.TabIndex = 10;
            // 
            // CVimage1
            // 
            this.CVimage1.Enabled = true;
            this.CVimage1.Location = new System.Drawing.Point(5, 77);
            this.CVimage1.Name = "CVimage1";
            this.CVimage1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVimage1.OcxState")));
            this.CVimage1.Size = new System.Drawing.Size(32, 32);
            this.CVimage1.TabIndex = 5;
            this.CVimage1.ImageSnaped += new System.EventHandler(this.CVimage1_ImageSnaped);
            // 
            // CVgrabber1
            // 
            this.CVgrabber1.Enabled = true;
            this.CVgrabber1.Location = new System.Drawing.Point(5, 43);
            this.CVgrabber1.Name = "CVgrabber1";
            this.CVgrabber1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVgrabber1.OcxState")));
            this.CVgrabber1.Size = new System.Drawing.Size(32, 32);
            this.CVgrabber1.TabIndex = 4;
            // 
            // CVdisplay1
            // 
            this.CVdisplay1.Location = new System.Drawing.Point(5, 5);
            this.CVdisplay1.Name = "CVdisplay1";
            this.CVdisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplay1.OcxState")));
            this.CVdisplay1.Size = new System.Drawing.Size(551, 150);
            this.CVdisplay1.TabIndex = 0;
            // 
            // ledOverload
            // 
            this.ledOverload.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledOverload.Location = new System.Drawing.Point(622, 155);
            this.ledOverload.Name = "ledOverload";
            this.ledOverload.OffColor = System.Drawing.Color.DarkRed;
            this.ledOverload.OnColor = System.Drawing.Color.Red;
            this.ledOverload.Size = new System.Drawing.Size(30, 29);
            this.ledOverload.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(648, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Processor Overload";
            // 
            // lblStreamsTotal1
            // 
            this.lblStreamsTotal1.AutoSize = true;
            this.lblStreamsTotal1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblStreamsTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamsTotal1.Location = new System.Drawing.Point(2, 58);
            this.lblStreamsTotal1.Name = "lblStreamsTotal1";
            this.lblStreamsTotal1.Size = new System.Drawing.Size(14, 13);
            this.lblStreamsTotal1.TabIndex = 53;
            this.lblStreamsTotal1.Text = "0";
            // 
            // lblBlipsTotal1
            // 
            this.lblBlipsTotal1.AutoSize = true;
            this.lblBlipsTotal1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBlipsTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlipsTotal1.Location = new System.Drawing.Point(2, 30);
            this.lblBlipsTotal1.Name = "lblBlipsTotal1";
            this.lblBlipsTotal1.Size = new System.Drawing.Size(14, 13);
            this.lblBlipsTotal1.TabIndex = 51;
            this.lblBlipsTotal1.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Streams";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Blips";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblBlipsTotal1);
            this.groupBox2.Controls.Add(this.lblStreamsTotal1);
            this.groupBox2.Location = new System.Drawing.Point(558, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(74, 74);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totals";
            // 
            // CVdisplayTile12
            // 
            this.CVdisplayTile12.Location = new System.Drawing.Point(122, 195);
            this.CVdisplayTile12.Name = "CVdisplayTile12";
            this.CVdisplayTile12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile12.OcxState")));
            this.CVdisplayTile12.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile12.TabIndex = 31;
            // 
            // CVdisplayTile13
            // 
            this.CVdisplayTile13.Location = new System.Drawing.Point(210, 195);
            this.CVdisplayTile13.Name = "CVdisplayTile13";
            this.CVdisplayTile13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile13.OcxState")));
            this.CVdisplayTile13.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile13.TabIndex = 32;
            // 
            // CVdisplayTile14
            // 
            this.CVdisplayTile14.Location = new System.Drawing.Point(298, 195);
            this.CVdisplayTile14.Name = "CVdisplayTile14";
            this.CVdisplayTile14.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile14.OcxState")));
            this.CVdisplayTile14.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile14.TabIndex = 33;
            // 
            // CVdisplayTile15
            // 
            this.CVdisplayTile15.Location = new System.Drawing.Point(386, 195);
            this.CVdisplayTile15.Name = "CVdisplayTile15";
            this.CVdisplayTile15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile15.OcxState")));
            this.CVdisplayTile15.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile15.TabIndex = 34;
            // 
            // CVdisplayTile16
            // 
            this.CVdisplayTile16.Location = new System.Drawing.Point(474, 195);
            this.CVdisplayTile16.Name = "CVdisplayTile16";
            this.CVdisplayTile16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile16.OcxState")));
            this.CVdisplayTile16.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile16.TabIndex = 35;
            // 
            // CVdisplayTile21
            // 
            this.CVdisplayTile21.Location = new System.Drawing.Point(650, 195);
            this.CVdisplayTile21.Name = "CVdisplayTile21";
            this.CVdisplayTile21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile21.OcxState")));
            this.CVdisplayTile21.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile21.TabIndex = 36;
            // 
            // CVdisplayTile22
            // 
            this.CVdisplayTile22.Location = new System.Drawing.Point(737, 195);
            this.CVdisplayTile22.Name = "CVdisplayTile22";
            this.CVdisplayTile22.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile22.OcxState")));
            this.CVdisplayTile22.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile22.TabIndex = 37;
            // 
            // CVdisplayTile23
            // 
            this.CVdisplayTile23.Location = new System.Drawing.Point(824, 195);
            this.CVdisplayTile23.Name = "CVdisplayTile23";
            this.CVdisplayTile23.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile23.OcxState")));
            this.CVdisplayTile23.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile23.TabIndex = 38;
            // 
            // CVdisplayTile24
            // 
            this.CVdisplayTile24.Location = new System.Drawing.Point(911, 195);
            this.CVdisplayTile24.Name = "CVdisplayTile24";
            this.CVdisplayTile24.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile24.OcxState")));
            this.CVdisplayTile24.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile24.TabIndex = 39;
            // 
            // CVdisplayTile25
            // 
            this.CVdisplayTile25.Location = new System.Drawing.Point(998, 195);
            this.CVdisplayTile25.Name = "CVdisplayTile25";
            this.CVdisplayTile25.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile25.OcxState")));
            this.CVdisplayTile25.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile25.TabIndex = 57;
            // 
            // CVdisplayTile26
            // 
            this.CVdisplayTile26.Location = new System.Drawing.Point(1085, 195);
            this.CVdisplayTile26.Name = "CVdisplayTile26";
            this.CVdisplayTile26.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile26.OcxState")));
            this.CVdisplayTile26.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile26.TabIndex = 58;
            // 
            // CVdisplayTile11
            // 
            this.CVdisplayTile11.Location = new System.Drawing.Point(34, 195);
            this.CVdisplayTile11.Name = "CVdisplayTile11";
            this.CVdisplayTile11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CVdisplayTile11.OcxState")));
            this.CVdisplayTile11.Size = new System.Drawing.Size(64, 64);
            this.CVdisplayTile11.TabIndex = 30;
            // 
            // ledT11
            // 
            this.ledT11.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT11.Location = new System.Drawing.Point(54, 259);
            this.ledT11.Name = "ledT11";
            this.ledT11.Size = new System.Drawing.Size(25, 25);
            this.ledT11.TabIndex = 72;
            // 
            // ledT12
            // 
            this.ledT12.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT12.Location = new System.Drawing.Point(142, 259);
            this.ledT12.Name = "ledT12";
            this.ledT12.Size = new System.Drawing.Size(25, 25);
            this.ledT12.TabIndex = 73;
            // 
            // ledT13
            // 
            this.ledT13.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT13.Location = new System.Drawing.Point(230, 259);
            this.ledT13.Name = "ledT13";
            this.ledT13.Size = new System.Drawing.Size(25, 25);
            this.ledT13.TabIndex = 74;
            // 
            // ledT14
            // 
            this.ledT14.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT14.Location = new System.Drawing.Point(318, 259);
            this.ledT14.Name = "ledT14";
            this.ledT14.Size = new System.Drawing.Size(25, 25);
            this.ledT14.TabIndex = 75;
            // 
            // ledT15
            // 
            this.ledT15.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT15.Location = new System.Drawing.Point(406, 259);
            this.ledT15.Name = "ledT15";
            this.ledT15.Size = new System.Drawing.Size(25, 25);
            this.ledT15.TabIndex = 76;
            // 
            // ledT16
            // 
            this.ledT16.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT16.Location = new System.Drawing.Point(494, 259);
            this.ledT16.Name = "ledT16";
            this.ledT16.Size = new System.Drawing.Size(25, 25);
            this.ledT16.TabIndex = 77;
            // 
            // ledT21
            // 
            this.ledT21.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT21.Location = new System.Drawing.Point(670, 259);
            this.ledT21.Name = "ledT21";
            this.ledT21.Size = new System.Drawing.Size(25, 25);
            this.ledT21.TabIndex = 78;
            // 
            // ledT22
            // 
            this.ledT22.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT22.Location = new System.Drawing.Point(757, 259);
            this.ledT22.Name = "ledT22";
            this.ledT22.Size = new System.Drawing.Size(25, 25);
            this.ledT22.TabIndex = 79;
            // 
            // ledT23
            // 
            this.ledT23.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT23.Location = new System.Drawing.Point(844, 259);
            this.ledT23.Name = "ledT23";
            this.ledT23.Size = new System.Drawing.Size(25, 25);
            this.ledT23.TabIndex = 80;
            // 
            // ledT24
            // 
            this.ledT24.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT24.Location = new System.Drawing.Point(931, 259);
            this.ledT24.Name = "ledT24";
            this.ledT24.Size = new System.Drawing.Size(25, 25);
            this.ledT24.TabIndex = 81;
            // 
            // ledT25
            // 
            this.ledT25.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT25.Location = new System.Drawing.Point(1018, 259);
            this.ledT25.Name = "ledT25";
            this.ledT25.Size = new System.Drawing.Size(25, 25);
            this.ledT25.TabIndex = 82;
            // 
            // ledT26
            // 
            this.ledT26.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledT26.Location = new System.Drawing.Point(1105, 259);
            this.ledT26.Name = "ledT26";
            this.ledT26.Size = new System.Drawing.Size(25, 25);
            this.ledT26.TabIndex = 83;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(2, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 17);
            this.label20.TabIndex = 85;
            this.label20.Text = "Fault Position:";
            // 
            // lblFaultPos
            // 
            this.lblFaultPos.AutoSize = true;
            this.lblFaultPos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFaultPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaultPos.Location = new System.Drawing.Point(115, 161);
            this.lblFaultPos.Name = "lblFaultPos";
            this.lblFaultPos.Size = new System.Drawing.Size(17, 17);
            this.lblFaultPos.TabIndex = 54;
            this.lblFaultPos.Text = "0";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.ledPLCStatus);
            this.groupBox5.Controls.Add(this.ledPLCFeintStream);
            this.groupBox5.Controls.Add(this.ledPLCStream);
            this.groupBox5.Controls.Add(this.ledPLCBlip);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(824, 155);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(261, 29);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(196, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 13);
            this.label24.TabIndex = 93;
            this.label24.Text = "Status";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default, "APP_EnableFeintProcessing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(133, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 92;
            this.label23.Text = "Feints";
            this.label23.Visible = global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default.APP_EnableFeintProcessing;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(59, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 91;
            this.label22.Text = "Streams";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(7, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 13);
            this.label21.TabIndex = 90;
            this.label21.Text = "Blips";
            // 
            // ledPLCStatus
            // 
            this.ledPLCStatus.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledPLCStatus.Location = new System.Drawing.Point(229, 5);
            this.ledPLCStatus.Name = "ledPLCStatus";
            this.ledPLCStatus.OffColor = System.Drawing.Color.DarkRed;
            this.ledPLCStatus.OnColor = System.Drawing.Color.Red;
            this.ledPLCStatus.Size = new System.Drawing.Size(25, 25);
            this.ledPLCStatus.TabIndex = 89;
            // 
            // ledPLCFeintStream
            // 
            this.ledPLCFeintStream.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default, "APP_EnableFeintProcessing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ledPLCFeintStream.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledPLCFeintStream.Location = new System.Drawing.Point(164, 5);
            this.ledPLCFeintStream.Name = "ledPLCFeintStream";
            this.ledPLCFeintStream.OffColor = System.Drawing.Color.DarkRed;
            this.ledPLCFeintStream.OnColor = System.Drawing.Color.Red;
            this.ledPLCFeintStream.Size = new System.Drawing.Size(25, 25);
            this.ledPLCFeintStream.TabIndex = 88;
            this.ledPLCFeintStream.Visible = global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default.APP_EnableFeintProcessing;
            // 
            // ledPLCStream
            // 
            this.ledPLCStream.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledPLCStream.Location = new System.Drawing.Point(99, 5);
            this.ledPLCStream.Name = "ledPLCStream";
            this.ledPLCStream.OffColor = System.Drawing.Color.DarkRed;
            this.ledPLCStream.OnColor = System.Drawing.Color.Red;
            this.ledPLCStream.Size = new System.Drawing.Size(25, 25);
            this.ledPLCStream.TabIndex = 87;
            // 
            // ledPLCBlip
            // 
            this.ledPLCBlip.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledPLCBlip.Location = new System.Drawing.Point(34, 5);
            this.ledPLCBlip.Name = "ledPLCBlip";
            this.ledPLCBlip.OffColor = System.Drawing.Color.DarkRed;
            this.ledPLCBlip.OnColor = System.Drawing.Color.Red;
            this.ledPLCBlip.Size = new System.Drawing.Size(25, 25);
            this.ledPLCBlip.TabIndex = 86;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.cmdPilkLogo;
            this.pictureBox1.Location = new System.Drawing.Point(558, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 73);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::Pilkngton.ProjectPaint.PaintApp.Properties.Resources.paint_red;
            this.pictureBox2.Location = new System.Drawing.Point(548, 185);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 95);
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "OPC Connect";
            this.label1.Visible = false;
            // 
            // ledOPCconect
            // 
            this.ledOPCconect.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.ledOPCconect.Location = new System.Drawing.Point(535, 155);
            this.ledOPCconect.Name = "ledOPCconect";
            this.ledOPCconect.OnColor = System.Drawing.Color.LawnGreen;
            this.ledOPCconect.Size = new System.Drawing.Size(30, 29);
            this.ledOPCconect.TabIndex = 72;
            this.ledOPCconect.Visible = global::Pilkngton.ProjectPaint.PaintApp.Properties.Settings.Default.APP_EnableOPC;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 943);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblFaultPos);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ledOPCconect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ledOverload);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.ledT26);
            this.Controls.Add(this.CVimage2);
            this.Controls.Add(this.ledT25);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.ledT24);
            this.Controls.Add(this.CVdisplay2);
            this.Controls.Add(this.ledT23);
            this.Controls.Add(this.CVgrabber2);
            this.Controls.Add(this.ledT22);
            this.Controls.Add(this.CVimage1);
            this.Controls.Add(this.ledT21);
            this.Controls.Add(this.CVgrabber1);
            this.Controls.Add(this.ledT16);
            this.Controls.Add(this.ledT15);
            this.Controls.Add(this.CVdisplay1);
            this.Controls.Add(this.ledT14);
            this.Controls.Add(this.CVdisplayTile11);
            this.Controls.Add(this.ledT13);
            this.Controls.Add(this.CVdisplayTile12);
            this.Controls.Add(this.ledT12);
            this.Controls.Add(this.CVdisplayTile13);
            this.Controls.Add(this.ledT11);
            this.Controls.Add(this.CVdisplayTile14);
            this.Controls.Add(this.CVdisplayTile15);
            this.Controls.Add(this.CVdisplayTile16);
            this.Controls.Add(this.CVdisplayTile26);
            this.Controls.Add(this.CVdisplayTile21);
            this.Controls.Add(this.CVdisplayTile25);
            this.Controls.Add(this.CVdisplayTile22);
            this.Controls.Add(this.CVdisplayTile23);
            this.Controls.Add(this.CVdisplayTile24);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Inspection System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabMain.ResumeLayout(false);
            this.tabMainResults.ResumeLayout(false);
            this.tabMainResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphFaultMap)).EndInit();
            this.tabMainCamera.ResumeLayout(false);
            this.tabMainCamera.PerformLayout();
            this.grpCam2Gain.ResumeLayout(false);
            this.grpCam2Gain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpCam2ROI.ResumeLayout(false);
            this.grpCam2ROI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam2Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam2Right)).EndInit();
            this.grpCam1ROI.ResumeLayout(false);
            this.grpCam1ROI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam1Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCam1Right)).EndInit();
            this.grpCam1Gain.ResumeLayout(false);
            this.grpCam1Gain.PerformLayout();
            this.grpCamFreq.ResumeLayout(false);
            this.grpCamFreq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slideOverload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2GreyScaleCursor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2PixelCursorRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2PixelCursorLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1GreyScaleCursor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1PixelCursorRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph1PixelCursorLeft)).EndInit();
            this.tabMainConfig.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabMainLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CVimage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVgrabber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVimage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVgrabber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledOverload)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVdisplayTile11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledT26)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCFeintStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPLCBlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledOPCconect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxCVDISPLAYLib.AxCVdisplay CVdisplay1;
        private AxCVGRABBERLib.AxCVgrabber CVgrabber1;
        private AxCVIMAGELib.AxCVimage CVimage1;
        private AxCVGRABBERLib.AxCVgrabber CVgrabber2;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplay2;
        private AxCVIMAGELib.AxCVimage CVimage2;
        private System.IO.Ports.SerialPort cam1ComPort;
        private System.IO.Ports.SerialPort cam2ComPort;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMainResults;
        private System.Windows.Forms.TabPage tabMainCamera;
        private System.Windows.Forms.TabPage tabMainConfig;
        private NationalInstruments.UI.WindowsForms.WaveformGraph graph2;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private NationalInstruments.UI.WindowsForms.WaveformGraph graph1;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private System.Windows.Forms.Label lblStreams2;
        private System.Windows.Forms.Label lblStreamsTotal2;
        private System.Windows.Forms.Label lblBlipsTotal2;
        private System.Windows.Forms.Label lblBlips2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabMainLog;
        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.Button cmdErrLogClear;
        private System.Windows.Forms.CheckedListBox lstErrorLog;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.PropertyGrid propertyGridMySettings;
        private NationalInstruments.UI.XYCursor graph1GreyScaleCursor;
        private NationalInstruments.UI.XYCursor graph2GreyScaleCursor;
        private NationalInstruments.UI.WindowsForms.Slide slideThreshold;
        private NationalInstruments.UI.WindowsForms.Led ledOverload;
        private NationalInstruments.UI.WindowsForms.ScatterGraph graphFaultMap;
        private NationalInstruments.UI.XAxis graphFaultMapxAxis;
        private NationalInstruments.UI.YAxis graphFaultMapyAxis;
        private NationalInstruments.UI.ScatterPlot graphFaultMapblips;
        public NationalInstruments.UI.ScatterPlot graphFaultMapstreams;
        private NationalInstruments.UI.WindowsForms.Led ledOPCconect;
        private System.Windows.Forms.Label label2;
        private NationalInstruments.UI.WindowsForms.Slide slideOverload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpCamFreq;
        private System.Windows.Forms.RadioButton rdoCamFreq500Hz;
        private System.Windows.Forms.RadioButton rdoCamFreq750Hz;
        private System.Windows.Forms.RadioButton rdoCamFreq1kHz;
        private System.Windows.Forms.RadioButton rdoCamFreq1_5kHz;
        private System.Windows.Forms.RadioButton rdoCamFreq2kHz;
        private System.Windows.Forms.RadioButton rdoCamFreq350Hz;
        private System.Windows.Forms.GroupBox grpCam1Gain;
        private System.Windows.Forms.RadioButton rdoCam1Gain6;
        private System.Windows.Forms.RadioButton rdoCam1Gain5;
        private System.Windows.Forms.RadioButton rdoCam1Gain4;
        private System.Windows.Forms.RadioButton rdoCam1Gain3;
        private System.Windows.Forms.RadioButton rdoCam1Gain2;
        private System.Windows.Forms.RadioButton rdoCam1Gain1;
        private System.Windows.Forms.RadioButton rdoCam1Gain0;
        private NationalInstruments.UI.XYCursor graph1PixelCursorRight;
        private NationalInstruments.UI.XYCursor graph1PixelCursorLeft;
        private NationalInstruments.UI.XYCursor graph2PixelCursorRight;
        private NationalInstruments.UI.XYCursor graph2PixelCursorLeft;
        private System.Windows.Forms.GroupBox grpCam2ROI;
        private NationalInstruments.UI.WindowsForms.NumericEdit spinCam2Left;
        private NationalInstruments.UI.WindowsForms.NumericEdit spinCam2Right;
        private System.Windows.Forms.GroupBox grpCam1ROI;
        private NationalInstruments.UI.WindowsForms.NumericEdit spinCam1Left;
        private NationalInstruments.UI.WindowsForms.NumericEdit spinCam1Right;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFrameCount1;
        private System.Windows.Forms.Label lblFrameCount2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblStreamsCurrent2;
        private System.Windows.Forms.Label lblBlipsCurrent2;
        private System.Windows.Forms.Label lblBlipsCurrent1;
        private System.Windows.Forms.Label lblStreamsCurrent1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private NationalInstruments.UI.ScatterPlot graphFaultMapoverload;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoImageSaveTiles;
        private System.Windows.Forms.RadioButton rdoImageSaveNone;
        private System.Windows.Forms.RadioButton rdoImageSaveNext1;
        private System.Windows.Forms.RadioButton rdoImageSaveFrames;
        private System.Windows.Forms.Label lblStreamsTotal1;
        private System.Windows.Forms.Label lblBlipsTotal1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoImageSaveNext2;
        private System.Windows.Forms.GroupBox grpCam2Gain;
        private System.Windows.Forms.RadioButton rdoCam2Gain6;
        private System.Windows.Forms.RadioButton rdoCam2Gain5;
        private System.Windows.Forms.RadioButton rdoCam2Gain4;
        private System.Windows.Forms.RadioButton rdoCam2Gain3;
        private System.Windows.Forms.RadioButton rdoCam2Gain2;
        private System.Windows.Forms.RadioButton rdoCam2Gain1;
        private System.Windows.Forms.RadioButton rdoCam2Gain0;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile12;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile13;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile14;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile15;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile16;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile21;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile22;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile23;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile24;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile25;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile26;
        private AxCVDISPLAYLib.AxCVdisplay CVdisplayTile11;
        private NationalInstruments.UI.WindowsForms.Led ledT11;
        private NationalInstruments.UI.WindowsForms.Led ledT12;
        private NationalInstruments.UI.WindowsForms.Led ledT13;
        private NationalInstruments.UI.WindowsForms.Led ledT14;
        private NationalInstruments.UI.WindowsForms.Led ledT15;
        private NationalInstruments.UI.WindowsForms.Led ledT16;
        private NationalInstruments.UI.WindowsForms.Led ledT21;
        private NationalInstruments.UI.WindowsForms.Led ledT22;
        private NationalInstruments.UI.WindowsForms.Led ledT23;
        private NationalInstruments.UI.WindowsForms.Led ledT24;
        private NationalInstruments.UI.WindowsForms.Led ledT25;
        private NationalInstruments.UI.WindowsForms.Led ledT26;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblFaultPos;
        private NationalInstruments.UI.WaveformPlot waveformPlot4;
        private NationalInstruments.UI.WaveformPlot waveformPlot6;
        private NationalInstruments.UI.WaveformPlot waveformPlot3;
        private NationalInstruments.UI.WaveformPlot waveformPlot5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private NationalInstruments.UI.WindowsForms.Led ledPLCStatus;
        private NationalInstruments.UI.WindowsForms.Led ledPLCFeintStream;
        private NationalInstruments.UI.WindowsForms.Led ledPLCStream;
        private NationalInstruments.UI.WindowsForms.Led ledPLCBlip;
        public NationalInstruments.UI.ScatterPlot graphFaultMapFeints;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

