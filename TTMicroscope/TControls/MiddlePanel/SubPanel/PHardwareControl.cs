using KMotions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TTMicroscope
{
    public partial class PHardwareControl : UserControl
    {
        public PHardwareControl()
        {
            InitializeComponent();
        }
        Button[] methodArr = new Button[3];

        public event MotorClickHandle OnMotorClick;
        #region Method

        public void ShowAxisPos(CAxisStatue[] cAxisStatueArr)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    string[] valueArr = new string[3] {
                    (cAxisStatueArr[0].PosPulse*1000).ToString("F1"),
                    (cAxisStatueArr[1].PosPulse*1000).ToString("F1"),
                    (cAxisStatueArr[2].PosPulse*1000).ToString("F2"),
                    };
                    tDataTable1.ValueArr = valueArr;
                    //tDataTable1.Refresh();

                }));
            }
            catch { }
        }


        #endregion
        private void FPizoCfg_Click(object sender, EventArgs e)
        {
        }

        private void PHardwareControl_Resize(object sender, EventArgs e)
        {
            //tGroupBox2.Height = Height - tGroupBox1.Bottom - 10;
        }

        private void Method1_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            for (int i = 0; i < methodArr.Length; i++)
            {
                if (methodArr[i] == bt)
                { 
                    bt.BackColor = Color.LightBlue;
                    bt.Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Bold);
                }   
                else { 
                    methodArr[i].BackColor = Color.WhiteSmoke;
                    methodArr[i].Font = new Font("微软雅黑", 10, System.Drawing.FontStyle.Regular);
                };
            } 
        }

        private void PHardwareControl_Load(object sender, EventArgs e)
        {
            methodArr = new Button[3] { Method1_Btn, Method2_Btn, Method3_Btn};
            methodArr[2].BackColor = Color.LightBlue;
            methodArr[2].Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Bold);
            Parameter_Cbx.SelectedIndex = 0;
            AxisIndex_Cbx.SelectedIndex = 1;
            tMotorManual1.OnMotorClick += TMotorManual1_OnMotorClick;
            ReadFormCfg();
        }

        private void TMotorManual1_OnMotorClick(EDirectMotorRun eDirectMotorRun)
        {
            if (OnMotorClick != null)
            { OnMotorClick(eDirectMotorRun); }
        }

        private void Move_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Method1_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            Start_Nud.Value = decimal.Parse(tDataTable1.ValueArr[2]);
        }

        private void End_Btn_Click(object sender, EventArgs e)
        {
            End_Nud.Value = decimal.Parse(tDataTable1.ValueArr[2]);
        }

        private void PEG_Btn_Click(object sender, EventArgs e)
        {

        }
        public void SaveFormCfg()
        { 
            string infoPath=Environment.CurrentDirectory+"pegCfg.cgf";
            if (!File.Exists(infoPath))
            { File.Create(infoPath).Close(); }
            using (StreamWriter sw = new StreamWriter(infoPath))
            {
                sw.WriteLine(Start_Nud.Text);
                sw.WriteLine(End_Nud.Text);
                sw.WriteLine(Intever_Nud.Text);
                sw.WriteLine(Vel_Nud.Text);
            }
        
        }

        public void ReadFormCfg()
        {
            string infoPath = Environment.CurrentDirectory + "pegCfg.cgf";
            if (File.Exists(infoPath))
            {
                using (StreamReader sr = new StreamReader(infoPath))
                {
                    Start_Nud.Text= sr.ReadLine();
                    End_Nud.Text = sr.ReadLine(); ;
                    Intever_Nud.Text = sr.ReadLine();
                    Vel_Nud.Text = sr.ReadLine(); ;
                }
            }

        }

        private void Home_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Vel_Nud_ValueChanged(object sender, EventArgs e)
        {
            double rate = (double)((Vel_Nud.Value) / Intever_Nud.Value);
            if (rate > 85)
            {
                MessageBox.Show("相机触发间隔 大于相机帧率,请降低速度，或者增大间隔", "提示");
            }
        }

        private void Intever_Nud_ValueChanged(object sender, EventArgs e)
        {
            double rate = (double)((Vel_Nud.Value) / Intever_Nud.Value);
            if (rate > 185)
            {
                MessageBox.Show("相机触发间隔 大于相机帧率,请降低速度，或者增大间隔", "提示");
            }
        }
    }
}
