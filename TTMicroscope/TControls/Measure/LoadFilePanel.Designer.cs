namespace TTMicroscope
{
    partial class LoadFilePanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.FilePath_Tbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReloY_Tbx = new System.Windows.Forms.TextBox();
            this.ReloX_Tbx = new System.Windows.Forms.TextBox();
            this.ReloZ_Tbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Load_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径";
            // 
            // FilePath_Tbx
            // 
            this.FilePath_Tbx.Enabled = false;
            this.FilePath_Tbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FilePath_Tbx.Location = new System.Drawing.Point(94, 10);
            this.FilePath_Tbx.Name = "FilePath_Tbx";
            this.FilePath_Tbx.ReadOnly = true;
            this.FilePath_Tbx.Size = new System.Drawing.Size(537, 26);
            this.FilePath_Tbx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "分辨率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(90, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(282, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Y:";
            // 
            // ReloY_Tbx
            // 
            this.ReloY_Tbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReloY_Tbx.Location = new System.Drawing.Point(302, 99);
            this.ReloY_Tbx.Name = "ReloY_Tbx";
            this.ReloY_Tbx.Size = new System.Drawing.Size(138, 26);
            this.ReloY_Tbx.TabIndex = 1;
            this.ReloY_Tbx.Text = "0.025";
            this.ReloY_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReloY_Tbx.TextChanged += new System.EventHandler(this.ReloX_Tbx_TextChanged);
            // 
            // ReloX_Tbx
            // 
            this.ReloX_Tbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReloX_Tbx.Location = new System.Drawing.Point(112, 99);
            this.ReloX_Tbx.Name = "ReloX_Tbx";
            this.ReloX_Tbx.Size = new System.Drawing.Size(138, 26);
            this.ReloX_Tbx.TabIndex = 1;
            this.ReloX_Tbx.Text = "0.025";
            this.ReloX_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReloX_Tbx.TextChanged += new System.EventHandler(this.ReloX_Tbx_TextChanged);
            // 
            // ReloZ_Tbx
            // 
            this.ReloZ_Tbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReloZ_Tbx.Location = new System.Drawing.Point(494, 98);
            this.ReloZ_Tbx.Name = "ReloZ_Tbx";
            this.ReloZ_Tbx.Size = new System.Drawing.Size(138, 26);
            this.ReloZ_Tbx.TabIndex = 1;
            this.ReloZ_Tbx.Text = "0.001";
            this.ReloZ_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReloZ_Tbx.TextChanged += new System.EventHandler(this.ReloX_Tbx_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(472, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Z:";
            // 
            // Load_Btn
            // 
            this.Load_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Load_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Load_Btn.Location = new System.Drawing.Point(637, 10);
            this.Load_Btn.Name = "Load_Btn";
            this.Load_Btn.Size = new System.Drawing.Size(97, 36);
            this.Load_Btn.TabIndex = 2;
            this.Load_Btn.Text = "加载";
            this.Load_Btn.UseVisualStyleBackColor = true;
            this.Load_Btn.Click += new System.EventHandler(this.Load_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Save_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Save_Btn.Location = new System.Drawing.Point(637, 97);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(97, 36);
            this.Save_Btn.TabIndex = 2;
            this.Save_Btn.Text = "保存";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // LoadFilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Save_Btn);
            this.Controls.Add(this.Load_Btn);
            this.Controls.Add(this.ReloZ_Tbx);
            this.Controls.Add(this.ReloX_Tbx);
            this.Controls.Add(this.ReloY_Tbx);
            this.Controls.Add(this.FilePath_Tbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoadFilePanel";
            this.Size = new System.Drawing.Size(793, 172);
            this.Load += new System.EventHandler(this.LoadFilePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ReloY_Tbx;
        public System.Windows.Forms.TextBox ReloX_Tbx;
        public System.Windows.Forms.TextBox FilePath_Tbx;
        public System.Windows.Forms.TextBox ReloZ_Tbx;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button Load_Btn;
        public System.Windows.Forms.Button Save_Btn;
    }
}
