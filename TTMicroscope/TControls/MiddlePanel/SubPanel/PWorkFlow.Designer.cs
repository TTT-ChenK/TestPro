namespace TTMicroscope
{
    partial class PWorkFlow
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
            this.tGroupBox3 = new TTMicroscope.TGroupBox();
            this.tGroupBox2 = new TTMicroscope.TGroupBox();
            this.wliWorkFlow1 = new TTMicroscope.WLIWorkFlow();
            this.msgInfo_Lbx = new System.Windows.Forms.ListBox();
            this.tGroupBox1 = new TTMicroscope.TGroupBox();
            this.Contiuns_Btn = new System.Windows.Forms.Button();
            this.Stop_Btn = new System.Windows.Forms.Button();
            this.Init_Btn = new System.Windows.Forms.Button();
            this.TotalTest_Btn = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageFold_Tbx = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tGroupBox3
            // 
            this.tGroupBox3.BackColor = System.Drawing.Color.White;
            this.tGroupBox3.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox3.BouderRatius = 4F;
            this.tGroupBox3.BouderWidth = 1F;
            this.tGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.tGroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox3.MTitle = "日志";
            this.tGroupBox3.MTitleIsLeft = false;
            this.tGroupBox3.Name = "tGroupBox3";
            this.tGroupBox3.Size = new System.Drawing.Size(347, 150);
            this.tGroupBox3.TabIndex = 1;
            this.tGroupBox3.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox3.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox3.TitleForeColor = System.Drawing.Color.Black;
            // 
            // tGroupBox2
            // 
            this.tGroupBox2.BackColor = System.Drawing.Color.White;
            this.tGroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox2.BouderRatius = 4F;
            this.tGroupBox2.BouderWidth = 1F;
            this.tGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.tGroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox2.MTitle = "测试流程";
            this.tGroupBox2.MTitleIsLeft = false;
            this.tGroupBox2.Name = "tGroupBox2";
            this.tGroupBox2.Size = new System.Drawing.Size(347, 756);
            this.tGroupBox2.TabIndex = 1;
            this.tGroupBox2.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox2.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox2.TitleForeColor = System.Drawing.Color.Black;
            // 
            // wliWorkFlow1
            // 
            this.wliWorkFlow1.BackColor = System.Drawing.Color.White;
            this.wliWorkFlow1.Location = new System.Drawing.Point(514, 248);
            this.wliWorkFlow1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wliWorkFlow1.Name = "wliWorkFlow1";
            this.wliWorkFlow1.Size = new System.Drawing.Size(345, 515);
            this.wliWorkFlow1.TabIndex = 2;
            this.wliWorkFlow1.Load += new System.EventHandler(this.wliWorkFlow1_Load);
            // 
            // msgInfo_Lbx
            // 
            this.msgInfo_Lbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msgInfo_Lbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgInfo_Lbx.FormattingEnabled = true;
            this.msgInfo_Lbx.ItemHeight = 20;
            this.msgInfo_Lbx.Items.AddRange(new object[] {
            "14:23 程序启动"});
            this.msgInfo_Lbx.Location = new System.Drawing.Point(502, 798);
            this.msgInfo_Lbx.Name = "msgInfo_Lbx";
            this.msgInfo_Lbx.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.msgInfo_Lbx.Size = new System.Drawing.Size(345, 240);
            this.msgInfo_Lbx.TabIndex = 3;
            // 
            // tGroupBox1
            // 
            this.tGroupBox1.BackColor = System.Drawing.Color.White;
            this.tGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox1.BouderRatius = 4F;
            this.tGroupBox1.BouderWidth = 1F;
            this.tGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.tGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox1.MTitle = "测试";
            this.tGroupBox1.MTitleIsLeft = false;
            this.tGroupBox1.Name = "tGroupBox1";
            this.tGroupBox1.Size = new System.Drawing.Size(347, 136);
            this.tGroupBox1.TabIndex = 1;
            this.tGroupBox1.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox1.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox1.TitleForeColor = System.Drawing.Color.Black;
            // 
            // Contiuns_Btn
            // 
            this.Contiuns_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Contiuns_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Contiuns_Btn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Contiuns_Btn.Location = new System.Drawing.Point(114, 40);
            this.Contiuns_Btn.Name = "Contiuns_Btn";
            this.Contiuns_Btn.Size = new System.Drawing.Size(100, 39);
            this.Contiuns_Btn.TabIndex = 28;
            this.Contiuns_Btn.Text = "连续测量";
            this.Contiuns_Btn.UseVisualStyleBackColor = true;
            // 
            // Stop_Btn
            // 
            this.Stop_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Stop_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_Btn.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Stop_Btn.Location = new System.Drawing.Point(222, 40);
            this.Stop_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop_Btn.Name = "Stop_Btn";
            this.Stop_Btn.Size = new System.Drawing.Size(100, 39);
            this.Stop_Btn.TabIndex = 25;
            this.Stop_Btn.Tag = "10";
            this.Stop_Btn.Text = "停止";
            this.Stop_Btn.UseVisualStyleBackColor = true;
            // 
            // Init_Btn
            // 
            this.Init_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Init_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Init_Btn.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Init_Btn.Location = new System.Drawing.Point(869, 122);
            this.Init_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Init_Btn.Name = "Init_Btn";
            this.Init_Btn.Size = new System.Drawing.Size(102, 39);
            this.Init_Btn.TabIndex = 26;
            this.Init_Btn.Tag = "11";
            this.Init_Btn.Text = "初始化";
            this.Init_Btn.UseVisualStyleBackColor = true;
            // 
            // TotalTest_Btn
            // 
            this.TotalTest_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.TotalTest_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalTest_Btn.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalTest_Btn.Location = new System.Drawing.Point(6, 40);
            this.TotalTest_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalTest_Btn.Name = "TotalTest_Btn";
            this.TotalTest_Btn.Size = new System.Drawing.Size(100, 39);
            this.TotalTest_Btn.TabIndex = 27;
            this.TotalTest_Btn.Tag = "9";
            this.TotalTest_Btn.Text = "测量";
            this.TotalTest_Btn.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(874, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 20);
            this.label23.TabIndex = 24;
            this.label23.Text = "次数:0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "测试结果存储名称";
            // 
            // ImageFold_Tbx
            // 
            this.ImageFold_Tbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageFold_Tbx.Location = new System.Drawing.Point(136, 3);
            this.ImageFold_Tbx.Name = "ImageFold_Tbx";
            this.ImageFold_Tbx.Size = new System.Drawing.Size(186, 26);
            this.ImageFold_Tbx.TabIndex = 30;
            this.ImageFold_Tbx.Text = "P1";
            this.ImageFold_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(46, 89);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(241, 20);
            this.progressBar1.TabIndex = 31;
            this.progressBar1.Value = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "进度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(289, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "100%";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(379, 1050);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 32;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(22, 93);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tGroupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(347, 1050);
            this.splitContainer2.SplitterDistance = 136;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tGroupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tGroupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(347, 910);
            this.splitContainer3.SplitterDistance = 756;
            this.splitContainer3.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(2, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 80);
            this.button3.TabIndex = 0;
            this.button3.Text = "流程";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(2, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 80);
            this.button2.TabIndex = 0;
            this.button2.Text = "测试";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 101);
            this.button1.TabIndex = 0;
            this.button1.Text = "参数和方法";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 1050);
            this.splitter1.TabIndex = 33;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TotalTest_Btn);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.Stop_Btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Contiuns_Btn);
            this.panel1.Controls.Add(this.ImageFold_Tbx);
            this.panel1.Location = new System.Drawing.Point(410, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 114);
            this.panel1.TabIndex = 34;
            // 
            // PWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Init_Btn);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.msgInfo_Lbx);
            this.Controls.Add(this.wliWorkFlow1);
            this.Name = "PWorkFlow";
            this.Size = new System.Drawing.Size(1186, 1050);
            this.Resize += new System.EventHandler(this.PWorkFlow_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TGroupBox tGroupBox2;
        private TGroupBox tGroupBox3;
        private System.Windows.Forms.ListBox msgInfo_Lbx;
        public WLIWorkFlow wliWorkFlow1;
        private TGroupBox tGroupBox1;
        private System.Windows.Forms.Button Contiuns_Btn;
        private System.Windows.Forms.Button Stop_Btn;
        public System.Windows.Forms.Button Init_Btn;
        public System.Windows.Forms.Button TotalTest_Btn;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImageFold_Tbx;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
