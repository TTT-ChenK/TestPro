using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope.TControls
{
    public partial class LeftTitlePanel : UserControl
    {
        public LeftTitlePanel()
        {
            InitializeComponent();
        }


        #region Vara
        Color[] colorListC = new Color[7] {Color.Red,Color.Orange,Color.Yellow,Color.Green,
            Color.Cyan,Color.Blue, Color.Purple };
        Thread t;
        int index = 0;

        #endregion

        private void LeftTitlePanel_Load(object sender, EventArgs e)
        {
            leftNevigate1.Nodes.Add("1.采集");
            leftNevigate1.Nodes[0].Nodes.Add("参数配置");
            leftNevigate1.Nodes[0].Nodes.Add("数据采集");
            leftNevigate1.Nodes.Add("2.分析");
            //leftNevigate1.Nodes[1].Nodes.Add("数据导入");
            //leftNevigate1.Nodes[1].Nodes.Add("台阶测试");
            //leftNevigate1.Nodes[1].Nodes.Add("平面度测试");
            //leftNevigate1.Nodes[1].Nodes.Add("粗糙度测试");
            //leftNevigate1.Nodes.Add("3.报表");
            //leftNevigate1.Nodes[2].Nodes.Add("Excel");
            //leftNevigate1.Nodes[2].Nodes.Add("Word");
            //leftNevigate1.Nodes.Add("4.其他");
            //leftNevigate1.Nodes[3].Nodes.Add("用户");
            //leftNevigate1.Nodes[3].Nodes.Add("帮助");
            leftNevigate1.ExpandAll();
            //Start();
        }

        private void LeftTitlePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            GraphicsPath gp= ControlsPublic.Round(new Rectangle(0,0,this.Width-1,this.Height-1), 10);
            g.DrawPath(new Pen(Color.Black, 2), gp);
            g.FillPath(new SolidBrush(Color.Black), gp);
            this.Region=new Region(gp);




        }

        private void LeftTitlePanel_Resize(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g= e.Graphics;
            float tW = Logo_P.Width * 3f / 4f;
            float step = tW / 7f;
            float w = step * 3f / 5f;
            float h = w / 2f;
            for (int i = 0; i < colorListC.Length; i++)
            {
                RectangleF re = new RectangleF(step * i + step - w + 5 + Logo_P.Left, Logo_P.Bottom + 6, w, h);
                g.FillRectangle(new SolidBrush(colorListC[i]), re);

            }

        }

        /// <summary>
        /// 线程开始
        /// </summary>
        public void Start()
        {
            t = new Thread(DrawICon);
            t.IsBackground = true;
            t.Start();
        }
        /// <summary>
        /// 线程终止
        /// </summary>
        public void Stop()
        {
            if (t != null)
            {
                t.Abort();
            }
        }
        /// <summary>
        /// 绘制图标
        /// </summary>
        private void DrawICon()
        {
            while (true)
            {

                this.Invoke(new Action(() =>
                {
                    Graphics g = panel1.CreateGraphics();
                    float tW = Logo_P.Width * 3f / 4f;
                    float step = tW / 7f;
                    float w = step * 3f / 5f;
                    float h = w / 2f;
                    for (int i = 0; i < colorListC.Length; i++)
                    {
                        RectangleF re = new RectangleF(step * i + step - w + 5+ Logo_P.Left, Logo_P.Bottom + 6, w, h);
                        if (i != (index % colorListC.Length))
                        { 
                            g.FillRectangle(new SolidBrush(colorListC[i]), re);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(this.BackColor), re);
                        }
                    }
                    //panel1.Refresh();
                }));
                Thread.Sleep(1000);
                index++;
            }

        }

        private void leftNevigate1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            { }
        }
    }
}
