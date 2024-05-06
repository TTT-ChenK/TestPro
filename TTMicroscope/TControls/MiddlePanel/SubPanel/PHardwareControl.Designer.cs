namespace TTMicroscope
{
    partial class PHardwareControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Parameter_Cbx = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Method3_Btn = new System.Windows.Forms.Button();
            this.Method2_Btn = new System.Windows.Forms.Button();
            this.Method1_Btn = new System.Windows.Forms.Button();
            this.AbsMove_Btn = new System.Windows.Forms.Button();
            this.Home_Btn = new System.Windows.Forms.Button();
            this.Enable_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AxisIndex_Cbx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DisEnable_Btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Start_Btn = new System.Windows.Forms.Button();
            this.Interver_Btn = new System.Windows.Forms.Button();
            this.End_Btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Start_Nud = new System.Windows.Forms.NumericUpDown();
            this.Intever_Nud = new System.Windows.Forms.NumericUpDown();
            this.End_Nud = new System.Windows.Forms.NumericUpDown();
            this.Vel_Nud = new System.Windows.Forms.NumericUpDown();
            this.PEG_Btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Pos_Tbx = new System.Windows.Forms.NumericUpDown();
            this.Dis_Tbx = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.EndMove_Btn = new System.Windows.Forms.Button();
            this.StartMove_Btn = new System.Windows.Forms.Button();
            this.IncMoveN_Btn = new System.Windows.Forms.Button();
            this.IncMoveP_Btn = new System.Windows.Forms.Button();
            this.objectSelect1 = new TTMicroscope.ObjectSelect();
            this.tMotorManual1 = new TTMicroscope.TMotorManual();
            this.tDataTable1 = new TTMicroscope.TDataTable();
            this.tGroupBox3 = new TTMicroscope.TGroupBox();
            this.tGroupBox2 = new TTMicroscope.TGroupBox();
            this.tGroupBox1 = new TTMicroscope.TGroupBox();
            this.ImageCount_Lab = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Start_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intever_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vel_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pos_Tbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dis_Tbx)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(62, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "方法";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "参数";
            // 
            // Parameter_Cbx
            // 
            this.Parameter_Cbx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Parameter_Cbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Parameter_Cbx.FormattingEnabled = true;
            this.Parameter_Cbx.Items.AddRange(new object[] {
            "参数一",
            "参数二",
            "参数三"});
            this.Parameter_Cbx.Location = new System.Drawing.Point(101, 42);
            this.Parameter_Cbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Parameter_Cbx.Name = "Parameter_Cbx";
            this.Parameter_Cbx.Size = new System.Drawing.Size(142, 28);
            this.Parameter_Cbx.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Method3_Btn);
            this.panel1.Controls.Add(this.Method2_Btn);
            this.panel1.Controls.Add(this.Method1_Btn);
            this.panel1.Location = new System.Drawing.Point(101, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 110);
            this.panel1.TabIndex = 7;
            // 
            // Method3_Btn
            // 
            this.Method3_Btn.BackColor = System.Drawing.Color.LightBlue;
            this.Method3_Btn.Enabled = false;
            this.Method3_Btn.FlatAppearance.BorderSize = 0;
            this.Method3_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Method3_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Method3_Btn.Location = new System.Drawing.Point(2, 74);
            this.Method3_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Method3_Btn.Name = "Method3_Btn";
            this.Method3_Btn.Size = new System.Drawing.Size(139, 34);
            this.Method3_Btn.TabIndex = 0;
            this.Method3_Btn.Text = "白光干涉";
            this.Method3_Btn.UseVisualStyleBackColor = false;
            this.Method3_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Method1_Btn_MouseClick);
            // 
            // Method2_Btn
            // 
            this.Method2_Btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Method2_Btn.Enabled = false;
            this.Method2_Btn.FlatAppearance.BorderSize = 0;
            this.Method2_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Method2_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Method2_Btn.Location = new System.Drawing.Point(2, 38);
            this.Method2_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Method2_Btn.Name = "Method2_Btn";
            this.Method2_Btn.Size = new System.Drawing.Size(139, 34);
            this.Method2_Btn.TabIndex = 0;
            this.Method2_Btn.Text = "光谱共焦";
            this.Method2_Btn.UseVisualStyleBackColor = false;
            this.Method2_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Method1_Btn_MouseClick);
            // 
            // Method1_Btn
            // 
            this.Method1_Btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Method1_Btn.Enabled = false;
            this.Method1_Btn.FlatAppearance.BorderSize = 0;
            this.Method1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Method1_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Method1_Btn.Location = new System.Drawing.Point(2, 2);
            this.Method1_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Method1_Btn.Name = "Method1_Btn";
            this.Method1_Btn.Size = new System.Drawing.Size(139, 32);
            this.Method1_Btn.TabIndex = 0;
            this.Method1_Btn.Text = "超景深";
            this.Method1_Btn.UseVisualStyleBackColor = false;
            this.Method1_Btn.Click += new System.EventHandler(this.Method1_Btn_Click);
            this.Method1_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Method1_Btn_MouseClick);
            // 
            // AbsMove_Btn
            // 
            this.AbsMove_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AbsMove_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbsMove_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AbsMove_Btn.Location = new System.Drawing.Point(121, 146);
            this.AbsMove_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AbsMove_Btn.Name = "AbsMove_Btn";
            this.AbsMove_Btn.Size = new System.Drawing.Size(67, 30);
            this.AbsMove_Btn.TabIndex = 18;
            this.AbsMove_Btn.Text = "Abs";
            this.AbsMove_Btn.UseVisualStyleBackColor = true;
            this.AbsMove_Btn.Click += new System.EventHandler(this.Move_Btn_Click);
            // 
            // Home_Btn
            // 
            this.Home_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Home_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Home_Btn.Location = new System.Drawing.Point(121, 66);
            this.Home_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Btn.Name = "Home_Btn";
            this.Home_Btn.Size = new System.Drawing.Size(68, 30);
            this.Home_Btn.TabIndex = 19;
            this.Home_Btn.Text = "回零";
            this.Home_Btn.UseVisualStyleBackColor = true;
            this.Home_Btn.Click += new System.EventHandler(this.Home_Btn_Click);
            // 
            // Enable_Btn
            // 
            this.Enable_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Enable_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enable_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Enable_Btn.Location = new System.Drawing.Point(47, 106);
            this.Enable_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Enable_Btn.Name = "Enable_Btn";
            this.Enable_Btn.Size = new System.Drawing.Size(68, 30);
            this.Enable_Btn.TabIndex = 20;
            this.Enable_Btn.Text = "使能";
            this.Enable_Btn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "轴号";
            // 
            // AxisIndex_Cbx
            // 
            this.AxisIndex_Cbx.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisIndex_Cbx.FormattingEnabled = true;
            this.AxisIndex_Cbx.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z",
            "R"});
            this.AxisIndex_Cbx.Location = new System.Drawing.Point(47, 67);
            this.AxisIndex_Cbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AxisIndex_Cbx.Name = "AxisIndex_Cbx";
            this.AxisIndex_Cbx.Size = new System.Drawing.Size(68, 28);
            this.AxisIndex_Cbx.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(14, 1072);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "----------------------------------------------------------------";
            this.label5.Visible = false;
            // 
            // DisEnable_Btn
            // 
            this.DisEnable_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DisEnable_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisEnable_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DisEnable_Btn.Location = new System.Drawing.Point(121, 105);
            this.DisEnable_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisEnable_Btn.Name = "DisEnable_Btn";
            this.DisEnable_Btn.Size = new System.Drawing.Size(68, 30);
            this.DisEnable_Btn.TabIndex = 20;
            this.DisEnable_Btn.Text = "失能";
            this.DisEnable_Btn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(236, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "S";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(238, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "I";
            // 
            // Start_Btn
            // 
            this.Start_Btn.FlatAppearance.BorderSize = 0;
            this.Start_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start_Btn.Location = new System.Drawing.Point(197, 68);
            this.Start_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(49, 26);
            this.Start_Btn.TabIndex = 26;
            this.Start_Btn.Text = "起始";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // Interver_Btn
            // 
            this.Interver_Btn.Enabled = false;
            this.Interver_Btn.FlatAppearance.BorderSize = 0;
            this.Interver_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Interver_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Interver_Btn.Location = new System.Drawing.Point(196, 150);
            this.Interver_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Interver_Btn.Name = "Interver_Btn";
            this.Interver_Btn.Size = new System.Drawing.Size(49, 26);
            this.Interver_Btn.TabIndex = 28;
            this.Interver_Btn.Text = "间隔";
            this.Interver_Btn.UseVisualStyleBackColor = true;
            // 
            // End_Btn
            // 
            this.End_Btn.FlatAppearance.BorderSize = 0;
            this.End_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.End_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.End_Btn.Location = new System.Drawing.Point(197, 109);
            this.End_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.End_Btn.Name = "End_Btn";
            this.End_Btn.Size = new System.Drawing.Size(49, 26);
            this.End_Btn.TabIndex = 26;
            this.End_Btn.Text = "终点";
            this.End_Btn.UseVisualStyleBackColor = true;
            this.End_Btn.Click += new System.EventHandler(this.End_Btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(7, 912);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "Jog运动";
            this.label10.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(194, 188);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 26);
            this.button1.TabIndex = 26;
            this.button1.Text = "Vel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.End_Btn_Click);
            // 
            // Start_Nud
            // 
            this.Start_Nud.DecimalPlaces = 3;
            this.Start_Nud.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start_Nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Start_Nud.Location = new System.Drawing.Point(240, 68);
            this.Start_Nud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Start_Nud.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.Start_Nud.Name = "Start_Nud";
            this.Start_Nud.Size = new System.Drawing.Size(77, 29);
            this.Start_Nud.TabIndex = 29;
            this.Start_Nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Intever_Nud
            // 
            this.Intever_Nud.DecimalPlaces = 3;
            this.Intever_Nud.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Intever_Nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Intever_Nud.Location = new System.Drawing.Point(240, 150);
            this.Intever_Nud.Name = "Intever_Nud";
            this.Intever_Nud.Size = new System.Drawing.Size(77, 29);
            this.Intever_Nud.TabIndex = 29;
            this.Intever_Nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Intever_Nud.Value = new decimal(new int[] {
            72,
            0,
            0,
            196608});
            this.Intever_Nud.ValueChanged += new System.EventHandler(this.Intever_Nud_ValueChanged);
            // 
            // End_Nud
            // 
            this.End_Nud.DecimalPlaces = 3;
            this.End_Nud.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.End_Nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.End_Nud.Location = new System.Drawing.Point(240, 109);
            this.End_Nud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.End_Nud.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.End_Nud.Name = "End_Nud";
            this.End_Nud.Size = new System.Drawing.Size(77, 29);
            this.End_Nud.TabIndex = 29;
            this.End_Nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Vel_Nud
            // 
            this.Vel_Nud.DecimalPlaces = 3;
            this.Vel_Nud.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vel_Nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Vel_Nud.Location = new System.Drawing.Point(241, 189);
            this.Vel_Nud.Name = "Vel_Nud";
            this.Vel_Nud.Size = new System.Drawing.Size(77, 29);
            this.Vel_Nud.TabIndex = 29;
            this.Vel_Nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Vel_Nud.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Vel_Nud.ValueChanged += new System.EventHandler(this.Vel_Nud_ValueChanged);
            // 
            // PEG_Btn
            // 
            this.PEG_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.PEG_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PEG_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PEG_Btn.Location = new System.Drawing.Point(320, 150);
            this.PEG_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PEG_Btn.Name = "PEG_Btn";
            this.PEG_Btn.Size = new System.Drawing.Size(30, 70);
            this.PEG_Btn.TabIndex = 20;
            this.PEG_Btn.Text = "设定";
            this.PEG_Btn.UseVisualStyleBackColor = true;
            this.PEG_Btn.Click += new System.EventHandler(this.PEG_Btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "步长";
            // 
            // Pos_Tbx
            // 
            this.Pos_Tbx.DecimalPlaces = 3;
            this.Pos_Tbx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pos_Tbx.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Pos_Tbx.Location = new System.Drawing.Point(47, 146);
            this.Pos_Tbx.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Pos_Tbx.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.Pos_Tbx.Name = "Pos_Tbx";
            this.Pos_Tbx.Size = new System.Drawing.Size(68, 29);
            this.Pos_Tbx.TabIndex = 29;
            this.Pos_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Dis_Tbx
            // 
            this.Dis_Tbx.DecimalPlaces = 1;
            this.Dis_Tbx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dis_Tbx.Location = new System.Drawing.Point(47, 189);
            this.Dis_Tbx.Name = "Dis_Tbx";
            this.Dis_Tbx.Size = new System.Drawing.Size(68, 29);
            this.Dis_Tbx.TabIndex = 29;
            this.Dis_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dis_Tbx.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(293, -17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "单位: μm";
            // 
            // EndMove_Btn
            // 
            this.EndMove_Btn.BackgroundImage = global::TTMicroscope.Properties.Resources.Move;
            this.EndMove_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EndMove_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.EndMove_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndMove_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndMove_Btn.Location = new System.Drawing.Point(321, 109);
            this.EndMove_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EndMove_Btn.Name = "EndMove_Btn";
            this.EndMove_Btn.Size = new System.Drawing.Size(30, 29);
            this.EndMove_Btn.TabIndex = 18;
            this.EndMove_Btn.UseVisualStyleBackColor = true;
            this.EndMove_Btn.Click += new System.EventHandler(this.Move_Btn_Click);
            // 
            // StartMove_Btn
            // 
            this.StartMove_Btn.BackgroundImage = global::TTMicroscope.Properties.Resources.Move;
            this.StartMove_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartMove_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.StartMove_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartMove_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartMove_Btn.Location = new System.Drawing.Point(320, 69);
            this.StartMove_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartMove_Btn.Name = "StartMove_Btn";
            this.StartMove_Btn.Size = new System.Drawing.Size(31, 28);
            this.StartMove_Btn.TabIndex = 18;
            this.StartMove_Btn.UseVisualStyleBackColor = true;
            this.StartMove_Btn.Click += new System.EventHandler(this.Move_Btn_Click);
            // 
            // IncMoveN_Btn
            // 
            this.IncMoveN_Btn.BackgroundImage = global::TTMicroscope.Properties.Resources.MoveDown;
            this.IncMoveN_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IncMoveN_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.IncMoveN_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IncMoveN_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IncMoveN_Btn.Location = new System.Drawing.Point(160, 189);
            this.IncMoveN_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IncMoveN_Btn.Name = "IncMoveN_Btn";
            this.IncMoveN_Btn.Size = new System.Drawing.Size(28, 30);
            this.IncMoveN_Btn.TabIndex = 18;
            this.IncMoveN_Btn.UseVisualStyleBackColor = true;
            this.IncMoveN_Btn.Click += new System.EventHandler(this.Move_Btn_Click);
            // 
            // IncMoveP_Btn
            // 
            this.IncMoveP_Btn.BackgroundImage = global::TTMicroscope.Properties.Resources.MoveUP;
            this.IncMoveP_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IncMoveP_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.IncMoveP_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IncMoveP_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IncMoveP_Btn.Location = new System.Drawing.Point(121, 189);
            this.IncMoveP_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IncMoveP_Btn.Name = "IncMoveP_Btn";
            this.IncMoveP_Btn.Size = new System.Drawing.Size(28, 30);
            this.IncMoveP_Btn.TabIndex = 18;
            this.IncMoveP_Btn.UseVisualStyleBackColor = true;
            this.IncMoveP_Btn.Click += new System.EventHandler(this.Move_Btn_Click);
            // 
            // objectSelect1
            // 
            this.objectSelect1.Location = new System.Drawing.Point(3, 229);
            this.objectSelect1.Name = "objectSelect1";
            this.objectSelect1.Size = new System.Drawing.Size(346, 330);
            this.objectSelect1.TabIndex = 24;
            // 
            // tMotorManual1
            // 
            this.tMotorManual1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tMotorManual1.DownColor = System.Drawing.Color.Gray;
            this.tMotorManual1.HolverColor = System.Drawing.Color.LightGray;
            this.tMotorManual1.Location = new System.Drawing.Point(66, 967);
            this.tMotorManual1.Margin = new System.Windows.Forms.Padding(4);
            this.tMotorManual1.Name = "tMotorManual1";
            this.tMotorManual1.RingColor = System.Drawing.Color.DarkGray;
            this.tMotorManual1.RingWidth = 20;
            this.tMotorManual1.Size = new System.Drawing.Size(257, 227);
            this.tMotorManual1.TabIndex = 10;
            this.tMotorManual1.UPColor = System.Drawing.Color.Gray;
            // 
            // tDataTable1
            // 
            this.tDataTable1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tDataTable1.Location = new System.Drawing.Point(4, 6);
            this.tDataTable1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tDataTable1.Name = "tDataTable1";
            this.tDataTable1.Size = new System.Drawing.Size(351, 50);
            this.tDataTable1.TabIndex = 9;
            this.tDataTable1.titleColor = System.Drawing.Color.Gainsboro;
            this.tDataTable1.TitleName = new string[] {
        "X",
        "Y",
        "Z",
        "角度",
        "压电"};
            this.tDataTable1.ValueArr = new string[] {
        "1.0",
        "2.0",
        "3.0",
        "4.0",
        "3.6"};
            // 
            // tGroupBox3
            // 
            this.tGroupBox3.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox3.BouderRatius = 4F;
            this.tGroupBox3.BouderWidth = 1F;
            this.tGroupBox3.Location = new System.Drawing.Point(1, 0);
            this.tGroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox3.MTitle = "测试方法&参数";
            this.tGroupBox3.MTitleIsLeft = false;
            this.tGroupBox3.Name = "tGroupBox3";
            this.tGroupBox3.Size = new System.Drawing.Size(352, 195);
            this.tGroupBox3.TabIndex = 2;
            this.tGroupBox3.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox3.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox3.TitleForeColor = System.Drawing.Color.Black;
            // 
            // tGroupBox2
            // 
            this.tGroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox2.BouderRatius = 5F;
            this.tGroupBox2.BouderWidth = 1F;
            this.tGroupBox2.Location = new System.Drawing.Point(4, 891);
            this.tGroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox2.MTitle = "运动控制";
            this.tGroupBox2.MTitleIsLeft = false;
            this.tGroupBox2.Name = "tGroupBox2";
            this.tGroupBox2.Size = new System.Drawing.Size(352, 488);
            this.tGroupBox2.TabIndex = 0;
            this.tGroupBox2.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox2.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox2.TitleForeColor = System.Drawing.Color.Black;
            // 
            // tGroupBox1
            // 
            this.tGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.tGroupBox1.BouderRatius = 4F;
            this.tGroupBox1.BouderWidth = 1F;
            this.tGroupBox1.Location = new System.Drawing.Point(0, 197);
            this.tGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.tGroupBox1.MTitle = "物镜&相机&光源";
            this.tGroupBox1.MTitleIsLeft = false;
            this.tGroupBox1.Name = "tGroupBox1";
            this.tGroupBox1.Size = new System.Drawing.Size(352, 365);
            this.tGroupBox1.TabIndex = 0;
            this.tGroupBox1.TitleBacColor = System.Drawing.Color.LightGray;
            this.tGroupBox1.TitleFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tGroupBox1.TitleForeColor = System.Drawing.Color.Black;
            // 
            // ImageCount_Lab
            // 
            this.ImageCount_Lab.AutoSize = true;
            this.ImageCount_Lab.BackColor = System.Drawing.Color.Transparent;
            this.ImageCount_Lab.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageCount_Lab.Location = new System.Drawing.Point(323, 10);
            this.ImageCount_Lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImageCount_Lab.Name = "ImageCount_Lab";
            this.ImageCount_Lab.Size = new System.Drawing.Size(26, 20);
            this.ImageCount_Lab.TabIndex = 30;
            this.ImageCount_Lab.Text = "->";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(266, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 23);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tDataTable1);
            this.panel3.Controls.Add(this.AxisIndex_Cbx);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Vel_Nud);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.End_Nud);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.Intever_Nud);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.Dis_Tbx);
            this.panel3.Controls.Add(this.Enable_Btn);
            this.panel3.Controls.Add(this.Pos_Tbx);
            this.panel3.Controls.Add(this.DisEnable_Btn);
            this.panel3.Controls.Add(this.Start_Nud);
            this.panel3.Controls.Add(this.Home_Btn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.AbsMove_Btn);
            this.panel3.Controls.Add(this.End_Btn);
            this.panel3.Controls.Add(this.IncMoveP_Btn);
            this.panel3.Controls.Add(this.Interver_Btn);
            this.panel3.Controls.Add(this.IncMoveN_Btn);
            this.panel3.Controls.Add(this.Start_Btn);
            this.panel3.Controls.Add(this.StartMove_Btn);
            this.panel3.Controls.Add(this.EndMove_Btn);
            this.panel3.Controls.Add(this.PEG_Btn);
            this.panel3.Location = new System.Drawing.Point(-1, 565);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 228);
            this.panel3.TabIndex = 32;
            // 
            // PHardwareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ImageCount_Lab);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.objectSelect1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tMotorManual1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Parameter_Cbx);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tGroupBox3);
            this.Controls.Add(this.tGroupBox2);
            this.Controls.Add(this.tGroupBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PHardwareControl";
            this.Size = new System.Drawing.Size(363, 1116);
            this.Load += new System.EventHandler(this.PHardwareControl_Load);
            this.Resize += new System.EventHandler(this.PHardwareControl_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Start_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intever_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vel_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pos_Tbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dis_Tbx)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TGroupBox tGroupBox1;
        private TGroupBox tGroupBox2;
        private TGroupBox tGroupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Parameter_Cbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Method3_Btn;
        private System.Windows.Forms.Button Method2_Btn;
        private System.Windows.Forms.Button Method1_Btn;
        private TDataTable tDataTable1;
        private TMotorManual tMotorManual1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button AbsMove_Btn;
        public System.Windows.Forms.Button Home_Btn;
        public System.Windows.Forms.Button Enable_Btn;
        public System.Windows.Forms.ComboBox AxisIndex_Cbx;
        public System.Windows.Forms.Button DisEnable_Btn;
        public System.Windows.Forms.Button IncMoveP_Btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Start_Btn;
        private System.Windows.Forms.Button Interver_Btn;
        private System.Windows.Forms.Button End_Btn;
        private System.Windows.Forms.Label label10;
        public ObjectSelect objectSelect1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.NumericUpDown Start_Nud;
        public System.Windows.Forms.NumericUpDown Intever_Nud;
        public System.Windows.Forms.NumericUpDown End_Nud;
        public System.Windows.Forms.NumericUpDown Vel_Nud;
        public System.Windows.Forms.Button PEG_Btn;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown Pos_Tbx;
        public System.Windows.Forms.NumericUpDown Dis_Tbx;
        public System.Windows.Forms.Button StartMove_Btn;
        public System.Windows.Forms.Button EndMove_Btn;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button IncMoveN_Btn;
        private System.Windows.Forms.Label ImageCount_Lab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
