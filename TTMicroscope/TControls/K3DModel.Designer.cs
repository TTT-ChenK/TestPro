namespace TTMicroscope.TControls
{
    partial class K3DModel
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
            this.renderWindowControl1 = new Kitware.VTK.RenderWindowControl();
            this.ThreeD_StepsH_Btn = new System.Windows.Forms.Button();
            this.ClearActor_Btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Pre_MakeLevel_Btn = new System.Windows.Forms.Button();
            this.FileLoad_Btn = new System.Windows.Forms.Button();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.analysisPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.Step_Lab = new System.Windows.Forms.Label();
            this.ThreeD_Roughness_Btn = new System.Windows.Forms.Button();
            this.DataPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderWindowControl1
            // 
            this.renderWindowControl1.AddTestActors = false;
            this.renderWindowControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.renderWindowControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderWindowControl1.Font = new System.Drawing.Font("宋体", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.renderWindowControl1.Location = new System.Drawing.Point(27, 62);
            this.renderWindowControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renderWindowControl1.Name = "renderWindowControl1";
            this.renderWindowControl1.Size = new System.Drawing.Size(401, 213);
            this.renderWindowControl1.TabIndex = 2;
            this.renderWindowControl1.TestText = null;
            // 
            // ThreeD_StepsH_Btn
            // 
            this.ThreeD_StepsH_Btn.FlatAppearance.BorderSize = 0;
            this.ThreeD_StepsH_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeD_StepsH_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ThreeD_StepsH_Btn.Image = global::TTMicroscope.Properties.Resources.台阶高度01;
            this.ThreeD_StepsH_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThreeD_StepsH_Btn.Location = new System.Drawing.Point(2, 89);
            this.ThreeD_StepsH_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ThreeD_StepsH_Btn.Name = "ThreeD_StepsH_Btn";
            this.ThreeD_StepsH_Btn.Size = new System.Drawing.Size(105, 38);
            this.ThreeD_StepsH_Btn.TabIndex = 10;
            this.ThreeD_StepsH_Btn.Tag = "";
            this.ThreeD_StepsH_Btn.Text = "台阶";
            this.ThreeD_StepsH_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ThreeD_StepsH_Btn.UseVisualStyleBackColor = true;
            this.ThreeD_StepsH_Btn.Click += new System.EventHandler(this.ThreeD_StepsH_Btn_Click);
            // 
            // ClearActor_Btn
            // 
            this.ClearActor_Btn.FlatAppearance.BorderSize = 0;
            this.ClearActor_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearActor_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearActor_Btn.Location = new System.Drawing.Point(2, 191);
            this.ClearActor_Btn.Name = "ClearActor_Btn";
            this.ClearActor_Btn.Size = new System.Drawing.Size(105, 38);
            this.ClearActor_Btn.TabIndex = 9;
            this.ClearActor_Btn.Text = "清除";
            this.ClearActor_Btn.UseVisualStyleBackColor = true;
            this.ClearActor_Btn.Click += new System.EventHandler(this.ClearActor_Btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(2, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "复位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pre_MakeLevel_Btn
            // 
            this.Pre_MakeLevel_Btn.FlatAppearance.BorderSize = 0;
            this.Pre_MakeLevel_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pre_MakeLevel_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pre_MakeLevel_Btn.Image = global::TTMicroscope.Properties.Resources.校平02;
            this.Pre_MakeLevel_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pre_MakeLevel_Btn.Location = new System.Drawing.Point(2, 46);
            this.Pre_MakeLevel_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Pre_MakeLevel_Btn.Name = "Pre_MakeLevel_Btn";
            this.Pre_MakeLevel_Btn.Size = new System.Drawing.Size(105, 38);
            this.Pre_MakeLevel_Btn.TabIndex = 6;
            this.Pre_MakeLevel_Btn.Tag = "校平";
            this.Pre_MakeLevel_Btn.Text = "校平";
            this.Pre_MakeLevel_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Pre_MakeLevel_Btn.UseVisualStyleBackColor = true;
            this.Pre_MakeLevel_Btn.Click += new System.EventHandler(this.Pre_MakeLevel_Btn_Click);
            // 
            // FileLoad_Btn
            // 
            this.FileLoad_Btn.FlatAppearance.BorderSize = 0;
            this.FileLoad_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileLoad_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileLoad_Btn.Image = global::TTMicroscope.Properties.Resources.输出文档01;
            this.FileLoad_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileLoad_Btn.Location = new System.Drawing.Point(2, 3);
            this.FileLoad_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.FileLoad_Btn.Name = "FileLoad_Btn";
            this.FileLoad_Btn.Size = new System.Drawing.Size(105, 38);
            this.FileLoad_Btn.TabIndex = 5;
            this.FileLoad_Btn.Text = "数据";
            this.FileLoad_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileLoad_Btn.UseVisualStyleBackColor = true;
            this.FileLoad_Btn.Click += new System.EventHandler(this.FileLoad_Btn_Click_1);
            // 
            // DataPanel
            // 
            this.DataPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.DataPanel.Controls.Add(this.analysisPanel);
            this.DataPanel.Controls.Add(this.ButtonPanel);
            this.DataPanel.Location = new System.Drawing.Point(3, 297);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(481, 303);
            this.DataPanel.TabIndex = 4;
            // 
            // analysisPanel
            // 
            this.analysisPanel.BackColor = System.Drawing.Color.White;
            this.analysisPanel.Location = new System.Drawing.Point(116, 4);
            this.analysisPanel.Name = "analysisPanel";
            this.analysisPanel.Size = new System.Drawing.Size(343, 244);
            this.analysisPanel.TabIndex = 12;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonPanel.Controls.Add(this.Step_Lab);
            this.ButtonPanel.Controls.Add(this.button2);
            this.ButtonPanel.Controls.Add(this.ThreeD_Roughness_Btn);
            this.ButtonPanel.Controls.Add(this.ClearActor_Btn);
            this.ButtonPanel.Controls.Add(this.button1);
            this.ButtonPanel.Controls.Add(this.FileLoad_Btn);
            this.ButtonPanel.Controls.Add(this.ThreeD_StepsH_Btn);
            this.ButtonPanel.Controls.Add(this.Pre_MakeLevel_Btn);
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(109, 303);
            this.ButtonPanel.TabIndex = 11;
            // 
            // Step_Lab
            // 
            this.Step_Lab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Step_Lab.AutoSize = true;
            this.Step_Lab.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Step_Lab.Location = new System.Drawing.Point(3, 280);
            this.Step_Lab.Name = "Step_Lab";
            this.Step_Lab.Size = new System.Drawing.Size(40, 20);
            this.Step_Lab.TabIndex = 13;
            this.Step_Lab.Text = "步骤:";
            // 
            // ThreeD_Roughness_Btn
            // 
            this.ThreeD_Roughness_Btn.FlatAppearance.BorderSize = 0;
            this.ThreeD_Roughness_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeD_Roughness_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ThreeD_Roughness_Btn.Image = global::TTMicroscope.Properties.Resources.粗糙度01;
            this.ThreeD_Roughness_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThreeD_Roughness_Btn.Location = new System.Drawing.Point(2, 132);
            this.ThreeD_Roughness_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.ThreeD_Roughness_Btn.Name = "ThreeD_Roughness_Btn";
            this.ThreeD_Roughness_Btn.Size = new System.Drawing.Size(105, 38);
            this.ThreeD_Roughness_Btn.TabIndex = 12;
            this.ThreeD_Roughness_Btn.Tag = "";
            this.ThreeD_Roughness_Btn.Text = "粗糙度";
            this.ThreeD_Roughness_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ThreeD_Roughness_Btn.UseVisualStyleBackColor = true;
            this.ThreeD_Roughness_Btn.Click += new System.EventHandler(this.ThreeD_Roughness_Btn_Click);
            // 
            // K3DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.renderWindowControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "K3DModel";
            this.Size = new System.Drawing.Size(487, 640);
            this.Load += new System.EventHandler(this.K3DModel_Load);
            this.Resize += new System.EventHandler(this.K3DModel_Resize);
            this.DataPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Kitware.VTK.RenderWindowControl renderWindowControl1;
        private System.Windows.Forms.Button FileLoad_Btn;
        public System.Windows.Forms.Button Pre_MakeLevel_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ClearActor_Btn;
        public System.Windows.Forms.Button ThreeD_StepsH_Btn;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        public System.Windows.Forms.Button ThreeD_Roughness_Btn;
        private System.Windows.Forms.Panel analysisPanel;
        private System.Windows.Forms.Label Step_Lab;
    }
}
