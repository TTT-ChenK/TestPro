namespace TTMicroscope
{
    partial class PDataAcq
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
            this.uManualControl1 = new TTMicroscope.UManualControl();
            this.SuspendLayout();
            // 
            // uManualControl1
            // 
            this.uManualControl1.BackColor = System.Drawing.Color.White;
            this.uManualControl1.Location = new System.Drawing.Point(363, 26);
            this.uManualControl1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.uManualControl1.Name = "uManualControl1";
            this.uManualControl1.Size = new System.Drawing.Size(813, 935);
            this.uManualControl1.TabIndex = 11;
            // 
            // PDataAcq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.uManualControl1);
            this.DoubleBuffered = true;
            this.Name = "PDataAcq";
            this.Size = new System.Drawing.Size(1819, 1020);
            this.Load += new System.EventHandler(this.PDataAcq_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PDataAcq_Paint);
            this.Resize += new System.EventHandler(this.PDataAcq_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        public UManualControl uManualControl1;
        //public PImage pImage1;
    }
}
