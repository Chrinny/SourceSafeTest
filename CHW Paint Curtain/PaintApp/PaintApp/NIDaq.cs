using System;
using NationalInstruments.DAQmx;
//IMPORTANT NOTE: ALL OF THE LOGIC EMPLOYED HERE IS ACTIVE LOW!

namespace Pilkngton.ProjectPaint.PaintApp
{
	/// <summary>
	/// controls access to the Nidaq card for the following DIGITAL output Stream, Blip and System Status
	/// </summary>
	public class NIDaq : ErrorReporter
	{
		/// <summary> status of the nidaq resources</summary>
		public bool AllDevicesCreatedOK = true;
		/// <summary> nidaq card id</summary>
		const string NiDaqCardId = "Dev2/";
		//const string NiDaqDIChannelStr = NiDaqCardId + "port0/line0:3";
		const string NiDaqDOChannelStr = NiDaqCardId + "port2/line0:3";//ports 2 and 3 for output
        const string NiDaqDOChannelStr2 = NiDaqCardId + "port2/line4:7"+","+NiDaqCardId + "port3/line0:7";
        //const string NiDaqDIChannelStr = NiDaqCardId + "port1/line0:3";//ports 0 and 1 for input
        public const int NumOutputs = 4;
        public const int NumInputs = 4; 
        public bool[] DOBits = new bool[NumOutputs] { false, false, false, false };
        public bool[] AddressBits = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };

        public byte BlipBit = 0;
        public byte StreamBit = 1;
        public byte StatusBit = 2;
        public byte FeintStreamBit = 3;
        private System.Windows.Forms.Timer tmrBlip;
        public int BlipTime_ms = 500;
        public bool OutputStopped = false;
        private Task myDITask;
        private DigitalSingleChannelReader myDIreader;
//        public UInt32 PlateWidthDIMask = 1;

        /// <summary>
        /// constructor, creates trhe digital writer and the blip timer used to time the duration of the blip output
        /// </summary>
        public NIDaq(int baseErrorNum, ErrorEventHandler handler):
            base(baseErrorNum, handler)//next available +2
		{
			//AllDevicesCreatedOK &= CreateDigitalWriter();
            tmrBlip = new System.Windows.Forms.Timer();//10
            tmrBlip.Interval = Properties.Settings.Default.Report_BlipDigOutOnTime_ms;	//used to time the duration of the blip output
            tmrBlip.Tick += new EventHandler(tmrBlip_Tick);
            tmrBlip.Enabled = false;
            TurnStatusOff();//status logic is inverted so 
            WriteAddressLines(4095); //all 1s
            //WriteAddressLines(2730); //alternate 1s and 0s
        }

