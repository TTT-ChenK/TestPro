using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KChart;
using KBase;
using Kitware.VTK;
using SharpDX.Direct3D12;
using System.Web.UI.WebControls;
using OpenCvSharp.Internal.Vectors;
using System.Web.Management;

namespace TTMicroscope.TControls
{
    public partial class K3DModel : UserControl
    {
        public K3DModel()
        {
            InitializeComponent();
        }
        #region Property

        /// <summary>
        /// 是否是分析模式
        /// </summary>
        private bool _isAnalysis = false;
        public bool IsAnalysis
        {
            set { _isAnalysis = value; K3DModel_Resize(null, null); }
            get { return _isAnalysis; }
        }

        #endregion

        #region variable
        vtkRenderWindow renderWindow;
        vtkRenderer renderer;
        vtkRenderWindowInteractor renderWindowInteractor;
        vtkLookupTable colorLookupTable = vtkLookupTable.New();

        vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
        vtkActor actor = vtkActor.New();
        vtkPoints points_cloud = vtkPoints.New();
        vtkPolyData mesh = vtkPolyData.New();
        vtkCamera camera;

        vtkScalarBarActor vtkScalarBarActor = vtkScalarBarActor.New();
        CustomInteractorStyle userStyle = new CustomInteractorStyle();
        vtkPointPicker pointPicker = vtkPointPicker.New();

        vtkActor poumian_actor = vtkActor.New();//剖面actor



        RunStep _step = RunStep.Null;
        public RunStep Step
        {
            set {
                _step = value;
                ShowStep(_step);
            }
            get { return _step; }
        }



        bool leftButtonIsDown = false;
        float[] originColor = new float[3] { 0.5f, 1, 0.5f };
        float[] selectColor = new float[3] { 0.5f, 0.5f, 0.5f };


        // 获取初始相机位置和方向
        double[] centerpoint;
        double minZ = 0;
        double maxZ = 1;



        CountLinePanel clp = new CountLinePanel();
        RoughTestPanel roughTest = new RoughTestPanel();
        LoadFilePanel loadFilePanel = new LoadFilePanel();
        LevelPanel levelPanel = new LevelPanel();

        #endregion

        #region Method

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitRender()
        {
            mapper?.Dispose();
            mapper = vtkPolyDataMapper.New();
            actor?.Dispose();
            actor = vtkActor.New();
            renderer?.Dispose();
            renderWindow = renderWindowControl1.RenderWindow;
            renderer = renderWindow.GetRenderers().GetFirstRenderer();
            camera?.Dispose();

            camera = renderer.GetActiveCamera();
            renderWindowInteractor?.Dispose();
            renderWindowInteractor = renderWindow.GetInteractor();
            vtkScalarBarActor.SetLookupTable(colorLookupTable);
            renderer.AddActor(vtkScalarBarActor);

            userStyle.SetPriority(1.0f);
            userStyle.SetInteractor(renderWindowInteractor);

            userStyle.LeftButtonPressEvt += new vtkObject.vtkObjectEventHandler(Interactor_LeftButtonPress);
            userStyle.LeftButtonReleaseEvt += new vtkObject.vtkObjectEventHandler(UserStyle_LeftButtonReleaseEvt);
            userStyle.RightButtonPressEvt += new vtkObject.vtkObjectEventHandler(Interactor_RightButtonPress);
            userStyle.MouseMoveEvt += new vtkObject.vtkObjectEventHandler(Interactor_MouseMove);
            camera.AnyEvt += Camera_AnyEvt;
            userStyle.AnyEvt += UserStyle_AnyEvt;
            //renderWindow.SetDesiredUpdateRate(30);
        }
        /// <summary>
        /// 加载Stl文件
        /// </summary>
        /// <param name="stlFilePath"></param>
        public vtkPolyData LoadStl(string stlFilePath)
        {
            if (File.Exists(stlFilePath))
            {
                vtkSTLReader reader = vtkSTLReader.New();
                reader.SetFileName(stlFilePath);
                reader.Update();
                vtkPolyData polydata = reader.GetOutput();
                return polydata;
            }
            return null;
        }

        /// <summary>
        /// 显示model
        /// </summary>
        /// <param name="polydata"></param>
        public void ShowModel(vtkPolyData polydata)
        {
            if (polydata != null)
            {
                double[] centerpoint = polydata.GetCenter();
                double[] bound = polydata.GetBounds();
                minZ = bound[4];
                maxZ = bound[5];
                colorLookupTable.SetTableRange(minZ, maxZ);
                colorLookupTable.SetHueRange(0.667, 0.0);
                colorLookupTable.Build();
                vtkUnsignedCharArray polycolors = vtkUnsignedCharArray.New();
                polycolors.SetNumberOfComponents(3);
                polycolors.SetName("Colors");

                for (int i = 0; i < polydata.GetNumberOfPoints(); i++)
                {
                    double[] dcolor = new double[3];
                    dcolor = colorLookupTable.GetColor(polydata.GetPoint(i)[2]);
                    polycolors.InsertNextTuple3(dcolor[0] * 255, dcolor[1] * 255, dcolor[2] * 255);
                }
                polydata.GetPointData().SetScalars(polycolors);

                mapper.SetInput(polydata);
                actor.SetMapper(mapper);

                renderer.AddActor(actor);
                renderer.SetBackground(1, 1, 1); // 设置为灰色背景


                vtkCamera camera = renderer.GetActiveCamera(); ;
                camera.SetPosition(centerpoint[0], centerpoint[1], maxZ);
                camera.SetFocalPoint(centerpoint[0], centerpoint[1], centerpoint[2]);
                camera.SetViewUp(0, 1, 0);
                renderer.SetActiveCamera(camera);
                renderer.ResetCamera();

                renderWindow.Render();
            }

        }

