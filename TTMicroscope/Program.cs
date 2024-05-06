using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTMicroscope.TControls;

namespace TTMicroscope
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Process[] P= Process.GetProcessesByName("TMicroscopeAlg");
            //if (P.Length > 0)
            //{ MessageBox.Show("程序已运行");return;}

            Application.Run(new Main());

            
        }
    }
}