        //private bool CreateDigitalReader()
        //{
        //    //103			using (TimedLock.Lock(DISyncLock))
        //    {
        //        bool retval = false;
        //        try
        //        {
        //            myDITask = new Task("DIReadTask");
        //            myDITask.DIChannels.CreateChannel(NiDaqDIChannelStr, "DigInputs", ChannelLineGrouping.OneChannelForAllLines);
        //            myDIreader = new DigitalSingleChannelReader(myDITask.Stream);
        //            retval = true;
        //        }
        //        catch (Exception e)
        //        {
        //            //dispose of the task
        //            myDITask.Dispose();
        //            OnError(BaseERRNUM + 2, e, " ERROR: NIDaq.CreateDigitalReader:  Failed to configure Digital Input  " + (char)13);
        //            retval = false;
        //        }
        //        return retval;
        //    }
        //}
        public void StopStartDITask(int mode) //mode 0:stop , 1:start , 2 stopstart
        {
            try
            {
                if (mode == 0 || mode == 2)
                    myDITask.Stop();

                if (mode == 1 || mode == 2)
                    myDITask.Start();
            }
            catch (Exception e)
            {
                OnError(BaseERRNUM + 19, e, " ERROR: NIDaq.StopStartDITask:  Failed to start or stop Nidaq task " + (char)13);
            }
        }
        public int GetPlateWidthCode()
        {
            UInt32 PlateWidthCode = myDIreader.ReadSingleSamplePortUInt32();
            myDITask.Stop();
            //PlateWidthCode = 255 - PlateWidthCode;
            return (int)PlateWidthCode;
            //if ((PlateWidthCode & PlateWidthDIMask) == PlateWidthDIMask)
            //    return true; //invert the logic if high return false, if low return true
            //else
            //    return false;
        }
        /// <summary>
        /// this timer is used to set the duration of the blip pulse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrBlip_Tick(object sender, EventArgs e)
        {
            tmrBlip.Enabled = false;
            TurnBlipOff();
       }
        /// <summary>
        /// dipose of all local objects
        /// </summary>
		public void Dispose()
		{
            tmrBlip.Enabled = false;
            tmrBlip.Dispose();
            for (int i = 0; i < 8; i++)
                DOBits[i] = false;
			WriteDOLines(); //turn the lights off

		}
        public void ClearAndStopOutputs()
        {
            for(int i=0;i<NumOutputs;i++)
                DOBits[i] = false;
            WriteDOLines();
            OutputStopped = true;
        }
        public void SetStream(bool val)
        {
            DOBits[StreamBit] = val;
            WriteDOLines();
        }
		public void TurnStreamOnReportPos(int Pos)
		{
            if (!DOBits[StreamBit])//if the stream line isn't already on
            {
                //if (!DOBits[BlipBit])//don't override the existing position
                    WriteAddressLines(Pos);//report the position
                DOBits[StreamBit] = true;
                WriteDOLines();
            }
		}
        public void TurnFeintStreamOnReportPos(int Pos)
        {
            if (!DOBits[FeintStreamBit])//if the stream line isn't already on
            {
                //if (!DOBits[BlipBit])//don't override the existing position
                WriteAddressLines(Pos);//report the position
                DOBits[FeintStreamBit] = true;
                WriteDOLines();
            }
        }
        public void TurnStreamOn()
        {
            if (!DOBits[StreamBit])
            {
                DOBits[StreamBit] = true;
                WriteDOLines();
            }
        }
        public void TurnStreamOff()
        {
            DOBits[StreamBit] = false;
            WriteDOLines();
        }
        public void TurnFeintStreamOff()
        {
            DOBits[FeintStreamBit] = false;
            WriteDOLines();
        }
        public void SetBlip(bool val)
        {
            DOBits[BlipBit] = val;
            WriteDOLines();
        }
        public void TurnBlipOn()
		{
            if (!DOBits[BlipBit])
            {
                DOBits[BlipBit] = true;
                WriteDOLines();
                tmrBlip.Enabled = true;
            }
		}
        public void TurnBlipOnReportPos(int Pos)
        {
            if (!DOBits[BlipBit])//if the blip line isn't already on
            {

                //if (!DOBits[StreamBit])//don't override the existing position
                    WriteAddressLines(Pos);//report the position
                DOBits[BlipBit] = true;
                WriteDOLines();
                tmrBlip.Enabled = true;
            }
        }
        public void TurnBlipOff()
        {
            DOBits[BlipBit] = false;
            WriteDOLines();
        }
        public void SetStatus(bool val)
        {
            DOBits[StatusBit] = val;
            WriteDOLines();
        }
        public void TurnStatusOn()//status logic is inverted
        {
            DOBits[StatusBit] = false;
            WriteDOLines();
        }
        public void TurnStatusOff()//status logic is inverted
        {
            DOBits[StatusBit] = true;
            WriteDOLines();
        }
        /// <summary>
        /// write the contents of DOBits to the Digital Output
        /// I have changed this from using a global task and ChannelWriter to newing them here because the code leaked?!
        /// When the new'd variables go out of scaope they will be marked for deletion by the garbage collector
        /// </summary>
 		public void WriteDOLines()
		{
            if (!OutputStopped && !Properties.Settings.Default.Report_DigOutLinesDisabled)
			try
			{
                using (Task myDOTask = new Task())
                {
                    //  Create an Digital Output channel and name it.
                    myDOTask.DOChannels.CreateChannel(NiDaqDOChannelStr, "DigOutputs", ChannelLineGrouping.OneChannelForAllLines);
                    //  Write digital port data. WriteDigitalSingChanSingSampPort writes a single sample
                    //  of digital data on demand, so no timeout is necessary.
                    DigitalSingleChannelWriter myDOWriter = new DigitalSingleChannelWriter(myDOTask.Stream);

                    myDOWriter.WriteSingleSampleMultiLine(true, DOBits);
                    myDOTask.Stop();
                }
            }
            catch (Exception e)
            {
                OnError(BaseERRNUM + 1, e, " ERROR: NIDaq.WriteDOLines:  Failed to write Digital Output Lines " + (char)13);
            }
        }
        public void WriteAddressLines(int Addr)
        {
            if (!OutputStopped && !Properties.Settings.Default.Report_DigOutLinesDisabled)
                try
                {
                    for (int i = 0; i < 12; i++)
                        AddressBits[i] = (Addr & (1 << i)) == 0 ? false : true;//decode the address
                    using (Task myDOTask = new Task())
                    {
                        //  Create an Digital Output channel and name it.
                        myDOTask.DOChannels.CreateChannel(NiDaqDOChannelStr2, "DigOutputs", ChannelLineGrouping.OneChannelForAllLines);
                        //  Write digital port data. WriteDigitalSingChanSingSampPort writes a single sample
                        //  of digital data on demand, so no timeout is necessary.
                        DigitalSingleChannelWriter myDOWriter = new DigitalSingleChannelWriter(myDOTask.Stream);

                        myDOWriter.WriteSingleSampleMultiLine(true, AddressBits);
                        myDOTask.Stop();
                    }

                }
                catch (Exception e)
                {
                    OnError(BaseERRNUM + 1, e, " ERROR: NIDaq.WriteDOLines:  Failed to write Digital Output Lines " + (char)13);
                }
        }
	}
}
