namespace TTMicroscope
{
    partial class SObject
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Object_Pbx = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pos_Lab = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Object_Pbx)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Object_Pbx, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.4138F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.58621F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(66, 116);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Object_Pbx
            // 
            this.Object_Pbx.BackgroundImage = global::TTMicroscope.Properties.Resources.SObjective2;
            this.Object_Pbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Object_Pbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Object_Pbx.Location = new System.Drawing.Point(3, 3);
            this.Object_Pbx.Name = "Object_Pbx";
            this.Object_Pbx.Size = new System.Drawing.Size(60, 78);
            this.Object_Pbx.TabIndex = 0;
            this.Object_Pbx.TabStop = false;
            this.Object_Pbx.Click += new System.EventHandler(this.Object_Pbx_Click);
            this.Object_Pbx.Paint += new System.Windows.Forms.PaintEventHandler(this.Object_Pbx_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Pos_Lab);
            this.panel1.Location = new System.Drawing.Point(3, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 20);
            this.panel1.TabIndex = 1;
            // 
            // Pos_Lab
            // 
            this.Pos_Lab.AutoSize = true;
            this.Pos_Lab.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pos_Lab.Location = new System.Drawing.Point(6, -1);
            this.Pos_Lab.Name = "Pos_Lab";
            this.Pos_Lab.Size = new System.Drawing.Size(45, 20);
            this.Pos_Lab.TabIndex = 0;
            this.Pos_Lab.Text = "位置1";
            // 
            // SObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SObject";
            this.Size = new System.Drawing.Size(66, 116);
            this.Load += new System.EventHandler(this.SObject_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SObject_Paint);
            this.Resize += new System.EventHandler(this.SObject_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Object_Pbx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Pos_Lab;
        public System.Windows.Forms.PictureBox Object_Pbx;
    }
}
