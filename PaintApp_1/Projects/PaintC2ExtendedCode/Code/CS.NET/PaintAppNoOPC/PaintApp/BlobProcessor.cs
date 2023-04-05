using System;

using System.Collections.Generic;
using System.Text;
using Cvb;
using CVBImage = Cvb.Image;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Dsp.Filters;

//using CVBLOBLib;

namespace Pilkngton.ProjectPaint.PaintApp
{
    /// <summary>
    /// this class is not used
    /// it is intended to allow blobs which overlap to have their bounding boxes merged
    /// </summary>
    public class BlobCoord : ErrorReporter
    {
        public int x;
        public int y;
        public int dx;
        public int dy;
        public BlobCoord(int baseErrorNum,ErrorEventHandler handler,int X, int Y, int DX, int DY):
            base(baseErrorNum, handler)
        {
            x = X;
            y = Y;
            dx = DX;
            dy = DY;
        }
    
        public bool vOverlap(ref BlobCoord next, int Bottom, int Top)
        {
            if (this.y == Bottom && next.y == Top) //is this touching the bottom and next touching the top
            {
                if ((this.x >= next.x && this.x <= next.x + next.dx)
                || (this.x + this.dx >= next.x && this.x + this.dx <= next.x + next.dx)
                || (next.x >= this.x && next.x + next.dx <= this.x + this.dx))
                {
                    next.dy += this.dy;
                    next.y = this.y;
                    if (this.x < next.x) next.x = this.x;
                    if (this.x + this.dx > next.x + next.dx) next.dx = (this.x + this.dx) - this.x;
                }
                return true;
            }
            else
                return false;
        }
        public bool hOverlap(ref BlobCoord next,int Right, int Left)
        {
            if (this.x + dx == Right && next.x == Left)
            {
                return true;
            }
            else
                return false;
        }
    }
    /// <summary>
    /// this class is not used
    /// it is intended to hold a listallow blobs which overlap to have their bounding boxes merged
    /// </summary>
    class BlobList
    {
        BlobCoord[] Array;//change to use a <Template> list of BlobCoords
        int maxNum, topPix, bottomPix, leftPix, rightPix;
        BlobList(int MaxNum, int TopPix, int BottomPix, int LeftPix, int RightPix)
        {
            maxNum = MaxNum;
            topPix = TopPix;
            bottomPix = BottomPix;
            leftPix = LeftPix;
            rightPix = RightPix;
            Array = new BlobCoord[MaxNum];    
        }
    }

