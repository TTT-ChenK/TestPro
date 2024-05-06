using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace TTMicroscope
{
    public class CFocusAlg
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="flag">1-方差，0-拉普拉斯，3-索贝尔</param>
        /// <returns></returns>
        public static double GetImgQualityScore(Mat src, int flag)
        {
            Mat imgLaplance = new Mat();
            Mat imageSobel = new Mat();
            Mat meanValueImage = new Mat();
            Mat meanImage = new Mat();
            Mat BlurMat = new Mat();
            Mat gray = new Mat();
            gray = src;
            //Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            //中值模糊 降低图像噪音
            //Cv2.MedianBlur(gray, BlurMat, 5);
            Cv2.BoxFilter(gray, BlurMat, MatType.CV_8UC3, new OpenCvSharp.Size(11, 11));
            string method = string.Empty;
            double meanValue = 0;
            if (flag == 1)
            {
                //方差法
                Cv2.MeanStdDev(BlurMat, meanValueImage, meanImage);
                meanValue = meanImage.At<double>(0, 0);
                method = "MeanStdDev";
            }
            else if (flag == 0)
            {
                //拉普拉斯
                Cv2.Laplacian(BlurMat, imgLaplance, MatType.CV_16S, 5, 1);
                Cv2.ConvertScaleAbs(imgLaplance, imgLaplance);
                //结果放大两倍,拉开差距
                meanValue = Cv2.Mean(imgLaplance)[0] * 2;
                method = "Laplacian";
            }
            else
            {
                //索贝尔
                Cv2.Sobel(BlurMat, imageSobel, MatType.CV_16S, 3, 3, 5);
                Cv2.ConvertScaleAbs(imageSobel, imageSobel);
                //结果放大两倍,拉开差距
                meanValue = Cv2.Mean(imageSobel)[0] * 2;
                method = "Sobel";

            }
            return meanValue;
        }

        public static Mat Bitmap2Mat(Bitmap bitmap)
        {
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);//用
            return mat;
        }

        public static Bitmap Mat2MBitmap(Mat mat)
        {

            Bitmap map = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
            return (Bitmap)map.Clone();

        }
    }
}
