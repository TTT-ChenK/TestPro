using OpenCvSharp.Flann;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class WLIWorkFlow : UserControl
    {
        public WLIWorkFlow()
        {
            InitializeComponent();
        }
       public CheckBox[] cbxs = new CheckBox[8];
        Button[] statues = new Button[8];

        public event EventHandler OnButtonClick;

        private void WLIWorkFlow_Load(object sender, EventArgs e)
        {
            cbxs = new CheckBox[9] { HardwareCheck_Cbx, EnvironmentCheck_Cbx,
                ProductCheck_Cbx, AutoFoucs_Cbx,
                MakeSureLimit_Cbx, LightVal_Cbx,
                GetData_Cbx, CalData_Cbx,ExporseData_Cbx
            };
            statues = new Button[9] { HardwareCheck_Statue, EnvironmentCheck_Statue,
                ProductCheck_Statue, AutoFoucs_Statue,
                MakeSureLimit_Statue, LightVal_Statue,
                GetData_Statue, CalData_Statue,ExporseData_Statue
            };
            SetStatue();
        }

        private void Cbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx =  (CheckBox)(sender);
            int tag = (int.Parse)((string)cbx.Tag);
            CGlobal.WLIDetectStep[tag]= cbx.Checked? EStepsStatue.WaitRuning : EStepsStatue.Default;

        }

        public void Btn_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int tag= (int.Parse)((string)bt.Tag);

            //初始化测试序列
            for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
            {
                CGlobal.WLIDetectStep[i] =  EStepsStatue.Default;
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
                    CGlobal.WLIDetectStep[i] = (cbxs[i].Checked) ? EStepsStatue.WaitRuning : EStepsStatue.Default;
                }
                TotalTest_Btn.Enabled = false;
            }
            else if(tag == 10)
            { TotalTest_Btn.Enabled = true;
                if (continueThread != null)
                {
                    continueThread.Abort();
                }
            }
            if (OnButtonClick != null)
            {
                OnButtonClick(sender, e);
            }
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        public void SetStatue()
        {
            Task.Run(() => {
                long index = 0;
                while (true)
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
                            {
                                if (CGlobal.WLIDetectStep[i] == EStepsStatue.Runinng)
                                {
                                    statues[i].BackColor = index % 2 == 0 ? Color.LightGray : Color.Yellow;
                                }
                                else if (CGlobal.WLIDetectStep[i] == EStepsStatue.OK)
                                {
                                    statues[i].BackColor = Color.Green;
                                }
                                else if (CGlobal.WLIDetectStep[i] == EStepsStatue.NG)
                                { statues[i].BackColor = Color.Red; }
                                else
                                { statues[i].BackColor = Color.LightGray; }

                            }
                        }));
                        index++;
                        Thread.Sleep(300);
                    }
                    catch { }
                }
            });
        }


        Thread continueThread;
        public void Contiuns_Btn_Click(object sender, EventArgs e)
        {
            if (continueThread == null )
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
                        Thread.Sleep(2000);
                        this.Invoke(new Action(() => {

                            //for (int i = 0; i < 20; i++)
                            //{
                            //    Thread.Sleep(1000);
                            //    label24.Text = "倒计时:" + (20 - i).ToString();
                            //}
                           
                            Btn_Click(TotalTest_Btn, null);
                            index++;
                            label23.Text = "测量次数:" + index.ToString();
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
    }
}
