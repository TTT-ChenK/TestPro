using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class KProgressBarH : UserControl
    {
        public KProgressBarH()
        {
            InitializeComponent();
        }
        private int _minValue = 0;
        [Category("TTProperty")]
        public int MinValue
        {
            set { _minValue = value; this.Invalidate(); }
            get { return _minValue; }
        }

        private int _maxValue = 100;
        [Category("TTProperty")]
        public int MaxValue
        {
            set
            {
                if (value > _minValue)
                { _maxValue = value; }
                this.Invalidate();
            }
            get { return _maxValue; }
        }

        private float _currentValue = 0;
        [Category("TTProperty")]
        public float CurrentValue
        {
            set
            {
                if (_currentValue != value)
                {
                    if (OnTProgressBarValueChanged != null)
                    { OnTProgressBarValueChanged(_currentValue, value); };
                    _currentValue = value;
                }
                this.Invalidate();
            }
            get
            {
                return
                   float.Parse(_currentValue.ToString("F2"));
            }
        }


        private float _minStep = 1;
        [Category("TTProperty")]
        public float MinStep
        {
            set
            {
                if (_minStep != value)
                {
                    if (_minStep < _maxValue / 4f)
                    { _minStep = value; }
                }
                this.Invalidate();
            }
            get
            {
                return _minStep;
            }
        }

        private Color _selectColor = Color.LightCyan;
        [Category("TTProperty")]
        public Color SelectColor
        {
            set { _selectColor = value; this.Invalidate(); }
            get { return _selectColor; }
        }

        private Color _unSelectColor = Color.Gray;
        [Category("TTProperty")]
        public Color UnSelectColor
        {
            set { _unSelectColor = value; this.Invalidate(); }
            get { return _unSelectColor; }
        }

        private Color _hoverColor = Color.Yellow;
        [Category("TTProperty")]
        public Color HoverColor
        {
            set { _hoverColor = value; }
            get { return _hoverColor; }
        }

        private bool _isShowPercent = true;
        [Category("TTProperty")]
        public bool IsShowPercent
        {
            set { _isShowPercent = value; }
            get { return _isShowPercent; }
        }



        public event KProgressBarValueChangedHandle OnTProgressBarValueChanged;



        //三角形起点
        private PointF[] pyUp;
        private PointF[] pyDown;
        private Point mouseP = new Point(0, 0);
        private int pyWidth = 20;
        bool isMouseDown = false;
        Rectangle recD = new Rectangle(5, 3, 100, 100);
        Rectangle recSelect = new Rectangle(5, 3, 100, 100);
        Rectangle recSUp = new Rectangle(0, 0, 0, 0);
        Rectangle recSDown = new Rectangle(0, 0, 0, 0);



        private void KProgressBarH_Load(object sender, EventArgs e)
        {

        }

        private void KProgressBarH_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(2, 2, Width - 20, Height - 4);
            recD = rec;

            RectangleF rec2 = new RectangleF(rec.X + 1, rec.Y + 1, rec.Width - 1, rec.Height - 1);
            Pen pen = new Pen(new SolidBrush(Color.LightGray), 1);
            g.DrawRectangle(pen, rec);
            g.FillRectangle(new SolidBrush(_unSelectColor), rec2);
            float ratio = (float)(CurrentValue - _minValue) / (float)(_maxValue - _minValue);
            RectangleF rec3 = new RectangleF(rec2.X, rec2.Y, rec2.Width * ratio, rec2.Height);
            g.FillRectangle(new SolidBrush(_selectColor), rec3);

            string ratioStr = (_isShowPercent ? (ratio * 100).ToString("F2") + "%": null) +"(" + (CurrentValue).ToString("F1") + ")";
            SizeF sf = g.MeasureString(ratioStr, this.Font);
            g.DrawString(ratioStr, this.Font, new SolidBrush(this.ForeColor), rec2.Left + (rec2.Width - sf.Width) / 2,
                rec2.Top + (rec2.Height - sf.Height) / 2);

            recSUp = new Rectangle(rec.Right, rec.Top, 16, rec.Height / 2);
            recSDown = new Rectangle(rec.Right, rec.Top + rec.Height / 2, 16, rec.Height / 2);

            g.FillRectangle(new SolidBrush(_unSelectColor), recSUp);
            pen = new Pen(new SolidBrush(Color.LightGray), 1);
            g.DrawRectangle(pen, recSUp);
            g.FillRectangle(new SolidBrush(_unSelectColor), recSDown);
            g.DrawRectangle(pen, recSDown);

            float offset = 2;
            pyUp = new PointF[3] {
                new PointF(recSUp.Left+recSUp.Width/2,recSUp.Top+offset),
                new PointF(recSUp.Right-offset,recSUp.Bottom-offset),
                new PointF(recSUp.Left+offset,recSUp.Bottom-offset),
                };
            g.FillPolygon(new SolidBrush(_selectColor), pyUp);
            g.DrawPolygon(pen, pyUp);

            pyDown = new PointF[3] {
                new PointF(recSDown.Left+recSUp.Width/2,recSDown.Bottom-offset),
                new PointF(recSDown.Right-offset,recSDown.Top+offset),
                new PointF(recSDown.Left+offset,recSDown.Top+offset),
                };
            g.FillPolygon(new SolidBrush(_selectColor), pyDown);
            g.DrawPolygon(pen, pyDown);

        }

        private void KProgressBarH_Resize(object sender, EventArgs e)
        {

        }

        private void KProgressBarH_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            float offset = 0;
            if (recSDown != null && recSDown.Contains(e.Location))
            {
                offset = -0.01f * _minStep;
            }
            if (recSUp != null && recSUp.Contains(e.Location))
            {
                offset = 0.01f * _minStep;
            }

            float CurrentValueNew = CurrentValue + offset;
            if (CurrentValueNew > _maxValue)
            { CurrentValueNew = _maxValue; }
            else if (CurrentValueNew < _minValue)
            { CurrentValueNew = _minValue; }
            CurrentValue = CurrentValueNew;
            this.Invalidate();
        }

        private void KProgressBarH_MouseMove(object sender, MouseEventArgs e)
        {

            if (recD.Contains(e.Location) && isMouseDown) //激活移动
            {
                float ratio = (e.X - mouseP.X) / (float)(recD.Width);
                float CurrentValueNew = CurrentValue + (float)((_maxValue - _minValue) * ratio);
                if (CurrentValueNew > _maxValue)
                { CurrentValueNew = _maxValue; }
                else if (CurrentValueNew < _minValue)
                { CurrentValueNew = _minValue; }
                else { }

                CurrentValue = CurrentValueNew;
            }

            mouseP = e.Location;
            this.Invalidate();
        }

        private void KProgressBarH_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }

    public delegate void KProgressBarValueChangedHandle(float oldValue, float newValue);
}
