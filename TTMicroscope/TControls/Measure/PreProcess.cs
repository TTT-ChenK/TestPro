using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class PreProcess : UserControl
    {
        public PreProcess()
        {
            InitializeComponent();
        }


        public event EventHandler OnPreProcessButtonClicked;
        private void PreProcess_Load(object sender, EventArgs e)
        {
            foreach (Control cl in this.Controls)
            {
                try
                {
                    Button bt = cl as Button;
                    cl.Click += BtnClicked;
                }
                catch { }
            }
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        public void BtnClicked(Object send, EventArgs e)
        {
            if (OnPreProcessButtonClicked != null)
                OnPreProcessButtonClicked(send, e);
        }
    }
}
