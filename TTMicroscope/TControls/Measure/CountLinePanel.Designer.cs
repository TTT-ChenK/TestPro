namespace TTMicroscope
{
    partial class CountLinePanel
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
            this.CouseAdd_Btn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ClearCursor_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CouseAdd_Btn
            // 
            this.CouseAdd_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CouseAdd_Btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CouseAdd_Btn.Location = new System.Drawing.Point(288, 3);
            this.CouseAdd_Btn.Name = "CouseAdd_Btn";
            this.CouseAdd_Btn.Size = new System.Drawing.Size(44, 26);
            this.CouseAdd_Btn.TabIndex = 0;
            this.CouseAdd_Btn.Text = "添加";
            this.CouseAdd_Btn.UseVisualStyleBackColor = true;
            this.CouseAdd_Btn.Click += new System.EventHandler(this.CouseAdd_Btn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ClearCursor_Btn);
            this.splitContainer1.Panel1.Controls.Add(this.CouseAdd_Btn);
            this.splitContainer1.Size = new System.Drawing.Size(758, 295);
            this.splitContainer1.SplitterDistance = 424;
            this.splitContainer1.TabIndex = 1;
            // 
            // ClearCursor_Btn
            // 
            this.ClearCursor_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearCursor_Btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearCursor_Btn.Location = new System.Drawing.Point(238, 3);
            this.ClearCursor_Btn.Name = "ClearCursor_Btn";
            this.ClearCursor_Btn.Size = new System.Drawing.Size(44, 26);
            this.ClearCursor_Btn.TabIndex = 0;
            this.ClearCursor_Btn.Text = "清除";
            this.ClearCursor_Btn.UseVisualStyleBackColor = true;
            this.ClearCursor_Btn.Click += new System.EventHandler(this.ClearCursor_Btn_Click);
            // 
            // CountLinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CountLinePanel";
            this.Size = new System.Drawing.Size(758, 295);
            this.Load += new System.EventHandler(this.CountLinePanel_Load);
            this.Resize += new System.EventHandler(this.CountLinePanel_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CouseAdd_Btn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button ClearCursor_Btn;
    }
}
