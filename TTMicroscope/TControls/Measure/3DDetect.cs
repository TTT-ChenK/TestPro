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
    public partial class _3DDetect : UserControl
    {
        public _3DDetect()
        {
            InitializeComponent();
        }
        public event EventHandler On3DButtonClicked;

        private void _3DDetect_Load(object sender, EventArgs e)
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
            if (On3DButtonClicked != null)
                On3DButtonClicked(send, e);
        }
    }
}
