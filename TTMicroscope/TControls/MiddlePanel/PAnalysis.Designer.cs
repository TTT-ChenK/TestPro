namespace TTMicroscope
{
    partial class PAnalysis
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.kPage1 = new KPageCtr.KPage();
            this.Test_Btn = new System.Windows.Forms.Button();
            this.WorkFlow_Trw = new System.Windows.Forms.TreeView();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.preProcess1 = new TTMicroscope.PreProcess();
            this.otherTool1 = new TTMicroscope.OtherTool();
            this.elePanel1 = new TTMicroscope.ElePanel();
            this._3DDetect1 = new TTMicroscope._3DDetect();
            this._2DDetect1 = new TTMicroscope._2DDetect();
            this.Pic_Tbx = new TTMicroscope.TGroupBox();
            this.Tool_Tbx = new TTMicroscope.TGroupBox();
            this.WorkFlow_Tbx = new TTMicroscope.TGroupBox();
            this.File_Tbx = new TTMicroscope.TGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImageFold_Btn = new System.Windows.Forms.Button();
            this.FileLoad_Btn = new System.Windows.Forms.Button();
            this.ModelLoad_Btn = new System.Windows.Forms.Button();
            this.ToolPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kPage1
            // 
            this.kPage1.AllowDrop = true;
            this.kPage1.AutoScroll = true;
            this.kPage1.BackColor = System.Drawing.Color.Transparent;
            this.kPage1.Location = new System.Drawing.Point(264, 36);
            this.kPage1.Margin = new System.Windows.Forms.Padding(1);
            this.kPage1.Name = "kPage1";
            this.kPage1.Size = new System.Drawing.Size(1218, 980);
            this.kPage1.TabIndex = 2;
            this.kPage1.DragDrop += new System.Windows.Forms.DragEventHandler(this.kPage1_DragDrop);
            this.kPage1.DragEnter += new System.Windows.Forms.DragEventHandler(this.kPage1_DragEnter);
            // 
            // Test_Btn
            // 
            this.Test_Btn.Location = new System.Drawing.Point(1395, 10);
            this.Test_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Test_Btn.Name = "Test_Btn";
            this.Test_Btn.Size = new System.Drawing.Size(83, 23);
            this.Test_Btn.TabIndex = 3;
            this.Test_Btn.Text = "增加一页";
            this.Test_Btn.UseVisualStyleBackColor = true;
            this.Test_Btn.Click += new System.EventHandler(this.Test_Btn_Click);
            // 
            // WorkFlow_Trw
            // 
            this.WorkFlow_Trw.AllowDrop = true;
            this.WorkFlow_Trw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WorkFlow_Trw.Location = new System.Drawing.Point(5, 239);
            this.WorkFlow_Trw.Margin = new System.Windows.Forms.Padding(2);
            this.WorkFlow_Trw.Name = "WorkFlow_Trw";
            this.WorkFlow_Trw.Size = new System.Drawing.Size(250, 702);
            this.WorkFlow_Trw.TabIndex = 5;
            this.WorkFlow_Trw.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WorkFlow_Trw_AfterSelect);
            this.WorkFlow_Trw.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.WorkFlow_Trw_NodeMouseClick);
            this.WorkFlow_Trw.DragDrop += new System.Windows.Forms.DragEventHandler(this.kPage1_DragEnter);
            this.WorkFlow_Trw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFlow_Trw_MouseDown);
            // 
            // ToolPanel
            // 
            this.ToolPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolPanel.BackColor = System.Drawing.Color.White;
            this.ToolPanel.Controls.Add(this.preProcess1);
            this.ToolPanel.Controls.Add(this.otherTool1);
            this.ToolPanel.Controls.Add(this.elePanel1);
            this.ToolPanel.Controls.Add(this._3DDetect1);
            this.ToolPanel.Controls.Add(this._2DDetect1);
            this.ToolPanel.Location = new System.Drawing.Point(1488, 36);
            this.ToolPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(327, 984);
            this.ToolPanel.TabIndex = 11;
            // 
            // preProcess1
            // 
            this.preProcess1.BackColor = System.Drawing.Color.White;
            this.preProcess1.Location = new System.Drawing.Point(1, 2);
            this.preProcess1.Margin = new System.Windows.Forms.Padding(1);
            this.preProcess1.Name = "preProcess1";
            this.preProcess1.Size = new System.Drawing.Size(328, 171);
            this.preProcess1.TabIndex = 11;
            // 
            // otherTool1
            // 
            this.otherTool1.BackColor = System.Drawing.Color.White;
            this.otherTool1.Location = new System.Drawing.Point(1, 865);
            this.otherTool1.Margin = new System.Windows.Forms.Padding(1);
            this.otherTool1.Name = "otherTool1";
            this.otherTool1.Size = new System.Drawing.Size(323, 93);
            this.otherTool1.TabIndex = 10;
            // 
            // elePanel1
            // 
            this.elePanel1.BackColor = System.Drawing.Color.White;
            this.elePanel1.Location = new System.Drawing.Point(1, 198);
            this.elePanel1.Margin = new System.Windows.Forms.Padding(1);
            this.elePanel1.Name = "elePanel1";
            this.elePanel1.Size = new System.Drawing.Size(323, 249);
            this.elePanel1.TabIndex = 7;
            // 
            // _3DDetect1
            // 
            this._3DDetect1.BackColor = System.Drawing.Color.White;
            this._3DDetect1.Location = new System.Drawing.Point(1, 624);
            this._3DDetect1.Margin = new System.Windows.Forms.Padding(1);
            this._3DDetect1.Name = "_3DDetect1";
            this._3DDetect1.Size = new System.Drawing.Size(325, 223);
            this._3DDetect1.TabIndex = 9;
            // 
            // _2DDetect1
            // 
            this._2DDetect1.BackColor = System.Drawing.Color.White;
            this._2DDetect1.Location = new System.Drawing.Point(1, 486);
            this._2DDetect1.Margin = new System.Windows.Forms.Padding(1);
            this._2DDetect1.Name = "_2DDetect1";
            this._2DDetect1.Size = new System.Drawing.Size(323, 135);
            this._2DDetect1.TabIndex = 8;
            // 
            // Pic_Tbx
            // 
            this.Pic_Tbx.BackColor = System.Drawing.Color.DarkGray;
            this.Pic_Tbx.BorderColor = System.Drawing.Color.DarkGray;
            this.Pic_Tbx.BouderRatius = 4F;
            this.Pic_Tbx.BouderWidth = 1F;
            this.Pic_Tbx.Location = new System.Drawing.Point(262, 4);
            this.Pic_Tbx.Margin = new System.Windows.Forms.Padding(4);
            this.Pic_Tbx.MTitle = "图像";
            this.Pic_Tbx.MTitleIsLeft = false;
            this.Pic_Tbx.Name = "Pic_Tbx";
            this.Pic_Tbx.Size = new System.Drawing.Size(1221, 1012);
            this.Pic_Tbx.TabIndex = 1;
            this.Pic_Tbx.TitleBacColor = System.Drawing.Color.LightGray;
            this.Pic_Tbx.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pic_Tbx.TitleForeColor = System.Drawing.Color.Black;
            // 
            // Tool_Tbx
            // 
            this.Tool_Tbx.BackColor = System.Drawing.Color.LightGray;
            this.Tool_Tbx.BorderColor = System.Drawing.Color.DarkGray;
            this.Tool_Tbx.BouderRatius = 4F;
            this.Tool_Tbx.BouderWidth = 1F;
            this.Tool_Tbx.Location = new System.Drawing.Point(1487, 4);
            this.Tool_Tbx.Margin = new System.Windows.Forms.Padding(4);
            this.Tool_Tbx.MTitle = "工具";
            this.Tool_Tbx.MTitleIsLeft = false;
            this.Tool_Tbx.Name = "Tool_Tbx";
            this.Tool_Tbx.Size = new System.Drawing.Size(328, 1012);
            this.Tool_Tbx.TabIndex = 1;
            this.Tool_Tbx.TitleBacColor = System.Drawing.Color.LightGray;
            this.Tool_Tbx.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tool_Tbx.TitleForeColor = System.Drawing.Color.Black;
            // 
            // WorkFlow_Tbx
            // 
            this.WorkFlow_Tbx.BorderColor = System.Drawing.Color.DarkGray;
            this.WorkFlow_Tbx.BouderRatius = 4F;
            this.WorkFlow_Tbx.BouderWidth = 1F;
            this.WorkFlow_Tbx.Location = new System.Drawing.Point(4, 207);
            this.WorkFlow_Tbx.Margin = new System.Windows.Forms.Padding(4);
            this.WorkFlow_Tbx.MTitle = "工作流";
            this.WorkFlow_Tbx.MTitleIsLeft = false;
            this.WorkFlow_Tbx.Name = "WorkFlow_Tbx";
            this.WorkFlow_Tbx.Size = new System.Drawing.Size(251, 809);
            this.WorkFlow_Tbx.TabIndex = 1;
            this.WorkFlow_Tbx.TitleBacColor = System.Drawing.Color.LightGray;
            this.WorkFlow_Tbx.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WorkFlow_Tbx.TitleForeColor = System.Drawing.Color.Black;
            // 
            // File_Tbx
            // 
            this.File_Tbx.BackColor = System.Drawing.Color.LightGray;
            this.File_Tbx.BorderColor = System.Drawing.Color.DarkGray;
            this.File_Tbx.BouderRatius = 4F;
            this.File_Tbx.BouderWidth = 1F;
            this.File_Tbx.Location = new System.Drawing.Point(3, 4);
            this.File_Tbx.Margin = new System.Windows.Forms.Padding(4);
            this.File_Tbx.MTitle = "文件";
            this.File_Tbx.MTitleIsLeft = false;
            this.File_Tbx.Name = "File_Tbx";
            this.File_Tbx.Size = new System.Drawing.Size(251, 195);
            this.File_Tbx.TabIndex = 1;
            this.File_Tbx.TitleBacColor = System.Drawing.Color.LightGray;
            this.File_Tbx.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.File_Tbx.TitleForeColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ImageFold_Btn);
            this.panel1.Controls.Add(this.FileLoad_Btn);
            this.panel1.Controls.Add(this.ModelLoad_Btn);
            this.panel1.Location = new System.Drawing.Point(5, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 163);
            this.panel1.TabIndex = 12;
            // 
            // ImageFold_Btn
            // 
            this.ImageFold_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageFold_Btn.Image = global::TTMicroscope.Properties.Resources.图片集__3_;
            this.ImageFold_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImageFold_Btn.Location = new System.Drawing.Point(55, 19);
            this.ImageFold_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ImageFold_Btn.Name = "ImageFold_Btn";
            this.ImageFold_Btn.Size = new System.Drawing.Size(101, 35);
            this.ImageFold_Btn.TabIndex = 4;
            this.ImageFold_Btn.Text = "图片文件";
            this.ImageFold_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImageFold_Btn.UseVisualStyleBackColor = true;
            this.ImageFold_Btn.Click += new System.EventHandler(this.ImageFold_Btn_Click);
            // 
            // FileLoad_Btn
            // 
            this.FileLoad_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileLoad_Btn.Image = global::TTMicroscope.Properties.Resources._3D;
            this.FileLoad_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileLoad_Btn.Location = new System.Drawing.Point(55, 58);
            this.FileLoad_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.FileLoad_Btn.Name = "FileLoad_Btn";
            this.FileLoad_Btn.Size = new System.Drawing.Size(101, 35);
            this.FileLoad_Btn.TabIndex = 4;
            this.FileLoad_Btn.Text = "点云数据";
            this.FileLoad_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileLoad_Btn.UseVisualStyleBackColor = true;
            this.FileLoad_Btn.Click += new System.EventHandler(this.FileLoad_Btn_Click);
            // 
            // ModelLoad_Btn
            // 
            this.ModelLoad_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModelLoad_Btn.Image = global::TTMicroscope.Properties.Resources.模型;
            this.ModelLoad_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModelLoad_Btn.Location = new System.Drawing.Point(55, 96);
            this.ModelLoad_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ModelLoad_Btn.Name = "ModelLoad_Btn";
            this.ModelLoad_Btn.Size = new System.Drawing.Size(101, 35);
            this.ModelLoad_Btn.TabIndex = 4;
            this.ModelLoad_Btn.Text = "模型数据";
            this.ModelLoad_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ModelLoad_Btn.UseVisualStyleBackColor = true;
            this.ModelLoad_Btn.Click += new System.EventHandler(this.ModelLoad_Btn_Click);
            // 
            // PAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolPanel);
            this.Controls.Add(this.WorkFlow_Trw);
            this.Controls.Add(this.Test_Btn);
            this.Controls.Add(this.kPage1);
            this.Controls.Add(this.Pic_Tbx);
            this.Controls.Add(this.Tool_Tbx);
            this.Controls.Add(this.WorkFlow_Tbx);
            this.Controls.Add(this.File_Tbx);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PAnalysis";
            this.Size = new System.Drawing.Size(1819, 1020);
            this.Load += new System.EventHandler(this.PAnalysis_Load);
            this.Resize += new System.EventHandler(this.PAnalysis_Resize);
            this.ToolPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TGroupBox File_Tbx;
        private TGroupBox Pic_Tbx;
        private TGroupBox WorkFlow_Tbx;
        private TGroupBox Tool_Tbx;
        private KPageCtr.KPage kPage1;
        private System.Windows.Forms.Button Test_Btn;
        private System.Windows.Forms.Button FileLoad_Btn;
        private System.Windows.Forms.Button ImageFold_Btn;
        private System.Windows.Forms.TreeView WorkFlow_Trw;
        private System.Windows.Forms.Button ModelLoad_Btn;
        private ElePanel elePanel1;
        private _2DDetect _2DDetect1;
        private _3DDetect _3DDetect1;
        private OtherTool otherTool1;
        private System.Windows.Forms.Panel ToolPanel;
        private PreProcess preProcess1;
        private System.Windows.Forms.Panel panel1;
    }
}
