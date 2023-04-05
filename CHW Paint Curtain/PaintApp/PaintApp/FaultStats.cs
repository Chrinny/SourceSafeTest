using System;
using System.Collections.Generic;
using System.Text;

namespace Pilkngton.ProjectPaint.PaintApp
{
    /// <summary>
    /// Generates Fault Statistics by accumulating Zoned Faults in timed Binns. 
    /// The current binn is determined by counting the number of minutes since midnight.
    /// Current statistics are regenerated on the fly by summing binns.
    /// There is a binn per zone for each time period and EXTRA binn on the end which is an aggregation (total) of the zones.
    /// Blips are treated as discrete faults and a count is produced.
    /// Streams are stored in terms of their duration in seconds i.e. for a line rate of 1kHz and a frame height of 512
    /// each detected stream in a frame adds 0.512s to the accumulated total for that zone.
    /// The aggregate blip count is the sum of all the zone count for the binn period
    /// The aggregate stream duration in seconds however is the sum of the zone durations when one or more stream were present
    /// </summary>
    public class FaultStats: ErrorReporter
    {
        
        private double[][] StreamZoneBinns;
        private double[][] FeintZoneBinns;
        private int[][] BlipZoneBinns;
        private double[][] StreamSizeBinns;
        private int[][] BlipSizeBinns;
        private double[] OverloadBinns;

        public int BinnIntervalMins = 5;
        public int BinnDays = 1;
        public int NumBinns;
        public int NumZones;
        public const int NumSizeCategories = 4;
        public int[] BlipSizes = new int[NumSizeCategories-1]{Properties.Settings.Default.Report_BlipSmallAreaPix,Properties.Settings.Default.Report_BlipMediumAreaPix,Properties.Settings.Default.Report_BlipLargeAreaPix};
        public int[] StreamSizes = new int[NumSizeCategories - 1] { Properties.Settings.Default.Report_StreamSmallWidthPix, Properties.Settings.Default.Report_StreamMediumWidthPix, Properties.Settings.Default.Report_StreamLargeWidthPix };

        public double[] xplot;
        public double[,] yplots;

        public int CurrentBinn;

