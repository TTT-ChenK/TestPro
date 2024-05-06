using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class PParameter : UserControl
    {
        public PParameter()
        {
            InitializeComponent();

        }


        SObject[] sb=new SObject[5];
        public MotionConfig motionConfig = new MotionConfig();
        ComboBox[] objectsArr = new ComboBox[5];
        NumericUpDown[] wdNud  = new NumericUpDown[5];
        NumericUpDown[] steppNud = new NumericUpDown[5];


        private void PParameter_Load(object sender, EventArgs e)
        {
            SaveMotionCfg_Btn.Enabled = true;
            objectsArr = new ComboBox[5] { Pos1Object_Cbx, Pos2Object_Cbx, Pos3Object_Cbx, Pos4Object_Cbx, Pos5Object_Cbx };
            wdNud=new NumericUpDown[5] { Object1Dis_Nud, Object2Dis_Nud, Object3Dis_Nud, Object4Dis_Nud, Object5Dis_Nud, };
            steppNud = new NumericUpDown[5] { Object1Step_Nud, Object2Step_Nud, Object3Step_Nud, Object4Step_Nud, Object5Step_Nud, };

            CGlobal.cObjectConfig.LoadObjectConfig();
            CGlobal.cameracfg.LoadCameraConfig();
            MotionConfig motionCfg= CGlobal.motionCfg.LoadMotionConfig();
            if (motionCfg == null)
            {
                CGlobal.motionCfg = new MotionConfig();
            }
            ShowMotionInfo();
            ShowObjectInfo();
            ShowCameraInfo();
        }



        private void PParameter_Resize(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FJogP_Btn_Click(object sender, EventArgs e)
        {

        }

        private void SavePara_Btn_Click(object sender, EventArgs e)
        {

        }


        private void SetPara_Btn_Click(object sender, EventArgs e)
        {

        }

        private void FObjects_Btn_Click(object sender, EventArgs e)
        {
            FObjectCfg foc=new FObjectCfg();
            foc.ShowDialog();
            ShowObjectInfo();
        }

        public void ShowObjectInfo()
        {
            CSignalObjectConfig[] cSignalObjectConfigs =  new CSignalObjectConfig[5]
                {
                CGlobal.cObjectConfig.Pos1Object,
                CGlobal.cObjectConfig.Pos2Object,
                CGlobal.cObjectConfig.Pos3Object,
                CGlobal.cObjectConfig.Pos4Object,
                CGlobal.cObjectConfig.Pos5Object,
                };
            string[] allObject=CGlobal.cObjectConfig.GetAllObject();
            for (int i = 0; i < cSignalObjectConfigs.Length; i++)
            {
                objectsArr[i].Items.Clear();
                objectsArr[i].Items.AddRange(allObject);
                string obText = cSignalObjectConfigs[i].ObjectName;
                int index= allObject.ToList().FindIndex(x => x == obText);
                if (index != -1)
                {
                    objectsArr[i].SelectedIndex = index;
                    wdNud[i].Value = (decimal)CGlobal.cObjectConfig.ObjectList[index].WorkDistance;
                    steppNud[i].Value = (decimal)CGlobal.cObjectConfig.ObjectList[index].RunStep;
                }
                else
                {
                    objectsArr[i].SelectedText = "";
                    wdNud[i].Value = -1;
                    steppNud[i].Value = -1;
                }
            }
        }

        public void GetObjectInfo()
        {
            CSignalObjectConfig[] cSignalObjectConfigs = new CSignalObjectConfig[5]
                {
                CGlobal.cObjectConfig.Pos1Object,
                CGlobal.cObjectConfig.Pos2Object,
                CGlobal.cObjectConfig.Pos3Object,
                CGlobal.cObjectConfig.Pos4Object,
                CGlobal.cObjectConfig.Pos5Object,
                };
            string[] allObject = CGlobal.cObjectConfig.GetAllObject();
            for (int i = 0; i < cSignalObjectConfigs.Length; i++)
            {
                cSignalObjectConfigs[i].ObjectName = objectsArr[i].Text;
                cSignalObjectConfigs[i].WorkDistance = (float)wdNud[i].Value;
                cSignalObjectConfigs[i].RunStep = (float)steppNud[i].Value;
            }
            CGlobal.cObjectConfig.Pos1Object = CGlobal.cObjectConfig.Pos1Object;
            CGlobal.cObjectConfig.Pos2Object = CGlobal.cObjectConfig.Pos2Object;
            CGlobal.cObjectConfig.Pos3Object = CGlobal.cObjectConfig.Pos3Object;
            CGlobal.cObjectConfig.Pos4Object = CGlobal.cObjectConfig.Pos4Object;
            CGlobal.cObjectConfig.Pos5Object = CGlobal.cObjectConfig.Pos5Object;
        }

        private void Pos1Object_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbObject = (ComboBox)sender;
            int index=int.Parse(cmbObject.Name.Substring(3,1))-1;
            wdNud[index].Value = (decimal)CGlobal.cObjectConfig.ObjectList[cmbObject.SelectedIndex].WorkDistance;
            steppNud[index].Value = (decimal)CGlobal.cObjectConfig.ObjectList[cmbObject.SelectedIndex].RunStep;
        }

        private void SaveObjectPara_Btn_Click(object sender, EventArgs e)
        {
            GetObjectInfo();
            CGlobal.cObjectConfig.SaveObjectConfig(CGlobal.cObjectConfig);
        }

        public void ShowCameraInfo()
        {
            CameraMac_Tbx.Text = CGlobal.cameracfg.CameraMac;
            PicH_Nud.Value = (decimal)CGlobal.cameracfg.ImgeH;
            PicW_Nud.Value = (decimal)CGlobal.cameracfg.ImgeW;
            ImageFold_Tbx.Text = CGlobal.cameracfg.ImageSaveFold ;
            isSaveImage_Cbx.Checked = CGlobal.cameracfg.IsSaveImage;
            Vel_Nud.Value = (decimal)CGlobal.cameracfg.ScanVel;
        }

        public void GetCameraInfo()
        {
            CGlobal.cameracfg.CameraMac= CameraMac_Tbx.Text;
            CGlobal.cameracfg.ImgeH=(int) PicH_Nud.Value;
            CGlobal.cameracfg.ImgeW = (int)PicW_Nud.Value;
            CGlobal.cameracfg.ImageSaveFold= ImageFold_Tbx.Text;
            CGlobal.cameracfg.IsSaveImage= isSaveImage_Cbx.Checked;
            CGlobal.cameracfg.ScanVel = (float)Vel_Nud.Value;
            CGlobal.cameracfg.SaveCameraConfig(CGlobal.cameracfg);

        }

        private void SaveCameraInfo_Btn_Click(object sender, EventArgs e)
        {
            GetCameraInfo();
        }


        public void ShowMotionInfo()
        {
            propertyGrid2.SelectedObject = CGlobal.motionCfg;
        }

        private void SaveMotionCfg_Btn_Click(object sender, EventArgs e)
        {
            CGlobal.motionCfg = (MotionConfig)propertyGrid2.SelectedObject;
            CGlobal.motionCfg.SaveMotionConfig(CGlobal.motionCfg);
        }
    }
}
