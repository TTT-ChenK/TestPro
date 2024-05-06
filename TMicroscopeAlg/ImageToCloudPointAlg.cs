using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TMicroscopeAlg
{
    public class ImageToCloudPointAlg
    {
        #region PAlg.dll
        [DllImport("TTTPoints.dll", EntryPoint = "Init")]
        public static extern int Init(int _imageCount, int _rows, int _cols, int _stepsSize);
        [DllImport("TTTPoints.dll")]
        public static extern int LoadFoldImages(IntPtr imgFoldPath);
        [DllImport("TTTPoints.dll")]
        public static extern int LoadImageFile(IntPtr imgFilePath, int index);
        [DllImport("TTTPoints.dll")]
        public static extern int PreProcess();
        [DllImport("TTTPoints.dll")]
        public static extern IntPtr ImageToPoints(int imgCount);
        [DllImport("TTTPoints.dll")]
        public static extern int PostBuffer(int imgCount);
        [DllImport("TTTPoints.dll")]
        public static extern int FreeAndDispose();
        [DllImport("TTTPoints.dll")]
        public static extern int FreeAndDispose2();

        [DllImport("TTTPoints.dll")]
        public static extern int TransImageData(IntPtr data, int index);
        [DllImport("TTTPoints.dll")]
        public static extern int WLISaveResult(IntPtr saveFilePath);
        [DllImport("TTTPoints.dll")]
        public static extern int TransImageData2();
        [DllImport("TTTPoints.dll")]
        public static extern int TransImageData3(int index);
        #endregion
    }
}
