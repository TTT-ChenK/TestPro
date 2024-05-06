using KMotions;
using KPublic;
using NationalInstruments.Restricted;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TTMicroscope.TControls;

namespace TTMicroscope
{
    public partial class PDataAcq : UserControl
    {
        public PDataAcq()
        {
            InitializeComponent();
        }

        public event EventHandler OnInit;
        public int lastJogAxisIndex = 0;


        public PImage pImage1=new PImage();
        #region Method  
        public void ShowMsg(string content)
        {
            uManualControl1.ShowMsg(content);
        }
        public void ShowImage(Bitmap img)
        {
            pImage1.ShowImage(img);
        }

        public void TotalMeasureClick(object sender, EventArgs e)
        {
            if (OnInit != null) OnInit(this, EventArgs.Empty);
        }

        public void ShowAxisPos(CAxisStatue[] cAxisStatueArr)
        {
            uManualControl1.ShowAxisPos(cAxisStatueArr);
           
        }
        private void OnMotorClickMethod(EDirectMotorRun eDirectMotorRun)
        {
            if (CGlobal.acsHdl == null) return;
            Tuple<EFunctionReturn, int, string> result = new Tuple<EFunctionReturn, int, string>( EFunctionReturn.Ok,0,null);
            switch (eDirectMotorRun)
            {
                case EDirectMotorRun.Default:
                    result = CGlobal.acsHdl.Stop(0, "halt");
                    result = CGlobal.acsHdl.Stop(CGlobal.motionCfg.ZAxisIndex, "halt");
                    break;
                case EDirectMotorRun.R_N:
                    result = CGlobal.acsHdl.Jog(0, 10, EJogDirection.N);
                    break;
                case EDirectMotorRun.R_P:
                    result = CGlobal.acsHdl.Jog(0, 10, EJogDirection.P);
                    break;

                case EDirectMotorRun.Z_N:
                    result = CGlobal.acsHdl.Jog(CGlobal.motionCfg.ZAxisIndex, (float)CGlobal.pEGCfg.Vel, EJogDirection.P);
                    break;
                    
                case EDirectMotorRun.Z_P:
                    result = CGlobal.acsHdl.Jog(CGlobal.motionCfg.ZAxisIndex, (float)CGlobal.pEGCfg.Vel, EJogDirection.N);
                    break;
            }

        }
        /// <summary>
        /// 显示聚焦数据
        /// </summary>
        /// <param name="foucsData"></param>
        public void ShowFoucsData(double foucsData)
        { this.uManualControl1.objectSelect1.ShowFouceData(foucsData); }
        #endregion

