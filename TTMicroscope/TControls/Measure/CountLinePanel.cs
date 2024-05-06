using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using KChart;
using KDataGridView;

namespace TTMicroscope
{
    public partial class CountLinePanel : UserControl
    {
        public CountLinePanel()
        {
            InitializeComponent();
        }
        public KChart.KChart kChart=new KChart.KChart();
        public KDataGridView.KDataView dataView=new KDataGridView.KDataView();

        private void CountLinePanel_Load(object sender, EventArgs e)
        {
            dataView.Font = new Font("微软雅黑", 10);
            splitContainer1.Panel1.Controls.Add(kChart);
            splitContainer1.Panel2.Controls.Add(dataView);
            kChart.Dock = DockStyle.Fill;
            dataView.Dock = DockStyle.Fill;
            kChart.Resize += KChart_Resize;
          
        }

        private void KChart_Resize(object sender, EventArgs e)
        {
            CouseAdd_Btn.Location = new Point(kChart.Right - CouseAdd_Btn.Width-3, 4);
            ClearCursor_Btn.Location = new Point(CouseAdd_Btn.Left - CouseAdd_Btn.Width-1, CouseAdd_Btn.Top);
        }

        private void CountLinePanel_Resize(object sender, EventArgs e)
        {
            kChart.Location = new Point(0,0);
            kChart.Size = new Size(Width*2/3,Height);
            dataView.Location = new Point(kChart.Width, 0);
            dataView.Size=new Size(Width- kChart.Width, Height);
            
        }

        private void CouseAdd_Btn_Click(object sender, EventArgs e)
        {
            kChart.AddCursours2((kChart.cursors2.Count > 0) ? (kChart.cursors2[kChart.cursors2.Count - 1].ID + 1) : 0);
            kChart.cursors2[kChart.cursors2.Count - 1].OnSelectDataChanged += SelectDataChangedMethod;
        }
        public void SelectDataChangedMethod(int id, ref List<PointF> selectdata)
        {
            if (selectdata != null)
            {
                int index = dataView.stepData.FindIndex(s => s.ItemName == id.ToString());

                if (index == -1)
                {
                    CCalDataItem cc = new CCalDataItem() { ItemName = id.ToString(), OriginData = selectdata, IsShow = (id != 0) };
                    dataView.AddStepData(cc);
                }
                else
                {
                    CCalDataItem cc = dataView.stepData[index];
                    cc.OriginData = selectdata;
                    dataView.stepData[index] = cc;
                    dataView.UpdataStepData();
                }
            }
        }

        private void ClearCursor_Btn_Click(object sender, EventArgs e)
        {
            kChart.ClearAllCursours();
            int count = dataView.stepData.Count;
            for (int i = count-1; i>=0; i--)
            {
                try
                {
                    int m = int.Parse(dataView.stepData[i].ItemName);
                    dataView.stepData.RemoveAt(i);
                }
                catch { }
                
               
            }
            dataView.Refresh();
            //kChart.SetData(new List<PointF>());
            //kChart.Refresh();
        }
    }
}
