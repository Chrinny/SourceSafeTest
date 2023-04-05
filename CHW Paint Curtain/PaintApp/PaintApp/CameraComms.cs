using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;


namespace Pilkngton.ProjectPaint.PaintApp
{
    /// <summary>
    /// class to handle camera settings programmed over the comm port
    /// </summary>
    class CameraComms : ErrorReporter
    {

        public SerialPort CommPort;
        public int MAXLINEFREQHZ = 4000, MINLINEFREQHZ = 100;
        public int MAXPIXELPOSITION = 0, MINPIXELPOSITION = 2047;
        public int MAXGAINVAL = 511, MINGAINVAL = 0;
        public int MAXANALOGGAIN = 30, MINANALOGGAIN = -10;

        /// <summary>
        /// Constructor: initialises the base class error reporting.
        /// </summary>
        /// <param name="commPort">ms comm port object</param>
        public CameraComms(int baseErrorNum,ErrorEventHandler handler,SerialPort commPort):
            base(baseErrorNum, handler)//next available +2
        {
            CommPort = commPort;
            CommPort.BaudRate = 9600;
            CommPort.Parity = Parity.None;
            CommPort.DataBits = 8;
            CommPort.StopBits = StopBits.One;
            CommPort.Open();
        }

        /// <summary>
        /// send an string to the camera
        /// </summary>
        /// <param name="cmdstring"></param>
        public void SendCmd(string cmdstring)
        {
            try
            {
                CommPort.WriteLine(cmdstring);
                CommPort.WriteLine("wus");
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 1, except, " ERROR: CameraComms.SendCmd:  problem whilst communicating with camera " + (char)13);
            }
        }
        /// <summary>
        /// set the camera's line frequency
        /// </summary>
        /// <param name="freqHz">fdrequency in Hz</param>
        /// <returns></returns>
        public int SetLineFreq(int freqHz)
        {
            if (freqHz < MINLINEFREQHZ)
                freqHz = MINLINEFREQHZ;
            else if (freqHz > MAXLINEFREQHZ)
                freqHz = MAXLINEFREQHZ; 
            SendCmd("ssf " + freqHz.ToString());

            return freqHz;
        }
        /// <summary>
        /// set the cameras analog gain
        /// </summary>
        /// <param name="gain"></param>
        /// <returns></returns>
        public double SetAnalogGain(int gain)
        {
            if (gain < MINANALOGGAIN)
                gain = MINANALOGGAIN;
            else if (gain > MAXANALOGGAIN)
                gain = MAXANALOGGAIN;
            SendCmd("sg 0 " + gain.ToString());
            return gain;
        }
        /// <summary>
        /// set the camera's PRNU for a particular pixel
        /// </summary>
        /// <param name="Position">pixel position</param>
        /// <param name="Gain">the gain value</param>
        public void SetPixelGain(int Position, int Gain)
        {
            if (Position < MINPIXELPOSITION)
                Position = MINPIXELPOSITION;
            else if (Position > MAXPIXELPOSITION)
                Position = MAXPIXELPOSITION;
            if (Gain < MINPIXELPOSITION)
                Gain = MINPIXELPOSITION;
            else if (Gain > MAXPIXELPOSITION)
                Position = MAXPIXELPOSITION; 
            SendCmd("spc " + Position.ToString() + " " + Gain.ToString());

            return;
        }
        /// <summary>
        /// close the comm port
        /// </summary>
        public void Close()
        {
            CommPort.Close();
        }
    }
}
