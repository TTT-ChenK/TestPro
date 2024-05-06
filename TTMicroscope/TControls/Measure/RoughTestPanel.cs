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
    public partial class RoughTestPanel : UserControl
    {
        public RoughTestPanel()
        {
            InitializeComponent();
        }

        private void RoughTestPanel_Load(object sender, EventArgs e)
        {
            CalStand_Cbx.SelectedIndex = 0;
            SFilt_Cbx.SelectedIndex = 0;
            LFilt_Cbx.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        public  void SetResult(double[] result)
        { 
            if (result !=null&&result.Length==7) {
                string filt = "F2";
                Sq_Tbx.Text = result[0].ToString(filt);
                Ssk_Tbx.Text = result[1].ToString(filt);
                Sku_Tbx.Text = result[2].ToString(filt);
                Sp_Tbx.Text = result[3].ToString(filt);
                Sv_Tbx.Text = result[4].ToString(filt);
                Sz_Tbx.Text = result[5].ToString(filt);
                Sa_Tbx.Text = result[6].ToString(filt);
            }
        }

        private void Rough_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