    /// <summary>
    /// BlobProcessor class provides segmentation and blob analysis functionality
    /// </summary>
    class BlobProcessor : ErrorReporter
    {
        public Blob.BLOB blob;
        //public Foundation.FBLOB blob;
        public int TilePtr;
        public bool saveTileImages = false;
        public AxCVIMAGELib.AxCVimage SrcImage;
        public AxCVDISPLAYLib.AxCVdisplay[] TileArray;
        public int NumTiles;
        public int Left, Top, Right, Bottom;
        public const int topMask = 1;
        public const int bottomMask = 2; 
        public const int streamMask = 3;
        public const int leftMask = 4;
        public const int rightMask = 8;
        public const int allMask = 15;
        public bool darkField =true;
        public double WhiteZoneFraction = 0.05;
        ///<summary>General delegate used when accessing the UI from another thread.  This delegate will be invoked  </summary>
        public delegate void RunOnUIThreadDelegate();
        public byte[] TopLine;
        public byte[] MiddleLine;
        public byte[] BottomLine;
        public byte[] CompositeLine;
        /// <summary>
        /// Constructor: initialises the base class error reporting.
        /// </summary>
        /// <param name="srcImage">the src image to extract blobs from</param>
        public BlobProcessor(int baseErrorNum,ErrorEventHandler handler,AxCVIMAGELib.AxCVimage srcImage):
            base(baseErrorNum, handler)//next available +7
        {
            WhiteZoneFraction = Properties.Settings.Default.Image_WhiteBoardFactor;
            SrcImage = srcImage;
            //blob = Foundation.FBlobCreate(srcImage.Image, 0);
            //Foundation.FBlobSetArea(blob,0,0,0,(int)SrcImage.AreaX1, (int)SrcImage.AreaY2);            
            blob = Blob.Create(srcImage.Image, 0);
            if (Blob.IsBlob(blob))
            {
                Left = 0;
                Top = 0;
                Right = (int)SrcImage.AreaX1;
                Bottom = (int)SrcImage.AreaY2;
                Blob.SetArea(blob, 0, Left, Top, Right, Bottom);
            }
            int imgWidth = Cvb.Image.ImageWidth(SrcImage.Image);
            TopLine = new byte[imgWidth];
            MiddleLine = new byte[imgWidth];
            BottomLine = new byte[imgWidth];
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="srcImage">the src image to extract blobs from</param>
        /// <param name="left">ROI X1</param>
        /// <param name="top">ROI Y1</param>
        /// <param name="right">ROI X2</param>
        /// <param name="bottom">ROI Y2</param>
        public BlobProcessor(int baseErrorNum,ErrorEventHandler handler,AxCVIMAGELib.AxCVimage srcImage, int left, int top, int right, int bottom) :
            base(baseErrorNum,handler)
        {
            SrcImage = srcImage;
            //blob = Foundation.FBlobCreate(srcImage.Image, 0);
            //Foundation.FBlobSetArea(blob, 0, left, top, right, bottom);

            blob = Blob.Create(srcImage.Image, 0);
            if (Blob.IsBlob(blob))
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
                Blob.SetArea(blob, 0, Left, Top, Right, Bottom);
            }               
        }
        /// <summary>
        /// Sets the horizontal region of interest so that the blob detection is limited to the new ROI.
        /// this is done to excelude overlap in the center or to remove edge effects where the FOV extends beyond
        /// the object being imaged.
        /// </summary>
        /// <param name="XstartPix"></param>
        /// <param name="XendPix"></param>
        public void setHorizontalROI(int XstartPix, int XendPix)
        {
            if (Blob.IsBlob(blob))
            {
                Left = XstartPix;
                Right = XendPix;

                Blob.SetArea(blob, 0, Left, Top, Right, Bottom);
            }
        }
        /// <summary>
        /// Set the detection parameters
        /// </summary>
        /// <param name="MaxNumBlobs">this limits memory consumption - will throw an exception if exceeded</param>
        /// <param name="MaxNumBlobsSorted">the maximum number of blobs to sort</param>
        /// <param name="SortDescending">true - sort biggest to smallest: false - sort smallest to biggest</param>
        /// <param name="Threshold">threshold for binarization</param>
        /// <param name="Darkfield">true - look for white objects on a black background: false look for black objects on a white background</param>
        public void ConfigureDetection(int MaxNumBlobs, int MaxNumBlobsSorted,int MinArea, bool SortDescending, int Threshold, bool Darkfield)
        {
            darkField = Darkfield;
            //Foundation.FBlobSetMaxExecTime(blob, 800);
            //Foundation.FBlobSetObjectFeature(blob, Threshold, Darkfield ? (int)Foundation.BlobFeatureType.FBLOB_WHITE_TO_FEATURE : (int)Foundation.BlobFeatureType.FBLOB_BLACK_TO_FEATURE);

            //Foundation.FBlobSetObjectFeatureRange(blob, Threshold, 256);
            ////Foundation.FBlobSetObjectTouchBorder(blob, Foundation.BlobTouchBorderFilter.FBLOB_BORDER_NONE);
            ////Foundation.FBlobSetSkipBinarization(blob, false);

            //Foundation.FBlobSetSortMode(blob, Foundation.BlobSortMode.FBLOB_SORT_SIZE, -1, -1, MaxNumBlobsSorted, (int)Foundation.BlobSortDirection.FBLOB_SORT_FALLING);
            if (Blob.IsBlob(blob))
            {
                Blob.SetExtractionMode(blob, Blob.TExtractionMode.NONE);//only blob size and bounding box calculated to save time
                Blob.SetMaxMemoryEx(blob, MaxNumBlobs, 0);//if this is set low and is exceeded it siezes up the processing
                //the sorting has been changed from size(biggest to smallest)to closenes to the LH edge 
                //i.e. most likely to be on the plate. This ensures they get reported first via the blip line and position
                Blob.SetSortMode(blob, Cvb.Blob.TSortMode.POSX, -1, -1, MaxNumBlobsSorted, Cvb.Blob.TSortOrder.RISING);//only deal with the top 100 blobs - this seems to limits the number of blobs to 100?!
                if (MinArea>0 && MinArea<1000) 
                    Blob.SetLimitArea(blob, MinArea, -1);
                else
                    OnError(BaseERRNUM + 1, null, " ERROR: BlobProcessor.ConfigureDetection:: attempt to set Min Area to > 1000 pixels " + (char)13);
                Blob.SetObjectFeature(blob, Threshold, Darkfield ? Blob.TObjectFeature.WHITE_TO_FEATURE : Blob.TObjectFeature.BLACK_TO_FEATURE);
            }   
        }
        /// <summary>
        /// Configure tile image saving
        /// </summary>
        /// <param name="numTiles">number of destination images in the tile array</param>
        /// <param name="tileArray">an array of image displays to write the tile images into</param>
        /// <param name="SaveTiles">whether or not to save tiles</param>
        public void ConfigureTiles(int numTiles, AxCVDISPLAYLib.AxCVdisplay[] tileArray,bool SaveTiles)
        {
            saveTileImages = SaveTiles;
            NumTiles = numTiles;
            TileArray = tileArray;
        }
        /// <summary>
        /// Checks if the object is touching the top and bottom of the image, if so it is classified as a stream
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dx"></param>
        /// <param name="y"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public int checkForStream(int x, int dx, int y, int dy)
        {
            if (y == (int)SrcImage.AreaY1 && dy == (int)SrcImage.AreaY2)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// check if the object is touching the top, the bottom or the top and bottom of the image, the latter is classified as a stream
        /// also check if the object is touching the left or right or both
        /// bit0 signifies touching the top
        /// bit1 signifies touching the bottom
        /// bit2 signifies touching the left
        /// bit3 signifies touching the right
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dx"></param>
        /// <param name="y"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public int getBorderMask(int x, int dx, int y, int dy)
        {
            int borderMask = 0;

            //if (y == (int)SrcImage.AreaY1)
            //    borderMask += topMask;
            //if (dy+y == (int)SrcImage.AreaY2)
            //    borderMask += bottomMask;
            //if (x == (int)SrcImage.AreaX1)
            //    borderMask += leftMask;
            //if (dx+x == (int)SrcImage.AreaX2)
            //    borderMask += rightMask;

            if (y == Top)
                borderMask += topMask;
            if (dy + y == Bottom)
                borderMask += bottomMask;
            if (x == Left)
                borderMask += leftMask;
            if (dx + x == Right)
                borderMask += rightMask;  

            return borderMask;
        }
        /// <summary>
        /// Returns the next Tile Array Index
        /// </summary>
        /// <returns>Tile Array Index</returns>
        public int getTileArrayIndex(out int previndex)
        {
            int retval = TilePtr;
            previndex = TilePtr > 0 ? TilePtr - 1 : NumTiles - 1;
            if (TilePtr < NumTiles-1)
                TilePtr++;
            else
                TilePtr = 0;
            return retval;
        }
                /// <summary>
        /// Returns a horizontal line from the image as an array
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="data"></param>
        public void getLineFromImage(int lineNum,ref byte[] data)
        {

            try
            {
                unsafe
                {
                    int imgHeight = Cvb.Image.ImageHeight(SrcImage.Image);
                    int imgWidth = Cvb.Image.ImageWidth(SrcImage.Image);
                    if (lineNum < 0 || lineNum > imgHeight)
                    {
                        OnError(BaseERRNUM + 2, null, " ERROR: BlobProcessor.GetLineFromImage::  problem requested line number" +lineNum.ToString()+ " outside of image coordinates " + (char)13);
                        return;
                    }
                    IntPtr imageBaseAddress;
                    IntPtr addrVPAT;
                    Cvb.Image.VPAEntry* pVPAT;
                    byte* pImageLine;

                    Cvb.Image.GetImageVPA(SrcImage.Image, 0, out imageBaseAddress, out addrVPAT);
                    pVPAT = (Cvb.Image.VPAEntry*)addrVPAT.ToPointer();
                    pImageLine = (byte*)imageBaseAddress + (int)pVPAT[lineNum].YEntry;
                    for (int x = 0; x < imgWidth; x++)
                    {
                        data[x] = *(pImageLine + (int)pVPAT[x].XEntry);
                    }
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 3, except, " ERROR: BlobProcessor.GetLineFromImage::  problem recovering line of data from image" + (char)13);
            }
        }
        /// <summary>
        /// Returns a horizontal line from the image as an array
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="data"></param>
        public void getLineFromImage(int lineNum,ref double[] data)
        {

            try
            {
                unsafe
                {
                    int imgHeight = Cvb.Image.ImageHeight(SrcImage.Image);
                    int imgWidth = Cvb.Image.ImageWidth(SrcImage.Image);
                    if (lineNum < 0 || lineNum > imgHeight)
                    {
                        OnError(BaseERRNUM + 2, null, " ERROR: BlobProcessor.GetLineFromImage::  problem requested line number" +lineNum.ToString()+ " outside of image coordinates " + (char)13);
                        return;
                    }
                    IntPtr imageBaseAddress;
                    IntPtr addrVPAT;
                    Cvb.Image.VPAEntry* pVPAT;
                    byte* pImageLine;

                    Cvb.Image.GetImageVPA(SrcImage.Image, 0, out imageBaseAddress, out addrVPAT);
                    pVPAT = (Cvb.Image.VPAEntry*)addrVPAT.ToPointer();
                    pImageLine = (byte*)imageBaseAddress + (int)pVPAT[lineNum].YEntry;
                    for (int x = 0; x < imgWidth; x++)
                    {
                        data[x] = *(pImageLine + (int)pVPAT[x].XEntry);
                    }
                }
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 3, except, " ERROR: BlobProcessor.GetLineFromImage::  problem recovering line of data from image" + (char)13);
            }
        }
        /// <summary>
        /// Predicts if a processing Overload will occur by extracting 3 lines from the image (top, middle, bottom)
        /// and determining the fraction of pixels that are above the threshold
        /// </summary>
        /// <param name="threshold">threshold</param>
        /// <param name="overloadfactor">the factor above which overload is predicted</param>
        /// <param name="whiteStartZone">an extra function tagged on to looked at the begining for white pixels - ignored if set to 0</param>
        /// <param name="whiteEndZone">an extra function tagged on to looked at the end for white pixels - ignored if set to 0</param>
        /// <param name="ZoneIsWhite">true if white pixels seen at the begining or end</param>
        /// <returns></returns>
        public bool predictOverload(int threshold,double overloadfactor,int whiteStartZone,int whiteEndZone,out bool ZoneIsWhite)
        {
            ZoneIsWhite = false;
            try
            {
                int NumPix = 0, NumWhiteZonePix = 0;
                int imgHeight = Cvb.Image.ImageHeight(SrcImage.Image);
                int imgWidth = Cvb.Image.ImageWidth(SrcImage.Image);

                getLineFromImage(0, ref TopLine);
                getLineFromImage((imgHeight / 2)-1, ref MiddleLine);
                getLineFromImage(imgHeight-1, ref BottomLine);

                CompositeLine = new byte[imgWidth];
                for (int i = 0; i < imgWidth; i++)
                {
                    if (TopLine[i] > threshold)
                    {
                        NumPix++;
                        if (whiteStartZone > 0 && i < whiteStartZone) NumWhiteZonePix++;
                        if (whiteEndZone > 0 && i > whiteEndZone) NumWhiteZonePix++;
                    }
                    if (MiddleLine[i] > threshold)
                    {
                        NumPix++;
                    }
                    if (BottomLine[i] > threshold)
                    {
                        NumPix++;
                    }
                    //compute the median
                    CompositeLine[i] = Math.Max(Math.Max(Math.Min(TopLine[i],MiddleLine[i]),Math.Min(TopLine[i],BottomLine[i])),Math.Min(MiddleLine[i],BottomLine[i]));                 
                }
                double fractionAboveThresh = (((double)NumPix) / (imgWidth * 3));
                double fractionZoneAboveThresh;
                if((whiteStartZone + whiteEndZone) >0)
                {
                    fractionZoneAboveThresh = (((double)NumWhiteZonePix) / ((whiteStartZone + imgWidth-whiteEndZone) * 3));
                    if (fractionZoneAboveThresh > WhiteZoneFraction)
                        ZoneIsWhite = true;

                }
                if (fractionAboveThresh > overloadfactor)
                    return true;
                else
                    return false;
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 4, except, " ERROR: BlobProcessor.predictOverload::  problem recovering lines of data from image" + (char)13);
            }
            return false;
        }
        /// <summary>
        /// Process the image for blips and streams
        /// </summary>
        /// <param name="blips">the number of blips</param>
        /// <param name="streams">the number of streams</param>
        /// <returns>the number of blobs (blips + streams)</returns>
        public int Process(int threshold)
        {
            int foundBlobs = 0;

            try
            {
                // set threshold
                Blob.SetObjectFeature(blob, threshold, this.darkField ? Blob.TObjectFeature.WHITE_TO_FEATURE : Blob.TObjectFeature.BLACK_TO_FEATURE);
                //Blob.SetObjectFeatureRange(blob, threshold, 256);
                //Foundation.FBlobSetObjectFeatureRange(blob, threshold, 256);
                // execute blob
                int retval = Blob.Exec(blob);
                if (retval != (int)Cvb.Error.CVC_ERROR_CODES.CVC_E_OK)
                    return -1;
                //Foundation.FBlobExec(blob);
                // get blob results
                Blob.GetNumBlobs(blob, out foundBlobs);
                //Foundation.FBlobGetNumBlobs(blob, out foundBlobs);
                Blob.Sort(blob);
                //Foundation.FBlobSort(blob);
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 5, except, " ERROR: BlobProcessor.Process:  problem whilst analysing or reporting blobs " + (char)13);

            }
            return foundBlobs;
        }
        /// <summary>
        /// Copies a tile from the source image at the blob's coordinates into the tile display at the current index
        /// </summary>
        /// <param name="BlobNumber">the blob whoose bounding box specifies the tile's extent</param>
        /// <param name="x">the start x postion</param>
        /// <param name="y">the start y postion</param>
        /// <param name="dx">the horizontal extent</param>
        /// <param name="dy">the vertical extent</param>
        /// <param name="index">the index into the array of tile image displays</param>
        /// <param name="previndex">the previous index so that the led indicator can be turned off</param>
        public void DisplayTile(int BlobNumber,int x, int y,int dx, int dy, out int index, out int previndex)
        {
//            int x = 0, y = 0, dx = 0, dy = 0;
            previndex = 0;
            index = 0;
            Cvb.Image.IMG ImgPtr;
            try
            {
                bool ImageMapOK = CVBImage.CreateImageMap(SrcImage.Image, x, y, x + dx, y + dy, dx + 1, dy + 1, out ImgPtr);
                if (ImageMapOK)
                {
                    index = getTileArrayIndex(out previndex);
                    //TileArray[previndex].Lock();
                    //TileArray[previndex].Appearance = CVDISPLAYLib.Appearance.Flat;
                    //TileArray[previndex].Refresh();
                    //TileArray[previndex].Unlock();
                    TileArray[index].Lock();
                    TileArray[index].Image = ImgPtr;
                    //TileArray[index].Appearance = CVDISPLAYLib.Appearance.ThreeDimensional;
                    TileArray[index].Refresh();
                    if (saveTileImages) 
                        TileArray[index].SaveImage(Properties.Settings.Default.Report_ImageDir+DateTime.Now.ToString("yyyyMMdd HH.mm.ss") + " Tile"+index.ToString()+".jpg");
                    
                    TileArray[index].Unlock();
                }
                CVBImage.ReleaseImage(ImgPtr);
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 6, except, " ERROR: BlobProcessor.Process:  problem refreshing tile image " + (char)13);
            }
        }
    }
    public class FeintStreamDetector : ErrorReporter
    {
        public int Height, Width, Left, Right;
        public Queue<byte[]> LineQ;
        public double[] LineAverageY, ROILineAverageY, ROILineAverageX, FilteredY;// LineFitPlotY;
        
        public NationalInstruments.Analysis.Dsp.Filters.WindowedFirBandpassFilter BPFilter;
        public double PixPermm;
        public FeintStreamDetector(int baseErrorNum, ErrorEventHandler handler, int height, int width,double pixPermm):
            base(baseErrorNum, handler)//next available +0
        {
            Height = height;
            Width = width;
            PixPermm = pixPermm;
            LineQ = new Queue<byte[]>(height);
            LineAverageY = new double[Width];
            ROILineAverageX = new double[Width];
            ROILineAverageY = new double[Width];
            FilteredY = new double[Width];
            //LineFitPlotY = new double[Width];
            //BPFilter = new WindowedFirBandpassFilter
        }
        public bool QIsFull()
        {
            if (LineQ.Count >= Height)
                return true;
            else
                return false;
        }
        public bool AddNewLine(ref byte[] newLine)
        {
            bool retval = false;
            byte[] lastLine;
            if (retval = QIsFull())
            {
                lastLine = LineQ.Dequeue();
                for (int i = 0; i < Width; i++)
                {
                    LineAverageY[i] = LineAverageY[i] + (newLine[i] / (Height*1.0)) - (lastLine[i] / (Height*1.0));//add in the current subtract the oldest both scaled
                }
            }
            else
            {
                for (int i = 0; i < Width; i++)
                {
                    LineAverageY[i] = LineAverageY[i] + (newLine[i] / (Height*1.0));//not charged yet so just add in the current
                }
            }
            LineQ.Enqueue(newLine);
            return retval;
        }
        public int FilterAndCheck(int ThreshOffset)
        {
            for (int i = 0; i < (Right - Left + 1); i++)
            {
                ROILineAverageY[i] = LineAverageY[Left + i];//copy the ROI data so the curve fitting/filtering only works on the ROI
            }
            if (Properties.Settings.Default.Image_FeintStreamFIRnotPolyFit)
            {
                double mmPerPix = 1.0/PixPermm;
                double SampleFreq = 1000.0/(1.0*mmPerPix);//freq in per metre
                double lowerCutOffFreq = 1000.0 / (Properties.Settings.Default.Image_FeintStreamMaxSize_mm * mmPerPix);//freq in per metre
                double upperCutOffFreq = 1000.0 / (Properties.Settings.Default.Image_FeintStreamMinSize_mm * mmPerPix);//freq in per metre
                int NumberCoefficients = Properties.Settings.Default.Image_FeintStreamFIRWidth;
                BPFilter = new WindowedFirBandpassFilter(SampleFreq, lowerCutOffFreq, upperCutOffFreq, NumberCoefficients, FirWindowType.Gaussian);//FirWindowType.Hamming);
                FilteredY = BPFilter.FilterData(ROILineAverageY);
 //               for (int i = (NumberCoefficients / 2) ;  i < (Right - Left + 1 - (NumberCoefficients / 2)) ;  i++)
                for (int i = 0 ;  i < FilteredY.Length ;  i++)
                {
                    if (FilteredY[i] >= ThreshOffset)
                        return i;//find the first excursion through the threshold
                }
            }
            else
            {
                int PolynomialOrder = Properties.Settings.Default.Image_FeintStreamPolyOrder;
                FilteredY = CurveFit.PolynomialFit(ROILineAverageX, ROILineAverageY, PolynomialOrder, PolynomialFitAlgorithm.QR);
                for (int i = 0; i < (Right - Left + 1); i++)
                {
                    if (ROILineAverageY[i] >= FilteredY[i] + ThreshOffset)
                        return i;//find the first excursion through the threshold
                }
            }

            return -1;
        }
        /// <summary>
        /// Sets the horizontal region of interest so that the blob detection is limited to the new ROI.
        /// this is done to excelude overlap in the center or to remove edge effects where the FOV extends beyond
        /// the object being imaged.
        /// </summary>
        /// <param name="XstartPix"></param>
        /// <param name="XendPix"></param>
        public void setHorizontalROI(int XstartPix, int XendPix)
        {
            Left = XstartPix;
            Right = XendPix;
            ROILineAverageX = new double[Right - Left+1];
            ROILineAverageY = new double[Right - Left + 1];
            for (int i = 0; i < (Right - Left + 1); i++)
                ROILineAverageX[i] = (double)i;
        }
    }
}
