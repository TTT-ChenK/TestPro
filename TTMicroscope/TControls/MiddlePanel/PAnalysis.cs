using Kitware.VTK;
using PCHandlerDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTMicroscope.TControls;
using KDataGridView;
using SharpDX.Direct2D1;
using System.IO;

namespace TTMicroscope
{
    public partial class PAnalysis : UserControl
    {
        public PAnalysis()
        {
            InitializeComponent();
        }
        vtkLookupTable colorLookupTable = vtkLookupTable.New();
        vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
        vtkActor actor = vtkActor.New();
        vtkPoints points_cloud = vtkPoints.New();
        vtkPolyData mesh = vtkPolyData.New();
        vtkRenderWindow renderWindow;
        vtkRenderer renderer;
        vtkRenderWindowInteractor renderWindowInteractor;
        vtkCamera camera;
        ImageList imageList = new ImageList();


        //数据集合
        List<CAnalysisData> analysisData = new List<CAnalysisData>();

        #region Method
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// 文件选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="content"></param>
        public void InSetWorkFlow(object sender, string content)
        {
            Button bt = sender as Button;
            bool isContained = imageList.Images.ContainsKey(bt.Name);

            if (!isContained)
            {
                if (bt.Image != null)
                { imageList.Images.Add(bt.Name, bt.Image); }
            }
            TreeNode node2 = new TreeNode(content);
            node2.ImageKey = bt.Name;
            node2.SelectedImageKey = bt.Name;
            WorkFlow_Trw.Nodes.Add(node2);
            WorkFlow_Trw.ExpandAll();
        }

        /// <summary>
        /// 工具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TreeViewOp(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bool isContained = imageList.Images.ContainsKey(bt.Name);

