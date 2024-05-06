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
using KImageCtr;
using System.IO;
using System.Drawing.Imaging;
using System.Web.UI;

namespace TTMicroscope
{
    public partial class PImage : System.Windows.Forms.UserControl
    {
        public PImage()
        {
            InitializeComponent();
        }
        public KImageCtr.KImageBox imageBox=new KImageBox();
        public K3DModel d3model=new K3DModel();
        long imageCount = 0;

        #region
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="bt"></param>
        public void ShowImage(Bitmap bt)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    imageBox.ShowImage(bt);
                }));
            }catch (Exception ex) { }
            
        }

        public void ShowImageCount(int count)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    ImageCount_Lab.Text = string.Format("数量: {0}", count);
                    imgSize_Lb.Text = string.Format("大小: {0} * {1}", CImage2PointCloud.PicW, CImage2PointCloud.picH);
                }));
            }
            catch (Exception ex) { }
        }


        public void ShowMaxVlue(int maxVal)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    MaxValue_lab.Text = string.Format("最大值: {0}", maxVal);

                }));
            }
            catch (Exception ex) { }
        }


        public void LoadImage(string btPath)
        {
            imageBox.LoadImageFromFile(btPath);


        }

        /// <summary>
        /// 重置图片数量
        /// </summary>
        public void ResetImageCount() {
            imageCount = 0;
            this.Invoke(new Action(() =>
            {
                ImageCount_Lab.Text = string.Format("数量:{0}", imageCount);
            }));
        }

        #endregion


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = new LinearGradientBrush(panel3.ClientRectangle, Color.LightGray, Color.WhiteSmoke, 90);
            GraphicsPath path = ControlsPublic.Round(panel3.ClientRectangle,0);
            g.FillPath(/*new SolidBrush(_titleBackColor)*/b, path);
        }

        private void Img3D_Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (Expand_Rb.Checked)
            {
                image_Spp.Panel1Collapsed=false;
                image_Spp.Panel2Collapsed = false;
            }
            else if (Img2D_Rb.Checked)
            {
                //image_Spp.Panel1Collapsed = true;
                //image_Spp.Panel2Collapsed = false;
                imageBox.BringToFront();
            }
            else if (Img3D_Rb.Checked)
            {
                //if (!image_Spp.Panel2Collapsed)
                //{
                //    image_Spp.Panel2Collapsed = true;
                //    image_Spp.Panel1Collapsed = false;
                //}
                d3model.BringToFront();
            }
        }

        private void PImage_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, panel3.Bottom);
            panel1.Size = new Size(Width, Height - panel3.Height - 5);
            if (image_Spp.Height != 0)
            {
                if (Expand_Rb.Checked)
                {
                    image_Spp.SplitterDistance = image_Spp.Height / 2;
                }
                panel3.Location = new Point(Width - panel3.Width - 30, panel3.Location.Y);
            }
        }

        private void PImage_Load(object sender, EventArgs e)
        {
            imageBox.ImageAreaBackColor=Color.Silver;
            panel1.Controls.Add(imageBox);
            imageBox.Show();
            imageBox.BringToFront();
            imageBox.Dock = DockStyle.Fill;

            panel1.Controls.Add(d3model);
            d3model.BringToFront();
            d3model.Dock = DockStyle.Fill;
            Img2D_Rb.Checked = true;
            CGlobal.resultSaveFold = Path.Combine(CGlobal.cameracfg.ImageSaveFold, DateTime.Now.ToString("yyyy-MM-dd"), ImageFold_Tbx.Text.Trim());
            imageBox.OnShowRGBInfo += ImageBox_OnShowRGBInfo;
            imageBox.OnShowMousePosition += ImageBox_OnShowMousePosition;
            comboBox1.SelectedIndex = 9;
        }

        private void ImageBox_OnShowMousePosition(Point mouseInPanel, Point mouseInImage)
        {
            this.Invoke(new Action(() =>
            {
                imageInfo_Lab.Text = string.Format("R-{0},G-{1},B-{2}",  imageBox.RGBValue[0], imageBox.RGBValue[1], imageBox.RGBValue[2]);
            }));
        }

        private void ImageBox_OnShowRGBInfo(int[] rGBInfo)
        {
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageBox.InitTarget();
            imageBox.ShowImage(imageBox._imageOrigin);
            imageBox?.Home_Btn_Click_1(null, null);
            return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //LoadImage(openFileDialog.FileName);

                ////string stldataModel = "C:\\Users\\28399\\Desktop\\E3DData\\stl\\triangles_PolygonMesh.stl";
                d3model.ShowStlModel(openFileDialog.FileName);
                d3model.ShowAxes();
                ////d3model.ShowColorTable();
            }
        }

        private void ImageFold_Tbx_TextChanged(object sender, EventArgs e)
        {
            CGlobal.resultSaveFold = Path.Combine(CGlobal.cameracfg.ImageSaveFold, DateTime.Now.ToString("yyyy-MM-dd"), ImageFold_Tbx.Text.Trim());
        }

        private void ZMove_Btn_Click(object sender, EventArgs e)
        {
            imageBox.opType = EOpType.ZoomOrMove;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != null && comboBox1.Text != "")
                {
                    double val = double.Parse(comboBox1.Text);
                    d3model.SetZScale(val);
                    d3model.Refresh();
                }
            }
            catch { }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {

            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "png图片|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = ofd.FileName;
                if (Img2D_Rb.Checked)
                {
                    if (imageBox._imageOrigin != null)
                    {
                        Bitmap bt = (Bitmap)imageBox._imageOrigin.Clone();
                        bt.Save(file);
                    }
                }
                else
                {
                    Bitmap bitmap = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(bitmap, new Rectangle(0, 0, d3model.Width, d3model.Height));
                    bitmap.Save(file, ImageFormat.Png);
                }
            }

        }
    }
}