        private void PDataAcq_Load(object sender, EventArgs e)
        {


            #region last
            //this.pHardwareControl1.AxisIndex_Cbx.SelectedIndex = 2;
            //this.pWorkFlow1.wliWorkFlow1.Init_Btn.Click += OnInit;
            //this.pHardwareControl1.Enable_Btn.Click += Enable_Btn_Click;
            //this.pHardwareControl1.DisEnable_Btn.Click += DisEnable_Btn_Click; ;
            //this.pHardwareControl1.Home_Btn.Click += Home_Btn_Click;
            //this.pHardwareControl1.AbsMove_Btn.Click +=AbsMove_Btn_Click;
            //this.pHardwareControl1.IncMoveP_Btn.Click += IncMoveP_Btn_Click;
            //this.pHardwareControl1.IncMoveN_Btn.Click += IncMoveN_Btn_Click; ;
            //this.pHardwareControl1.StartMove_Btn.Click += StartMove_Btn_Click;
            //this.pHardwareControl1.EndMove_Btn.Click += EndMove_Btn_Click; ;
            //this.pHardwareControl1.OnMotorClick += OnMotorClickMethod;
            //this.pHardwareControl1.PEG_Btn.Click += PEG_Btn_Click; ;
            ////this.pHardwareControl1.objectSelect1.OutTrig_Btn.Click += OutTrig_Btn_Click;
            ////this.pHardwareControl1.objectSelect1.SWTrig_Btn.Click += SWTrig_Btn_Click;
            //this.pHardwareControl1.objectSelect1.LightVal_Pro.OnTProgressBarValueChanged += LightVal_Pro_OnTProgressBarValueChanged;
            //this.pHardwareControl1.objectSelect1.ExposureTime_Pro.OnTProgressBarValueChanged += ExposureTime_Pro_OnTProgressBarValueChanged; ;
            //this.pHardwareControl1.objectSelect1.OnObjectSelectChanged += ObjectSelect1_OnObjectSelectChanged;
            #endregion

            this.Controls.Add(pImage1);
            this.pImage1.imageBox.opType = KImageCtr.EOpType.ZoomOrMove;
            this.pImage1.imageBox.OnMouseWheel += ImageBox_OnMouseWheel; ;

            this.uManualControl1.OnResize += PDataAcq_Resize;
            this.uManualControl1.AxisIndex_Cbx.SelectedIndex = 2;
            this.uManualControl1.Init_Btn.Click += OnInit;
            this.uManualControl1.Enable_Btn.Click += Enable_Btn_Click;

            this.uManualControl1.DisEnable_Btn.Click += DisEnable_Btn_Click; ;
            this.uManualControl1.Home_Btn.Click += Home_Btn_Click;
            this.uManualControl1.AbsMove_Btn.Click += AbsMove_Btn_Click;
            this.uManualControl1.IncMoveP_Btn.Click += IncMoveP_Btn_Click;
            this.uManualControl1.IncMoveN_Btn.Click += IncMoveN_Btn_Click; ;
            this.uManualControl1.StartMove_Btn.Click += StartMove_Btn_Click;
            this.uManualControl1.EndMove_Btn.Click += EndMove_Btn_Click; ;
            this.uManualControl1.PEG_Btn.Click += PEG_Btn_Click; ;
            this.uManualControl1.objectSelect1.LightVal_Pro.OnTProgressBarValueChanged += LightVal_Pro_OnTProgressBarValueChanged;
            //this.uManualControl1.objectSelect1.ExposureTime_Pro.OnTProgressBarValueChanged += ExposureTime_Pro_OnTProgressBarValueChanged; ;
            //this.uManualControl1.objectSelect1.OnObjectSelectChanged += ObjectSelect1_OnObjectSelectChanged2; ;

            this.uManualControl1.objectSelect1.sObject1.OnObjectSelect += SObject1_OnObjectSelect;
            this.uManualControl1.objectSelect1.sObject2.OnObjectSelect += SObject1_OnObjectSelect;
            this.uManualControl1.objectSelect1.sObject3.OnObjectSelect += SObject1_OnObjectSelect;
            this.uManualControl1.objectSelect1.sObject4.OnObjectSelect += SObject1_OnObjectSelect;
            this.uManualControl1.objectSelect1.sObject5.OnObjectSelect += SObject1_OnObjectSelect;

            lastDistance = CGlobal.cObjectConfig.Pos2Object.WorkDistance; 
        }

