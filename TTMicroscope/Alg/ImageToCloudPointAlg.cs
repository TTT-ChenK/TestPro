using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TTMicroscope
{
    public class ImageToCloudPointAlg
    {
        //private const string dllPath = "arrayfire_test2.dll";

        //[DllImport("arrayfire_test2.dll", EntryPoint = "init")]
        //public static extern bool WLIInit(int rows, int cols);

        //[DllImport("arrayfire_test2.dll", EntryPoint = "mainAlgo")]
        //public static extern bool WLIMainAlgo();

        //[DllImport("arrayfire_test2.dll", EntryPoint = "addPicture")]
        //public static extern bool WLIAddPicture(int index, IntPtr data);

        //[DllImport("arrayfire_test2.dll", EntryPoint = "getResult")]
        //public static extern bool WLIGetResult(IntPtr result);

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
