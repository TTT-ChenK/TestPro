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
    public partial class LoadFilePanel : UserControl
    {
        public LoadFilePanel()
        {
            InitializeComponent();
        }

        private void LoadFilePanel_Load(object sender, EventArgs e)
        {
            CGlobal.analisisCfg.LoadAnalysisConfig();
            SetCfg();
        }

        /// <summary>
        /// 设置
        /// </summary>
        public void SetCfg()
        { 
            ReloX_Tbx.Text=CGlobal.analisisCfg.XRolution.ToString();
            ReloY_Tbx.Text = CGlobal.analisisCfg.YRolution.ToString();
            ReloZ_Tbx.Text = CGlobal.analisisCfg.ZRolution.ToString();
        }

        private void ReloX_Tbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CGlobal.analisisCfg.XRolution=float.Parse(ReloX_Tbx.Text);
                CGlobal.analisisCfg.YRolution= float.Parse(ReloY_Tbx.Text);
                CGlobal.analisisCfg.ZRolution=float.Parse(ReloZ_Tbx.Text);
            }
            catch {
                MessageBox.Show("数据格式有误."); }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.analisisCfg.SaveAnalysisConfig(CGlobal.analisisCfg);
        }

        private void Load_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
