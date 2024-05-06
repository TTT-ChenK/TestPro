namespace TTMicroscope
{
    partial class ObjectSelect
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Curve_Panel = new System.Windows.Forms.Panel();
            this.Max_Lab = new System.Windows.Forms.Label();
            this.Min_Lab = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SWTrig_Btn = new System.Windows.Forms.Button();
            this.OutTrig_Btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ExposureTime_Pro = new TTMicroscope.KProgressBarH();
            this.LightVal_Pro = new TTMicroscope.KProgressBarH();
            this.sObject5 = new TTMicroscope.SObject();
            this.sObject4 = new TTMicroscope.SObject();
            this.sObject3 = new TTMicroscope.SObject();
            this.sObject2 = new TTMicroscope.SObject();
            this.sObject1 = new TTMicroscope.SObject();
            this.Curve_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "物镜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "----------------------------------------------------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "聚焦";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "曲线";
            // 
            // Curve_Panel
            // 
            this.Curve_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Curve_Panel.Controls.Add(this.Max_Lab);
            this.Curve_Panel.Controls.Add(this.Min_Lab);
            this.Curve_Panel.Controls.Add(this.chart1);
            this.Curve_Panel.ForeColor = System.Drawing.SystemColors.Control;
            this.Curve_Panel.Location = new System.Drawing.Point(37, 126);
            this.Curve_Panel.Name = "Curve_Panel";
            this.Curve_Panel.Size = new System.Drawing.Size(292, 64);
            this.Curve_Panel.TabIndex = 3;
            // 
            // Max_Lab
            // 
            this.Max_Lab.AutoSize = true;
            this.Max_Lab.ForeColor = System.Drawing.Color.Black;
            this.Max_Lab.Location = new System.Drawing.Point(1, 14);
            this.Max_Lab.Name = "Max_Lab";
            this.Max_Lab.Size = new System.Drawing.Size(11, 12);
            this.Max_Lab.TabIndex = 3;
            this.Max_Lab.Text = "0";
            this.Max_Lab.Visible = false;
            // 
            // Min_Lab
            // 
            this.Min_Lab.AutoSize = true;
            this.Min_Lab.ForeColor = System.Drawing.Color.Black;
            this.Min_Lab.Location = new System.Drawing.Point(1, 0);
            this.Min_Lab.Name = "Min_Lab";
            this.Min_Lab.Size = new System.Drawing.Size(11, 12);
            this.Min_Lab.TabIndex = 3;
            this.Min_Lab.Text = "0";
            this.Min_Lab.Visible = false;
            // 
            // chart1
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(-2, -1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(292, 64);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(6, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "----------------------------------------------------------------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "光源";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "亮度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(0, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 30;
            this.label9.Text = "模式";
            // 
            // SWTrig_Btn
            // 
            this.SWTrig_Btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.SWTrig_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SWTrig_Btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SWTrig_Btn.Location = new System.Drawing.Point(37, 195);
            this.SWTrig_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.SWTrig_Btn.Name = "SWTrig_Btn";
            this.SWTrig_Btn.Size = new System.Drawing.Size(151, 35);
            this.SWTrig_Btn.TabIndex = 31;
            this.SWTrig_Btn.Text = "内部";
            this.SWTrig_Btn.UseVisualStyleBackColor = true;
            this.SWTrig_Btn.Click += new System.EventHandler(this.SWTrig_Btn_Click);
            // 
            // OutTrig_Btn
            // 
            this.OutTrig_Btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.OutTrig_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutTrig_Btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutTrig_Btn.Location = new System.Drawing.Point(186, 195);
            this.OutTrig_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.OutTrig_Btn.Name = "OutTrig_Btn";
            this.OutTrig_Btn.Size = new System.Drawing.Size(142, 35);
            this.OutTrig_Btn.TabIndex = 32;
            this.OutTrig_Btn.Text = "外部";
            this.OutTrig_Btn.UseVisualStyleBackColor = true;
            this.OutTrig_Btn.Click += new System.EventHandler(this.OutTrig_Btn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "曝光";
            // 
            // ExposureTime_Pro
            // 
            this.ExposureTime_Pro.CurrentValue = 500F;
            this.ExposureTime_Pro.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExposureTime_Pro.HoverColor = System.Drawing.Color.Yellow;
            this.ExposureTime_Pro.IsShowPercent = false;
            this.ExposureTime_Pro.Location = new System.Drawing.Point(36, 237);
            this.ExposureTime_Pro.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.ExposureTime_Pro.MaxValue = 10000;
            this.ExposureTime_Pro.MinStep = 1F;
            this.ExposureTime_Pro.MinValue = 0;
            this.ExposureTime_Pro.Name = "ExposureTime_Pro";
            this.ExposureTime_Pro.SelectColor = System.Drawing.Color.Silver;
            this.ExposureTime_Pro.Size = new System.Drawing.Size(293, 37);
            this.ExposureTime_Pro.TabIndex = 27;
            this.ExposureTime_Pro.UnSelectColor = System.Drawing.Color.WhiteSmoke;
            // 
            // LightVal_Pro
            // 
            this.LightVal_Pro.CurrentValue = 0F;
            this.LightVal_Pro.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LightVal_Pro.HoverColor = System.Drawing.Color.Yellow;
            this.LightVal_Pro.IsShowPercent = true;
            this.LightVal_Pro.Location = new System.Drawing.Point(37, 287);
            this.LightVal_Pro.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.LightVal_Pro.MaxValue = 100;
            this.LightVal_Pro.MinStep = 1F;
            this.LightVal_Pro.MinValue = 0;
            this.LightVal_Pro.Name = "LightVal_Pro";
            this.LightVal_Pro.SelectColor = System.Drawing.Color.Silver;
            this.LightVal_Pro.Size = new System.Drawing.Size(291, 37);
            this.LightVal_Pro.TabIndex = 27;
            this.LightVal_Pro.UnSelectColor = System.Drawing.Color.WhiteSmoke;
            // 
            // sObject5
            // 
            this.sObject5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sObject5.IsSelected = false;
            this.sObject5.Location = new System.Drawing.Point(277, 4);
            this.sObject5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sObject5.Name = "sObject5";
            this.sObject5.ObjectiveName = "100X";
            this.sObject5.Positon = "位置5";
            this.sObject5.Size = new System.Drawing.Size(52, 102);
            this.sObject5.TabIndex = 0;
            this.sObject5.Tag = "5";
            // 
            // sObject4
            // 
            this.sObject4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sObject4.IsSelected = false;
            this.sObject4.Location = new System.Drawing.Point(217, 4);
            this.sObject4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sObject4.Name = "sObject4";
            this.sObject4.ObjectiveName = "50X";
            this.sObject4.Positon = "位置4";
            this.sObject4.Size = new System.Drawing.Size(52, 102);
            this.sObject4.TabIndex = 0;
            this.sObject4.Tag = "4";
            // 
            // sObject3
            // 
            this.sObject3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sObject3.IsSelected = false;
            this.sObject3.Location = new System.Drawing.Point(157, 4);
            this.sObject3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sObject3.Name = "sObject3";
            this.sObject3.ObjectiveName = "20X";
            this.sObject3.Positon = "位置3";
            this.sObject3.Size = new System.Drawing.Size(52, 102);
            this.sObject3.TabIndex = 0;
            this.sObject3.Tag = "3";
            // 
            // sObject2
            // 
            this.sObject2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sObject2.IsSelected = true;
            this.sObject2.Location = new System.Drawing.Point(97, 4);
            this.sObject2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sObject2.Name = "sObject2";
            this.sObject2.ObjectiveName = "10X";
            this.sObject2.Positon = "位置2";
            this.sObject2.Size = new System.Drawing.Size(52, 102);
            this.sObject2.TabIndex = 0;
            this.sObject2.Tag = "2";
            // 
            // sObject1
            // 
            this.sObject1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sObject1.IsSelected = false;
            this.sObject1.Location = new System.Drawing.Point(37, 4);
            this.sObject1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sObject1.Name = "sObject1";
            this.sObject1.ObjectiveName = "5X";
            this.sObject1.Positon = "位置1";
            this.sObject1.Size = new System.Drawing.Size(52, 102);
            this.sObject1.TabIndex = 0;
            this.sObject1.Tag = "1";
            // 
            // ObjectSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OutTrig_Btn);
            this.Controls.Add(this.SWTrig_Btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ExposureTime_Pro);
            this.Controls.Add(this.LightVal_Pro);
            this.Controls.Add(this.Curve_Panel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sObject5);
            this.Controls.Add(this.sObject4);
            this.Controls.Add(this.sObject3);
            this.Controls.Add(this.sObject2);
            this.Controls.Add(this.sObject1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Name = "ObjectSelect";
            this.Size = new System.Drawing.Size(340, 332);
            this.Load += new System.EventHandler(this.ObjectSelect_Load);
            this.Resize += new System.EventHandler(this.ObjectSelect_Resize);
            this.Curve_Panel.ResumeLayout(false);
            this.Curve_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Curve_Panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button SWTrig_Btn;
        public System.Windows.Forms.Button OutTrig_Btn;
        private System.Windows.Forms.Label label7;
        public KProgressBarH ExposureTime_Pro;
        public KProgressBarH LightVal_Pro;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label Max_Lab;
        private System.Windows.Forms.Label Min_Lab;
        public SObject sObject1;
        public SObject sObject2;
        public SObject sObject3;
        public SObject sObject4;
        public SObject sObject5;
    }
}
