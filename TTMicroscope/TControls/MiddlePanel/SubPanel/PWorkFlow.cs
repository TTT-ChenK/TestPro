using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TTMicroscope
{
    public partial class PWorkFlow : UserControl
    {
        public PWorkFlow()
        {
            InitializeComponent();
        }

        private void PWorkFlow_Resize(object sender, EventArgs e)
        {
            tGroupBox3.Height = Height - tGroupBox2.Bottom - 10;
            msgInfo_Lbx.Height = tGroupBox3.Height - 80;
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        public void ShowMsg(string content)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    string str = string.Format("{0} {1}", time, content);
                    msgInfo_Lbx.Items.Insert(0, str);
                }));
            }catch(Exception ex) { }
        }

        private void wliWorkFlow1_Load(object sender, EventArgs e)
        {

        }
    }
}
