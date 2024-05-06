using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class TMotorManual : UserControl
    {
        public TMotorManual()
        {
            InitializeComponent();
        }

        #region
        private int _ringWidth = 40;
        [Category("TTProperty"), Description("圆环宽度")]
        public int RingWidth
        {
            get { return _ringWidth; }
            set
            {
                if (value >= 1)
                { _ringWidth = value; }
            }
        }

        private Color _ringColor = Color.DarkGray;
        [Category("TTProperty"), Description("圆环颜色")]
        public Color RingColor
        {
            get { return _ringColor; }
            set
            { _ringColor = value; }
        }


        private Color _holverColor = Color.LightGray;
        [Category("TTProperty"), Description("激活颜色")]
        public Color HolverColor
        {
            get { return _holverColor; }
            set
            { _holverColor = value; }
        }

        private Color _downColor = Color.Gray;
        [Category("TTProperty"), Description("鼠标按下颜色")]
        public Color DownColor
        {
            get { return _downColor; }
            set
            { _downColor = value; }
        }

        private Color _upColor = Color.Gray;
        [Category("TTProperty"), Description("鼠标弹起颜色")]
        public Color UPColor
        {
            get { return _upColor; }
            set
            { _upColor = value; }
        }

        private EDirectMotorRun _directRun = EDirectMotorRun.Default;
        [Category("TTProperty"), Description("运动方向")]
        public EDirectMotorRun DirectRun
        {
            get { return _directRun; }

        }

        #endregion

        public event MotorClickHandle OnMotorClick;

        Point mouseP = new Point();
        bool mouseIsDown = false;
        List<PathData> pdList = new List<PathData>();

        bool rotateP = false;
        bool rotateN = false;

        private void TMotorManual_Load(object sender, EventArgs e)
        {

        }

        private void TMotorManual_Paint(object sender, PaintEventArgs e)
        {

            
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            #region 大圆环
            float r = ((Width > Height) ? Height : Width) / 2f;
            PointF centP = new PointF(r, (Height - 2 * r) / 2f + r); //中心点
            float distance = (float)Math.Sqrt(Math.Pow(mouseP.X - centP.X, 2) + Math.Pow(mouseP.Y - centP.Y, 2));
            RectangleF bigRec = new RectangleF(centP.X - r, centP.Y - r, 2 * r, 2 * r);
            float r2 = r - _ringWidth;
            RectangleF smallRec = new RectangleF(centP.X - r2, centP.Y - r2, 2 * r2, 2 * r2);
            Color drawColor = RingColor;
            if (distance < r && distance > r2)
            {
                drawColor = _holverColor;
                if (mouseIsDown)
                { drawColor = _downColor; rotateP = true; _directRun = EDirectMotorRun.R_P; }
            }
            g.FillEllipse(new SolidBrush(drawColor), bigRec);
            g.FillEllipse(new SolidBrush(this.BackColor), smallRec);
            #endregion

            #region 小圆环
            float rs = 50; //33
            distance = (float)Math.Sqrt(Math.Pow(mouseP.X - centP.X, 2) + Math.Pow(mouseP.Y - centP.Y, 2));
            bigRec = new RectangleF(centP.X - rs, centP.Y - rs, 2 * rs, 2 * rs);
            r2 = rs - _ringWidth / 2f-8;
            smallRec = new RectangleF(centP.X - r2, centP.Y - r2, 2 * r2, 2 * r2);
            drawColor = RingColor;
            if (distance < rs && distance > r2)
            {
                drawColor = _holverColor;
                if (mouseIsDown)
                { drawColor = _downColor; rotateN = true; _directRun = EDirectMotorRun.R_N; }
            }
            g.FillEllipse(new SolidBrush(drawColor), bigRec);
            g.FillEllipse(new SolidBrush(this.BackColor), smallRec);
            #endregion

            #region 构建10个箭头
            float rcross = (r + rs) / 2f - 10; //10
            float bigR = 25; //20
            float smallR = 20; //15
            float offset = (float)(rcross * Math.Sqrt(2f) / 2f-5);
            PathData pd1 = GetCrossPoints(new PointF(centP.X, centP.Y + rcross-3), 0, bigR);
            PathData pd2 = GetCrossPoints(new PointF(centP.X + offset, centP.Y + offset), 45, smallR);
            PathData pd3 = GetCrossPoints(new PointF(centP.X + rcross-3, centP.Y), 90, bigR);
            PathData pd4 = GetCrossPoints(new PointF(centP.X + offset, centP.Y - offset), 135, smallR);
            PathData pd5 = GetCrossPoints(new PointF(centP.X, centP.Y - rcross+3), 180, bigR);
            PathData pd6 = GetCrossPoints(new PointF(centP.X - offset, centP.Y - offset), 225, smallR);
            PathData pd7 = GetCrossPoints(new PointF(centP.X - rcross+3, centP.Y), 270, bigR);
            PathData pd8 = GetCrossPoints(new PointF(centP.X - offset, centP.Y + offset), 315, smallR);

            PathData pd9 = GetCrossPoints(new PointF(centP.X + r + 15, centP.Y + r - 30), 0, bigR);
            PathData pd10 = GetCrossPoints(new PointF(centP.X + r + 15, centP.Y - r + 30), 180, bigR);

            pdList.Clear();
            pdList.Add(pd1);
            pdList.Add(pd2);
            pdList.Add(pd3);
            pdList.Add(pd4);
            pdList.Add(pd5);
            pdList.Add(pd6);
            pdList.Add(pd7);
            pdList.Add(pd8);
            pdList.Add(pd9);
            pdList.Add(pd10);

            for (int i = 0; i < pdList.Count; i++)
            {
                PathData P1 = pdList[i];
                bool isIn = MouseIsIn(P1, mouseP);
                drawColor = RingColor;
                if (isIn)
                {
                    drawColor = HolverColor;
                    if (mouseIsDown)
                    {
                        drawColor = DownColor;
                        _directRun = (EDirectMotorRun)i;
                    }
                }
                g.FillPolygon(new SolidBrush(drawColor), P1.Points);
            }
            //if (OnMotorClick != null)
            //{ OnMotorClick(_directRun); }
            #endregion

            #region 绘制分割线
            PointF[] pArr = GetSpitRectangle(centP, 90, r - _ringWidth / 2F, 25);
            g.DrawLines(new Pen(this.BackColor, 4), pArr);
            pArr = GetSpitRectangle(centP, 270, r - _ringWidth / 2F, 25);
            g.DrawLines(new Pen(this.BackColor, 4), pArr);


            pArr = GetSpitRectangle(centP, 0, rs - _ringWidth / 4F-5, 12);
            g.DrawLines(new Pen(this.BackColor, 4), pArr);
            pArr = GetSpitRectangle(centP, 180, rs - _ringWidth / 4F-5, 12);
            g.DrawLines(new Pen(this.BackColor, 4), pArr);


            #endregion

            #region 
            float offsetC = 15;
            float RT = 4;
            //X
            drawColor = Color.Gray;
            Font dF = new Font("宋体", 10);
            PointF px1 = new PointF(centP.X + offsetC, centP.Y);
            PointF px2 = new PointF(centP.X - offsetC - 3, centP.Y);
            g.DrawLine(new Pen(Color.Black, 1), px1, px2);
            PointF[] px = new PointF[3] {
                new PointF(px1.X,px1.Y+RT),
                new PointF(px1.X,px1.Y-RT),
                new PointF((float)(px1.X+Math.Sqrt(3)*RT),(float)(px1.Y)) };
            g.FillPolygon(new SolidBrush(drawColor), px);
            g.DrawString("x", dF, new SolidBrush(drawColor), px1.X - 10, px1.Y - 1);

            //Y
            PointF py1 = new PointF(centP.X, centP.Y + offsetC);
            PointF py2 = new PointF(centP.X, centP.Y - offsetC);
            g.DrawLine(new Pen(Color.Black, 1), py1, py2);
            PointF[] py = new PointF[3] {
                new PointF(py2.X+RT,py2.Y),
                new PointF(py2.X-RT,py2.Y),
                new PointF((float)(py2.X),(float)(py2.Y-Math.Sqrt(3)*RT)) };
            g.FillPolygon(new SolidBrush(drawColor), py);
            g.DrawString("y", dF, new SolidBrush(drawColor), py2.X - 10, py2.Y - 2);
            //Z
            PointF pz1 = new PointF(centP.X + r + 15, centP.Y - 20);
            PointF pz2 = new PointF(centP.X + r + 15, centP.Y + 20);
            g.DrawLine(new Pen(Color.Black, 1), pz1, pz2);
            PointF[] pz = new PointF[3] {
                new PointF(pz1.X+RT,pz1.Y),
                new PointF(pz1.X-RT,pz1.Y),
                new PointF(pz1.X,(float)(pz1.Y-Math.Sqrt(3)*RT)) };

            g.FillPolygon(new SolidBrush(drawColor), pz);
            g.DrawString("z", dF, new SolidBrush(drawColor), pz1.X - 10, pz1.Y - 2);
            #endregion
        }

        private void TMotorManual_MouseDown(object sender, MouseEventArgs e)
        {
            
            mouseIsDown = true;
            mouseP = e.Location;
            //this.Refresh();

            for (int i = 0; i < pdList.Count; i++)
            {
                PathData P1 = pdList[i];
                bool isIn = MouseIsIn(P1, mouseP);
                if (isIn)
                {  _directRun = (EDirectMotorRun)i;   }
            }

            if (OnMotorClick != null)
            {
                OnMotorClick(_directRun);
            }
            this.Invalidate();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              

        }

        private void TMotorManual_MouseMove(object sender, MouseEventArgs e)
        {
            mouseP = e.Location;
            this.Invalidate();
        }

        private void TMotorManual_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            mouseP = e.Location;
            _directRun = EDirectMotorRun.Default;
            rotateP = false;
            rotateN = false;
            if (OnMotorClick != null)
            {
                OnMotorClick(_directRun);
            }
            this.Invalidate();
        }

        /// <summary>
        ///  获取箭头的轨迹点
        /// </summary>
        /// <param name="centetP">三角形与方形交界处中点</param>
        /// <param name="angle">旋转角度</param>
        /// <param name="r">中心点到三角形顶点距离</param>
        /// <returns></returns>
        private PathData GetCrossPoints(PointF centetP, float angle, float r, bool isOnlyTrig = false)
        {
            float a2 = (float)(angle / 180F * Math.PI);
            float d = (float)(2f / Math.Sqrt(3) * r);
            float x = centetP.X;
            float y = centetP.Y;
            float sin = (float)Math.Sin(a2);
            float cos = (float)Math.Cos(a2);
            List<PointF> points = new List<PointF>();
            PointF p1 = new PointF(x + r * sin, y + r * cos);
            PointF p2 = new PointF(x + d / 2f * cos, y - d / 2f * sin);
            PointF p3 = new PointF(x + d / 4f * cos, y - d / 4f * sin);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            if (!isOnlyTrig)
            {
                PointF p4 = new PointF(p3.X - r * 0.7f * sin, p3.Y - r * 0.7f * cos);
                PointF p6 = new PointF(x - d / 4f * cos, y + d / 4f * sin);
                PointF p5 = new PointF(p6.X - r * 0.7f * sin, p6.Y - r * 0.7f * cos);
                PointF p7 = new PointF(x - d / 2f * cos, y + d / 2f * sin);
                points.Add(p4);
                points.Add(p5);
                points.Add(p6);
                points.Add(p7);
            }

            PathData pathData = new PathData();
            pathData.Points = points.ToArray();
            return pathData;
        }

        /// <summary>
        /// 判断鼠标是否在多边形内部(与多边形交点个数为奇数则在内部)
        /// </summary>
        /// <param name=""></param>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool MouseIsIn(PathData pd, Point P)
        {
            PointF[] _pointList = pd.Points;
            int i;
            int j;
            bool result = false;
            for (i = 0, j = _pointList.Length - 1; i < _pointList.Length; j = i++)
            {
                if ((_pointList[i].Y > P.Y) != (_pointList[j].Y > P.Y) &&
                    (P.X < (_pointList[j].X - _pointList[i].X) * (P.Y - _pointList[i].Y) /
                    (_pointList[j].Y - _pointList[i].Y) + _pointList[i].X))
                {
                    result = !result;
                }
            }
            return result;

        }

        /// <summary>
        /// 获取分割矩形
        /// </summary>
        /// <returns></returns>
        private PointF[] GetSpitRectangle(PointF centerP, float angle, float cycleR, float len)
        {
            float a = (float)(angle / 180f * Math.PI);
            float a1 = (float)((45 - angle) / 180f * Math.PI);
            float a2 = (float)((45 + angle) / 180f * Math.PI);
            PointF sF = new PointF(centerP.X - (float)(cycleR * Math.Sin(a)), centerP.Y + (float)(cycleR * Math.Cos(a)));

            PointF s1 = new PointF(sF.X + (float)(len * Math.Sin(a1)), sF.Y - (float)(len * Math.Cos(a1)));
            PointF s2 = new PointF(sF.X + (float)(len * Math.Sin(a2)), sF.Y + (float)(len * Math.Cos(a2)));

            PointF[] pArr = new PointF[4];

            pArr[0] = pArr[2] = sF;
            pArr[1] = s1;
            pArr[3] = s2;
            return pArr;
        }

    }

    /// <summary>
    /// 运动方向
    /// </summary>
    public enum EDirectMotorRun
    {
        Y_N=0, //Y-
        XP_YN =1,//X+与Y-45度
        X_P=2,//X+
        XP_YP=3,
        Y_P=4,
        XN_YP=5,
        X_N=6,
        Xx_YN_Y=7,
        Z_P=8,
        Z_N=9,
        R_P = 10,
        R_N = 11,
        Default
    }

    public delegate void MotorClickHandle(EDirectMotorRun eDirectMotorRun);
}
