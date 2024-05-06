namespace TTMicroscope
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MiddlePanle = new System.Windows.Forms.Panel();
            this.Test_Btn = new System.Windows.Forms.Button();
            this.Offset_Nud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.leftTitlePanel1 = new TTMicroscope.TControls.LeftTitlePanel();
            this.topTitle1 = new TTMicroscope.TopTitle();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Offset_Nud)).BeginInit();
            this.SuspendLayout();
            // 
            // MiddlePanle
            // 
            this.MiddlePanle.BackColor = System.Drawing.SystemColors.Window;
            this.MiddlePanle.Location = new System.Drawing.Point(101, 60);
            this.MiddlePanle.Name = "MiddlePanle";
            this.MiddlePanle.Size = new System.Drawing.Size(1819, 1020);
            this.MiddlePanle.TabIndex = 2;
            // 
            // Test_Btn
            // 
            this.Test_Btn.Location = new System.Drawing.Point(1223, 7);
            this.Test_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Test_Btn.Name = "Test_Btn";
            this.Test_Btn.Size = new System.Drawing.Size(56, 18);
            this.Test_Btn.TabIndex = 3;
            this.Test_Btn.Text = "Test";
            this.Test_Btn.UseVisualStyleBackColor = true;
            this.Test_Btn.Visible = false;
            // 
            // Offset_Nud
            // 
            this.Offset_Nud.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Offset_Nud.Location = new System.Drawing.Point(879, 4);
            this.Offset_Nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Offset_Nud.Name = "Offset_Nud";
            this.Offset_Nud.Size = new System.Drawing.Size(60, 26);
            this.Offset_Nud.TabIndex = 4;
            this.Offset_Nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Offset_Nud.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Offset_Nud.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(942, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "um";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1001, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // leftTitlePanel1
            // 
            this.leftTitlePanel1.BackColor = System.Drawing.Color.Transparent;
            this.leftTitlePanel1.Location = new System.Drawing.Point(-1, -1);
            this.leftTitlePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.leftTitlePanel1.Name = "leftTitlePanel1";
            this.leftTitlePanel1.Size = new System.Drawing.Size(102, 1081);
            this.leftTitlePanel1.TabIndex = 1;
            // 
            // topTitle1
            // 
            this.topTitle1.Color1 = System.Drawing.Color.DarkGray;
            this.topTitle1.Color2 = System.Drawing.Color.LightGray;
            this.topTitle1.Location = new System.Drawing.Point(99, -2);
            this.topTitle1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.topTitle1.MenuFont = new System.Drawing.Font("微软雅黑", 10F);
            this.topTitle1.Name = "topTitle1";
            this.topTitle1.Size = new System.Drawing.Size(1821, 61);
            this.topTitle1.SplitRatioHeight = 0.9F;
            this.topTitle1.SplitRatioWidth = 0.7F;
            this.topTitle1.SwAngle = 40F;
            this.topTitle1.SwTitle = "先进显微镜";
            this.topTitle1.TabIndex = 0;
            this.topTitle1.TitleFont = new System.Drawing.Font("微软雅黑", 20F);
            this.topTitle1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.topTitle1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 973);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Offset_Nud);
            this.Controls.Add(this.Test_Btn);
            this.Controls.Add(this.MiddlePanle);
            this.Controls.Add(this.leftTitlePanel1);
            this.Controls.Add(this.topTitle1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Offset_Nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TopTitle topTitle1;
        private TControls.LeftTitlePanel leftTitlePanel1;
        private System.Windows.Forms.Panel MiddlePanle;
        private System.Windows.Forms.Button Test_Btn;
        private System.Windows.Forms.NumericUpDown Offset_Nud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}