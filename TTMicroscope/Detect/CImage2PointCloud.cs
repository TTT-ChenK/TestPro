using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WLIAlgo;
using System.Drawing;


namespace TTMicroscope
{
    public class CImage2PointCloud
    {
        static  WLIAlgoWrapper wrapper = new WLIAlgoWrapper();
        public static int picH = 1024;
        public static int PicW = 1024;
        public static int imgIndex = 0;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="picHeight"></param>
        /// <param name="picWidth"></param>
        /// <returns></returns>
        public static string Init(int picHeight, int picWidth,int totalImageCount,int stepSize)
        {
            imgIndex = 0;
            string re = null;
            //wrapper.Init(picHeight, picWidth, re);
            int ree=ImageToCloudPointAlg.Init(totalImageCount, picHeight, picWidth, stepSize);

            return re;  
        }


        public static void AddPic(byte[] imgPtr,int index)
        {
            Mat mat = new Mat(picH, PicW, MatType.CV_8UC1);
            Marshal.Copy(imgPtr, 0, mat.Data, picH*PicW);
            // mat = mat.Transpose();
            int reI = ImageToCloudPointAlg.TransImageData(mat.Data, index);
            SaveImage(mat, index);     
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="bt"></param>
        /// <param name="index"></param>
        public static void SaveImage(Mat bitMapArray, int index)
        {
            if (!Directory.Exists(CGlobal.resultSaveFold))
            { Directory.CreateDirectory(CGlobal.resultSaveFold); }
            //if (CGlobal.cameracfg.IsSaveImage)
            //{
            //    Task.Run(() =>
            //    {

            //        string fileName = Path.Combine(CGlobal.resultSaveFold, index.ToString() + ".png");
            //        bitMapArray.SaveImage(fileName);
            //        bitMapArray.Dispose();
            //        //bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            //    });
            //}
        }


        public static string DetectMainMethod0()
        {
            string re = null;
            //wrapper.MainAlgo(re);
            //Mat result = new Mat(picH, PicW, MatType.CV_32FC1);
            //wrapper.GetResult(result.Data, re);
            //Cv2.Rotate(result, result, RotateFlags.Rotate180);
            //float[] resArray = new float[result.Total()];

            //Marshal.Copy(result.Data, resArray, 0, resArray.Length);
            //SaveData(CGlobal.resultSaveFold+"\\result.txt", resArray, PicW, picH);
            return re;
        }

        public static string DetectMainMethod()
        {
            string re = null;
            IntPtr reP = ImageToCloudPointAlg.ImageToPoints(200);
            float[] resultArray = new float[picH * PicW];
            // 从IntPtr指针ptr中拷贝数据到resultArray数组
            if (reP != null)
            {
                Marshal.Copy(reP, resultArray, 0, picH * PicW);
                SaveData(CGlobal.resultSaveFold + "\\result.txt", resultArray, PicW, picH);
            }
            return re;
        }


        public static void SaveData(string savePath, float[] data, int rows, int cols)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < cols; k++)
                {
                    sb.Append(Convert.ToString(Math.Round(data[i * cols + k], 6)));
                    if (k != cols - 1)
                        sb.Append(',');
                }
                sb.Append('\n');
            }
            string str = sb.ToString();
            SaveTextToFile(str, savePath);
        }

        private static bool SaveTextToFile(string str, string targetPath)
        {
            try
            {
                if (File.Exists(targetPath))
                    File.Delete(targetPath);

                FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate);

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(str);
                }
                fs.Dispose();
            }
            catch (IOException)
            {
                Console.WriteLine();
            }
            return true;
        }
    }
}
