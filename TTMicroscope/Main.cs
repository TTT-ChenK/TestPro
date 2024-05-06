using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTMicroscope.TControls;
using TTCameraLib;

using KMotions.Acs;
using KPublic;
using System.Threading;
using KMotions;
using System.IO;
using OpenCvSharp;
using System.Runtime.InteropServices;

using ACS.SPiiPlusNET;
using DouUpDownCountHandler;

using System.IO.MemoryMappedFiles;
using System.Diagnostics;
using System.Web.Management;


namespace TTMicroscope
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.MaximumSize=Screen.AllScreens[0].WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            int count = Screen.AllScreens.Length;
            if (count == 2)
            { }
        }

        #region V panel
        PParameter pParameter = new PParameter();
        PDataAcq pDataAcq = new PDataAcq();
        PAnalysis pAnalysis = new PAnalysis();
        float[] resultArray;
        string resultSavePath = "";
        DouUpDownCount ddc= new DouUpDownCount();
        #endregion

        Thread motionThread;
        int imageCount = 0;
        Thread showImageThread;
        #region Method

        #region 相机
        //相机指令
        byte[] cameraCmdData = new byte[4];
        static MemoryMappedFile cameraCmd = MemoryMappedFile.CreateOrOpen("cameraCmd", 4);
        MemoryMappedViewAccessor cameraCmdAccessor = cameraCmd.CreateViewAccessor();
        //相机指令数据
        byte[] cameraCmdCfgData = new byte[108];
        static MemoryMappedFile cameraCmdCfg = MemoryMappedFile.CreateOrOpen("cameraCfg", 108);
        MemoryMappedViewAccessor cameraCmdDataAccessor = cameraCmdCfg.CreateViewAccessor();
        //图像数据
        byte[] imageSendCmdData = new byte[4];
        static MemoryMappedFile imageSendCmd = MemoryMappedFile.CreateOrOpen("imageSendCmd", 4);
        MemoryMappedViewAccessor imageSendCmdAccessor = imageSendCmd.CreateViewAccessor();
        /// <summary>
        /// 初始化相机
        /// </summary>
        public bool InitCamera()
        {
            ShowMsg("初始化相机");
            byte[] cameraB = Encoding.ASCII.GetBytes(CGlobal.cameracfg.CameraMac);
            byte[] lenB=BitConverter.GetBytes(cameraB.Length);
            Array.Copy(lenB, 0, cameraCmdCfgData, 0, 4);
            Array.Copy(cameraB, 0, cameraCmdCfgData, 4, cameraB.Length);
            cameraCmdDataAccessor.WriteArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
            //发送打开相机指令
            cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(ECameraCmd.OpenCamera)), 0, 4);
            //等待返回指令
            
            bool isOk = WaitCameraCmdIsOk();
            string msg = isOk? "相机初始化成功" : "相机初始化失败;";
            ShowMsg(msg);
            if (isOk)
            {
                //设置相机模式
                pDataAcq.uManualControl1.objectSelect1.SWTrig_Btn_Click(null, null);
                SetImageHW(CGlobal.cameracfg.ImgeW, CGlobal.cameracfg.ImgeH);
                isOk = WaitCameraCmdIsOk();
                SetCameraModel(0x00);
                isOk = WaitCameraCmdIsOk();
                showImageThread = new Thread(ShowImageMethod);
                showImageThread.IsBackground = true;
                showImageThread.Start();
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// 等待
        /// </summary>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public bool WaitCameraCmdIsOk(int waitTime=5000)
        {
            int cmdRc = 100;
            int count = waitTime/10;
            int index = 0;
            while ((cmdRc != -1 && cmdRc != 0)&&index<count)
            {
                cameraCmdAccessor.ReadArray(0, cameraCmdData, 0, cameraCmdData.Length);
                cmdRc = BitConverter.ToInt32(cameraCmdData, 0);
                Thread.Sleep(10);
                index++;
            }
            return (cmdRc== 0)&& (index< count-2);
        }


        /// <summary>
        /// 图像显示
        /// </summary>
        public void ShowImageMethod()
        {
            Thread.Sleep(3000);
            while (true)
            {
                Thread.Sleep(10);
                try
                {
                    this.Invoke(new System.Action(() =>
                    {
                        imageSendCmdAccessor.ReadArray(0, imageSendCmdData, 0, imageSendCmdData.Length);
                        if (BitConverter.ToInt32(imageSendCmdData, 0) == 1)
                        {
                            imageCount++;
                            pDataAcq.pImage1.ShowImageCount(imageCount);
                            #region 获取图片
                            int len = 2048 * 2048;
                            byte[] recData = new byte[len];
                            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateOrOpen("ImageData", len))
                            {
                                using (MemoryMappedViewAccessor accessor = memoryMappedFile.CreateViewAccessor())
                                {
                                    accessor.ReadArray(0, recData, 0, recData.Length);
    
                                }
                                imageSendCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)0), 0, 4);
                            }
                            #endregion
                            if (recData.Length > 0)
                            {
                                byte[] data = recData;
                                if (data != null)
                                {
                                    Mat mat = new Mat(CImage2PointCloud.picH, CImage2PointCloud.PicW, MatType.CV_8UC1);
                                    Marshal.Copy(data, 0, mat.Data, CImage2PointCloud.picH * CImage2PointCloud.PicW);
                                    int maxValue = data.ToList().Max();
                                    pDataAcq.pImage1.ShowMaxVlue(maxValue);
                                    Bitmap bt = CFocusAlg.Mat2MBitmap(mat);
                                    if (bt != null)
                                    {
                                        try
                                        {
                                            Bitmap showBit=(Bitmap)bt.Clone();
                                            showBit.RotateFlip(RotateFlipType.Rotate180FlipY);
                                            showBit.RotateFlip(RotateFlipType.Rotate180FlipX);
                                            pDataAcq.ShowImage(showBit);
                                            Mat mat1 = CFocusAlg.Bitmap2Mat((Bitmap)bt.Clone());
                                            double fouceScore = CFocusAlg.GetImgQualityScore(mat, 0);
                                            pDataAcq.ShowFoucsData(fouceScore);
                                            if (pDataAcq.uManualControl1.wliWorkFlow1.LightVal_Cbx.Checked)
                                            {
                                                int nb = 0;
                                                DouUpDownCount.Count_num(data, CImage2PointCloud.picH, CImage2PointCloud.PicW, 1, ref nb);
                                                pDataAcq.uManualControl1.wliWorkFlow1.LightVal_Statue.BackColor = nb > 10 ? System.Drawing.Color.Red : System.Drawing.Color.LightGray;
                                                pDataAcq.uManualControl1.wliWorkFlow1.LightVal_Statue.Text = nb > 10 ? nb.ToString() : null;
                                            }

                                        }
                                        catch { }
                                    }
                                    CGlobal.showDataStack.Clear();
                                }
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                }
            }
        }

        /// <summary>
        /// 设置相机模式
        /// </summary>
        /// <param name="model">00-软触发 01-外部触发</param>
        public void SetCameraModel(byte model)
        {
            cameraCmdCfgData[0] = model;
            cameraCmdDataAccessor.WriteArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
            cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(ECameraCmd.SetModel)), 0, 4);
            if (model == 0x01) pDataAcq.uManualControl1.objectSelect1.OutTrig_Btn_Click(null, null);
            else pDataAcq.uManualControl1.objectSelect1.SWTrig_Btn_Click(null, null);

        }

        /// <summary>
        /// 设置相机模式
        /// </summary>
        /// <param name="model">00-软触发 01-外部触发</param>
        public void SetExporseTime(int time)
        {
            Array.Copy(BitConverter.GetBytes(time), 0, cameraCmdCfgData,0, 4);
            cameraCmdDataAccessor.WriteArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
            cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(ECameraCmd.SetExporseTime)), 0, 4);

        }


        /// <summary>
        /// 设置相机模式
        /// </summary>
        /// <param name="model">00-软触发 01-外部触发</param>
        public void SetImageHW(int W,int H)
        {
            CImage2PointCloud.PicW = W;
            CImage2PointCloud.picH = H;
            Array.Copy(BitConverter.GetBytes(W), 0, cameraCmdCfgData, 0, 4);
            Array.Copy(BitConverter.GetBytes(H), 0, cameraCmdCfgData, 4, 4);
            cameraCmdDataAccessor.WriteArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
            Thread.Sleep(100);
            cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(ECameraCmd.SetImageWH)), 0, 4);

        }




        #endregion


        byte[] motionData = new byte[208];
        static MemoryMappedFile motionCmd = MemoryMappedFile.CreateOrOpen("motionData", 208);
        MemoryMappedViewAccessor motionCmdAccessor = cameraCmdCfg.CreateViewAccessor();


        /// <summary>
        /// 初始化运动控制
        /// </summary>
        public bool InitMotion()
        {
            try
            {
                ShowMsg("初始化运动控制");
                SAcsConnectPara sAcsConnectPara = new SAcsConnectPara();
                sAcsConnectPara.ipAddr = CGlobal.motionCfg.AcsControlerIp;
                sAcsConnectPara.port = CGlobal.motionCfg.AcsControlerPort;
                Tuple<KPublic.EFunctionReturn, int, string> result = CGlobal.acsHdl.Init(sAcsConnectPara);
                string msg = result.Item1 == KPublic.EFunctionReturn.Ok ? "运动控制初始化成功" : "运动控制初始化失败;" + result.Item2;
                ShowMsg(msg);
                if (result.Item1 == KPublic.EFunctionReturn.Ok)
                {
                    CGlobal.acsHdl.EnableAxis(0, true);

                    CGlobal.acsHdl.SetAccelerationImm(0, 72, true);
                    CGlobal.acsHdl.SetDecelerationImm(0, 72, true);
                    CGlobal.acsHdl.SetVelocity(0, 72, true);
                    CGlobal.acsHdl.EnableAxis(2, true);
                    motionThread = new Thread(GetAxisStatueMethod);
                    motionThread.IsBackground = true;
                    motionThread.Start(); return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 获取轴状态线程
        /// </summary>
        public void GetAxisStatueMethod()
        {
            while (!CGlobal.IsEixt)
            {
                try
                {
                    Thread.Sleep(10);
                    if (CGlobal.motionCfg != null)
                    {
                        for (int i = 0; i < CGlobal.cAxisStatueArr.Length; i++)
                        {
                            if (i != 1)
                            {
                                CAxisStatue cAxisStatue = new CAxisStatue();
                                AxisStates axisStates = new AxisStates();
                                MotorStates motorStates = new MotorStates();
                                Tuple<KPublic.EFunctionReturn, int, string> result = CGlobal.acsHdl.GetAxisStatue(i, ref cAxisStatue);
                                
                                CGlobal.acsHdl.Get_axis_state(i, ref axisStates, ref motorStates);

                                int data = (int)motorStates;
                                bool isRun= ((data >> 5) & 0x01) == 0x01;
                                cAxisStatue.IsStop = ((data>>5)&0x01)!=0x01;
                                CGlobal.cAxisStatueArr[i] = cAxisStatue;
                            }
                        }
                        pDataAcq.ShowAxisPos(CGlobal.cAxisStatueArr);
                        int zIsStop = CGlobal.cAxisStatueArr[2].IsStop?0:1;
                        float pos = (float)CGlobal.cAxisStatueArr[2].PosPulse;
                        Array.Copy(BitConverter.GetBytes(zIsStop), 0, motionData,0, 4);
                        Array.Copy(BitConverter.GetBytes(pos), 0, motionData, 4, 4);
                        if (motionCmdAccessor.CanWrite)
                        {
                            motionCmdAccessor.WriteArray(0,motionData,0,motionData.Length);
                        }
                    }
                }
                catch { }

            }

        }
        int count1 = 0;


        /// <summary>
        /// 显示信息
        /// </summary>
        public void ShowMsg(string content)
        {
            pDataAcq.ShowMsg(content);

        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="bt"></param>
        /// <param name="index"></param>
        public void SaveImage(Bitmap bt, int index)
        {
            if (/*CGlobal.cameracfg.IsSaveImage*/true)
            {
                Task.Run(() =>
                {
                    if (!Directory.Exists(CGlobal.resultSaveFold))
                    { Directory.CreateDirectory(CGlobal.resultSaveFold); }
                    string fileName = Path.Combine(CGlobal.resultSaveFold, index.ToString() + ".png");
                    bt.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                });
            }
        }

        public void SaveImage(Mat mat, int index)
        {
            if (/*CGlobal.cameracfg.IsSaveImage*/true)
            {
                string imgPath = Path.Combine(resultSavePath, "Pics");
                Task.Run(() =>
                {
                    if (!Directory.Exists(imgPath))
                    { Directory.CreateDirectory(imgPath); }
                    string fileName = Path.Combine(imgPath, index.ToString() + ".png");
                    mat.SaveImage(fileName);
                });
            }
        }

        #endregion

        #region TestMethod

        #region

        byte[] algCmdData = new byte[4];
        static MemoryMappedFile algCmd = MemoryMappedFile.CreateOrOpen("algCmd", 4);
        MemoryMappedViewAccessor algCmdAccessor = algCmd.CreateViewAccessor();

        byte[] algCmdCfgData = new byte[108];
        static MemoryMappedFile algCmdCfg = MemoryMappedFile.CreateOrOpen("algCmdData", 108);
        MemoryMappedViewAccessor algCmdCfgAccessor = algCmdCfg.CreateViewAccessor();

        /// <summary>
        /// 发送初始化指令
        /// </summary>
        /// <param name="imgCount"></param>
        public void SetInitCmd(int imgCount,int w,int h)
        {
            byte[] countB=BitConverter.GetBytes(imgCount);
            byte[] wB = BitConverter.GetBytes(w);
            byte[] hB = BitConverter.GetBytes(h);
            Array.Copy(countB, 0, algCmdCfgData, 0, countB.Length);
            Array.Copy(wB, 0, algCmdCfgData, 4, wB.Length);
            Array.Copy(hB, 0, algCmdCfgData, 8, hB.Length);
            algCmdCfgAccessor.WriteArray(0, algCmdCfgData, 0, algCmdCfgData.Length);
            Thread.Sleep(50);
            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(EAlgCmd.InitAlg)), 0, 4);
        }
        /// <summary>
        /// 设置传递数据
        /// </summary>
        /// <param name="imageFold"></param>
        public void SetTransImage(string imageFold)
        {
            byte[] countB = Encoding.ASCII.GetBytes(imageFold);
            int len=countB.Length;
            byte[] bytes = BitConverter.GetBytes(len);
            Array.Copy(bytes, 0, algCmdCfgData, 0, bytes.Length);
            Array.Copy(countB, 0, algCmdCfgData, 4, countB.Length);
            algCmdCfgAccessor.WriteArray(0, algCmdCfgData, 0, algCmdCfgData.Length);
            Thread.Sleep(150);
            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(EAlgCmd.TransImage)), 0, 4);
        }
        /// <summary>
        /// 发送算法检测指令
        /// </summary>
        public void SetAlgDetectCmd()
        {
            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(EAlgCmd.AlgDetect)), 0, 4);
        }



        /// <summary>
        /// 等待
        /// </summary>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public bool WaitAlgCmdIsOk(int waitTime = 10000)
        {
            int cmdRc = 100;
            int count = waitTime / 10;
            int index = 0;
            while ((cmdRc != -1 && cmdRc != 0) && index < count)
            {
                algCmdAccessor.ReadArray(0, algCmdData, 0, algCmdData.Length);
                cmdRc = BitConverter.ToInt32(algCmdData, 0);
                Thread.Sleep(10);
                index++;
            }
            return (cmdRc == 0) && (index < count - 2);
        }



        #endregion






        public event TestStatueChangeHandle OnTestStatueChange;
        public event ShowMsgHandle OnShowMsg;

        public void TotalDetectMethod()
        {
            pDataAcq.pImage1.Img2D_Rb.Checked = true;
            Task.Factory.StartNew(() =>
            {
                int waitruningIndex = 0;
                while (waitruningIndex != -1)
                {
                    int runingIndex = CGlobal.WLIDetectStep.ToList().FindIndex(x => x == EStepsStatue.Runinng);
                    waitruningIndex = CGlobal.WLIDetectStep.ToList().FindIndex(x => x == EStepsStatue.WaitRuning);
                    if (runingIndex == -1)
                    {

                        switch (waitruningIndex)
                        {
                            case 0: HardwareCheck(); break;
                            case 1: EnvenmentCheck(); break;
                            case 2: ProductCheck(); break;
                            case 3: AutoFoucs(); break;
                            case 4: MakesureUpAndLowLimint(); break;
                            case 5: MakesureLightVal(); break;
                            case 6:
                                if (!GetImageData())
                                {
                                    for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
                                    { CGlobal.WLIDetectStep[i] = EStepsStatue.Default;}
                                    this.Invoke(new System.Action(() =>
                                    {
                                        pDataAcq.uManualControl1.TotalTest_Btn.Enabled = true;
                                    }));
                                }
                                //GetImageData();

                                break;
                            case 7:
                                if (!CalData())
                                {
                                    for (int i = 0; i < CGlobal.WLIDetectStep.Length; i++)
                                    { CGlobal.WLIDetectStep[i] = EStepsStatue.Default; }
                                    this.Invoke(new System.Action(() =>
                                    {
                                        pDataAcq.uManualControl1.TotalTest_Btn.Enabled = true;
                                    }));
                                }
                                break;
                            case 8: ExportResult(); break;
                            case 9: break;
                            case 10: break;
                        }
                    }
                }

            });
        }

        /// <summary>
        /// 硬件检查
        /// </summary>
        /// <returns></returns>
        public bool HardwareCheck()
        {
            Task.Run(() =>
            {
                if (CGlobal.WLIDetectStep[0] == EStepsStatue.WaitRuning)
                {
                    CGlobal.WLIDetectStep[0] = EStepsStatue.Runinng;

                }

                CGlobal.WLIDetectStep[0] = EStepsStatue.OK;
            });
            return true;
        }

        /// <summary>
        /// 环境检查
        /// </summary>
        /// <returns></returns>
        public bool EnvenmentCheck()
        {
            Task.Run(() =>
            {
                if (CGlobal.WLIDetectStep[1] == EStepsStatue.WaitRuning)
                { CGlobal.WLIDetectStep[1] = EStepsStatue.Runinng; }

                CGlobal.WLIDetectStep[1] = EStepsStatue.OK;
            });
            return true;
        }

        /// <summary>
        /// 产品检测
        /// </summary>
        /// <returns></returns>
        public bool ProductCheck()
        {
            Task.Run(() =>
            {
                if (CGlobal.WLIDetectStep[2] == EStepsStatue.WaitRuning)
                { CGlobal.WLIDetectStep[2] = EStepsStatue.Runinng; }

                CGlobal.WLIDetectStep[2] = EStepsStatue.OK;
            });
            return true;
        }

        /// <summary>
        /// 主动对焦
        /// </summary>
        /// <returns></returns>
        public bool AutoFoucs()
        {
            ShowMsg("开始自动对焦");
            if (CGlobal.camera == null)
            { CGlobal.WLIDetectStep[3] = EStepsStatue.NG; return false; }
            CGlobal.camera.SetTrigMode(TrigMode.OFF);
            List<double> fouceDataList = new List<double>();
            ShowMsg("向上移动0.1cm");
            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 0.8, true);
            Thread.Sleep(100);
            CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, 0.1); //向上走
            Thread.Sleep(500);
            while (!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop)
            { Thread.Sleep(10); }
            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 0.01, true);
            ShowMsg("向下移动，寻找焦面");
            CGlobal.camera.SetFramRate(500);

            //double start = CGlobal.cAxisStatueArr[2].PosPulse - 0.001;
            //double interver = -0.002;
            //double end = CGlobal.cAxisStatueArr[2].PosPulse - 0.399;
            //CGlobal.acsHdl.SetPegInc(0, 0x101, 0x101, 0, 0x0000, 1, start, interver, end, 0, 2);
            Thread.Sleep(100);



            CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, -0.4); //向下走
            Thread.Sleep(100);
            if (CGlobal.WLIDetectStep[3] == EStepsStatue.WaitRuning)
            { CGlobal.WLIDetectStep[3] = EStepsStatue.Runinng; }
            Task.Run(() =>
            {
                while (CGlobal.WLIDetectStep[3] == EStepsStatue.Runinng)
                {
                    if (CGlobal.autoFouceDataQueue.Count > 0)
                    {
                        for (int i = 0; i < CGlobal.autoFouceDataQueue.Count; i++)
                        {
                            byte[] data = CGlobal.autoFouceDataQueue.Dequeue();
                            Mat mat = new Mat(CImage2PointCloud.picH, CImage2PointCloud.PicW, MatType.CV_8UC1);
                            Marshal.Copy(data, 0, mat.Data, CImage2PointCloud.picH * CImage2PointCloud.PicW);
                            double fouceScore = CFocusAlg.GetImgQualityScore(mat, 0);
                            fouceDataList.Add(fouceScore);
                            if (fouceDataList.Count > 20)
                            {
                                //IntPtr dataInptr = Marshal.AllocHGlobal(fouceDataList.Count); ;
                                //Marshal.Copy(fouceDataList.ToArray(), 0, dataInptr, fouceDataList.Count);
                                bool haveJizhi = false;
                                int JizhiNb = -1;
                                IntPtr pos = DouUpDownCountHandlerDll.DouUpDownCountHandler.Findjizhi(fouceDataList.ToArray(), fouceDataList.Count, 0.35, ref haveJizhi, ref JizhiNb);

                                if (haveJizhi)
                                {
                                    CGlobal.acsHdl.Stop(CGlobal.motionCfg.ZAxisIndex, "halt");
                                    CGlobal.autofouceData = CGlobal.cAxisStatueArr[2].PosPulse;
                                    int[] posArr = new int[JizhiNb];
                                    Marshal.Copy(pos, posArr, 0, JizhiNb);
                                    CGlobal.WLIDetectStep[3] = EStepsStatue.OK;
                                    ShowMsg("寻找焦面结束");
                                }
                                pos = IntPtr.Zero;
                            }
                        }

                    }

                }
                CGlobal.WLIDetectStep[3] = EStepsStatue.OK;
            });

            return true;

        }

        /// <summary>
        /// 确定上下限
        /// </summary>
        /// <returns></returns>
        public bool MakesureUpAndLowLimint()
        {
            ShowMsg("开始查找上下限");
            List<double> fouceDataList = new List<double>();
            CGlobal.autoFouceDataQueue.Clear();
            if (CGlobal.WLIDetectStep[4] == EStepsStatue.WaitRuning)
            { CGlobal.WLIDetectStep[4] = EStepsStatue.Runinng; }

            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 0.8, true);
            CGlobal.acsHdl.AbsMove(CGlobal.motionCfg.ZAxisIndex, CGlobal.autofouceData);
            Thread.Sleep(100);
            while (!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop)
            { Thread.Sleep(10); }
            Thread.Sleep(100);
            ShowMsg("向上移动0.1cm");
            CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, 0.1); //向上走
            Thread.Sleep(100);
            while (!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop)
            { Thread.Sleep(10); }
            CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 0.02, true);
            //设置相机
            CGlobal.camera.SetTrigMode(TrigMode.ON);
            CGlobal.autoFouceDataQueue.Clear();
            ShowMsg("设置PEG参数");
            double start = CGlobal.cAxisStatueArr[2].PosPulse - 0.001;
            double interver = -0.001;
            double end = CGlobal.cAxisStatueArr[2].PosPulse - 0.199;
            CGlobal.acsHdl.SetPegInc(0, 0x101, 0x101, 0, 0x0000, 1, start, interver, end, 0, 2);
            Task.Run(() =>
            {
                ShowMsg("开始向下移动");
                CGlobal.acsHdl.IncMove(CGlobal.motionCfg.ZAxisIndex, -0.2); //向下走
                Thread.Sleep(100);
                while ((!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop) || CGlobal.autoFouceDataQueue.Count > 0)
                {

                    if (CGlobal.autoFouceDataQueue.Count > 0)
                    {
                        byte[] data = CGlobal.autoFouceDataQueue.Dequeue();
                        Mat mat = new Mat(CImage2PointCloud.picH, CImage2PointCloud.PicW, MatType.CV_8UC1);
                        Marshal.Copy(data, 0, mat.Data, CImage2PointCloud.picH * CImage2PointCloud.PicW);
                        double fouceScore = CFocusAlg.GetImgQualityScore(mat, 0);
                        fouceDataList.Add(fouceScore);
                    }
                }
                ShowMsg("移动结束");
                if (fouceDataList.Count > 20)
                {
                    ShowMsg("计算上下限");
                    //IntPtr dataInptr = Marshal.AllocHGlobal(fouceDataList.Count); ;
                    //Marshal.Copy(fouceDataList.ToArray(), 0, dataInptr, fouceDataList.Count);
                    bool haveJizhi = false;
                    int JizhiNb = -1;
                    IntPtr pos = DouUpDownCountHandlerDll.DouUpDownCountHandler.Findjizhi(fouceDataList.ToArray(), fouceDataList.Count, 0.15, ref haveJizhi, ref JizhiNb);
                    using (StreamWriter sw = new StreamWriter("D:\\F.txt"))
                    {
                        for (int i = 0; i < fouceDataList.Count; i++)
                        {
                            sw.WriteLine(fouceDataList[i].ToString());
                        }
                    }




                    if (haveJizhi)
                    {
                        string tx = "";
                        //CGlobal.acsHdl.Stop(CGlobal.zAixIndex, "halt");
                        //CGlobal.autofouceData = CGlobal.cAxisStatueArr[2].PosPulse;
                        int[] posArr = new int[JizhiNb];
                        Marshal.Copy(pos, posArr, 0, JizhiNb);
                        CGlobal.WLIDetectStep[4] = EStepsStatue.OK;
                        if (JizhiNb == 0)
                        { CGlobal.WLIDetectStep[4] = EStepsStatue.NG; }
                        else if (JizhiNb == 1)
                        {
                            CGlobal.limitdata[0] = start + interver * posArr[0];
                            CGlobal.limitdata[1] = start + interver * posArr[0];
                            CGlobal.WLIDetectStep[4] = EStepsStatue.OK;
                        }
                        else
                        {
                            CGlobal.limitdata[0] = start + interver * posArr[0];
                            CGlobal.limitdata[1] = start + interver * posArr[JizhiNb - 1];
                            CGlobal.WLIDetectStep[4] = EStepsStatue.OK;
                            tx = posArr[0].ToString() + "," + posArr[JizhiNb - 1].ToString();
                        }
                        if (CGlobal.WLIDetectStep[4] == EStepsStatue.OK)
                        {
                            ShowMsg("查找上下限成功," + tx);
                            this.Invoke(new System.Action(() =>
                            {
                                pDataAcq.uManualControl1.Start_Nud.Value = (decimal)CGlobal.limitdata[0] * 1000 + 8;
                                pDataAcq.uManualControl1.End_Nud.Value = (decimal)CGlobal.limitdata[1] * 1000 - 3;
                            }));
                        }

                    }
                    //pos = IntPtr.Zero;
                }




            });
            return true;

        }
        /// <summary>
        /// 光强确认
        /// </summary>
        /// <returns></returns>
        public bool MakesureLightVal()
        {
            if (CGlobal.WLIDetectStep[5] == EStepsStatue.WaitRuning)
            { CGlobal.WLIDetectStep[5] = EStepsStatue.Runinng; }
            Task.Run(() =>
            {


                CGlobal.WLIDetectStep[5] = EStepsStatue.OK;
            });
            return true;

        }

        /// <summary>
        /// 采集数据
        /// </summary>
        /// <returns></returns>
        public bool GetImageData()
        {
            ShowMsg("设置触发参数");
            resultSavePath=CGlobal.resultSaveFold+"-"+System.DateTime.Now.ToString("HH-mm-ss");
            SetCameraModel(0x01);
            pDataAcq.PEG_Btn_Click(null, null);
            CGlobal.pEGCfg.CalImageCount();
            Thread.Sleep(20);
            CGlobal.detectDataQueue.Clear();
            CImage2PointCloud.imgIndex = 0;
            
            Thread.Sleep(20); ;
            CGlobal.WLIDetectStep[6] = EStepsStatue.Runinng;
            if (CGlobal.pEGCfg.ImageCount > 2000)
            {
                ShowMsg("ImageCount >2000"); 
                CGlobal.WLIDetectStep[6] = EStepsStatue.NG;
                return false;
            }
            double rate = (double)((CGlobal.pEGCfg.Vel )/CGlobal.pEGCfg.InteverZ );
            if (rate > 190)
            {
                ShowMsg("相机触发间隔 大于相机帧率,请降低速度，或者增大间隔");
                CGlobal.WLIDetectStep[6] = EStepsStatue.NG;
                return false;
            }

            Task.Run(() =>
            {
                CGlobal.acsHdl.EnableAxis(CGlobal.motionCfg.ZAxisIndex, true);
                CGlobal.acsHdl.SetAccelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zAcc / CGlobal.zRatio, true);
                CGlobal.acsHdl.SetDecelerationImm(CGlobal.motionCfg.ZAxisIndex, CGlobal.zDec / CGlobal.zRatio, true);
                CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, 3800000, true);
                Thread.Sleep(10);
                float offset = (float)Offset_Nud.Value/ CGlobal.zRatio;
                offset = (float)1f / CGlobal.zRatio;
                CGlobal.acsHdl.AbsMove(CGlobal.motionCfg.ZAxisIndex, CGlobal.pEGCfg.StartZ + ((CGlobal.pEGCfg.StartZ < CGlobal.pEGCfg.EndZ)? (-1*offset) : (offset)));
                ShowMsg("算法初始化");
                ShowMsg("移动至起始点");
                SetCameraModel(0x01);
                Thread.Sleep(100);
                while (!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop)
                { Thread.Sleep(10); }
                pDataAcq.PEG_Btn_Click(null, null);
                CGlobal.pEGCfg.CalImageCount();
                //int re5= ImageToCloudPointAlg.Init(CGlobal.pEGCfg.ImageCount, CImage2PointCloud.picH, CImage2PointCloud.PicW,72);
                //初始化
                SetInitCmd(CGlobal.pEGCfg.ImageCount-8,CImage2PointCloud.PicW, CImage2PointCloud.picH); //初始化
                bool isOk1 = WaitAlgCmdIsOk();
                if (!isOk1)
                { ShowMsg("Init 失败; ImageCount,"); CGlobal.WLIDetectStep[6] = EStepsStatue.NG; }
                else
                {
                    Thread.Sleep(100);
                    while (!CGlobal.cAxisStatueArr[CGlobal.motionCfg.ZAxisIndex].IsStop)
                    { Thread.Sleep(10); }
                    CGlobal.acsHdl.SetVelocity(CGlobal.motionCfg.ZAxisIndex, CGlobal.pEGCfg.Vel, true);
                    Thread.Sleep(200);
                    ShowMsg("运动至终点，开始采集图片");
                    CGlobal.pEGCfg.CalImageCount();
                    pDataAcq.PEG_Btn_Click(null, null);
                    Thread.Sleep(200);
                    DateTime start = DateTime.Now;
                    //传递数据指令
                    //SetCameraModel(0x00);
                    SetTransImage(resultSavePath);
                    double moveEnd = CGlobal.pEGCfg.EndZ  + ((CGlobal.pEGCfg.StartZ > CGlobal.pEGCfg.EndZ) ? ( offset) : (-1 * offset));
                    CGlobal.acsHdl.AbsMove(CGlobal.motionCfg.ZAxisIndex, CGlobal.pEGCfg.EndZ + ((CGlobal.pEGCfg.StartZ > CGlobal.pEGCfg.EndZ) ? -1*offset : (1 * offset)));
                    Thread.Sleep(100);
                    bool isOk= WaitAlgCmdIsOk();
                    ShowMsg("结束采集图片");
                    //ShowMsg("采集图片耗时" + DateTime.Now.Subtract(start).TotalMilliseconds.ToString());
                    ShowMsg("传输图片中......");
                    SetCameraModel(0x00);
                    isOk = WaitAlgCmdIsOk();
                    //ShowMsg("传递图片数量：" + CImage2PointCloud.imgIndex.ToString());
                    ShowMsg("结束传输图片");
                    CGlobal.WLIDetectStep[6] = isOk ? EStepsStatue.OK: EStepsStatue.NG;
                }

            });

            return true;
        }
        /// <summary>
        /// 计算数据
        /// </summary>
        /// <returns></returns>
        public bool CalData()
        {

            CGlobal.WLIDetectStep[7] = EStepsStatue.Runinng;
            ShowMsg("开始算法计算.");
            //Thread.Sleep(1000);
            SetAlgDetectCmd();
           bool isOk= WaitAlgCmdIsOk();

            ShowMsg("结束算法计算.");
            Task.Run(() =>
            {
                if (CGlobal.WLIDetectStep[7] == EStepsStatue.WaitRuning)
                {}
                CGlobal.WLIDetectStep[7] = EStepsStatue.OK;
            });
            return true;
        }
        /// <summary>
        /// 计算数据
        /// </summary>
        /// <returns></returns>
        public bool ExportResult()
        {
            CGlobal.WLIDetectStep[8] = EStepsStatue.Runinng;
            ShowMsg("开始输出数据");
            Task.Run(() =>
            {
                CGlobal.WLIDetectStep[8] = EStepsStatue.OK;
                if (OnTestStatueChange != null)
                {
                    OnTestStatueChange(101, Path.Combine(resultSavePath,"result"));
                }


                this.Invoke(new System.Action(() =>
                    {
                        pDataAcq.uManualControl1.TotalTest_Btn.Enabled = true;
                    }));

                ShowMsg("结束输出数据");
            });
            return true;

        }
        #endregion

        #region AlgOp

        /// <summary>
        /// 启动算法模块
        /// </summary>
        /// <param name="exeName"></param>
        /// <returns></returns>
        public bool RunAlgExe(string exeName= "TMicroscopeAlg.exe")
        {
            Task.Run(() =>
            {
                string exefilePath = Path.Combine(Environment.CurrentDirectory, exeName);
                if (File.Exists(exefilePath))
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = exefilePath;
                    Process process = Process.Start(processStartInfo);

                    if (process != null)
                    {
                        ShowMsg("算法模块启动成功.");
                        return true;
                    }
                    else
                    {
                        ShowMsg("算法模块启动失败.");
                        return false;
                    }

                }
                else
                { ShowMsg("算法程序未找到."); return false; }
            });
            return true;

        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public bool  KillProcess(string processName = "TMicroscopeAlg")
        {
            foreach (var process in Process.GetProcessesByName("TMicroscopeAlg"))
            {
                try
                {
                    process.Kill(); // 尝试关闭进程
                    process.WaitForExit(); // 等待进程退出
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            CGlobal.cObjectConfig.LoadObjectConfig();
            CGlobal.motionCfg.LoadMotionConfig();
            LoadCameraCfg();
            RunAlgExe();
            ShowMsg("程序启动");
            topTitle1.Min_Btn.Click += Main_Min;
            topTitle1.Max_Btn.Click += Main_Max;
            topTitle1.Close_Btn.Click += Main_Close;
            leftTitlePanel1.DoubleClick += Main_Max;
            leftTitlePanel1.leftNevigate1.NodeMouseClick += NodeMouseClick;
            pDataAcq.OnInit += Init_Btn_Click;

            pDataAcq.uManualControl1.wliWorkFlow1.OnButtonClick += WliWorkFlow1_OnButtonClick;
            OnTestStatueChange += CWLIDetect_OnTestStatueChange;
            MiddlePanle.Controls.Add(pDataAcq); pDataAcq.Dock = DockStyle.Fill;
            Init_Btn_Click(null, null);
            pParameter.SavePara_Btn.Click += SavePara_Btn_Click;

            pDataAcq.uManualControl1.objectSelect1.SWTrig_Btn.Click += SWTrig_Btn_Click;
            pDataAcq.uManualControl1.objectSelect1.OutTrig_Btn.Click += OutTrig_Btn_Click; ;
            pDataAcq.uManualControl1.objectSelect1.ExposureTime_Pro.OnTProgressBarValueChanged += ExposureTime_Pro_OnTProgressBarValueChanged;
            pDataAcq.uManualControl1.objectSelect1.ShowObjectName();

            pDataAcq.uManualControl1.objectSelect1.SWTrig_Btn.Click += SWTrig_Btn_Click1;
            pDataAcq.pImage1.Img2D_Rb.CheckedChanged += Img2D_Rb_CheckedChanged;
        }

        private void Img2D_Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb=(RadioButton)sender;
            if (cb.Checked)
            {
                SetCameraModel(0x00);
                pDataAcq.uManualControl1.objectSelect1.SWTrig_Btn_Click(null, null);
            }
        }

        private void SWTrig_Btn_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ExposureTime_Pro_OnTProgressBarValueChanged(float oldValue, float newValue)
        {
            SetExporseTime((int)newValue);
        }

        private void OutTrig_Btn_Click(object sender, EventArgs e)
        {
            SetCameraModel(0x01);
        }

        private void SWTrig_Btn_Click(object sender, EventArgs e)
        {
            SetCameraModel(0x00);
        }

        private void CWLIDetect_OnTestStatueChange(int stepIndex, string msg)
        {
            if (stepIndex == 101)
            {
                Task.Run(() =>
                {
                    this.Invoke(new System.Action(() =>
                    {
                        pDataAcq.pImage1.Img3D_Rb.Checked = true;
                        Thread.Sleep(10);

                        string pathStr = Path.Combine(resultSavePath, "Result");
                        if (!Directory.Exists(pathStr))
                        { Directory.CreateDirectory(pathStr); }
                        string[] arr = pathStr.Split('\\');
                        string filePath = Path.Combine(pathStr, "Result-" + arr[arr.Length - 2] + ".png");

                        string[] files = Directory.GetFiles(msg,"*.txt");
                        if(files.Length>0)
                        pDataAcq.pImage1.d3model.ShowPointCloudData(resultArray, files[0], pathStr);
                    }));
                    Thread.Sleep(100);
                });
            }
        }

        private void WliWorkFlow1_OnButtonClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button bt = (System.Windows.Forms.Button)sender;
            int index = (int.Parse)(bt.Tag.ToString());
            if (index < 10)
            { TotalDetectMethod(); }
            else if (index == 10)
            { 
            }
            else if (index == 11)
            { }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            ReSetLocationAndSize();
            this.Refresh();
        }

        public void Main_Min(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void Main_Max(object sender, EventArgs e)
        {
            WindowStatueChanged();
        }
        public void Main_Close(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出程序", "请选择", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                pDataAcq.uManualControl1.SaveFormCfg();
                CGlobal.IsEixt = true;
                KillProcess();
                Thread.Sleep(100);
                if (CGlobal.acsHdl != null)
                {
                    CGlobal.acsHdl.CloseAxis(0);
                    //CGlobal.acsHdl.CloseAxis(1);
                    CGlobal.acsHdl.CloseAxis(2);
                    CGlobal.acsHdl.Analog_Output(0, -0.3);
                }
                this.Close();
            }

        }
        public void ReSetLocationAndSize()
        {

            leftTitlePanel1.Location = new System.Drawing.Point(0, 0);
            leftTitlePanel1.Height = Height;
            topTitle1.Location = new System.Drawing.Point(leftTitlePanel1.Width - 5, -1);
            topTitle1.Width = Width - leftTitlePanel1.Width + 5;
            topTitle1.TopTitle_Resize(null, null);
            MiddlePanle.Size = new System.Drawing.Size(Width - leftTitlePanel1.Width, Height - topTitle1.Height + 1);
            MiddlePanle.Location = new System.Drawing.Point(leftTitlePanel1.Width, topTitle1.Height - 1);
        }

        public void WindowStatueChanged()
        {
            if (this.WindowState == FormWindowState.Maximized)
            { this.WindowState = FormWindowState.Normal; }
            else
            { this.WindowState = FormWindowState.Maximized; }
            ReSetLocationAndSize();
        }

        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int lv = e.Node.Level;
            int index = e.Node.Index;

            
            if (lv == 0)
            {
                #region 第一层
                switch (index)
                {
                    case 0: break;
                    case 1:
                        //MiddlePanle.Controls.Add(pAnalysis); pAnalysis.Dock = DockStyle.Fill;
                        //pAnalysis.PAnalysis_Resize(null, null);
                        //pAnalysis.Refresh();
                        if (!MiddlePanle.Controls.Contains(pDataAcq))
                        { MiddlePanle.Controls.Clear(); MiddlePanle.Controls.Add(pDataAcq); }
                        pDataAcq.pImage1.Img3D_Rb.Checked = true;
                        pDataAcq.pImage1.d3model.IsAnalysis= !pDataAcq.pImage1.d3model.IsAnalysis;
                        break;
                    case 2:

                        break;
                    default: break;
                }
                #endregion
            }
            if (lv == 1)
            {
                MiddlePanle.Controls.Clear();
                string identity = string.Format("{0}_{1}", e.Node.Parent.Index, index);
                string nevigateStr = e.Node.Parent.Text.Split('.')[1] + "/" + e.Node.Text;
                topTitle1.ShowNevigateInfo(nevigateStr);
                #region 第二层
                switch (identity)
                {
                    case "0_0":
                        string cameraPath = Path.Combine(CGlobal.cfgFold, "camera.cfg");
                        if (File.Exists(cameraPath))
                        {
                            CGlobal.cameracfg.LoadCameraConfig();
                            

                            pParameter.PicW_Nud.Value = CGlobal.cameracfg.ImgeW;
                            pParameter.PicH_Nud.Value = CGlobal.cameracfg.ImgeH;
                            pParameter.Vel_Nud.Value = (decimal)CGlobal.cameracfg.ScanVel; 
                        }
                        MiddlePanle.Controls.Add(pParameter);
                        pParameter.Dock = DockStyle.Fill;
                        break;
                    case "0_1":
                        if (CGlobal.cameracfg.ImgeW != CImage2PointCloud.PicW || CGlobal.cameracfg.ImgeH != CImage2PointCloud.picH)
                        {
                            SetImageHW(CGlobal.cameracfg.ImgeW, CGlobal.cameracfg.ImgeH);
                            bool  isOk = WaitCameraCmdIsOk();
                            ShowMsg(isOk ? "设置图片大小成功" : "设置图片大小失败");
                        }
                        pDataAcq.uManualControl1.Vel_Nud.Value = (decimal)CGlobal.cameracfg.ScanVel;
                        MiddlePanle.Controls.Add(pDataAcq);
                        pDataAcq.uManualControl1.objectSelect1.ShowObjectName();
                        pDataAcq.Dock = DockStyle.Fill;
                        pDataAcq.pImage1.Img3D_Rb.Checked = false;
                        pDataAcq.pImage1.d3model.IsAnalysis = false;
                        break;
                    case "0_2": break;
                    default: break;
                }
                #endregion
            }
        }

        private void topTitle1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowStatueChanged();
        }


        private void Init_Btn_Click(object sender, EventArgs e)
        {
           bool isOk1= InitCamera();
           bool isOk2= InitMotion();
            this.pDataAcq.uManualControl1.wliWorkFlow1.Init_Btn.Enabled = !(isOk1&& isOk2);
        }

        private void SavePara_Btn_Click(object sender, EventArgs e)
        {
            string cameraPath = Path.Combine(CGlobal.cfgFold, "camera.cfg");
            if (!Directory.Exists(CGlobal.cfgFold))
            { Directory.CreateDirectory(CGlobal.cfgFold); }
            if (!File.Exists(cameraPath))
            { File.Create(cameraPath).Close(); }

            if (File.Exists(cameraPath))
            {
                //using (StreamWriter sw = new StreamWriter(cameraPath))
                //{
                //    sw.WriteLine(pParameter.PicW_Nud.Text);
                //    sw.WriteLine(pParameter.PicH_Nud.Text);
                //    sw.WriteLine(pParameter.Vel_Nud.Text);

                //    sw.WriteLine(pParameter.Pos1_Nud.Text);
                //    sw.WriteLine(pParameter.Pos2_Nud.Text);
                //    sw.WriteLine(pParameter.Pos3_Nud.Text);
                //    sw.WriteLine(pParameter.Pos4_Nud.Text);
                //    sw.WriteLine(pParameter.Pos5_Nud.Text);

                //}
                LoadCameraCfg();

            }
        }

        public void LoadCameraCfg()
        {
            string cameraPath = Path.Combine(CGlobal.cfgFold, "camera.cfg");

            CGlobal.cameracfg.LoadCameraConfig();
            CImage2PointCloud.PicW = CGlobal.cameracfg.ImgeW;
            CImage2PointCloud.picH = CGlobal.cameracfg.ImgeH;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