        /// <summary>
        /// 显示StlModel
        /// </summary>
        /// <param name="stlFilePath"></param>
        public void ShowStlModel(string stlFilePath)
        {
            vtkPolyData data = LoadStl(stlFilePath);
            if (data != null)
            { ShowModel(data); }
        }
        //显示坐标轴
        public void ShowAxes()
        {
            var axes = new vtkAxesActor();
            var widget = new vtkOrientationMarkerWidget();
            widget.SetOutlineColor(0.9300, 0.5700, 0.1300);
            widget.SetOrientationMarker(axes);
            widget.SetInteractor(renderWindowInteractor);
            widget.SetViewport(0.0, 0.0, 0.2, 0.2);
            widget.On();
            widget.InteractiveOff();
        }

        /// <summary>
        /// 显示颜色条
        /// </summary>
        public void ShowColorTable1()
        {
            vtkScalarBarActor scalarBar = vtkScalarBarActor.New();
            scalarBar.SetTitle("Z");//标注条标题
            scalarBar.SetLookupTable(mapper.GetLookupTable());
            scalarBar.GetPositionCoordinate().SetCoordinateSystemToNormalizedViewport();
            scalarBar.GetPositionCoordinate().SetValue(0.1, 0.1);
            scalarBar.SetOrientationToHorizontal();
            scalarBar.SetNumberOfLabels(8);
            scalarBar.SetWidth(0.4);
            scalarBar.SetHeight(0.1);

            vtkTextProperty labelProperty = scalarBar.GetLabelTextProperty();
            labelProperty.SetFontSize(12);
            scalarBar.SetLabelTextProperty(labelProperty);
            renderer.AddViewProp(scalarBar);



            vtkScalarBarWidget scalarBarWidget = vtkScalarBarWidget.New();
            scalarBarWidget.SetInteractor(renderWindowInteractor);
            scalarBarWidget.SetScalarBarActor(scalarBar);
            scalarBarWidget.Off();
            scalarBarWidget.SetEnabled(1);

        }

        /// <summary>
        /// 显示颜色条
        /// </summary>
        public void ShowColorTable()
        {
            vtkScalarBarRepresentation scalarBarRep = vtkScalarBarRepresentation.New();

            scalarBarRep.SetOrientation(1); // 0 for horizontal, 1 for vertical
            scalarBarRep.SetShowBorderToOn();
            //scalarBarRep.SetNumberOfLabels(5);
            // 其他设置...

            vtkScalarBarActor scalarBar = vtkScalarBarActor.New();
            scalarBar.SetLookupTable(mapper.GetLookupTable());
            scalarBarRep.SetScalarBarActor(scalarBar);
            renderer.AddViewProp(scalarBarRep);

            scalarBarRep.SetPosition(0.9, 0.1);
            scalarBarRep.SetPosition2(0.08, 0.8);

        }
        /// <summary>
        /// 设置缩放系数
        /// </summary>
        /// <param name="zScale"></param>
        public void SetZScale(double zScale)
        {
            renderer.GetActors();
            if (actor != null)
            {
                vtkActorCollection acts = renderer.GetActors();
                acts.InitTraversal();
                int count = acts.GetNumberOfItems();
                for (int i = 0; i < count; i++)
                {
                    vtkActor va= acts.GetNextActor();
                    actor.SetScale(1, 1, zScale);
                }
                renderWindow.Render();
                
            }
        }

        public int GetActorsCount()
        {
            vtkActorCollection acts = renderer.GetActors();
            int count = acts.GetNumberOfItems();
            return count;
        }

        /// <summary>
        /// 显示数据（读取文件）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        /// <param name="savePath"></param>
        public void ShowPointCloudData(float[] data,string filePath,string savePath)
        {
            //InitAnalysis();
            string resultPath = filePath;
            if (!File.Exists(resultPath))
            { MessageBox.Show(resultPath + " 文件不存在.");return; }

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
                    for (int i = 0; i <sLineArr.Length; i++)
                    {
                        double x = i;
                        double y = rowIndex;
                        int len = sLineArr.Length;
                        if (sLineArr[len-i-1] != null && sLineArr[len - i - 1] != "")
                        {
                            double z = double.Parse(sLineArr[len - i - 1]) / 80f;
                            points_cloud.InsertNextPoint(x, y, z*1);
                        }
                        
                    }
                    rowIndex++;
                }
                //合成多边形数据
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
                centerpoint = mesh.GetCenter();
                Console.WriteLine("centerpoint: {0}, {1}, {2}", centerpoint[0], centerpoint[1], centerpoint[2]);
                double[] bound = mesh.GetBounds();
                minZ = bound[4];
                maxZ = bound[5];
                colorLookupTable.SetTableRange(minZ, maxZ);
                colorLookupTable.SetHueRange(0.667, 0.0);
                vtkScalarBarActor.SetWidth(0.08);
                vtkScalarBarActor.SetPosition(0.9, 0.2);
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
                mapper.SetInput(mesh);
                actor.SetMapper(mapper);
                renderer.AddActor(actor); 
                renderer.SetBackground(0.0, 0.0, 0.0); // 设置为灰色背景
                InitCameraPos();
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public void ShowPointCloudData2(float[] data,int rowCount, int colCount)
        {
            //InitAnalysis();
            int rowIndex = 0;
            points_cloud = vtkPoints.New();
            mesh = vtkPolyData.New();
            int col = 0;

            for (int j = 0; j < rowCount; j++)
            {
                col = colCount;
                for (int i = 0; i < colCount; i++)
                {
                    double x = i;
                    double y = rowIndex;
                    int len = colCount;
                    float[] points = new float[len];
                    Array.Copy(data, j * colCount, points, 0, len);
                    if (points[len - i - 1] != null)
                    {
                        double z = points[len - i - 1] / 80f;
                        points_cloud.InsertNextPoint(x, y, z * 1);
                    }
                }
                rowIndex++;
            }

            //合成多边形数据
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


            centerpoint = mesh.GetCenter();
            Console.WriteLine("centerpoint: {0}, {1}, {2}", centerpoint[0], centerpoint[1], centerpoint[2]);
            double[] bound = mesh.GetBounds();
            minZ = bound[4];
            maxZ = bound[5];
            colorLookupTable.SetTableRange(minZ, maxZ);
            colorLookupTable.SetHueRange(0.667, 0.0);
            vtkScalarBarActor.SetWidth(0.06);
            vtkScalarBarActor.SetPosition(0.94, 0.2);
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
            mapper.SetInput(mesh);

            actor.SetMapper(mapper);
            renderer.AddActor(actor);
            renderer.SetBackground(0.0, 0.0, 0.0); // 设置为灰色背景
            InitCameraPos();
        }

