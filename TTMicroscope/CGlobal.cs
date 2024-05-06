using KMotions;
using KMotions.Acs;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTCameraLib;

namespace TTMicroscope
{
    public  class CGlobal
    {
        //物镜配置
        public static CObjectConfig cObjectConfig=new CObjectConfig();
        public static AnalisisCfg analisisCfg = new AnalisisCfg();




        public static HaiKangCamera camera;
        public static CameraConfig cameracfg =new CameraConfig(); //00100000000
        public static MotionConfig motionCfg=new MotionConfig();
        public static CPEGParameter pEGCfg=new CPEGParameter();
        public static CAcsMotion acsHdl = new CAcsMotion();
        public static CAxisStatue[] cAxisStatueArr =new CAxisStatue[] {new CAxisStatue(),new CAxisStatue(),new CAxisStatue() };
        public static bool IsEixt = false;
        //检测数据队列
        public static Queue<byte[]> detectDataQueue=new Queue<byte[]>();
        public static Stack<byte[]> showDataStack = new Stack<byte[]>();
        public static string resultSaveFold = CGlobal.cameracfg.ImageSaveFold;
        public static Queue<byte[]> autoFouceDataQueue = new Queue<byte[]>();
        public static int zAixIndex = 2;
        public static double autofouceData = 0;
        public static double[] limitdata = new double[2];
        /// <summary>
        /// 测试步骤
        /// </summary>
        public static EStepsStatue[] WLIDetectStep=new EStepsStatue[9] { 
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default,
            EStepsStatue.Default
        };
        public static int currentRunStep = -1;
        public static bool isBusy=false;

        public static float zRatio = 0.005F;  //1脉冲=0.005um

        public static float zAcc = 1000; //um/s
        public static float zDec = 1000; //um/s

        public static string cfgFold = "D:\\cfg";


        public static float[] objectsPos = new float[5] { 0.0f,0.0f,0.0f,0.0f,0.0f};
    }
    public delegate void TestStatueChangeHandle(int stepIndex, string msg);
    public delegate void ShowMsgHandle(string msg);
    public enum ECameraCmd
    {
        OpenCamera = 101,
        CloseCamera,
        StartGrap,
        StopGrap,
        SetExporseTime,
        SetGrain,
        SetModel,
        SetImageWH
    }

    public enum EAlgCmd
    {
        InitAlg = 201,
        TransImage,
        AlgDetect,
    }
}
