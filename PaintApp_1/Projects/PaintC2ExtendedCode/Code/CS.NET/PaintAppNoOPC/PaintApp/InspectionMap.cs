using System;
using System.Collections.Generic;
using System.Text;

namespace Pilkngton.ProjectPaint.PaintApp
{
    /// <summary>
    /// Computes the coverage and overlap of each camera based on their start and stop  positions in mm
    /// There are also start and stop pixels for each camera if not all of the pixels are to be used.
    /// The entire coverage of the 2 cameras is divided into 16 zones with special attention paid to the overlap
    /// </summary>
    public class InspectionMap : ErrorReporter
    {
        public const int Camera1 = 0, Camera2 = 1;
        public double Cam1Startmm = 0.0F;
        public double Cam1Endmm = 1700.0F;
        public double Cam2Startmm = 1650.0F;
        public double Cam2Endmm = 3350.0F;

        public int Cam1Startpix = 0;
        public int Cam1Endpix = 2047;
        public int Cam2Startpix = 0;
        public int Cam2Endpix = 2047;

        public double PixPermmCam1 = 0;
        public double PixPermmCam2 = 0;

        public int NumZones = 16;//8 per camera
        public double ZoneSizemm = 210.0;

        public double ZoneSizepixCam1 = 0F;
        public double ZoneSizepixCam2 = 0F;

        public double[] Zonesmm;
        public int[][] ZonesPixCam;
        //        public int[] ZonesPixCam2;

        public Int16 BlipsByZone;
        public Int16 StreamsByZone;
        public bool ProcessorOverloaded;

        /// <summary>
        /// Constructor: initialises the base class error reporting and gets the camera and zone data from the config file
        /// </summary>
        /// <param name="baseErrorNum"></param>
        /// <param name="handler"></param>
        public InspectionMap(int baseErrorNum, ErrorEventHandler handler)
            : base(baseErrorNum, handler)//next available +5
        {
            NumZones = Properties.Settings.Default.Align_NumZones;
            ZoneSizemm = Properties.Settings.Default.Align_ZoneSizemm;

            Cam1Startmm = Properties.Settings.Default.Align_Cam1Startmm;
            Cam1Endmm = Properties.Settings.Default.Align_Cam1Endmm;
            Cam2Startmm = Properties.Settings.Default.Align_Cam2Startmm;
            Cam2Endmm = Properties.Settings.Default.Align_Cam2Endmm;

            Cam1Startpix = Properties.Settings.Default.Align_Cam1Startpix;
            Cam1Endpix = Properties.Settings.Default.Align_Cam1Endpix;
            Cam2Startpix = Properties.Settings.Default.Align_Cam2Startpix;
            Cam2Endpix = Properties.Settings.Default.Align_Cam2Endpix;
            try
            {
                Zonesmm = new double[NumZones];
                ZonesPixCam = new int[NumZones / 2][];
                for (int i = 0; i < NumZones/2; i++)
                    ZonesPixCam[i] = new int[2];
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 1, except, " ERROR: InspectionMap.Constructor:  problem whilst communicating with camera " + (char)13);
            }
            CalculateZones();
        }

        /// <summary>
        /// There are 2 zone arrays, one for each camera. They contain the pixel at the END of the zone
        /// i.e. in array pos 0 is the last pixel in first zone
        /// the overlap needs to be taken into account in camera2s zone postions
        /// it is calculated by subtracting the start postion of camera2 from the last zone position of camera1 
        /// and scaling by pixels per mm
        /// </summary>
        public void CalculateZones()
        {
            try
            {
                PixPermmCam1 = (Cam1Startpix - Cam1Endpix) / (Cam1Startmm - Cam1Endmm);
                PixPermmCam2 = (Cam2Startpix - Cam2Endpix) / (Cam2Startmm - Cam2Endmm);

                ZoneSizepixCam1 = ZoneSizemm * PixPermmCam1;
                ZoneSizepixCam2 = ZoneSizemm * PixPermmCam2;

                // the overlap needs to be taken into account in camera2s zone postions
                // it is calculated by subtracting the start postion of camera2 from the last zone position of camera1 
                // and scaling by pixels per mm
                double Cam2OffsetPix = (((NumZones / 2) * ZoneSizemm) - Cam2Startmm) * PixPermmCam2;

                for (int i = 0; i < (NumZones / 2); i++)
                {
                    ZonesPixCam[i][Camera1] = (int)(Cam1Startpix + ((i + 1) * ZoneSizepixCam1));
                    ZonesPixCam[i][Camera2] = (int)(Cam2OffsetPix + Cam2Startpix + ((i + 1) * ZoneSizepixCam2));
                }
                ZonesPixCam[(NumZones / 2) - 1][Camera1] = Cam1Endpix;
                ZonesPixCam[(NumZones / 2) - 1][Camera2] = Cam2Endpix;
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 2, except, " ERROR: InspectionMap.getZoneMask:  problem whilst calculating zone masks " + (char)13);

            }
        }
        public int getPosition_mm(int camera, int x)
        {
            int pos = 0;
            if (camera == Camera1)
            {
                pos = (int)(Cam1Startmm + (x * PixPermmCam1));
            }
            else
            {
                pos = (int)(Cam2Startmm + (x * PixPermmCam2));
            }
            return pos;
        }
        /// <summary>
        /// This function produces a bitmask of the blob's zone postion based on start position only. 
        /// No account is made of a fault spanning more than one zone
        /// Once the zone has been located the function returns
        /// </summary>
        /// <param name="camera">which camera the blob was seen by</param>
        /// <param name="x">the start position of the blob</param>
        /// <returns>a bit mask of the zone position</returns>
        public int getZoneMask(int camera, int x)
        {
            int mask = 1, retval = 0;

            try
            {
                if (camera == Camera2)  //if were on camera 2 start the mask half way up
                    mask = mask << (NumZones / 2); 

                for (int i = 0; i < NumZones / 2; i++)
                {
                    if (x < ZonesPixCam[i][camera])// && x >= ZonesPixCam[i - 1][camera])
                    {
                        retval |= mask;
                        return retval;
                    }
                    mask = mask << 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 3, except, " ERROR: InspectionMap.getZoneMask:  problem whilst producing correct zone mask for blob " + (char)13);
             }
            return retval |= mask;
        }
        /// <summary>
        /// This function produces a bitmask of the blob's zone postion based on its start postion and extent
        /// i.e. if the blob spans several zones their corresponding bits will be set
        /// </summary>
        /// <param name="camera">which camera the blob was seen by</param>
        /// <param name="x">the start position of the blob</param>
        /// <param name="dx">the length of the blob</param>
        /// <returns>a bit mask of the zone positions</returns>
        public int getZoneMask(int camera, int x, int dx)
        {
            int mask = 1,retval =0;
            if(camera == Camera2)
                mask = mask << (NumZones / 2);
            try
            {
                for (int i = 0; i < NumZones/2; i++)
                {//if the current zone > the blob start and the previous zone < the blob end then the blob is somewhere in this zone
                    if (ZonesPixCam[i][camera] >= x && ((i == 0) ? true : ZonesPixCam[i - 1][camera] < (x + dx)))//if i=0 then can't check for previous zone
                    {
                        retval |= mask;
                    }
                    mask = mask << 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 4, except, " ERROR: InspectionMap.getZoneMask:  problem whilst producing correct zone mask for blob " + (char)13);
            }
            return retval;
        }
    }

}