        /// <summary>
        /// 设置相机位置
        /// </summary>
        public void InitCameraPos()
        {
            if (centerpoint != null)
            {
                camera.SetPosition(centerpoint[0], centerpoint[1], maxZ);
                camera.SetFocalPoint(centerpoint[0], centerpoint[1], centerpoint[2]);
                camera.SetViewUp(0, 1, 0);
                renderer.SetActiveCamera(camera);
                renderer.ResetCamera();
                camera.SetParallelProjection(1);
                renderWindow.Render();
            }
        }

        /// <summary>
        /// 获取相机的信息
        /// </summary>
        public void GetCameraInfo()
        {
            if (camera != null)
            {
                ratationMatrix = camera.GetViewTransformMatrix();
                angle = camera.GetViewAngle();
                translations = camera.GetPosition();
                scale = camera.GetViewUp();
            }
        }

        public void InitAnalysis()
        {
            Step = RunStep.Null;
            RemoveCutLint();
            RemoveLevelTraig();
            RemoveRectangle();

        }

        /// <summary>
        /// 获取小区域大小
        /// </summary>
        /// <param name="data"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public List<double> SelectRegion(float[] data, int row,int col, int x1, int x2, int y1, int y2)
        {
            int xcount = 0;
            int ycount = 0;
            List<double> result = new List<double>();
            int i = 0;
            for (int y = Math.Min( y1, y2); y < Math.Max(y1, y2); y++)
            {
                ycount = 0;
                for (int x = Math.Min(x1, x2); x < Math.Max(x1, x2); x++, i++)
                {
                    result.Add(data[y * col + x]); ycount++;
                }
                xcount++;
            }

            return result;
        }


        List<vtkActor> list = new List<vtkActor>();
        List<vtkActor> LevingActor=new List<vtkActor>();
        List<vtkActor> CutLineActor = new List<vtkActor>();
        List<vtkActor> RectangleActor = new List<vtkActor>();
        /// <summary>
        /// 增加球
        /// </summary>
        /// <param name="postion"></param>
        public void AddvtkSphereSource(double[] postion)
        {
            if (postion.Length == 3)
            {
                vtkSphereSource sphere = vtkSphereSource.New();      //点的位置加入圆球
                vtkLineSource line = vtkLineSource.New();
                
               
                sphere.SetThetaResolution(51);
                sphere.SetPhiResolution(17);
                sphere.SetRadius(10);
                vtkPolyDataMapper sphere_mapper = vtkPolyDataMapper.New();
                sphere_mapper.SetInput(sphere.GetOutput());
                vtkActor sphere_actor = vtkActor.New();
                sphere_actor.SetMapper(sphere_mapper);
                sphere_actor.SetPosition(postion[0], postion[1], postion[2]);
                vtkProperty sphere_property = vtkProperty.New();
                sphere_property.SetColor(originColor[0], originColor[1], originColor[2]);
                sphere_actor.SetProperty(sphere_property);
                renderer.AddActor(sphere_actor);
                list.Add(sphere_actor);
                renderWindow.Render(); 
            }
        }

        vtkLineSource lineS1 = vtkLineSource.New();      //点的位置加入圆球
        vtkLineSource lineS2 = vtkLineSource.New();      //点的位置加入圆球
        vtkLineSource lineS3 = vtkLineSource.New();      //点的位置加入圆球
        public vtkActor InitLineSource(vtkLineSource lineS)
        {
            //if (p1.Length == 3)
            {

                vtkPolyDataMapper line_mapper = vtkPolyDataMapper.New();
                line_mapper.SetInput(lineS.GetOutput());
                vtkActor line_actor = vtkActor.New();
                line_actor.SetMapper(line_mapper);
                vtkProperty sphere_property = vtkProperty.New();
                sphere_property.SetColor(originColor[0], originColor[1], originColor[2]);
                line_actor.SetProperty(sphere_property);
                return line_actor;
            }
            //else
            //{ return null; }
        }
        public vtkActor InitSpherSource(double[] postion)
        {
            if (postion.Length == 3)
            {
                vtkSphereSource sphere = vtkSphereSource.New();      //点的位置加入圆球
                sphere.SetThetaResolution(51);
                sphere.SetPhiResolution(17);
                sphere.SetRadius(15);
                vtkPolyDataMapper sphere_mapper = vtkPolyDataMapper.New();
                sphere_mapper.SetInput(sphere.GetOutput());
                vtkActor sphere_actor = vtkActor.New();
                sphere_actor.SetMapper(sphere_mapper);
                sphere_actor.SetPosition(postion[0], postion[1], postion[2]);
                vtkProperty sphere_property = vtkProperty.New();
                sphere_property.SetColor(originColor[0], originColor[1], originColor[2]);
                sphere_actor.SetProperty(sphere_property);
                return sphere_actor;
            }
            else
            { return null; }
        }

