using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTMicroscope.TControls;

namespace TTMicroscope
{
    public partial class TopTitle : UserControl
    {
        public TopTitle()
        {
            InitializeComponent();
        }

        private string _swTitle = "先进显微镜";
        [Category("TTProperty")]
        public string SwTitle
        {
            set { _swTitle = value; }
            get { return _swTitle; }
        }

        private Font _titleFont = new Font("微软雅黑", 20);
        [Category("TTProperty")]
        public Font TitleFont
        {
            set { _titleFont = value; }
            get { return _titleFont; }
        }

        private Font _menuFont = new Font("微软雅黑", 10);
        [Category("TTProperty")]
        public Font MenuFont
        {
            set { _menuFont = value; }
            get { return _menuFont; }
        }

        private float _swAngle = 80;
        [Category("TTProperty")]
        public float SwAngle
        {
            set { _swAngle = value; }
            get { return _swAngle; }
        }

        private float _splitRatioWidth = 0.7f;
        [Category("TTProperty")]
        public float SplitRatioWidth
        {
            set { _splitRatioWidth = value; }
            get { return _splitRatioWidth; }
        }

        private float _splitRatioHeight = 0.9f;
        [Category("TTProperty")]
        public float SplitRatioHeight
        {
            set { _splitRatioHeight = value; }
            get { return _splitRatioHeight; }
        }

        private Color _color1 = Color.Gray;
        [Category("TTProperty")]
        public Color Color1
        {
            set { _color1 = value; }
            get { return _color1; }
        }

        private Color _color2 = Color.LightGray;
        [Category("TTProperty")]
        public Color Color2
        {
            set { _color2 = value; }
            get { return _color2; }
        }


        Timer t=new Timer();


        private void TopTitle_Load(object sender, EventArgs e)
        {
            t.Start();
            t.Interval = 1000;
            t.Tick += T_Tick;
        }
        bool isFirst = true;
        private void T_Tick(object sender, EventArgs e)
        {
            Time_Lb.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (isFirst)
            { TopTitle_Resize(null, null); }
            isFirst = false;
        }

        private void TopTitle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            #region 区域绘图
            float r = 20;
            Pen p = new Pen(Color.Red);
            PointF cent1 = new PointF(Width * _splitRatioWidth, _splitRatioHeight * Height);
            PointF cent2 = new PointF(Width * _splitRatioWidth + 50, Height - r);
            float saAngle = _swAngle;
            float a = (float)((90 - saAngle) / 180f * Math.PI);
            PointF p1 = new PointF(cent1.X + (float)(r * Math.Cos(a)), cent1.Y - (float)(r * Math.Sin(a)));
            PointF p2 = new PointF(cent2.X - (float)(r * Math.Cos(a)), cent2.Y + (float)(r * Math.Sin(a)));


            GraphicsPath path = new GraphicsPath();
            path.AddArc(new RectangleF(cent1.X - r, cent1.Y - r, 2 * r, 2 * r), 270, saAngle);
            path.AddLine(p1, p2);
            path.AddArc(new RectangleF(cent2.X - r, cent2.Y - r, 2 * r, 2 * r), 90, saAngle);
            path.AddLine(new PointF(cent2.X, cent2.Y + r), new PointF(Width, cent2.Y + r));
            path.AddLine(new PointF(Width, cent2.Y + r), new PointF(Width, 0));
            path.AddLine(new PointF(Width, 0), new PointF(0, 0));
            path.AddLine(new PointF(0, 0), new PointF(0, cent1.Y - r));
            path.AddLine(new PointF(0, cent1.Y - r), new PointF(cent1.X - r, cent1.Y - r));
            g.FillPath(new SolidBrush(_color1), path);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddArc(new RectangleF(cent1.X - r, cent1.Y - r, 2 * r, 2 * r), 270, saAngle);
            path2.AddLine(p1, p2);
            path2.AddArc(new RectangleF(cent2.X - r, cent2.Y - r, 2 * r, 2 * r), 90, saAngle);
            path2.AddLine(new PointF(cent2.X, cent2.Y + r), new PointF(0, cent2.Y + r));
            path2.AddLine(new PointF(0, cent2.Y + r), new PointF(0, cent1.Y - r));
            path2.AddLine(new PointF(0, cent1.Y - r), new PointF(cent1.X - r, cent1.Y - r));
            g.FillPath(new SolidBrush(_color2), path2);
            #endregion

            #region 表头
            SizeF sf = g.MeasureString(_swTitle, _titleFont);
            //g.DrawString(_swTitle, _titleFont, new SolidBrush(this.ForeColor), Logo_Pbx.Right + 25, (_splitRatioHeight * Height - sf.Height - r) / 2f);

            #endregion
        }

        public void TopTitle_Resize(object sender, EventArgs e)
        {
            float h = Height * 0.5f;

            Close_Btn.Location = new Point(Width - Close_Btn.Width - 8, 4);
            Max_Btn.Location = new Point(Width - Close_Btn.Width - Max_Btn.Width - 16, 5);
            Min_Btn.Location = new Point(Width - Close_Btn.Width - Max_Btn.Width - Min_Btn.Width - 24, 4);
            Max_Btn.BackColor = Close_Btn.BackColor = Min_Btn.BackColor = _color1;
            Statue_P.Location = new Point(Width - Statue_P.Width - 30, Height - Statue_P.Height - 3);
            Info_Lab.Location = new Point((Width - Info_Lab.Width) / 2, Height - Info_Lab.Height +1);
            Info_Lab.Visible = false;
            Time_Lb.Location=new Point( Min_Btn.Left- Time_Lb.Width-30, Time_Lb.Location.Y);
            this.Refresh();
           
        }

        private void TopTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) ControlsPublic.Move(this.Parent.Handle);
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 显示导航信息
        /// </summary>
        /// <param name="tx"></param>
        public void ShowNevigateInfo(string tx)
        {
            this.Invoke(new Action(() => {
                NevigataInfo_Lab.Text=tx;
                }));
        }

        private void Max_Btn_Click(object sender, EventArgs e)
        {
            //Form f = (Form)this.Parent;
            //f.WindowState = FormWindowState.Maximized;
        }

        private void TopTitle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void TopTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
