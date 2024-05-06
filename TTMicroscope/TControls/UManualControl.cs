using KMotions;
using NationalInstruments.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class UManualControl : UserControl
    {
        public UManualControl()
        {
            InitializeComponent();
        }

        Button[] btnArr = new Button[6];
        Color PanelCollapsedColor = Color.White;
        Color PanelCollapsedColor2 = Color.Gainsboro;
        int buttonW = 20;
        int splitW = 360;

        public event EventHandler OnResize;
        private void UManualControl_Load(object sender, EventArgs e)
        {
            btnArr = new Button[6] { Test_Btn,Parameter_Btn,Len_Btn,Flow_btn,Motion_Btn,Log_Btn};
            ReadFormCfg();
        }

        private void UManualControl_Paint(object sender, PaintEventArgs e)
        {

        }

        public void UManualControl_Resize(object sender, EventArgs e)
        {
            if (Width < 480)
            {
                splitContainer1.SplitterDistance = (Width - buttonW) + 10;
                splitContainer2.SplitterDistance = Width - buttonW + 10; }
            else
            {
                splitContainer1.SplitterDistance = (Width - buttonW) / 2-1;
                splitContainer2.SplitterDistance = (Width - buttonW) / 2 - buttonW;
            }
            if (OnResize != null)
            { OnResize(sender, e); }
            splitContainer3.SplitterDistance = 180; 
            splitContainer5.SplitterDistance = 180;

            splitContainer4.SplitterDistance = 400;
            splitContainer6.SplitterDistance = 550;
        }

        private void Test_Btn_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
            Test_Btn.BackColor= splitContainer3.Panel1Collapsed? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();
        }

        private void Parameter_Btn_Click(object sender, EventArgs e)
        {
            splitContainer5.Panel1Collapsed = !splitContainer5.Panel1Collapsed;
            Parameter_Btn.BackColor = splitContainer5.Panel1Collapsed ? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();

        }

        private void Len_Btn_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel1Collapsed = !splitContainer4.Panel1Collapsed;
            Len_Btn.BackColor = splitContainer4.Panel1Collapsed ? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();
        }

        private void Flow_btn_Click(object sender, EventArgs e)
        {
            splitContainer6.Panel1Collapsed = !splitContainer6.Panel1Collapsed;
            Flow_btn.BackColor = splitContainer6.Panel1Collapsed ? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();
        }

        private void Motion_Btn_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel2Collapsed = !splitContainer4.Panel2Collapsed;
            Motion_Btn.BackColor = splitContainer4.Panel2Collapsed ? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();
        }

        private void Log_Btn_Click(object sender, EventArgs e)
        {
            splitContainer6.Panel2Collapsed = !splitContainer6.Panel2Collapsed;
            Log_Btn.BackColor = splitContainer6.Panel2Collapsed ? PanelCollapsedColor : PanelCollapsedColor2;
            Rest();
        }

        public void Rest()
        {
            bool isAllCollapsed = (Test_Btn.BackColor == PanelCollapsedColor) && (Len_Btn.BackColor == PanelCollapsedColor) && (Motion_Btn.BackColor == PanelCollapsedColor);
            bool isAllCollapsed2 = (Parameter_Btn.BackColor == PanelCollapsedColor) && (Flow_btn.BackColor == PanelCollapsedColor) && (Log_Btn.BackColor == PanelCollapsedColor);

            splitContainer1.Panel1Collapsed = isAllCollapsed;
            splitContainer2.Panel1Collapsed=isAllCollapsed2;
            this.Width = ((isAllCollapsed ? 0 : 1) + (isAllCollapsed2 ? 0 : 1)) * splitW + buttonW+24;
        }

        public void SaveFormCfg()
        {
            if (!Directory.Exists(CGlobal.cfgFold))
            { Directory.CreateDirectory(CGlobal.cfgFold); }
            string infoPath = Path.Combine(CGlobal.cfgFold, "peg.cfg");
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
            if (!Directory.Exists(CGlobal.cfgFold))
            { Directory.CreateDirectory(CGlobal.cfgFold); }
            string infoPath = Path.Combine(CGlobal.cfgFold, "peg.cfg");
            if (File.Exists(infoPath))
            {
                using (StreamReader sr = new StreamReader(infoPath))
                {
                    Start_Nud.Text = sr.ReadLine();
                    End_Nud.Text = sr.ReadLine(); ;
                    Intever_Nud.Text = sr.ReadLine();
                    Vel_Nud.Text = sr.ReadLine(); ;
                }
            }

        }
        /// <summary>
        /// 显示信息
        /// </summary>
        public void ShowMsg(string content)
        {
            try
            {
                this.BeginInvoke(new System.Action(() =>
                {
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    string str = string.Format("{0} {1}", time, content);
                    msgInfo_Lbx.Items.Insert(0, str);
                }));
            }
            catch (Exception ex) { }
        }

        public void ShowAxisPos(CAxisStatue[] cAxisStatueArr)
        {
            try
            {
                this.Invoke(new System.Action(() =>
                {
                    string[] valueArr = new string[3] {
                    (cAxisStatueArr[0].PosPulse).ToString("F1"),
                    (cAxisStatueArr[2].PosPulse*CGlobal.zRatio).ToString("F2"),
                    (cAxisStatueArr[2].PosPulse*1000).ToString("F2"),
                    };
                    tDataTable1.ValueArr = valueArr;
                    //tDataTable1.Refresh();

                }));
            }
            catch { }
        }

        private void AxisIndex_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AxisIndex_Cbx.SelectedIndex == 0)
            {
                IncMoveN_Btn.BackgroundImage = Properties.Resources.旋转2;
                IncMoveP_Btn.BackgroundImage = Properties.Resources.旋转1;
            }
            else if(AxisIndex_Cbx.SelectedIndex ==2)
            {
                IncMoveN_Btn.BackgroundImage = Properties.Resources.MoveUP;
                IncMoveP_Btn.BackgroundImage = Properties.Resources.MoveDown;
            }
        }

        private void TotalTest_Btn_Click(object sender, EventArgs e)
        {
            wliWorkFlow1.Btn_Click(sender,e);
        }


        private void Stop_Btn_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int tag = (int.Parse)((string)bt.Tag);

            //初始化测试序列
            for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
            {
                CGlobal.WLIDetectStep[i] = EStepsStatue.Default;
            }
            if (tag < 9)
            {
                for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
                {
                    CGlobal.WLIDetectStep[i] = (i == tag) ? EStepsStatue.WaitRuning : EStepsStatue.Default;
                }
            }
            else if (tag == 9)
            {
                for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
                {
                    CGlobal.WLIDetectStep[i] = (wliWorkFlow1.cbxs[i].Checked) ? EStepsStatue.WaitRuning : EStepsStatue.Default;
                }
                TotalTest_Btn.Enabled = false;
            }
            else if (tag == 10)
            {
                TotalTest_Btn.Enabled = true;
                if (continueThread != null)
                {
                    continueThread.Abort();
                }
            }
            //if (OnButtonClick != null)
            //{
            //    OnButtonClick(sender, e);
            //}




            //wliWorkFlow1.Btn_Click(sender, e);
        }

        Thread continueThread;
        private void Contiuns_Btn_Click(object sender, EventArgs e)
        {
            if (continueThread == null)
            {
                continueThread = new Thread(ContinusMethod);
                continueThread.IsBackground = true;
                continueThread.Start();
            }
        }
        int index = 0;
        public void ContinusMethod()
        {

            while (true)
            {
                try
                {
                    if (TotalTest_Btn.Enabled)
                    {
                        Thread.Sleep(3000);
                        this.Invoke(new System.Action(() => {
                            wliWorkFlow1.Btn_Click(TotalTest_Btn, null);
                            index++;
                            //label23.Text = "测量次数:" + index.ToString();
                            TotalTest_Btn.Enabled=false;
                        }));

                    }


                }
                catch
                { }

                Thread.Sleep(500);
                //if (TotalTest_Btn.Enabled)
                //{
                //    for (int i = 0; i < 20; i++)
                //    {
                //        Thread.Sleep(1000);
                //        this.Invoke(new Action(() =>
                //        {
                //            label24.Text = "倒计时:" + (20 - i).ToString();
                //        }));

                //    }
                //}
            }
            continueThread.Abort();
            continueThread = null;
        }

        private void PEG_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            Start_Nud.Value = (decimal)((float.Parse(tDataTable1.ValueArr[2]))*CGlobal.zRatio/1000);
        }

        private void End_Btn_Click(object sender, EventArgs e)
        {
            End_Nud.Value = (decimal)((float.Parse(tDataTable1.ValueArr[2])) * CGlobal.zRatio/1000);
        }

        private void StartMove_Btn_Click(object sender, EventArgs e)
        {

        }

        private void tGroupBox6_Resize(object sender, EventArgs e)
        {
            msgInfo_Lbx.Height= tGroupBox6.Height-20;
        }

        private void ImageFold_Tbx_TextChanged(object sender, EventArgs e)
        {
            CGlobal.resultSaveFold = Path.Combine(CGlobal.cameracfg.ImageSaveFold, DateTime.Now.ToString("yyyy-MM-dd"), ImageFold_Tbx.Text.Trim());
        }
    }
}