        /// <summary>
        /// 初始化校平区域
        /// </summary>
        public void InitLevelTraig()
        {
            if (actor != null)
            {
                LevingActor.Clear();
                double[] bouder = actor.GetBounds();
                double w = Math.Abs(bouder[1] - bouder[0]);
                double h = Math.Abs(bouder[2] - bouder[3]);
                //第一个球
                double[] p1 = new double[3] { bouder[0] + w / 3f, bouder[2] + h / 2f, 0 };
                double[] p2 = new double[3] { bouder[0] + w * 2f / 3f, bouder[2] + h / 3f, 0 };
                double[] p3 = new double[3] { bouder[0] + w * 2f / 3f, bouder[2] + h * 2f / 3f, 0 };

                //if (pointPicker.Pick(p1[0], p1[1], 0, renderer) == 1)
                //{ p1 = pointPicker.GetPickPosition(); }
                //if (pointPicker.Pick(p2[0], p2[1], 0, renderer) == 1)
                //{ p2 = pointPicker.GetPickPosition(); }
                //if (pointPicker.Pick(p3[0], p3[1], 0, renderer) == 1)
                //{ p3 = pointPicker.GetPickPosition(); }

                //p1[2] = p2[2] = p3[2] = maxZ;


                vtkActor v1 = InitSpherSource(p1);
                vtkActor v2 = InitSpherSource(p2);
                vtkActor v3 = InitSpherSource(p3);

                lineS1.SetPoint1(p1[0], p1[1], p1[2]);
                lineS1.SetPoint2(p2[0], p2[1], p2[2]);

                lineS2.SetPoint1(p2[0], p2[1], p2[2]);
                lineS2.SetPoint2(p3[0], p3[1], p3[2]);

                lineS3.SetPoint1(p3[0], p3[1], p3[2]);
                lineS3.SetPoint2(p1[0], p1[1], p1[2]);


                vtkActor l1 = InitLineSource(lineS1);
                vtkActor l2 = InitLineSource(lineS2);
                vtkActor l3 = InitLineSource(lineS3);

                LevingActor.Add(v1);
                LevingActor.Add(v2);
                LevingActor.Add(v3);
                LevingActor.Add(l1);
                LevingActor.Add(l2);
                LevingActor.Add(l3);

                for (int i = 0; i < LevingActor.Count; i++)
                {
                    renderer.AddActor(LevingActor[i]);
                }
                renderWindow.Render();
            }
        }
        /// <summary>
        /// 重置校平区域
        /// </summary>
        public void ResetLevelTraig()
        {
            if (LevingActor.Count == 6)
            {
                double[] p1 = LevingActor[0].GetCenter();
                double[] p2 = LevingActor[1].GetCenter();
                double[] p3 = LevingActor[2].GetCenter();
                lineS1.SetPoint1(p1[0], p1[1], p1[2]);
                lineS1.SetPoint2(p2[0], p2[1], p2[2]);
                lineS2.SetPoint1(p2[0], p2[1], p2[2]);
                lineS2.SetPoint2(p3[0], p3[1], p3[2]);
                lineS3.SetPoint1(p3[0], p3[1], p3[2]);
                lineS3.SetPoint2(p1[0], p1[1], p1[2]);
                //renderWindow.Render();
            }
        }
        /// <summary>
        /// 移除
        /// </summary>
        public void RemoveLevelTraig()
        {
            for (int i = 0; i < LevingActor.Count; i++)
            {
                renderer.RemoveActor(LevingActor[i]);
            }
            renderWindow.Render();
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void RemoveRectangle()
        {
            for (int i = 0; i < RectangleActor.Count; i++)
            {
                renderer.RemoveActor(RectangleActor[i]);
            }
            renderWindow.Render();
        }
        /// <summary>
        /// 初始化剖面线
        /// </summary>
        public void InitCutLine()
        {
            if (actor != null)
            {


                CutLineActor.Clear();
                double[] bouder = actor.GetBounds();
                double w = Math.Abs(bouder[1] - bouder[0]);
                double h = Math.Abs(bouder[2] - bouder[3]);
                double[] p1 = new double[3] { bouder[0] + w / 3f, bouder[2] + h / 2f, maxZ };
                double[] p2 = new double[3] { bouder[0] + w *2f/ 3f, bouder[2] + h / 3f, maxZ };

                vtkActor v1s = InitSpherSource(p1);
                vtkActor v2s= InitSpherSource(p2);
                CutLineActor.Add(v1s);
                CutLineActor.Add(v2s);
                renderer.AddActor(CutLineActor[0]);
                renderer.AddActor(CutLineActor[1]);
                Vector3 v1 = new Vector3((float)p1[0], (float)p1[1], (float)p1[2]);
                Vector3 v2 = new Vector3((float)p2[0], (float)p2[1], (float)p2[2]);
                Vector3 v3 = new Vector3((float)p2[0], (float)p2[1], 0);

                Vector3 nomal = ComputeNormal(v1, v2, v3);
                List<PointF> fList = GetData(v1, nomal);
                if (fList == null) return;
                CutLineActor.Add(poumian_actor);
                clp.kChart.SetData(fList);
                renderWindow.Render();
            }
        }
        /// <summary>
        /// 重置坡面线
        /// </summary>
        public void ResetCutLine()
        {
            double[] p1 = CutLineActor[0].GetCenter();
            double[] p2 = CutLineActor[1].GetCenter();
            Vector3 v1 = new Vector3((float)p1[0], (float)p1[1], (float)p1[2]);
            Vector3 v2 = new Vector3((float)p2[0], (float)p2[1], (float)p2[2]);
            Vector3 v3 = new Vector3((float)p2[0], (float)p2[1], 0);

            Vector3 nomal = ComputeNormal(v1, v2, v3);
            List<PointF> fList = GetData(v1, nomal);
            if (fList == null) return;
            clp.kChart.SetData(fList);
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void RemoveCutLint()
        {
            for (int i = 0; i < CutLineActor.Count; i++)
            {
                renderer.RemoveActor(CutLineActor[i]);
            }
            renderWindow.Render();
        }
        /// <summary>
        /// 初始化剖面线
        /// </summary>
        public void InitRectangle()
        {
            if (actor != null)
            {
                RectangleActor.Clear();
                double[] bouder = actor.GetBounds();
                double w = Math.Abs(bouder[1] - bouder[0]);
                double h = Math.Abs(bouder[2] - bouder[3]);
                double[] p1 = new double[3] { bouder[0] + w / 3f, bouder[2] + h / 2f, 0.01f };
                double[] p2 = new double[3] { bouder[0] + w * 2f / 3f, bouder[2] + h / 3f, 0.01f };

                vtkActor v1s = InitSpherSource(p1);
                vtkActor v2s = InitSpherSource(p2);
                RectangleActor.Add(v1s);
                RectangleActor.Add(v2s);
                renderer.AddActor(RectangleActor[0]);
                renderer.AddActor(RectangleActor[1]);
                Vector3 v1 = new Vector3((float)p1[0], (float)p1[1], 0.01f);
                Vector3 v2 = new Vector3((float)p1[0], (float)p2[1], 0.01f);
                Vector3 v3 = new Vector3((float)p2[0], (float)p1[1], 0.01f);

                Vector3 nomal = ComputeNormal(v1, v2, v3);
                vtkActor va = GetRectangleData2(v1, v2, v3);
                RectangleActor.Add(va);
                renderer.AddActor(va);
                renderWindow.Render();
            }
        }

        public void ResetRectangle()
        {
            if (actor != null)
            {
                double[] p1 = RectangleActor[0].GetCenter();
                double[] p2 = RectangleActor[1].GetCenter();

                Vector3 v1 = new Vector3((float)p1[0], (float)p1[1], 0.01f);
                Vector3 v2 = new Vector3((float)p1[0], (float)p2[1], 0.01f);
                Vector3 v3 = new Vector3((float)p2[0], (float)p1[1], 0.01f);

                planeSource.SetOrigin(v1.x, v1.y, v1.z);
                planeSource.SetPoint1(v2.x, v2.y, v2.z);
                planeSource.SetPoint2(v3.x, v3.y, v3.z);
            }
        }

        vtkPlaneSource planeSource = new vtkPlaneSource();

        public vtkActor GetRectangleData2(Vector3 origin, Vector3 p1,Vector3 p2)
        {
            
            planeSource.SetOrigin(origin.x, origin.y, origin.z);
            planeSource.SetPoint1(p1.x, p1.y, p1.z);
            planeSource.SetPoint2(p2.x, p2.y, p2.z);

            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(planeSource.GetOutput());
            //poumian_actor=vtkActor.New();
            vtkProperty property = poumian_actor.GetProperty();
            property.SetColor(originColor[0], originColor[1], originColor[2]); // 设置颜色，RGB值都在0-1之间
            property.SetOpacity(0.5); // 设置透明度, 0-1之间，0为完全透明，1为完全不透明
            property.SetDiffuse(1);
            property.SetLineWidth(5); // 设置线宽
            poumian_actor.SetProperty(property);
            poumian_actor.SetMapper(mapper);
            renderer.AddActor(poumian_actor);
            return poumian_actor;
        }





        /// <summary>
        /// 获取剖面的数据
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="nomal"></param>
        /// <returns></returns>
        public List<PointF> GetData(Vector3 origin, Vector3 nomal)
        {
            List<PointF> fList = new List<PointF>();
            vtkPlane cuttingPlane = vtkPlane.New();    //定义切割平面
            cuttingPlane.SetOrigin(origin.x, origin.y, origin.z); // 设定平面的原点
            cuttingPlane.SetNormal(nomal.x, nomal.y, nomal.z); // 设定平面的法线方向

            vtkPolyData polydata = mesh;
            double[] bounds = polydata.GetBounds();//获得物体的外包盒参数
            vtkCubeSource vtkcubesource = vtkCubeSource.New();//定义外包盒
            vtkcubesource.SetBounds(bounds[0], bounds[1], bounds[2], bounds[3], bounds[4] * 1.3, bounds[5] * 1.3);
            // 使用vtkCutter获取剖面
            vtkCutter cutter = vtkCutter.New();
            cutter.SetCutFunction(cuttingPlane);      // 设定剖面平面
            cutter.SetInput(vtkcubesource.GetOutput()); // 设定输入模型
            cutter.Update();    // 更新剖面数据

            // 使用vtkCutter获取表面上的线，用于画出表格中的线
            vtkCutter cutter_line = vtkCutter.New();
            cutter_line.SetCutFunction(cuttingPlane);      // 设定剖面平面
            cutter_line.SetInput(polydata); // 设定输入模型
            cutter_line.Update();    // 更新剖面数据

            vtkPolyData cutter_polydata = cutter.GetOutput(); //获得剖面线框，是一个长方形
            vtkCellArray polygons = vtkCellArray.New();
            polygons.InsertNextCell(4); // 4个顶点
            polygons.InsertCellPoint(0);
            polygons.InsertCellPoint(1);
            polygons.InsertCellPoint(2);
            polygons.InsertCellPoint(3);
            cutter_polydata.SetPolys(polygons);//将线框填满成面


            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(cutter_polydata);
            //vtkActor actor = vtkActor.New();
            vtkProperty property = poumian_actor.GetProperty();
            property.SetColor(1, 0, 0); // 设置颜色，RGB值都在0-1之间
            property.SetOpacity(0.3); // 设置透明度, 0-1之间，0为完全透明，1为完全不透明
            property.SetDiffuse(1);
            property.SetLineWidth(5); // 设置线宽
            poumian_actor.SetProperty(property);
            poumian_actor.SetMapper(mapper);

            renderer.AddActor(poumian_actor);

            // 获取剖面数据
            vtkPolyData cutData = cutter_line.GetOutput();
            vtkPoints vps = cutData.GetPoints();
            if (vps == null) return null;
            long nub = vps.GetNumberOfPoints();

            for (int i = 0; i < nub; i++)
            {
                double[] dataP = vps.GetPoint(i);
                PointF pf = new PointF((float)dataP[0], (float)dataP[2]*80f/1000f);
                fList.Add(pf);
            }
            fList = fList.OrderByDescending(p => p.X).ToList();
            return fList;
        }

        /// <summary>
        /// 获取法线向量
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public Vector3 ComputeNormal(Vector3 A, Vector3 B, Vector3 C)
        {
            Vector3 AB = B - A;
            Vector3 AC = C - A;
            return Vector3.Cross(AB, AC);
        }

        /// <summary>
        /// 显示测试步骤
        /// </summary>
        /// <param name="estep"></param>
        public void ShowStep(RunStep estep)
        {
            this.Invoke(new Action(() =>
            {
                Step_Lab.Text = string.Format("步骤:{0}", Enum.GetName(typeof(RunStep), estep));
            }));
        
        }

        #endregion

        private void K3DModel_Load(object sender, EventArgs e)
        {
            InitRender();
            K3DModel_Resize(null, null);
            analysisPanel.Controls.Add(roughTest);
            analysisPanel.Controls.Add(clp);
            analysisPanel.Controls.Add(loadFilePanel);
            analysisPanel.Controls.Add(levelPanel);
            loadFilePanel.Dock = DockStyle.Fill;
            roughTest.Dock = DockStyle.Fill;
            clp.Dock = DockStyle.Fill;
            levelPanel.Dock = DockStyle.Fill;
            loadFilePanel.BringToFront();
            loadFilePanel.Load_Btn.Click += FileLoad_Btn_Click;
            levelPanel.Leveing_Btn.Click += Leveing_Btn_Click;
            roughTest.Rough_Btn.Click += Rough_Btn_Click;

        }


        private void K3DModel_Resize(object sender, EventArgs e)
        {
            int w = 5;
            renderWindowControl1.Location = new Point(w, w);
            renderWindowControl1.Size = new Size(Width - 2 * w - 1, Height - 2 * w - 1);
            DataPanel.Visible = IsAnalysis;
            if (IsAnalysis)
            {
                DataPanel.Width = renderWindowControl1.Width;
                DataPanel.Height = 300;
                renderWindowControl1.Height = renderWindowControl1.Height - DataPanel.Height;
                DataPanel.Location = new Point(renderWindowControl1.Left, renderWindowControl1.Bottom);
                DataPanel.BringToFront();
                DataPanel.Show();
                analysisPanel.Height = DataPanel.Height;
                analysisPanel.Width = DataPanel.Width - ButtonPanel.Width;
                analysisPanel.Location = new Point(ButtonPanel.Width, 0);
            }

        }

        
        bool isOneSelected = false;
        vtkActor selctedActor = vtkActor.New();
        List<Vector3> vList = new List<Vector3>();
        List<double[]> markPoint = new List<double[]>();
        vtkMatrix4x4 ratationMatrix;
        double angle = 0;
        double[] translations;
        double[] scale;
        int rowcount = 0;
        int colcount = 0;
        List<float> origindata = new List<float>();
        List<float> leveringdata = new List<float>();

        private void Camera_AnyEvt(vtkObject sender, vtkObjectEventArgs e)
        {
           Type t= e.GetType();
            string name = sender.GetClassName();
            uint id = e.EventId;
            if (id == 33)
            {
                Console.WriteLine("Camera p1:{0},p2:{1},p2:{2}", name, id, angle);
                if ((scale != null&& isOneSelected)|Step== RunStep.Leveing | Step == RunStep.Rough)
                {
                    if (scale != null)
                    {
                        camera.SetViewUp(scale[0], scale[1], scale[2]);
                        camera.SetPosition(translations[0], translations[1], translations[2]);
                    }
                }

            }
        }
        private void UserStyle_AnyEvt(vtkObject sender, vtkObjectEventArgs e)
        {
            string name = sender.GetClassName();
            uint id = e.EventId;
            Console.WriteLine("UserStyle p1:{0},p2:{1}", name, id);
        }
        private void Interactor_LeftButtonPress(vtkObject sender, vtkObjectEventArgs e)
        {
            GetCameraInfo();
            leftButtonIsDown = true;
            int[] pos = this.renderWindowInteractor.GetEventPosition();
            if (pointPicker.Pick(pos[0], pos[1], 0, renderer) == 1)
            {
                double[] pickedXYZ = pointPicker.GetPickPosition();
                if (isOneSelected&&Step!= RunStep.Null)
                {
                    selctedActor.SetPosition(pickedXYZ[0], pickedXYZ[1], pickedXYZ[2]);
                    if (Step == RunStep.Leveing)
                    {
                        if (LevingActor.Count == 6)
                        {
                            ResetLevelTraig();

                        }
                        #region 
                        //AddvtkSphereSource(pickedXYZ);
                        //markPoint.Add(pickedXYZ);
                        //if (markPoint.Count == 3)
                        //{
                        //    int[] pointXY = new int[6] { (int)markPoint[0][0],(int)markPoint[0][1],
                        //        (int)markPoint[1][0], (int)markPoint[1][1], (int)markPoint[2][0], (int)markPoint[2][1] };
                        //    IntPtr floatArrayPtr = PCHandlerDll.PCHandler.PCLevelling1(origindata.ToArray(), pointXY, 3, rowcount, colcount);
                        //    float[] level = new float[rowcount * rowcount];
                        //    Marshal.Copy(floatArrayPtr, level, 0, level.Length);
                        //    leveringdata = level.ToList();
                        //    ShowPointCloudData2(leveringdata.ToArray(), rowcount, colcount);
                        //    markPoint.Clear();
                        //    Step = RunStep.Null;
                        //}
                        #endregion
                    }
                    else if (Step == RunStep.CutLine)
                    {
                        ResetCutLine();

                    }
                    else if (Step == RunStep.Rough)
                    {
                        ResetRectangle();
                        //AddvtkSphereSource(pickedXYZ);
                        //markPoint.Add(pickedXYZ);


                    }

                    vtkProperty sphere_property = selctedActor.GetProperty();
                    sphere_property.SetColor(originColor[0], originColor[1], originColor[2]);
                    isOneSelected = false;
                    renderWindow.Render();
                }
                else
                {
                    vtkAssemblyPath vtkAssemblyPath = pointPicker.GetPath();
                    vtkActorCollection acts = renderer.GetActors();
                    acts.InitTraversal();
                    vtkActor first = acts.GetNextActor();
                    int count = acts.GetNumberOfItems();
                    isOneSelected = false;
                    
                    selctedActor = null;
                    for (int i = 0; i <(Step== RunStep.Rough?2: count - 1); i++)
                    {
                        vtkActor act = acts.GetNextActor();

                        double[] center = act.GetCenter();
                        double[] bouder = act.GetBounds();
                        bool isSelected = false;
                        if (((bouder[0] < pickedXYZ[0] && pickedXYZ[0] < bouder[1]) && (bouder[2] < pickedXYZ[1] && pickedXYZ[1] < bouder[3]))
                            && (Math.Abs(bouder[0] - bouder[1]) < 55) && (Math.Abs(bouder[2] - bouder[3]) < 55))
                        {
                            isSelected = true;
                            isOneSelected = true;
                            selctedActor = act;
                        }
                        vtkProperty sphere_property = act.GetProperty();
                        sphere_property.SetColor(isSelected ? selectColor[0] : originColor[0],
                            isSelected ? selectColor[1] : originColor[1],
                           isSelected ? selectColor[2] : originColor[2]);
                    }

                    if (isOneSelected)
                    {
                        GetCameraInfo();
                    }
                }
            }

            #region


            #endregion

            Console.WriteLine(string.Format("LeftButtonPress"));
            renderWindow.Render();
        }

        private void UserStyle_LeftButtonReleaseEvt(vtkObject sender, vtkObjectEventArgs e)
        {
            leftButtonIsDown=false;
        }
        public void Interactor_RightButtonPress(vtkObject sender, vtkObjectEventArgs e)
        {
            isOneSelected = false;
            selctedActor = null;
            GetCameraInfo();
            Console.WriteLine(string.Format("RightButtonPress"));
            vtkActorCollection acts = renderer.GetActors();
            acts.InitTraversal();
            acts.GetNextActor();
            int count = acts.GetNumberOfItems();
            for (int i = 0; i < count - 1; i++)
            {
                vtkActor act = acts.GetNextActor();
                vtkProperty sphere_property = act.GetProperty();
                sphere_property.SetColor( originColor[0],
                    originColor[1],
                    originColor[2]);
            }
        }


        public void Interactor_MouseMove(vtkObject sender, vtkObjectEventArgs e)
        {
            int[] pos = this.renderWindowInteractor.GetEventPosition();
            if (isOneSelected && selctedActor != null && leftButtonIsDown)
            {
                //if (pointPicker.Pick(pos[0], pos[1], 0, renderer) == 1)
                //{
                //    double[] pickedXYZ = pointPicker.GetPickPosition();
                //    selctedActor.SetPosition(pickedXYZ[0], pickedXYZ[1], pickedXYZ[2]);


                //}
            }
            //InitCameraPos();
            Console.WriteLine(string.Format("x:{0},y:{1}", pos[0], pos[1]));
            //renderWindow.Render();
        }

        private void Leveing_Btn_Click(object sender, EventArgs e)
        {
            if ((LevingActor.Count == 6) && Step == RunStep.Leveing)
            {
                List<double[]> markPoint2 = new List<double[]>();
                for (int i = 0; i <3; i++)
                {
                    double[] pickedXYZ = LevingActor[i].GetCenter();
                    //if (pointPicker.Pick(pos[0], pos[1], 0, renderer) == 1)
                    {
                        //double[] pickedXYZ = pointPicker.GetPickPosition();
                        #region 

                        markPoint2.Add(pickedXYZ);
                        if (markPoint2.Count == 3)
                        {
                            int[] pointXY = new int[6] { (int)markPoint2[0][0],(int)markPoint2[0][1],
                            (int)markPoint2[1][0], (int)markPoint2[1][1], (int)markPoint2[2][0], (int)markPoint2[2][1] };
                            IntPtr floatArrayPtr = PCHandlerDll.PCHandler.PCLevelling1(origindata.ToArray(), pointXY, 3, rowcount, colcount);
                            float[] level = new float[rowcount * colcount];
                            Marshal.Copy(floatArrayPtr, level, 0, level.Length);
                            leveringdata = level.ToList();
                            ShowPointCloudData2(leveringdata.ToArray(), rowcount, colcount);
                            markPoint2.Clear();
                            //Step = RunStep.Null;
                        }
                        #endregion

                    }
                }
            }
        }

        private void Rough_Btn_Click(object sender, EventArgs e)
        {
            if (RectangleActor.Count == 3)
            {
                double[] pp1= RectangleActor[0].GetCenter();
                double[] pp2 = RectangleActor[1].GetCenter();
                int x1 = (int)pp1[0];
                int y1 = (int)pp1[1];
                int x2 = (int)pp2[0];
                int y2 = (int)pp2[1];

                List<double> subData = SelectRegion(origindata.ToArray(), rowcount, colcount, x1, x2, y1, y2);
                float ls = float.Parse(roughTest.SFilt_Cbx.Text);
                float lc = float.Parse(roughTest.LFilt_Cbx.Text);
                double resolutionX = float.Parse(loadFilePanel.ReloX_Tbx.Text);
                double resolutionY = float.Parse(loadFilePanel.ReloY_Tbx.Text);
                int width = Math.Abs(x2 - x1);
                int height = Math.Abs(y2 - y1);
                IntPtr result = PCHandlerDll.PCHandler.Calculate_Roughness(subData.ToArray(), width, height, roughTest.S_Cbx.Checked, lc, ls, resolutionX, resolutionY);
                double[] array = new double[7];
                Marshal.Copy(result, array, 0, array.Length);
                roughTest.SetResult(array);
                //markPoint.Clear();
                //Step = RunStep.Null;
            }
        }

        private void FileLoad_Btn_Click(object sender, EventArgs e)
        {
            loadFilePanel.BringToFront();
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "点云数据|*.txt";
            
            rowcount = 0;
            colcount = 0;
            origindata.Clear();
            leveringdata.Clear();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string fileStr = ofd.FileName;
                    loadFilePanel.FilePath_Tbx.Text = fileStr;
                    using (StreamReader sr = new StreamReader(fileStr))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] lineArr = line.Split(',');
                            colcount = lineArr.Length;
                            for (int i = 0; i < lineArr.Length; i++)
                            {
                                origindata.Add(float.Parse(lineArr[i]));
                            }
                            rowcount++;
                        }
                    }
                    ShowPointCloudData2(origindata.ToArray(), rowcount, colcount);
                    renderer.Render();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Step = RunStep.Null;
            }
        }

        private void Pre_MakeLevel_Btn_Click(object sender, EventArgs e)
        {

            InitAnalysis();
            int count = GetActorsCount();
            
            if (count == 0) return;
            RemoveCutLint();
            RemoveRectangle();
            InitCameraPos();
            levelPanel.BringToFront();
            SetZScale(0.00000001f);
            
            if (Step != RunStep.Leveing)
            {
                InitLevelTraig();
                Step = RunStep.Leveing;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveCutLint();
            RemoveRectangle();
            RemoveLevelTraig();
            Step = RunStep.Null;
            InitCameraPos();
        }


        private void ClearActor_Btn_Click(object sender, EventArgs e)
        {
            vtkActorCollection acts = renderer.GetActors();
            acts.InitTraversal();
            vtkActor va = acts.GetNextActor();
            int count = acts.GetNumberOfItems();
            for (int i = 0; i < count - 1; i++)
            {
                va = acts.GetNextActor();
                renderer.RemoveActor(va);
            }
            markPoint.Clear();
            renderWindow.Render();
        }

        private void ThreeD_StepsH_Btn_Click(object sender, EventArgs e)
        {
            InitAnalysis();
            int count = GetActorsCount();
            if (count == 0) return;
            RemoveRectangle();
            RemoveLevelTraig();
            SetZScale(1);
            clp.BringToFront();
            if (Step != RunStep.CutLine)
            {
                InitCutLine();
            }
            
            Step = RunStep.CutLine;
        }

        private void ThreeD_Roughness_Btn_Click(object sender, EventArgs e)
        {
            InitAnalysis();
            int count =GetActorsCount();
            if (count == 0)return;
            RemoveCutLint();
            RemoveLevelTraig();
            SetZScale(0.00000001f);
            roughTest.BringToFront();
            if (Step != RunStep.Rough)
            { InitRectangle(); }
            Step = RunStep.Rough;
        }

        private void FileLoad_Btn_Click_1(object sender, EventArgs e)
        {
            InitAnalysis();
            RemoveCutLint();
            RemoveRectangle();
            RemoveLevelTraig();
            loadFilePanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SetZScale(0.0001f);
            //InitLevelTraig();
            //vtkActor va= InitSpherSource(new double[3] { 20, 20, 20 });
            // renderer.AddActor(va);
            // renderWindow.Render();

            InitRectangle();

        }
    }

    /// <summary>
    /// 运行状态
    /// </summary>
    public enum RunStep
    {
        LoadFile,
        Leveing,
        CutLine,
        Rough,
        Null,
    }
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x
            );
        }
    }

    public class CustomInteractorStyle : vtkInteractorStyleTrackballActor
    {
        private vtkActor disableActor;

        public void setDisableActor(vtkActor vtkActor)
        { disableActor = vtkActor; }

        public override void OnLeftButtonDown()
        {
            
            base.OnLeftButtonDown();
        }

        public override void OnMiddleButtonDown()
        {
            // 移动actor的代码
            base.OnMiddleButtonDown();
        }

        public override void OnRightButtonDown()
        {
            // 移动actor的代码
            base.OnRightButtonDown();
        }

        public override void OnMouseMove()
        {
            base.OnMouseMove();
        }
        public override void OnLeftButtonUp()
        {
            base.OnLeftButtonUp();
        }


    }

}
