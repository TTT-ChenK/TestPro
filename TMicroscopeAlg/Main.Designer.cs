namespace TMicroscopeAlg
{
    partial class Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Start_Btn = new System.Windows.Forms.Button();
            this.Stop_Btn = new System.Windows.Forms.Button();
            this.msgInfo_Lbx = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ImageCount_Tbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IsStop_Btn = new System.Windows.Forms.Button();
            this.Position_Tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(12, 12);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(106, 33);
            this.Start_Btn.TabIndex = 0;
            this.Start_Btn.Text = "Start";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // Stop_Btn
            // 
            this.Stop_Btn.Location = new System.Drawing.Point(139, 12);
            this.Stop_Btn.Name = "Stop_Btn";
            this.Stop_Btn.Size = new System.Drawing.Size(106, 33);
            this.Stop_Btn.TabIndex = 0;
            this.Stop_Btn.Text = "Stop";
            this.Stop_Btn.UseVisualStyleBackColor = true;
            this.Stop_Btn.Click += new System.EventHandler(this.Stop_Btn_Click);
            // 
            // msgInfo_Lbx
            // 
            this.msgInfo_Lbx.FormattingEnabled = true;
            this.msgInfo_Lbx.ItemHeight = 12;
            this.msgInfo_Lbx.Location = new System.Drawing.Point(12, 111);
            this.msgInfo_Lbx.Name = "msgInfo_Lbx";
            this.msgInfo_Lbx.Size = new System.Drawing.Size(234, 328);
            this.msgInfo_Lbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "采集数量：";
            // 
            // ImageCount_Tbx
            // 
            this.ImageCount_Tbx.Location = new System.Drawing.Point(69, 51);
            this.ImageCount_Tbx.Name = "ImageCount_Tbx";
            this.ImageCount_Tbx.ReadOnly = true;
            this.ImageCount_Tbx.Size = new System.Drawing.Size(100, 21);
            this.ImageCount_Tbx.TabIndex = 3;
            this.ImageCount_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Z 轴状态：";
            // 
            // IsStop_Btn
            // 
            this.IsStop_Btn.Enabled = false;
            this.IsStop_Btn.Location = new System.Drawing.Point(69, 82);
            this.IsStop_Btn.Name = "IsStop_Btn";
            this.IsStop_Btn.Size = new System.Drawing.Size(72, 23);
            this.IsStop_Btn.TabIndex = 4;
            this.IsStop_Btn.Text = "Stop";
            this.IsStop_Btn.UseVisualStyleBackColor = true;
            // 
            // Position_Tbx
            // 
            this.Position_Tbx.Location = new System.Drawing.Point(147, 84);
            this.Position_Tbx.Name = "Position_Tbx";
            this.Position_Tbx.ReadOnly = true;
            this.Position_Tbx.Size = new System.Drawing.Size(100, 21);
            this.Position_Tbx.TabIndex = 3;
            this.Position_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 450);
            this.Controls.Add(this.IsStop_Btn);
            this.Controls.Add(this.Position_Tbx);
            this.Controls.Add(this.ImageCount_Tbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msgInfo_Lbx);
            this.Controls.Add(this.Stop_Btn);
            this.Controls.Add(this.Start_Btn);
            this.Name = "Main";
            this.Text = "MicroscopeAlg";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Btn;
        private System.Windows.Forms.Button Stop_Btn;
        private System.Windows.Forms.ListBox msgInfo_Lbx;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImageCount_Tbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button IsStop_Btn;
        private System.Windows.Forms.TextBox Position_Tbx;
    }
}

