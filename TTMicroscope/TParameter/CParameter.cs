using Kitware.VTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace TTMicroscope
{
    internal class CParameter
    {
    }
    /// <summary>
    /// 相机配置
    /// </summary>
    [Serializable]
    public class CameraConfig
    {
        [Category("相机"), DisplayName("类型")]
        public TCameraType CameraType { set; get; }
        [Category("相机"), DisplayName("序列号")]
        public string CameraMac { set; get; }


        private uint exporsetime = 1;
        [Category("相机"), DisplayName("曝光")]
        public uint Exporsetime
        {
            set
            {
                if (value > 1000000)
                { exporsetime = 1000000; }
                else
                { exporsetime = value; }
            }

            get { return exporsetime; }
        }

        private uint gain = 1;
        [Category("相机"), DisplayName("增益")]
        public uint Gain
        {
            set
            {
                if (value > 100)
                { gain = 100; }
                else
                { gain = value; }
            }
            get { return gain; }
        }

        private string imageSaveFold = "D:\\image";
        [Category("其他"), DisplayName("图片存储路径")]
        public string ImageSaveFold
        {
            set
            {
                imageSaveFold= value;
            }
            get {
                return imageSaveFold; }
        }

        private bool _isSaveImage = false;
        [Category("其他"), DisplayName("是否存储图片")]
        public bool IsSaveImage
        {
            set
            {
                _isSaveImage = value;
            }
            get { return _isSaveImage; }
        }


        private int imgW=2048;
        [Category("其他"), DisplayName("图片宽")]
        public int ImgeW
        {
            get { return imgW; }
            set { imgW = value; }
        }
        private int imgH = 2048;
        [Category("其他"), DisplayName("图片高")]
        public int ImgeH
        {
            get { return imgH; }
            set { imgH = value; }
        }

        private float scanVel = 5;
        [Category("其他"), DisplayName("图片高")]
        public float ScanVel
        {
            get { return scanVel; }
            set { scanVel = value; }
        }



        public CameraConfig()
        {
            CameraMac = /*"DA2385053"*/"DA2385043";
            imageSaveFold = "D:\\testImage";
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <returns></returns>
        public bool LoadCameraConfig()
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "camera.cfg");
            if (File.Exists(filePath))
            {
                CameraConfig obj = (CameraConfig)SerializeObject.FileToObject(filePath);
                if (obj == null) return false;
                CameraMac = obj.CameraMac;
                exporsetime = obj.exporsetime;
                gain = obj.gain;
                imageSaveFold  = obj.imageSaveFold;
                IsSaveImage = obj.IsSaveImage;
                imgW = obj.imgW;
                imgH = obj.imgH;
                scanVel = obj.scanVel;
                return true;
            }
              
            return false;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public bool SaveCameraConfig(CameraConfig cfg)
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "camera.cfg");
            SerializeObject.ObjectToFile(cfg, filePath);
            return true;

        }

    }

    /// <summary>
    /// 运动类相关配置
    /// </summary>
    [Serializable]
    public class MotionConfig
    {
        [Category("X轴"), DisplayName("轴号")]
        public uint XAxisIndex { set; get; }
        [Category("X轴"), DisplayName("是否使用")]
        public bool XAxisIsUsed { set; get; }
        [Category("X轴"), DisplayName("速度")]
        public double XAxisSpeed { set; get; }
        [Category("X轴"), DisplayName("加速度")]
        public double XAxisAcc { set; get; }
        [Category("X轴"), DisplayName("减速度")]
        public double XAxisDec { set; get; }


        [Category("Y轴"), DisplayName("轴号")]
        public uint YAxisIndex { set; get; }
        [Category("Y轴"), DisplayName("是否使用")]
        public bool YAxisIsUsed { set; get; }
        [Category("Y轴"), DisplayName("速度")]
        public double YAxisSpeed { set; get; }
        [Category("Y轴"), DisplayName("加速度")]
        public double YAxisAcc { set; get; }
        [Category("Y轴"), DisplayName("减速度")]
        public double YAxisDec { set; get; }


        [Category("Z轴"), DisplayName("轴号")]
        public int ZAxisIndex { set; get; }
        [Category("Z轴"), DisplayName("是否使用")]
        public bool ZAxisIsUsed { set; get; }
        [Category("Z轴"), DisplayName("速度")]
        public double ZAxisSpeed { set; get; }
        [Category("Z轴"), DisplayName("加速度")]
        public double ZAxisAcc { set; get; }
        [Category("Z轴"), DisplayName("减速度")]
        public double ZAxisDec { set; get; }


        [Category("物镜转盘轴"), DisplayName("轴号")]
        public uint RAxisIndex { set; get; }
        [Category("物镜转盘轴"), DisplayName("是否使用")]
        public bool RAxisIsUsed { set; get; }
        [Category("物镜转盘轴"), DisplayName("速度")]
        public double RAxisSpeed { set; get; }
        [Category("物镜转盘轴"), DisplayName("加速度")]
        public double RAxisAcc { set; get; }
        [Category("物镜转盘轴"), DisplayName("减速度")]
        public double RAxisDec { set; get; }

        [Category("物镜位置"), DisplayName("位置1")]
        public double ObjectivePos1 { set; get; }
        [Category("物镜位置"), DisplayName("位置2")]
        public double ObjectivePos2 { set; get; }
        [Category("物镜位置"), DisplayName("位置3")]
        public double ObjectivePos3 { set; get; }
        [Category("物镜位置"), DisplayName("位置4")]
        public double ObjectivePos4 { set; get; }
        [Category("物镜位置"), DisplayName("位置5")]
        public double ObjectivePos5 { set; get; }

        [Category("驱动器配置"), DisplayName("Ip地址")]
        public string AcsControlerIp
        { set; get; }
        [Category("驱动器配置"), DisplayName("端口")]
        public int AcsControlerPort
        { set; get; }

        public MotionConfig()
        {
            AcsControlerIp = "10.0.0.100";
            AcsControlerPort = 701;
            ObjectivePos1 = 0;
            ObjectivePos2 = 72;
            ObjectivePos3 = 144;
            ObjectivePos4 = 216;
            ObjectivePos5 = 288;

            XAxisIndex = 0;
            XAxisIsUsed = true;
            XAxisSpeed = 2000;
            XAxisAcc = 1000;
            XAxisDec = 1000;

            YAxisIndex = 0;
            YAxisIsUsed = true;
            YAxisSpeed = 2000;
            YAxisAcc = 1000;
            YAxisDec = 1000;

            ZAxisIndex = 2;
            ZAxisIsUsed = true;
            ZAxisSpeed = 2000;
            ZAxisAcc = 1000;
            ZAxisDec = 1000;

            RAxisIndex = 0;
            RAxisIsUsed = true;
            RAxisSpeed = 2000;
            RAxisAcc = 1000;
            RAxisDec = 1000;
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <returns></returns>
        public MotionConfig LoadMotionConfig()
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "MotionConfig.cfg");
            if (File.Exists(filePath))
            {
                MotionConfig obj = (MotionConfig)SerializeObject.FileToObject(filePath);
                return obj;
            }
            else { return null; }
        }
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="obj"></param>
        public void SaveMotionConfig(MotionConfig obj) {
            string filePath = Path.Combine(CGlobal.cfgFold, "MotionConfig.cfg");
            SerializeObject.ObjectToFile(obj, filePath);
        }

    }

    /// <summary>
    /// PEG参数
    /// </summary>
    public class CPEGParameter
    {
        //起始点
        public double StartZ { set; get; } 
        //结束点
        public double EndZ { set; get; }
        //间隔
        public double InteverZ { set; get; }
        //速度
        public double Vel { set; get; }

        public int ImageCount { set; get; }

        public CPEGParameter()
        {
            StartZ = 0;
            EndZ = 1;
            InteverZ = 0.02;
            Vel = 600;

        }
        public void CalImageCount()
        {
            double m1 = (EndZ - StartZ);

            ImageCount = (int)(((EndZ - StartZ) / InteverZ))-1;
            if (ImageCount > 1000)
            {
            }
        }
    }


    /// <summary>
    /// 物镜配置
    /// </summary>
    [Serializable]
    public class CObjectConfig
    {
        public List<CSignalObjectConfig> ObjectList { get; set; }
        public CSignalObjectConfig Pos1Object { get; set; }
        public CSignalObjectConfig Pos2Object { get; set; }
        public CSignalObjectConfig Pos3Object { get; set; }
        public CSignalObjectConfig Pos4Object { get; set; }
        public CSignalObjectConfig Pos5Object { get; set; }
        public CObjectConfig()
        { 
            ObjectList = new List<CSignalObjectConfig>();
            Pos1Object = new CSignalObjectConfig();
            Pos2Object = new CSignalObjectConfig();
            Pos3Object = new CSignalObjectConfig(); 
            Pos4Object = new CSignalObjectConfig();
            Pos5Object = new CSignalObjectConfig();
        }


        /// <summary>
        /// 加载物镜配置
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <returns></returns>
        public bool LoadObjectConfig()
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "Objects.cfg");
            if (File.Exists(filePath))
            {
                CObjectConfig obj = (CObjectConfig)SerializeObject.FileToObject(filePath);
                ObjectList=obj.ObjectList;
                Pos1Object = obj.Pos1Object;
                Pos2Object = obj.Pos2Object;
                Pos3Object = obj.Pos3Object;
                Pos4Object = obj.Pos4Object;
                Pos5Object = obj.Pos5Object;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 保存物镜
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public bool SaveObjectConfig(CObjectConfig cfg)
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "Objects.cfg");
            SerializeObject.ObjectToFile(cfg, filePath);
            return true;

        }

        /// <summary>
        /// 获取所有物镜
        /// </summary>
        /// <returns></returns>
        public string[] GetAllObject()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < ObjectList.Count; i++)
            {
                list.Add(ObjectList[i].ObjectName); 
            }
            return list.ToArray();
        }

    }

    [Serializable]
    public class CSignalObjectConfig
    {
        [DisplayName("物镜名称")]
        public string ObjectName { get; set; }

        [DisplayName("工作距离(微米)")]
        public float WorkDistance { get; set; }

        [DisplayName("运动步长(微米)")]
        public float RunStep { get; set; }
        [DisplayName("其他")]
        public string Others { get; set; }


        public CSignalObjectConfig() { ObjectName = "Name"; WorkDistance = RunStep = 0;Others = "备注"; }
    }

    public class SerializeObject
    {
        /// <summary>
        /// 序列化成二进制对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filePath">路径</param>
        public static void ObjectToFile(object obj,string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite(filePath))
            {
                formatter.Serialize(stream, obj);
            }
        }
        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static object FileToObject(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return null;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = File.OpenRead(filePath))
                {
                    object obj = formatter.Deserialize(stream);
                    return obj;
                }
            }
            catch { return null; }
        }
    }
}
