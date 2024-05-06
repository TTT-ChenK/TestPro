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

namespace TTMicroscope
{
    public partial class TGroupBox : UserControl
    {
        public TGroupBox()
        {
            InitializeComponent();
        }

        #region TProperty
        private string _mTitle = "名称XXX";
        [Category("TTProperty")]
        public string MTitle
        {
            set { _mTitle = value; }
            get { return _mTitle; }
        }

        private bool _mTitleIsLeft = false;
        [Category("TTProperty")]
        public bool MTitleIsLeft
        {
            set { _mTitleIsLeft = value;this.Refresh(); }
            get { return _mTitleIsLeft; }
        }


        private Font _titleFont = new Font("微软雅黑", 16);
        [Category("TTProperty")]
        public Font TitleFont
        {
            set { _titleFont = value; }
            get { return _titleFont; }
        }

        private float _borderWidth = 1f;
        [Category("TTProperty")]
        public float BouderWidth
        {
            set { _borderWidth = value; }
            get { return _borderWidth; }
        }

        private float _borderRatius = 10f;
        [Category("TTProperty")]
        public float BouderRatius
        {
            set { _borderRatius = value; }
            get { return _borderRatius; }
        }

        private Color _titleForeColor = Color.Red;
        [Category("TTProperty")]
        public Color TitleForeColor
        {
            set { _titleForeColor = value; this.Refresh(); }
            get { return _titleForeColor; }
        }


        private Color _borderColor = Color.Red;
        [Category("TTProperty")]
        public Color BorderColor
        {
            set { _borderColor = value; }
            get { return _borderColor; }
        }

        private Color _titleBackColor = Color.LightGray;
        [Category("TTProperty")]
        public Color TitleBacColor
        {
            set
            {
                _titleBackColor = value;
            }
            get { return _titleBackColor; }
        }



        #endregion

        #region Vaverty

        GraphicsPath titlePath = null;

        #endregion




        private void TGroupBox_Load(object sender, EventArgs e)
        {

        }

        private void TGroupBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            SizeF _titleSz = g.MeasureString(_mTitle, _titleFont);
            GraphicsPath gp = GetBorderPath(_titleSz);


            #region 外框&标题
            Brush b = new LinearGradientBrush(new RectangleF(new Point(0, 0), new SizeF(Width, _titleSz.Height * 1.3f)), _titleBackColor, Color.WhiteSmoke, 90);
            g.FillPath(/*new SolidBrush(_titleBackColor)*/b, titlePath);
            g.DrawPath(new Pen(_borderColor, _borderWidth), gp);
            PointF pf= new PointF(((Width - 2) - _titleSz.Width) / 2f + 1, _titleSz.Height * 0.15f + 1);
            if (_mTitleIsLeft)
            { pf = new PointF(6, _titleSz.Height * 0.15f + 1); }

            g.DrawString(_mTitle, _titleFont, new SolidBrush(_titleForeColor), pf);
            #endregion

        }

        private void TGroupBox_Resize(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取外框
        /// </summary>
        private GraphicsPath GetBorderPath(SizeF _titleSz)
        {
            GraphicsPath path = new GraphicsPath();
            titlePath = new GraphicsPath();
            float saAngle = 90;
            float w = _borderRatius * 2;
            float offset = 1;
            float titlePathH = _titleSz.Height * 1.3f;
            //leftTopConner
            path.AddArc(new RectangleF(offset, offset, w, w), 180, saAngle);
            titlePath.AddArc(new RectangleF(offset, offset, w, w), 180, saAngle);
            //topLine
            PointF p1 = new PointF(offset + _borderRatius, offset);
            PointF p2 = new PointF((Width - (offset + _borderRatius)), offset);
            path.AddLine(p1, p2);
            titlePath.AddLine(p1, p2);

            //rightTopConner
            path.AddArc(new RectangleF(Width - (offset + w), offset, w, w), 270, saAngle);
            titlePath.AddArc(new RectangleF(Width - (offset + w), offset, w, w), 270, saAngle);
            //rightLine
            p1 = new PointF(Width - offset, _borderRatius + offset);
            p2 = new PointF(Width - offset, Height - (_borderRatius + offset));
            path.AddLine(p1, p2);
            p1 = new PointF(Width - offset, _borderRatius + offset);
            p2 = new PointF(Width - offset, titlePathH + offset);
            titlePath.AddLine(p1, p2);

            //rightBottomConner
            path.AddArc(new RectangleF(Width - (offset + w), Height - (offset + w), w, w), 0, saAngle);
            //BottomLine
            p1 = new PointF(Width - (_borderRatius + offset), Height - offset);
            p2 = new PointF((_borderRatius + offset), Height - offset);
            path.AddLine(p1, p2);

            p1 = new PointF(Width - offset, titlePathH + offset);
            p2 = new PointF(offset, titlePathH + offset);
            titlePath.AddLine(p1, p2);



            //LifeBottomConner
            path.AddArc(new RectangleF(offset, Height - (offset + w), w, w), 90, saAngle);
            //BottomLine
            p1 = new PointF(offset, Height - (offset + _borderRatius));
            p2 = new PointF(offset, (offset + _borderRatius));
            path.AddLine(p1, p2);

            p1 = new PointF(offset, titlePathH + offset);
            p2 = new PointF(offset, titlePathH - (offset + _borderRatius));
            titlePath.AddLine(p1, p2);
            return path;
        }
    }
}