            if (!isContained)
            {
                if (bt.Image != null)
                { imageList.Images.Add(bt.Name, bt.Image); }
            }
            TreeNode ParaNode = WorkFlow_Trw.SelectedNode;
            if (ParaNode != null)
            {
                TreeNode node2 = new TreeNode(bt.Text);
                node2.SelectedImageKey = bt.Name;
                node2.ImageKey = bt.Name;
                ParaNode.Nodes.Add(node2);
                ParaNode.ExpandAll();
            }
        }


        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PreProcessBtnClick(object sender, EventArgs e)
        { 
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "Pre_Imges2Points_Btn":
                    break;
                case "Pre_Ponts2Model_Btn":
                    break;
                case "Pre_MakeLevel_Btn":
                    break;
                case "Pre_Filt_Btn":
                    break;
                case "Pre_ImageRotate_Btn":
                    break;
                case "Pre_Splice_Btn":
                    break;
            }
        }

        /// <summary>
        /// 元素构建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ElBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "El_3DModel_Btn":
                    break;
                case "El_Profile_Btn":
                    break;
                case "El_Contour_Btn":
                    break;
                case "El_Area_Btn":
                    break;
                case "El_EquelLevel_Btn":
                    break;
                case "El_Point_Btn":
                    break;
                case "El_Line_Btn":
                    break;
                case "El_Flat_Btn":
                    break;
                case "El_Cycle_Btn":
                    break;
            }
        }

        /// <summary>
        /// 2D处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TwoDProcessBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "TwoD_Point2Point_Btn":
                    break;
                case "TwoD_Straightness_Btn":
                    break;
                case "TwoD_Area_Btn":
                    break;
                case "TwoD_Angle_Btn":
                    break;

            }
        }

        /// <summary>
        /// 3D处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThreeDProcessBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "ThreeD_Flatness_Btn":
                    break;
                case "ThreeD_Roughness_Btn":
                    break;
                case "ThreeD_StepsH_Btn":
                    break;
                case "ThreeD_MinH_Btn":
                    break;
                case "ThreeD_MaxH_Btn":
                    break;
                case "ThreeD_Volume_Btn":
                    break;

            }
        }


        /// <summary>
        /// 3D处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OtherBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "Other_SavePro_Btn":
                    break;
                case "Other_LoadPro_Btn":
                    break;
                case "Other_Export_Btn":
                    break;
                case "Other_Print_Btn":
                    break;

            }
        }



        #endregion

        private void PAnalysis_Load(object sender, EventArgs e)
        {
            preProcess1.OnPreProcessButtonClicked += TreeViewOp;
            elePanel1.OnEleButtonClicked += TreeViewOp;
            _2DDetect1.On2DButtonClicked += TreeViewOp;
            _3DDetect1.On3DButtonClicked += TreeViewOp;
            otherTool1.OnOtherButtonClicked += TreeViewOp;

            preProcess1.OnPreProcessButtonClicked += PreProcessBtnClick;
            elePanel1.OnEleButtonClicked += ElBtnClick;
            _2DDetect1.On2DButtonClicked += TwoDProcessBtnClick;
            _3DDetect1.On3DButtonClicked += ThreeDProcessBtnClick;
            otherTool1.OnOtherButtonClicked += OtherBtnClick;




            WorkFlow_Trw.ImageList= imageList;
            kPage1.CreatePage("pppp");
            kPage1.CreatePage("pppp");
        }

        public void PAnalysis_Resize(object sender, EventArgs e)
        {
            WorkFlow_Tbx.Height = Height - File_Tbx.Height - 20;
            Tool_Tbx.Location=new Point(Width-Tool_Tbx.Width-5, Tool_Tbx.Location.Y);
            Tool_Tbx.Height = Height - 7;
            Pic_Tbx.Width = Width - WorkFlow_Tbx.Width - Tool_Tbx.Width - 20;
            Pic_Tbx.Height = Height - 10; ;
            kPage1.Size = new Size(Pic_Tbx.Width-3,Pic_Tbx.Height-34 );
            WorkFlow_Trw.Width = WorkFlow_Tbx.Width-2;
            WorkFlow_Trw.Height = WorkFlow_Tbx.Height - 42;

            ToolPanel.Width = Tool_Tbx.Width-4;
            WorkFlow_Trw.Height = Tool_Tbx.Height - 40;
            ToolPanel.Left = Tool_Tbx.Left+2;
            ToolPanel.Height = Tool_Tbx.Height - 34;
            WorkFlow_Trw.Height = WorkFlow_Tbx.Height - 30;
        }

        private void ImageFold_Btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string fold = fbd.SelectedPath;
                string[] foldArr= fold.Split('\\');
                string showPath = fold;
                if (foldArr.Length > 2)
                {
                    showPath = string.Format("...\\{0}\\{1}", foldArr[foldArr.Length - 2], foldArr[foldArr.Length - 1]);
                }
                InSetWorkFlow((Button)sender, showPath);
                analysisData.Add(new CAnalysisData(fold));
            }
        }

        private void FileLoad_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "点云数据|*.txt;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] foldArr = ofd.FileName.Split('\\');
                string showPath = ofd.FileName;
                if (foldArr.Length > 2)
                {
                    showPath = string.Format("...\\{0}\\{1}", foldArr[foldArr.Length - 2], foldArr[foldArr.Length - 1]);
                }
                InSetWorkFlow(sender, showPath) ;
                analysisData.Add(new CAnalysisData(ofd.FileName));
            }
        }
        private void ModelLoad_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "三维模型|*.stl";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] foldArr = ofd.FileName.Split('\\');
                string showPath = ofd.FileName;
                if (foldArr.Length > 2)
                {
                    showPath = string.Format("...\\{0}\\{1}", foldArr[foldArr.Length - 2], foldArr[foldArr.Length - 1]);
                }
                InSetWorkFlow(sender, showPath);
                analysisData.Add(new CAnalysisData(ofd.FileName));
            }
        }
        private void Test_Btn_Click(object sender, EventArgs e)
        {
            kPage1.CreatePage("pppp");
            int mm = kPage1.CurrentPageIndex;
        }
        private void kPage1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                if ((e.KeyState & 8) == 8)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        vtkPolyData vTKdata;
        private void WorkFlow_Trw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeView tv = sender as TreeView;
                if (tv != null&& tv.SelectedNode!=null)
                {
                    string tx   = tv.SelectedNode.Text;

                }
            }
        }

        private void kPage1_DragDrop(object sender, DragEventArgs e)
        {
        }


        public void ShowPointCloudData(float[] data, string filePath, string savePath)
        {
            //renderer.RemoveActor(actor);
            //InitRender();
            string resultPath = /*CGlobal.resultSaveFold + "\\result.txt"*/filePath;
            if (!File.Exists(resultPath))
            { MessageBox.Show(resultPath + " 文件不存在."); return; }

            using (StreamReader sr = new StreamReader(resultPath))
            {
                int rowIndex = 0;
                points_cloud = vtkPoints.New();
                mesh = vtkPolyData.New();
                int col = 0;
                while (!sr.EndOfStream)
                {
                    string sLineBuffer = sr.ReadLine();
                    string[] sLineArr = sLineBuffer.Split(new char[] { ',' });
                    col = sLineArr.Length;
                    for (int i = 0; i < sLineArr.Length; i++)
                    {
                        double x = i;
                        double y = rowIndex;
                        if (sLineArr[i] != null && sLineArr[i] != "")
                        {
                            double z = double.Parse(sLineArr[i]) / 80f;
                            points_cloud.InsertNextPoint(x, y, z);
                        }

                    }
                    rowIndex++;
                }
                //合成多边形数据

                //
                mesh.Reset();
                mesh.SetPoints(points_cloud);
                vtkCellArray strips = vtkCellArray.New();
                for (int y = 0; y < rowIndex - 1; y++)
                {
                    strips.InsertNextCell(2 * col);
                    for (int x = 0; x < col; x++)
                    {
                        strips.InsertCellPoint(y * col + x);
                        strips.InsertCellPoint((y + 1) * col + x);
                    }
                }
                mesh.SetStrips(strips);


                double[] centerpoint = mesh.GetCenter();
                //vtkPoints point_cloud = vtkPoints.New();
                //point_cloud = mesh.GetPoints();
                Console.WriteLine("centerpoint: {0}, {1}, {2}", centerpoint[0], centerpoint[1], centerpoint[2]);
                double[] bound = mesh.GetBounds();
                double minZ = bound[4];
                double maxZ = bound[5];
                //vtkLookupTable colorLookupTable = vtkLookupTable.New();
                colorLookupTable.SetTableRange(minZ, maxZ);
                colorLookupTable.SetHueRange(0.667, 0.0);
                colorLookupTable.Build();

                vtkUnsignedCharArray polycolors = vtkUnsignedCharArray.New();
                polycolors.SetNumberOfComponents(3);
                polycolors.SetName("Colors");

                for (int i = 0; i < mesh.GetNumberOfPoints(); i++)
                {
                    double[] dcolor = new double[3];
                    dcolor = colorLookupTable.GetColor(mesh.GetPoint(i)[2]);
                    polycolors.InsertNextTuple3(dcolor[0] * 255, dcolor[1] * 255, dcolor[2] * 255);
                }
                mesh.GetPointData().SetScalars(polycolors);


                //vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
                mapper.SetInput(mesh);


                // 5. 创建Actor
                //var actor = vtkActor.New();
                actor.SetMapper(mapper);

                //// Window
                //vtkRenderWindow renderWindow = renderWindowControl1.RenderWindow;
                //// renderer

                //renderer = renderWindow.GetRenderers().GetFirstRenderer();
                // 8. 添加Actor到渲染器中并设置背景颜色
                renderer.AddActor(actor);
                renderer.SetBackground(0.5, 0.5, 0.5); // 设置为灰色背景




                camera.SetPosition(centerpoint[0], centerpoint[1], maxZ);
                camera.SetFocalPoint(centerpoint[0], centerpoint[1], centerpoint[2]);
                camera.SetViewUp(0, 1, 0);
                renderer.SetActiveCamera(camera);
                renderer.ResetCamera();

                //pointPicker = vtkPointPicker.New();
                //renderWindowInteractor = renderWindow.GetInteractor();
                //renderWindowInteractor.LeftButtonPressEvt += new vtkObject.vtkObjectEventHandler(Interactor_AnyEventHandler);
                //uint v = renderWindowInteractor.AddObserver(
                // 9. 渲染并开始交互
                //renderWindow.Render();
                //points_cloud.Dispose();
                //points_cloud.FastDelete();
                ////mesh.Dispose();
                //mesh.DeleteCells();
                ////strips.Dispose();
                ////polycolors.Dispose();
                //GC.Collect();
                //GC.Collect();

                this.Invoke(new System.Action(() =>
                {

                    #region

                    string pathStr = savePath;
                    if (!Directory.Exists(pathStr))
                    { Directory.CreateDirectory(pathStr); }
                    string[] arr = pathStr.Split('\\');
                    string filePath1 = Path.Combine(pathStr, "Result-" + arr[arr.Length - 2] + ".png");
                    //System.Drawing.Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;
                    //Bitmap dumpBitmap = new Bitmap(screenRect.Width, screenRect.Height);
                    //Graphics tg = Graphics.FromImage(dumpBitmap);
                    //tg.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(dumpBitmap.Width, dumpBitmap.Height));
                    //dumpBitmap.Save(filePath);
                    //dumpBitmap.Dispose();
                    System.Drawing.Bitmap bt = new System.Drawing.Bitmap(this.Width, this.Height);
                    using (Graphics g = Graphics.FromImage(bt))
                    {
                        this.DrawToBitmap(bt, new System.Drawing.Rectangle(0, 0, this.Width,
                            this.Height));
                    }
                    //bt.Save(filePath1, System.Drawing.Imaging.ImageFormat.Png);
                    #endregion

                }));
            }
        }

        private void WorkFlow_Trw_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void WorkFlow_Trw_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn= sender as TreeNode;
            if (tn!=null)
            {
                WorkFlow_Trw.SelectedImageKey = tn.ImageKey;
            }         
        }


    }
}
