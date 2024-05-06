using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TTMicroscope.TControls
{
    public class ControlsPublic
    {
        #region Move

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x112;
        private const int HTCAPTION = 0x0002;
        private const int SC_MOVE = 0xF010;


        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="hwnd"></param>
        public static void Move(IntPtr hwnd)
        {
            //调动系统函数移动窗体
            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        /// <summary>
        /// 获取圆角
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static GraphicsPath Round(Rectangle rectangle,int radius)
        {
            Region region1;
            GraphicsPath oPath = new GraphicsPath();
            int x = 0;
            int y = 0;
            int thisWidth = rectangle.Width;
            int thisHeight = rectangle.Height;
            int angle = radius;
            if (angle > 0)
            {
                oPath.AddArc(x, y, angle, angle, 180, 90);                                 // 左上角
                oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);                 // 右上角
                oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);  // 右下角
                oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90);                 // 左下角
                oPath.CloseAllFigures();
                region1 = new Region(oPath);
            }
            else
            {
                oPath.AddLine(x + angle, y, thisWidth - angle, y);                         // 顶端
                oPath.AddLine(thisWidth, y + angle, thisWidth, thisHeight - angle);        // 右边
                oPath.AddLine(thisWidth - angle, thisHeight, x + angle, thisHeight);       // 底边
                oPath.AddLine(x, y + angle, x, thisHeight - angle);                        // 左边
                oPath.CloseAllFigures();
                region1 = new Region(oPath);
            }
            oPath.Flatten(new Matrix(), 0.001f);
            return oPath;
        }
    }
}
