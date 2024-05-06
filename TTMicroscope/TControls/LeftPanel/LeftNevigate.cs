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
    public partial class LeftNevigate : TreeView
    {
        public LeftNevigate()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawAll;


        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Font textF = new Font("微软雅黑", 10, FontStyle.Bold);
            SolidBrush txtBrush = new SolidBrush(Color.White);         //被选中的字体颜色
            SolidBrush bacBrush = new SolidBrush(Color.FromArgb(243, 243, 243));         //被选中的背景颜色
            Rectangle rt = e.Bounds;
            string drawText = e.Node.Text;

            if (e.Node.Level == 0)
            {
                rt = new Rectangle(rt.Left + 10, rt.Top, rt.Width, rt.Height);
                textF = new Font("微软雅黑", 12, FontStyle.Bold);
            }
            else if (e.Node.Level == 1)
            { rt = new Rectangle(rt.Left + 20, rt.Top, rt.Width, rt.Height); }
            //if (e.Node.Level == 0)
            {
                if (e.Node.IsSelected)
                {
                    g.DrawString(drawText, textF, txtBrush, rt);
                }
                else
                {
                    g.DrawString(drawText, textF, txtBrush, rt);
                }
            }

            if (e.Node.Level == 1)
            {
                float m = rt.Height;
                string imageStr=e.Node.Parent.Index.ToString()+"-"+e.Node.Index.ToString();
                Image img=GetImage(imageStr);
                //g.FillRectangle(new SolidBrush(this.BackColor), new RectangleF(rt.Left - m, rt.Top - 5, m, m));
                //g.DrawImage(img, rt.Left-60, rt.Top - 10,30,30);
            }
            base.OnDrawNode(e);
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.IsExpanded)
                e.Node.Collapse();
            else e.Node.ExpandAll();
            base.OnNodeMouseClick(e);

        }


        private const int TVS_NOTOOLTIPS = 0x80;

        /// <summary>
        /// Disables the tooltip activity for the treenodes.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = p.Style | TVS_NOTOOLTIPS;
                return p;
            }
        }

        public Image GetImage(string imageIndex)
        {
            switch (imageIndex)
            {
                case "0-0":
                    return Properties.Resources.ImgCfg;
                    break;
                case "0-1":
                    return Properties.Resources.ImgAcq;
                    break;
                case "1-0":
                    return Properties.Resources.ImgData;
                    break;
                default:
                    return Properties.Resources.ImgData;
                    break;

            }

        }
    }
}