        double lastDistance = 0;
        int lastInex = -1;
        private void SObject1_OnObjectSelect(string name)
        {
            double targetDistance = 0;
            double pos = -1;
            CGlobal.cObjectConfig.LoadObjectConfig();
            switch (name)
            {
                case "sObject1":
                    pos = CGlobal.motionCfg.ObjectivePos1;
                    targetDistance = CGlobal.cObjectConfig.Pos1Object.WorkDistance;
                    
                    break;
                case "sObject2":
                    pos = CGlobal.motionCfg.ObjectivePos2;
                    targetDistance = CGlobal.cObjectConfig.Pos2Object.WorkDistance;
                    break;
                case "sObject3":
                    pos = CGlobal.motionCfg.ObjectivePos3;
                    targetDistance = CGlobal.cObjectConfig.Pos3Object.WorkDistance;
                    break;
                case "sObject4":
                    pos = CGlobal.motionCfg.ObjectivePos4;
                    targetDistance = CGlobal.cObjectConfig.Pos4Object.WorkDistance;
                    break;
                case "sObject5":
                    pos = CGlobal.motionCfg.ObjectivePos5;
                    targetDistance = CGlobal.cObjectConfig.Pos5Object.WorkDistance;
                    break;

            }
            if (CGlobal.acsHdl != null&&pos!=-1)
            {
                CGlobal.acsHdl.SetAccelerationImm(0,272,true);
                CGlobal.acsHdl.SetDecelerationImm(0,272, true);
                CGlobal.acsHdl.SetVelocity(0, 216, true);
                CGlobal.acsHdl.AbsMove((int)CGlobal.motionCfg.RAxisIndex,pos);
            }

            if (lastInex != -1)
            {
                switch (lastInex)
                {
                    case 1:
                        lastDistance = CGlobal.cObjectConfig.Pos1Object.WorkDistance;
                        break;
                    case 2:
                        lastDistance = CGlobal.cObjectConfig.Pos2Object.WorkDistance;
                        break;
                    case 3:
                        lastDistance = CGlobal.cObjectConfig.Pos3Object.WorkDistance;
                        break;
                    case 4:
                        lastDistance = CGlobal.cObjectConfig.Pos4Object.WorkDistance;
                        break;
                    case 5:
                        lastDistance = CGlobal.cObjectConfig.Pos5Object.WorkDistance;
                        break;

                }
                double offset = targetDistance - lastDistance;
                if (Math.Abs(offset) > 0)
                {
                    if (MessageBox.Show(string.Format("Z向移动补偿{0}微米？", offset), "请选择", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc*2 / CGlobal.zRatio, true);
                        CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec * 2 / CGlobal.zRatio, true);
                        CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 2000f / CGlobal.zRatio, true);

                        double movePos = offset / CGlobal.zRatio;
                        CGlobal.acsHdl.IncMove((int)CGlobal.motionCfg.ZAxisIndex, offset / CGlobal.zRatio);
                    }
                }
                //lastDistance = targetDistance;
            }
            lastInex =int.Parse(name.Substring(name.Length-1,1).ToString());
        }

        private void ObjectSelect1_OnObjectSelectChanged1(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StartMove_Btn_Click(object sender, EventArgs e)
        {
            //CGlobal.pEGCfg.Vel = 10000;
            CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, CGlobal.pEGCfg.Vel, true);
            if (CGlobal.pEGCfg.Vel<1)
            { PEG_Btn_Click(null, null); }
           
            Tuple<EFunctionReturn, int, string> re = CGlobal.acsHdl.AbsMove(this.uManualControl1.AxisIndex_Cbx.SelectedIndex,
            double.Parse(this.uManualControl1.Start_Nud.Text) / CGlobal.zRatio);
        }

        private void EndMove_Btn_Click(object sender, EventArgs e)
        {
            //CGlobal.pEGCfg.Vel = 10000;
            CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, CGlobal.pEGCfg.Vel, true);
            if (CGlobal.pEGCfg.Vel < 1)
            { PEG_Btn_Click(null, null); }
            CGlobal.acsHdl.AbsMove(this.uManualControl1.AxisIndex_Cbx.SelectedIndex,
            double.Parse(this.uManualControl1.End_Nud.Text) / CGlobal.zRatio);
        }


        private void IncMoveP_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc/CGlobal.zRatio, true);
            CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec / CGlobal.zRatio, true);
            //CGlobal.acsHdl.SetAccelerationImm(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, (double)this.uManualControl1.Vel_Tbx.Value / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetVelocity(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, (double)this.uManualControl1.Vel_Tbx.Value / CGlobal.zRatio, true);
            double pos = (double)((double.Parse(this.uManualControl1.Dis_Tbx.Text)) / CGlobal.zRatio);
            CGlobal.acsHdl.IncMove(this.uManualControl1.AxisIndex_Cbx.SelectedIndex,
                    this.uManualControl1.AxisIndex_Cbx.SelectedIndex == CGlobal.motionCfg.ZAxisIndex ? pos  :
             double.Parse(this.uManualControl1.Dis_Tbx.Text));
        }

        private void IncMoveN_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec / CGlobal.zRatio, true);
            //CGlobal.acsHdl.SetAccelerationImm(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, (double)this.uManualControl1.Vel_Tbx.Value / CGlobal.zRatio, true);
            CGlobal.acsHdl.SetVelocity(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, (double)this.uManualControl1.Vel_Tbx.Value / CGlobal.zRatio, true);
            double pos = ((double.Parse(this.uManualControl1.Dis_Tbx.Text)) / CGlobal.zRatio);
            Tuple<EFunctionReturn, int, string> re=CGlobal.acsHdl.IncMove(this.uManualControl1.AxisIndex_Cbx.SelectedIndex,
                    this.uManualControl1.AxisIndex_Cbx.SelectedIndex == CGlobal.motionCfg.ZAxisIndex ? pos * -1 :
             double.Parse(this.uManualControl1.Dis_Tbx.Text) * -1);
        }
        private void AbsMove_Btn_Click(object sender, EventArgs e)
        {
            //CGlobal.acsHdl.SetAccelerationImm(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, 2, true);
            //CGlobal.acsHdl.SetVelocity(2, 1, true);

            //CGlobal.acsHdl.SetAccelerationImm(CGlobal.zAixIndex, (double)this.uManualControl1.Vel_Nud.Value * 2, true);
            CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, 1000, true);
            CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, 1000, true);
            CGlobal.acsHdl.SetVelocity(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, (double)this.uManualControl1.Vel_Tbx.Value, true);
            CGlobal.acsHdl.AbsMove(this.uManualControl1.AxisIndex_Cbx.SelectedIndex,
            this.uManualControl1.AxisIndex_Cbx.SelectedIndex == CGlobal.motionCfg.ZAxisIndex ? (double.Parse(this.uManualControl1.Pos_Tbx.Text)) / CGlobal.zRatio :
             double.Parse(this.uManualControl1.Pos_Tbx.Text));


        }
        private void ImageBox_OnMouseWheel(int value)
        {
            if(value < 0)
            {
                CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, -0.0001/ CGlobal.zRatio);
            }
            else if(value >0)
            { CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, 0.0001 / CGlobal.zRatio); }
        }



        private void LightVal_Pro_OnTProgressBarValueChanged(float oldValue, float newValue)
        {
            CGlobal.acsHdl.Analog_Output(0, newValue-0.3);
        }

        private void ObjectSelect1_OnObjectSelectChanged(object sender, MouseEventArgs e)
        {
            SObject sb = (SObject)sender;
            int index = (int)sb.Tag;
            
            double[] posArr = new double[5] {
                CGlobal.motionCfg.ObjectivePos1,
                CGlobal.motionCfg.ObjectivePos2,
                CGlobal.motionCfg.ObjectivePos3,
                CGlobal.motionCfg.ObjectivePos4,
                CGlobal.motionCfg.ObjectivePos5
            };
            if (CGlobal.acsHdl != null)
            {
                CGlobal.acsHdl.AbsMove((int)CGlobal.motionCfg.RAxisIndex, posArr[index - 1]);
            }

        }
        private void SWTrig_Btn_Click(object sender, EventArgs e)
        {
            if (CGlobal.camera != null)
            {
                CGlobal.camera.SetTrigMode(TTCameraLib.TrigMode.OFF);
            }
        }

        private void OutTrig_Btn_Click(object sender, EventArgs e)
        {
            if (CGlobal.camera != null)
            {
                CGlobal.camera.SetTrigMode(TTCameraLib.TrigMode.ON);
            }
        }

        public void PEG_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                double firstPoint = double.Parse(this.uManualControl1.Start_Nud.Value.ToString())/ CGlobal.zRatio;
                double intever = double.Parse(this.uManualControl1.Intever_Nud.Value.ToString()) / CGlobal.zRatio;
                //intever = 72;
                double lastPoint = double.Parse(this.uManualControl1.End_Nud.Value.ToString()) / CGlobal.zRatio;
                double vel = double.Parse(this.uManualControl1.Vel_Nud.Value.ToString()) / CGlobal.zRatio;
                intever = (firstPoint > lastPoint ? -1 : 1) * intever;
                CGlobal.pEGCfg.StartZ = firstPoint;
                CGlobal.pEGCfg.InteverZ = intever;
                CGlobal.pEGCfg.EndZ = lastPoint;
                CGlobal.pEGCfg.Vel= vel;
                CGlobal.pEGCfg.CalImageCount();
                Tuple<EFunctionReturn, int, string> result = CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, vel, true);
                //result = CGlobal.acsHdl.SetPegInc(0, 0x101, 0x101, 0, 0x0000, 1, firstPoint, intever, lastPoint, 0, 2);
                result = CGlobal.acsHdl.SetPegInc(0, 0x00000001, 0b000, 8, 0b0000, 1, firstPoint, intever, lastPoint, 0, 2);
                double rate = (double)((CGlobal.pEGCfg.Vel) / CGlobal.pEGCfg.InteverZ);
                if (rate > 185)
                {
                    MessageBox.Show("相机触发间隔 大于相机帧率,请降低速度，或者增大间隔", "提示");
                }
            }
            catch (Exception ex) {
                ShowMsg(ex.Message);
            }
        }



        private void Home_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.acsHdl.Home(this.uManualControl1.AxisIndex_Cbx.SelectedIndex);
            CGlobal.acsHdl.RunBuffer(4, "XX");
        }

        private void Enable_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.acsHdl.EnableAxis(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, true);
        }
        private void DisEnable_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.acsHdl.EnableAxis(this.uManualControl1.AxisIndex_Cbx.SelectedIndex, false);
        }
        private void PDataAcq_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Title_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Brush b = new LinearGradientBrush(panel5.ClientRectangle, Color.LightGray, Color.WhiteSmoke, LinearGradientMode.Horizontal);
            //g.FillRectangle(b, panel5.ClientRectangle);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

           //GraphicsPath gp = ControlsPublic.Round(new Rectangle(0, 0, panel3.Width - 1, panel3.Height - 1), 10);
           // g.DrawPath(new Pen(Color.Red, 2), gp);
        }

        private void PDataAcq_Resize(object sender, EventArgs e)
        {
            //this.Font = new Font("微软雅黑", 12); ;
            //pWorkFlow1.Location = new Point(Width-pWorkFlow1.Width, 0);
            //pWorkFlow1.Height = Height;
            //pHardwareControl1.Location = new Point(Width - pWorkFlow1.Width - pHardwareControl1.Width, 0);
            //pHardwareControl1.Height= Height;

            uManualControl1.Location = new System.Drawing.Point(Width - uManualControl1.Width, 0);
            uManualControl1.Height = Height-3;
            pImage1.Location = new System.Drawing.Point(3, 0);
            pImage1.Size = new System.Drawing.Size(Width - uManualControl1.Width - 5, Height);
            //pImage1.Size = new Size(Width - pWorkFlow1.Width - pHardwareControl1.Width - 5, Height);
        }
    }
}
