using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTCameraLib;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics.Eventing.Reader;
using OpenCvSharp;
using System.IO;
using System.Web;
using System.Drawing.Imaging;

namespace TMicroscopeAlg
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
        }


        #region Camera

        Thread cameraThread;
        Thread imageThread;


        HaiKangCamera camera = new HaiKangCamera();
        int imgW = 2048;
        int imgH = 2048;
        int imgCount = 0;
        byte[] imgSendData = new byte[2048 * 2048];

        long catchCount = 0;

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
        /// 相机发送指令
        /// </summary>
        public void CameraCmdReadMethod()
        {
            while (true)
            {
                cameraCmdAccessor.ReadArray(0, cameraCmdData, 0, cameraCmdData.Length);
                int cameraCmdIdata = BitConverter.ToInt32(cameraCmdData, 0);
                if (cameraCmdIdata != 0&& cameraCmdIdata != -1)
                {
                    ECameraCmd ecc = (ECameraCmd)(cameraCmdIdata);
                    bool re = true;
                    switch (ecc)
                    {
                        case ECameraCmd.OpenCamera:
                            re= InitCamera();
                            break;
                        case ECameraCmd.CloseCamera:
                            break;
                        case ECameraCmd.StartGrap:
                            break;
                        case ECameraCmd.StopGrap:
                            break;
                        case ECameraCmd.SetExporseTime:
                            re = SetExporseTime();
                            break;
                        case ECameraCmd.SetGrain:
                            re = SetGrain();
                            break;
                        case ECameraCmd.SetModel:
                            re = SetModel();
                            break;
                        case ECameraCmd.SetImageWH:
                            re = SetImageHW();
                            break;
                        default: break;
                    }
                    //恢复指令区
                    cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(re ? 0 : -1)), 0, 4);
                }
            }
        }
        byte[] lastImageData;
        /// <summary>
        /// 发送图片数据
        /// </summary>
        public void SendImgDataMethod()
        {
            lastImageData = new byte[imgW * imgH];
            while (true)
            {
                if (!imgSendData.Equals(lastImageData))
                {
                    imageSendCmdAccessor.ReadArray(0, imageSendCmdData, 0, imageSendCmdData.Length);
                    int cmd = BitConverter.ToInt32(imageSendCmdData, 0);
                    if (cmd == 0 && imageSendCmdAccessor.CanWrite)
                    {
                        MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateOrOpen("ImageData", imgW * imgH);
                        MemoryMappedViewAccessor accessor = memoryMappedFile.CreateViewAccessor();
                        accessor.WriteArray(0, imgSendData, 0, imgSendData.Length);
                        imageSendCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)1), 0, 4);

                    }
                    lastImageData = imgSendData;
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 初始化相机
        /// </summary>
        public bool InitCamera()
        {
            bool isOk = true;
            TTCameraFactory factory = new TTCameraFactory();
            camera = new HaiKangCamera();
            List<string> cameraList = new List<string>();
            camera.GetCameraList(out cameraList);
            Tuple<TTPublic.EFunctionReturn, string> result = camera.Connect(0);
            string msg = result.Item1 == TTPublic.EFunctionReturn.Ok ? "相机初始化成功" : "相机初始化失败;" + result.Item2;
            if (result.Item1 == TTPublic.EFunctionReturn.Ok)
            {
                result = camera.SetFramRate(200);
                result = camera.SetParams(500, -1, -1);
                Thread.Sleep(100);
                GetImageWH();
                camera.StartGrab();
                camera.OnCameraCallback2 += Camera_OnCameraCallback2;
                return true;
            }
            else
            { isOk = false; }
            ShowMsg("InitCamera " + (isOk ? "OK" : "NG"));
            return isOk;
        }
        /// <summary>
        /// 获取长宽
        /// </summary>
        /// <returns></returns>
        public bool GetImageWH()
        {
            if (camera != null)
            {
                camera.GetWidthHeight(out int width, out int height);
                imgW = width;
                imgH = height;
                imgSendData = new byte[imgW * imgH];
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// 设置模式
        /// </summary>
        /// <returns></returns>
        public bool SetModel()
        {
            bool isOk = true;  
            cameraCmdDataAccessor.ReadArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
            if (camera != null)
            {
                Tuple<TTPublic.EFunctionReturn, string> re = camera.SetTrigMode(cameraCmdCfgData[0] == 0x00 ? TrigMode.OFF : TrigMode.ON);
                isOk = re.Item1 == TTPublic.EFunctionReturn.Ok;
            }
            else { isOk = false; }
            ShowMsg("SetModel " + (isOk ? "OK" : "NG"));
            return isOk;
        }
        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="exporsetime"></param>
        /// <returns></returns>
        public bool SetExporseTime()
        {
            bool isOk = true;   
            if (camera != null)
            {
                cameraCmdDataAccessor.ReadArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
                int exporsetime = BitConverter.ToInt32(cameraCmdCfgData, 0);

                Tuple<TTPublic.EFunctionReturn, string> re = camera.SetParams(exporsetime,-1,-1);
                isOk = re.Item1 == TTPublic.EFunctionReturn.Ok;
            }
            else { isOk = false; }
            ShowMsg("SetExporseTime " + (isOk ? "OK" : "NG"));
            return isOk;
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="exporsetime"></param>
        /// <returns></returns>
        public bool SetGrain()
        {
            bool isOk = true;
            if (camera != null)
            {
                cameraCmdDataAccessor.ReadArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
                int gain = BitConverter.ToInt32(cameraCmdCfgData, 0);
                Tuple<TTPublic.EFunctionReturn, string> re = camera.SetParams(-1, gain, -1);
                isOk = re.Item1 == TTPublic.EFunctionReturn.Ok;
            }
            else { isOk = false; }
            ShowMsg("SetModel " + (isOk ? "OK" : "NG"));
            return isOk;
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="exporsetime"></param>
        /// <returns></returns>
        public bool SetImageHW()
        {
            bool isOk = true;
            if (camera != null)
            {
                cameraCmdDataAccessor.ReadArray(0, cameraCmdCfgData, 0, cameraCmdCfgData.Length);
                int W = BitConverter.ToInt32(cameraCmdCfgData, 0);
                int H = BitConverter.ToInt32(cameraCmdCfgData, 4);
                camera.StopGrab();
               
                Tuple<TTPublic.EFunctionReturn, string> re = camera.SetWidthHeight(W, H);
                isOk= re.Item1 == TTPublic.EFunctionReturn.Ok;
                GetImageWH();
                camera.StartGrab();
            }
            else { isOk = false; }
            ShowMsg("SetModel " + (isOk ? "OK" : "NG"));
            return isOk;

        }


        /// <summary>
        /// 相机获取图像
        /// </summary>
        /// <param name="bitmapIntptr"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Camera_OnCameraCallback2(IntPtr bitmapIntptr)
        {
            try
            {
                byte[] bitMapArray = new byte[imgW * imgH];
                Marshal.Copy(bitmapIntptr, bitMapArray, 0, bitMapArray.Length);
                imgSendData = bitMapArray;

                //检测传递数据
                if (isTransImage)
                {
                    byte[] bitMapArrayDetect = new byte[imgW * imgH];
                    Marshal.Copy(bitmapIntptr, bitMapArrayDetect, 0, bitMapArrayDetect.Length);
                    detectData.Enqueue(bitMapArrayDetect);
                }
                catchCount++; ShowCatchCount(catchCount);
            }
            catch { }
        }

        #endregion

        #region Alg
        Thread algThread;
        bool isTransImage = false;
        Queue<byte[]> detectData = new Queue<byte[]>();
        int transInndex = 0;
        string resultFold = "";
        //su
        byte[] algCmdData = new byte[4];
        static MemoryMappedFile algCmd = MemoryMappedFile.CreateOrOpen("algCmd", 4);
        MemoryMappedViewAccessor algCmdAccessor = algCmd.CreateViewAccessor();

        byte[] algCmdCfgData = new byte[108];
        static MemoryMappedFile algCmdCfg = MemoryMappedFile.CreateOrOpen("algCmdData", 108);
        MemoryMappedViewAccessor algCmdCfgAccessor = algCmdCfg.CreateViewAccessor();



        /// <summary>
        /// 算法发送指令
        /// </summary>
        public void AlgCmdReadMethod()
        {
            while (true)
            {
                algCmdAccessor.ReadArray(0, algCmdData, 0, algCmdData.Length);
                int algCmdIdata = BitConverter.ToInt32(algCmdData, 0);
                if (algCmdIdata != -1&& algCmdIdata != 0)
                {
                    EAlgCmd eac = (EAlgCmd)(algCmdIdata);
                    bool re = true;
                    switch (eac)
                    {
                        case EAlgCmd.InitAlg:
                            re = InitAlg();
                            ShowMsg("InitAlg");
                            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(re ? 0 : -1)), 0, 4);
                            break;
                        case EAlgCmd.TransImage:
                            ShowMsg("TransImage");
                            re = TransImage();
                            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(re ? 0 : -1)), 0, 4);
                            break;
                        case EAlgCmd.AlgDetect:
                            ShowMsg("AlgDetect");
                            re= AlgDetect();
                            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(re ? 0 : -1)), 0, 4);
                            ShowMsg("-----disp-----");
                            Disp();
                            ShowMsg("-----Complete-----");
                            break;
                        default: break;
                    }
                    //恢复指令区(0 正确，10001返回错)
                    
                }
            }
        }

        /// <summary>
        /// 初始化算法
        /// </summary>
        public bool InitAlg()
        {
            algCmdCfgAccessor.ReadArray(0, algCmdCfgData, 0, algCmdCfgData.Length);
            int imageCount=BitConverter.ToInt32(algCmdCfgData,0);
            imgCount = imageCount;
            transInndex = 0;
            isTransImage = false;
            Thread.Sleep(10);
            detectData.Clear();
            int w = BitConverter.ToInt32(algCmdCfgData, 4);
            int h = BitConverter.ToInt32(algCmdCfgData, 8);
            int re= ImageToCloudPointAlg.Init(imageCount, w, h, 72);
            return re != -1;
        }

        /// <summary>
        /// 传递图片
        /// </summary>
        /// <returns></returns>
        public bool TransImage()
        {
            algCmdCfgAccessor.ReadArray(0, algCmdCfgData, 0, algCmdCfgData.Length);
            int len = BitConverter.ToInt32(algCmdCfgData, 0);
            byte[] foldB=new byte[len];
            Array.Copy(algCmdCfgData, 4, foldB, 0, foldB.Length);
            resultFold = Encoding.ASCII.GetString(foldB);
            isTransImage=true;
            int index = 0;
            while (transInndex<imgCount)
            {
                if (detectData.Count > 0)
                {
                    byte[] imageData = detectData.Dequeue();
                    Mat mat = new Mat(imgH, imgW, MatType.CV_8UC1);
                    mat.SetArray(imageData); ;
                    int re = ImageToCloudPointAlg.TransImageData(mat.Data, transInndex);
                    SaveImage(mat, transInndex);
                    if (re == -1)
                    { ShowMsg("TransImage Error"); }
                    transInndex++;
                    ShowMsg("TransImage" + transInndex);
                    index = 0;
                }
                else
                {
                    index++;
                    Thread.Sleep(10);
                    
                }

                if (index > 200)
                { return false; }
            }
            isTransImage = false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AlgDetect()
        {
            int re2 = ImageToCloudPointAlg.TransImageData2();
            ShowMsg("TransImageData2");
            int reD = ImageToCloudPointAlg.PostBuffer(transInndex);
            ShowMsg("PostBuffer");
            IntPtr reP = ImageToCloudPointAlg.ImageToPoints(transInndex);
            ShowMsg("ImageToPoints");
            float[] resultArray = new float[imgH * imgW];
            Marshal.Copy(reP, resultArray, 0, imgH * imgW);
            string pathStr = Path.Combine(resultFold, "Result");
            if (!Directory.Exists(pathStr))
            { Directory.CreateDirectory(pathStr); }
            string[] arr = pathStr.Split('\\');
            string filePath = Path.Combine(pathStr, "Result-" + arr[arr.Length - 2] + ".txt");
            SaveData(filePath, resultArray, imgW, imgH);
            ShowMsg("SaveData");
           
            
            return true;
        }
        /// <summary>
        /// 内存回收
        /// </summary>
        public void Disp()
        {
            ImageToCloudPointAlg.FreeAndDispose();
            GC.Collect();
            ImageToCloudPointAlg.FreeAndDispose2();
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="index"></param>
        public void SaveImage(Mat mat, int index)
        {
            if (/*CGlobal.cameracfg.IsSaveImage*/true)
            {
                string imgPath = Path.Combine(resultFold, "Pics");
                Task.Run(() =>
                {
                    if (!Directory.Exists(imgPath))
                    { Directory.CreateDirectory(imgPath); }
                    string fileName = Path.Combine(imgPath, index.ToString() + ".png");
                    mat.SaveImage(fileName);
                });
            }
        }

        /// <summary>
        /// 保存结果
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public static void SaveData(string savePath, float[] data, int rows, int cols)
        {
            float max=data.ToList().Max();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < cols; k++)
                {
                    sb.Append(Convert.ToString(Math.Round((data[i * cols + k]*(-1))+ max, 6)));
                    if (k != cols - 1)
                        sb.Append(',');
                }
                sb.Append('\n');
            }
            string str = sb.ToString();
            SaveTextToFile(str, savePath);
        }
        private static bool SaveTextToFile(string str, string targetPath)
        {
            try
            {
                if (File.Exists(targetPath))
                    File.Delete(targetPath);

                FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate);

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(str);
                }
                fs.Dispose();
            }
            catch (IOException)
            {
                Console.WriteLine();
            }
            return true;
        }

        #endregion

        #region Motion
        //相机指令数据
        byte[] motionData = new byte[208];
        static MemoryMappedFile motionCmd = MemoryMappedFile.CreateOrOpen("motionData", 208);
        MemoryMappedViewAccessor motionCmdAccessor = cameraCmdCfg.CreateViewAccessor();

        bool zIsStop = false;
        float zPosition=0.0f;

        Thread motionThread;


        /// <summary>
        /// 运动控制监控线程
        /// </summary>
        public void MotionMethod()
        {
            while (true)
            {
                if (motionCmdAccessor.CanRead)
                {
                    motionCmdAccessor.ReadArray(0, motionData, 0, motionData.Length);
                    zIsStop = BitConverter.ToInt32(motionData, 0) == 0;
                    zPosition = BitConverter.ToSingle(motionData, 4);
                    ShowMotionInfo(zIsStop, zPosition/20f);
                }
                Thread.Sleep(20);
            }
        }



        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            cameraCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(0)), 0, 4);
            algCmdAccessor.WriteArray(0, BitConverter.GetBytes((int)(0)), 0, 4);
            Start_Btn_Click(null, null);
        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            cameraThread = new Thread(CameraCmdReadMethod);
            cameraThread.IsBackground = true;
            cameraThread.Start();

            imageThread = new Thread(SendImgDataMethod);
            imageThread.IsBackground = true;
            imageThread.Start();

            algThread = new Thread(AlgCmdReadMethod);
            algThread.IsBackground = true;
            algThread.Start();

            motionThread = new Thread(MotionMethod);
            motionThread.IsBackground = true;
            motionThread.Start();
        }

        private void Stop_Btn_Click(object sender, EventArgs e)
        {
            if (cameraThread != null)
            { cameraThread.Abort(); }
            if (imageThread != null)
            { imageThread.Abort(); }
            if (algThread != null)
            { algThread.Abort(); }
            if (motionThread != null)
            { motionThread.Abort(); }
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="content"></param>
        public void ShowMsg(string content)
        {
            try
            {
                this.Invoke(new System.Action(() =>
                {
                    if (msgInfo_Lbx.Items.Count > 1000)
                    { msgInfo_Lbx.Items.Clear();}

                    string time = DateTime.Now.ToString("HH:mm:ss");
                    string str = string.Format("{0} {1}", time, content);
                    msgInfo_Lbx.Items.Insert(0, str);
                }));
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 显示图片采集数量
        /// </summary>
        /// <param name="count"></param>
        public void ShowCatchCount(long count)
        {
            this.BeginInvoke(new Action(() =>
            {
                ImageCount_Tbx.Text = count.ToString();
            }));
        }

        /// <summary>
        /// 显示图片采集数量
        /// </summary>
        /// <param name="count"></param>
        public void ShowMotionInfo(bool isStop,float position)
        {
            this.BeginInvoke(new Action(() =>
            {
                IsStop_Btn.Text = isStop ? "Stop" : "Moving";
                Position_Tbx.Text = position.ToString();
            }));
        }

    }
}
