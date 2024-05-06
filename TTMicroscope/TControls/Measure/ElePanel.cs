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
    public partial class ElePanel : UserControl
    {
        public ElePanel()
        {
            InitializeComponent();
        }
        public event EventHandler OnEleButtonClicked;
        private void Cloud3D_Btn_Click(object sender, EventArgs e)
        {

        }

        private void ElePanel_Load(object sender, EventArgs e)
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

        private void BtnClicked(object sender, EventArgs e)
        {
            if (OnEleButtonClicked != null)
            { OnEleButtonClicked(sender, e); }
        }
    }
}
