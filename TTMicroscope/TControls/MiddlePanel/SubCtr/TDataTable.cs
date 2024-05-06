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
    public partial class TDataTable : UserControl
    {
        public TDataTable()
        {
            InitializeComponent();
        }
        private string[] _titleName = new string[] { "表头名称" };
        [Category("TTProperty"), Description("表头名称")]
        public string[] TitleName
        {
            get { return _titleName; }
            set
            {
                if (value != null && value.Length >= 1)
                {
                    _titleName = value;
                }
            }
        }

        private string[] _valueArr = new string[] { "1.0" };
        [Category("TTProperty"), Description("数据")]
        public string[] ValueArr
        {
            get { return _valueArr; }
            set
            {
                if (value != null && value.Length >= 1)
                {
                    _valueArr = value;
                    this.Refresh();
                }
            }
        }

        private Color _titleColor = Color.LightGray;
        [Category("TTProperty")]
        public Color titleColor
        {
            set { _titleColor = value; }
            get { return _titleColor; }
        }
        private void TDataTable_Load(object sender, EventArgs e)  
        {

        }

        private void TDataTable_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font f = this.Font;
            SizeF sf = g.MeasureString(_titleName[0], f);
            float titleH = sf.Height * 1.2f;
            g.FillRectangle(new SolidBrush(_titleColor), new RectangleF(0, 0, Width, titleH));
            float wOffset = (float)Width / (float)_titleName.Length;
            for (int i = 0; i < _titleName.Length; i++)
            {
                sf = g.MeasureString(_titleName[i], f);
                g.DrawString(_titleName[i], f, new SolidBrush(this.ForeColor), i * wOffset + (wOffset - sf.Width) / 2f, (titleH - sf.Height) / 2);
                g.DrawLine(new Pen(Color.LightGray), new PointF(i * wOffset, 0), new PointF(i * wOffset, Height));
                g.DrawRectangle(new Pen(Color.LightGray), new Rectangle(0, 0, Width - 1, Height - 1));

                if (i < _valueArr.Length)
                {
                    sf = g.MeasureString(_valueArr[i], f);
                    g.DrawString(_valueArr[i], f, new SolidBrush(this.ForeColor), i * wOffset + (wOffset - sf.Width) / 2f, titleH + (titleH - sf.Height) / 2);
                }
            }
        }
    }
}
