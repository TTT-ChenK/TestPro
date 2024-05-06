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
    public partial class SObject : UserControl
    {
        public SObject()
        {
            InitializeComponent();
        }


        private string _ObjectiveName =  "X10" ;
        [Category("TTProperty"), Description("物镜名称")]
        public string ObjectiveName
        {
            get { return _ObjectiveName; }
            set
            {
                _ObjectiveName = value;this.Refresh();
            }
        }

        private string _posititon = "位置1";
        [Category("TTProperty"), Description("位置名称")]
        public string Positon
        {
            get { return _posititon; }
            set
            {
                Pos_Lab.Text = value;
                _posititon = value;
            }
        }
        private bool _isSelected =true;
        [Category("TTProperty"), Description("是否选择")]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                Object_Pbx.BackgroundImage = _isSelected ? Properties.Resources.SObjective2 : Properties.Resources.Objective1;
            }
        }

        public event ObjectSelectHandle OnObjectSelect;
        private void SObject_Load(object sender, EventArgs e)
        {

        }

        private void SObject_Paint(object sender, PaintEventArgs e)
        {
            Pos_Lab.Font = new Font("微软雅黑", 10.5f);
        }

        private void Object_Pbx_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font("微软雅黑", 8);
            Graphics g=e.Graphics;
           
            string[] strArr = _ObjectiveName.Split('_');
            SizeF sz = g.MeasureString(strArr[0], f);
            g.DrawString(strArr[0], f, new SolidBrush(Color.Black),
                (Object_Pbx.Width - sz.Width) / 2, (Object_Pbx.Height - sz.Height) / 2-6);
            if (strArr.Length > 1)
            {
                sz = g.MeasureString(strArr[1], f);
                g.DrawString(strArr[1], f, new SolidBrush(Color.Black),
                    (Object_Pbx.Width - sz.Width) / 2, (Object_Pbx.Height - sz.Height) / 2+sz.Height-6);
            }
        }

        private void SObject_Resize(object sender, EventArgs e)
        {
            Pos_Lab.Location=new Point((panel1.Width- Pos_Lab.Width)/2, (panel1.Height - Pos_Lab.Height) / 2);
        }

        private void Object_Pbx_Click(object sender, EventArgs e)
        {
            if (OnObjectSelect != null)
            { OnObjectSelect(this.Name); }
        }
    }

    public delegate void ObjectSelectHandle(string name);
}