        /// <summary>
        /// Constructor: initialises the base class error reporting.
        /// </summary>
        /// <param name="baseErrorNum"></param>
        /// <param name="handler"></param>
        public FaultStats(int baseErrorNum, ErrorEventHandler handler) :
            base(baseErrorNum, handler)//next available +11
        {
            try
            {
                BinnIntervalMins = Properties.Settings.Default.Report_BinnIntervalMins;
                BinnDays = Properties.Settings.Default.Report_BinnDays;
                NumZones = Properties.Settings.Default.Align_NumZones;
                NumBinns = BinnDays * 24 * 60 / BinnIntervalMins;
                StreamZoneBinns = new double[NumBinns][];
                FeintZoneBinns = new double[NumBinns][];
                BlipZoneBinns = new int[NumBinns][];
                StreamSizeBinns = new double[NumBinns][];
                BlipSizeBinns = new int[NumBinns][]; 
                
                OverloadBinns = new double[NumBinns];
                for (int i = 0; i < NumBinns; i++)
                {
                    StreamZoneBinns[i] = new double[NumZones + 1];//extra one at the end for totals
                    FeintZoneBinns[i] = new double[NumZones + 1];//extra one at the end for totals
                    BlipZoneBinns[i] = new int[NumZones + 1];//extra one at the end for totals
                    StreamSizeBinns[i] = new double[NumSizeCategories];//don't need extra at end because already covered in ZoneBinns
                    BlipSizeBinns[i] = new int[NumSizeCategories];//don't need extra at end because already covered in ZoneBinns
                }
                CurrentBinn = (DateTime.Now.Hour * 60 + DateTime.Now.Minute) / BinnIntervalMins;
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 1, except, " ERROR: FaultStats.Constructor: problem allocating binn array " + (char)13);
            }
        }
        /// <summary>
        /// Finds the current binn to be accumulating blip counts and stream durations into.
        /// This is done by dividing the number of minutes since midnight by the binn duration minutes.
        /// </summary>
        /// <returns>the binn number</returns>
        public int getCurrentBinn()
        {
            int minsSinceMidnight = 0,retval = 0;
            try
            {
                DateTime Tnow = DateTime.Now;
                minsSinceMidnight = Tnow.Hour * 60 + Tnow.Minute;
                retval = minsSinceMidnight / BinnIntervalMins;
                while (CurrentBinn != retval)//if time has moved on clear out the intervening binns
                {
                    if (++CurrentBinn >= NumBinns)
                        CurrentBinn = 0;
                    clearBinns(CurrentBinn);
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 2, except, " ERROR: FaultStats.getCurrentBinn: problem calculating minsSinceMidnight " + (char)13);
            }
            return retval;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public void clearBinns(int position)
        {
            for (int j = 0; j < NumZones; j++)
            {
                BlipZoneBinns[position][j] = 0;
                StreamZoneBinns[position][j] = 0;
                FeintZoneBinns[position][j] = 0;
            }
            OverloadBinns[position] = 0;
            for (int j = 0; j < NumSizeCategories; j++)
            {
                BlipSizeBinns[position][j] = 0;
                StreamSizeBinns[position][j] = 0;
            }
        }
        public void clearBinns()
        {
            for (int i = 0; i < NumBinns; i++)
            {
                for (int j = 0; j < NumZones; j++)
                {
                    BlipZoneBinns[i][j] = 0;
                    StreamZoneBinns[i][j] = 0;
                    FeintZoneBinns[i][j] = 0;
                }
                OverloadBinns[i] = 0;
                for (int j = 0; j < NumSizeCategories; j++)
                {
                    BlipSizeBinns[i][j] = 0;
                    StreamSizeBinns[i][j] = 0;
                }
            }
        }
        /// <summary>
        /// Update the stats being accumulated in the current binn positions
        /// </summary>
        /// <param name="BlipMask">a bit mask containing any zones that have one or more blips</param>
        public void updateBlips(int BlipMask,int AreaPix)
        {
            int currentBinn = getCurrentBinn();
            try
            {
                for (int i = 0; i < NumZones; i++)//update the zone binns
                {
                    if ((BlipMask & 1 << i) > 0)
                    {
                        BlipZoneBinns[currentBinn][i]++;    //update the zone count
                        BlipZoneBinns[currentBinn][NumZones]++;//update the total
                    }
                }
                for (int i = 0; i < NumSizeCategories-1; i++)//update the size binns, there are 4 categories but only 3 size bounmdaries
                {
                    if (AreaPix < BlipSizes[i])
                    {
                        BlipSizeBinns[currentBinn][i]++;
                        return;//when size bin found quit
                    }
                }
                BlipSizeBinns[currentBinn][NumSizeCategories - 1]++;// if we've reached here then it must be the largest
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 4, except, " ERROR: FaultStats.updateBlips: problem updating blips " + (char)13);
            }
        }
        /// <summary>
        /// Update the stats being accumulated in the current binn positions
        /// </summary>
        /// <param name="StreamMask">a bit mask containing any zones that have one or more streams</param>
        public void updateStreams(int StreamMask,int WidthPix)
        {
            int currentBinn = getCurrentBinn();
            double CamFrameTimeSeconds = ((double)Properties.Settings.Default.Camera_FrameHeightPixels) / Properties.Settings.Default.Camera_LineRate_Hz;
            try
            {
                for (int i = 0; i < NumZones; i++)
                {
                    if ((StreamMask & 1 << i) > 0)
                    {
                        StreamZoneBinns[currentBinn][i] += CamFrameTimeSeconds;    //update the zone count
                    }
                }
                if (StreamMask > 0)//only add one frame time into the total if ANY streams present
                    StreamZoneBinns[currentBinn][NumZones] += CamFrameTimeSeconds;//update the total

                for (int i = 0; i < NumSizeCategories - 1; i++)//update the size binns, there are 4 categories but only 3 size bounmdaries
                {
                    if (WidthPix < StreamSizes[i])
                    {
                        StreamSizeBinns[currentBinn][i] += CamFrameTimeSeconds;
                        return;//when size bin found quit
                    }
                }
                StreamSizeBinns[currentBinn][NumSizeCategories - 1] += CamFrameTimeSeconds;// if we've reached here then it must be the largest
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 5, except, " ERROR: FaultStats.updateBlips: problem updating streams " + (char)13);
            }
        }
        /// <summary>
        /// Update the stats being accumulated in the current binn positions
        /// </summary>
        /// <param name="FeintMask">a bit mask containing any zones that have one or more streams</param>
        public void updateFeints(int FeintMask, int WidthPix)
        {
            int currentBinn = getCurrentBinn();
            double CamFrameTimeSeconds = ((double)Properties.Settings.Default.Camera_FrameHeightPixels) / Properties.Settings.Default.Camera_LineRate_Hz;
            try
            {
                for (int i = 0; i < NumZones; i++)
                {
                    if ((FeintMask & 1 << i) > 0)
                    {
                        FeintZoneBinns[currentBinn][i] += CamFrameTimeSeconds;    //update the zone count
                    }
                }
                if (FeintMask > 0)//only add one frame time into the total if ANY streams present
                    StreamZoneBinns[currentBinn][NumZones] += CamFrameTimeSeconds;//update the total

                for (int i = 0; i < NumSizeCategories - 1; i++)//update the size binns, there are 4 categories but only 3 size bounmdaries
                {
                    if (WidthPix < StreamSizes[i])
                    {
                        StreamSizeBinns[currentBinn][i] += CamFrameTimeSeconds;
                        return;//when size bin found quit
                    }
                }
                StreamSizeBinns[currentBinn][NumSizeCategories - 1] += CamFrameTimeSeconds;// if we've reached here then it must be the largest
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 5, except, " ERROR: FaultStats.updateBlips: problem updating streams " + (char)13);
            }
        }
        /// <summary>
        /// Update the stats being accumulated in the current binn positions
        /// </summary>
        public void updateOverload(bool overload)
        {
            int currentBinn = getCurrentBinn();
            double CamFrameTimeSeconds = ((double)Properties.Settings.Default.Camera_FrameHeightPixels) / Properties.Settings.Default.Camera_LineRate_Hz;
            try
            {
                if(overload)
                    OverloadBinns[currentBinn] += CamFrameTimeSeconds;//update the total
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 6, except, " ERROR: FaultStats.updateBlips: problem updating Overloads " + (char)13);
            }
        }
        /// <summary>
        /// Generates plot data in the form required for the NI PlotMultipleXY graph function
        /// i.e. an array of x postions - in our case the zone postions
        /// and an 2D array of points - in our case streams and blips
        /// NOTE: the graph epects the Y data to be formatted in rows, so to get a entry in the rolling map
        /// you give it a value = the current binn position!
        /// A point is displayed for a binn position if there is one or more blip/stream in the binn else the point is
        /// given a negative value so that it isn't dispalyed.
        /// So in summary, the x values are the zones the y values times (binn intervals) and the graph is turned through 90degrees (DataOrientation.DataInRows)
        /// the x values (zones) will run 0-15;0-15...0-15 and the y values will be = the bin value if there is a fault
        /// present e.g. 0 for the first row 1 for the second, 2 for the thrird (for a 1 minute binn interval)
        /// </summary>
        /// <param name="hours">period of hours from NOW for which the plot datashould be generated</param>
        public void GetPlotData(int hours)
        {
            try
            {
                int numXsteps = (hours * 60) / BinnIntervalMins;
                int numdata = numXsteps * NumZones; //we need as many X positions as we have Y positions

                xplot = new double[numdata];
                yplots = new double[4, numdata];

                int index = getCurrentBinn();

                for (int i = 0; i < numXsteps; i++)
                {
                    for (int j = 0; j < NumZones; j++)
                    {
                        xplot[j + (i * NumZones)] = j + 0.5;//NEED TO GENERATE 

                        if (StreamZoneBinns[index][j] > 0)
                            yplots[0, j + (i * NumZones)] = i * BinnIntervalMins + (double)BinnIntervalMins / 2;
                        else
                            yplots[0, j + (i * NumZones)] = -10;
                        if (BlipZoneBinns[index][j] > 0)
                            yplots[1, j + (i * NumZones)] = i * BinnIntervalMins + (double)BinnIntervalMins / 2;
                        else
                            yplots[1, j + (i * NumZones)] = -10;
                        if (OverloadBinns[index] > 0)
                            yplots[2, j + (i * NumZones)] = i * BinnIntervalMins + (double)BinnIntervalMins / 2;
                        else
                            yplots[2, j + (i * NumZones)] = -10;
                        if (FeintZoneBinns[index][j] > 0)
                            yplots[3, j + (i * NumZones)] = i * BinnIntervalMins + (double)BinnIntervalMins / 2;
                        else
                            yplots[3, j + (i * NumZones)] = -10;
                    }
                    if (--index < 0) //check for roll over
                        index = NumBinns - 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 7, except, " ERROR: FaultStats.updateBlips: problem updating streams " + (char)13);
            }
        }
        /// <summary>
        /// Call getStreamTimeByZone with the zone set to the last zone where the totals are kept
        /// </summary>
        /// <param name="periodHours"></param>
        /// <returns></returns>
        public double getTotalStreamTimeS(int periodHours)
        {
            return getStreamTimeByZone(periodHours, NumZones);

        }
        /// <summary>
        /// Get the accummulated overload time for periodHours
        /// </summary>
        /// <param name="periodHours"></param>
        /// <returns></returns>
        public double getTotalOverloadTimeS(int periodHours)
        {
            double OverloadTimeS = 0;
            try
            {
                if (periodHours > BinnDays * 24)
                    periodHours = BinnDays * 24;
                int NumBinnsToAccumulate = periodHours * 60 / BinnIntervalMins;
                int currentBinn = getCurrentBinn();
                int index;
                index = currentBinn;
                for (int i = 0; i < NumBinnsToAccumulate; i++)
                {
                    OverloadTimeS += OverloadBinns[index];
                    if (--index < 0) //check for roll over 
                        index = NumBinns - 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 8, except, " ERROR: FaultStats.getOverloadTimeByZone: problem accumulating Overload times " + (char)13);
            }
            return OverloadTimeS;
        }
        /// <summary>
        /// Get the accummulated stream time for periodHours for a particular zone
        /// </summary>
        /// <param name="periodHours">hours from now to sum</param>
        /// <param name="Zone">zone to sum</param>
        /// <returns>the stream time</returns>
        public double getStreamTimeByZone(int periodHours, int Zone)
        {
            double StreamTimeS = 0;
            try
            {
                if (periodHours > BinnDays * 24)
                    periodHours = BinnDays * 24;
                int NumBinnsToAccumulate = periodHours * 60 / BinnIntervalMins;
                int currentBinn = getCurrentBinn(), index;
                index = currentBinn;
                for (int i = 0; i < NumBinnsToAccumulate; i++)
                {
                    StreamTimeS += StreamZoneBinns[index][Zone];
                    if (--index < 0) //check for roll over 
                        index = NumBinns-1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 9, except, " ERROR: FaultStats.getStreamTimeByZone: problem accumulating stream times " + (char)13);
            }
            return StreamTimeS;
        }
        /// <summary>
        /// Get the accummulated stream time for periodHours for a particular zone
        /// </summary>
        /// <param name="periodHours">hours from now to sum</param>
        /// <param name="Size">Size category to sum</param>
        /// <returns>the stream time</returns>
        public double getStreamTimeBySize(int periodHours, int Size)
        {
            double StreamTimeS = 0;
            try
            {
                if (periodHours > BinnDays * 24)
                    periodHours = BinnDays * 24;
                int NumBinnsToAccumulate = periodHours * 60 / BinnIntervalMins;
                int currentBinn = getCurrentBinn(), index;
                index = currentBinn;
                for (int i = 0; i < NumBinnsToAccumulate; i++)
                {
                    StreamTimeS += StreamZoneBinns[index][Size];
                    if (--index < 0) //check for roll over 
                        index = NumBinns - 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 9, except, " ERROR: FaultStats.getStreamTimeByZone: problem accumulating stream times " + (char)13);
            }
            return StreamTimeS;
        }
        /// <summary>
        /// Call getBlipsTimeByZone with the zone set to the last zone where the totals are kept
        /// </summary>
        /// <param name="periodHours"></param>
        /// <returns></returns>
        public int getTotalBlips(int periodHours)
        {
            return getBlipsByZone(periodHours, NumZones);

        }
        /// <summary>
        /// Get the accummulated blip count for periodHours for a particular zone
        /// </summary>
        /// <param name="periodHours">hours from now to sum</param>
        /// <param name="Zone">zone to sum</param>
        /// <returns>the blip count</returns>
        public int getBlipsByZone(int periodHours, int Zone)
        {
            int Blips = 0, index = 0;
            try
            {
                if (periodHours > BinnDays * 24)
                    periodHours = BinnDays * 24;
                int NumBinnsToAccumulate = periodHours * 60 / BinnIntervalMins;
                int currentBinn = getCurrentBinn();
                index = currentBinn;
                for (int i = 0; i < NumBinnsToAccumulate; i++)
                {
                    Blips += BlipZoneBinns[index][Zone];
                    if (--index < 0) //check for roll over 
                        index = NumBinns-1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 10, except, " ERROR: FaultStats.getBlipsByZone: problem accumulating blip counts " + (char)13);
            }
            return Blips;
        }
        /// <summary>
        /// Get the accummulated blip count for periodHours for a particular zone
        /// </summary>
        /// <param name="periodHours">hours from now to sum</param>
        /// <param name="Size">Size category to sum</param>
        /// <returns>the blip count</returns>
        public int getBlipsBySize(int periodHours, int Size)
        {
            int Blips = 0, index = 0;
            try
            {
                if (periodHours > BinnDays * 24)
                    periodHours = BinnDays * 24;
                int NumBinnsToAccumulate = periodHours * 60 / BinnIntervalMins;
                int currentBinn = getCurrentBinn();
                index = currentBinn;
                for (int i = 0; i < NumBinnsToAccumulate; i++)
                {
                    Blips += BlipSizeBinns[index][Size];
                    if (--index < 0) //check for roll over 
                        index = NumBinns - 1;
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 10, except, " ERROR: FaultStats.getBlipsByZone: problem accumulating blip counts " + (char)13);
            }
            return Blips;
        }
    }
}
