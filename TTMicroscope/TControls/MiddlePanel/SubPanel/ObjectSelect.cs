using NationalInstruments.Restricted;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class ObjectSelect : UserControl
    {
        public ObjectSelect()
        {
            InitializeComponent();
            sb = new SObject[5] { sObject1, sObject2, sObject3,sObject4,sObject5 };
            for (int i = 0; i < sb.Length; i++)
            { 
                sb[i].OnObjectSelect += sObject1_MouseClick;

            }
        }
        SObject[] sb = new SObject[5];
        public event ObjectSelectHandle OnObjectSelectChanged;
        private void sObject1_MouseClick(string name)
        {
            int index = int.Parse(name.Substring(name.Length - 1, 1));
            for (int i = 0; i < sb.Length; i++)
            {
                if(i==index-1) sb[i].IsSelected = true;
                else sb[i].IsSelected = false;
            }


        }


        public void SWTrig_Btn_Click(object sender, EventArgs e)
        {
            OutTrig_Btn.BackColor= Color.WhiteSmoke;
            SWTrig_Btn.BackColor= Color.LightBlue;
            SWTrig_Btn.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            OutTrig_Btn.Font = new Font("微软雅黑", 10, FontStyle.Regular);

        }

        public void OutTrig_Btn_Click(object sender, EventArgs e)
        {
            SWTrig_Btn.BackColor = Color.WhiteSmoke;
            OutTrig_Btn.BackColor = Color.LightBlue;
            OutTrig_Btn.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            SWTrig_Btn.Font = new Font("微软雅黑", 10, FontStyle.Regular);
        }

        private void ObjectSelect_Load(object sender, EventArgs e)
        {

        }

        private void ObjectSelect_Resize(object sender, EventArgs e)
        { 
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] != null)
                { sb[i].Size = new Size(52, 102); }
            }
        }

        List<double> ydata=new List<double>();
        /// <summary>
        /// 显示聚焦数据
        /// </summary>
        public void ShowFouceData(double newData)
        {
          
            this.Invoke(new MethodInvoker(delegate {
                if (chart1.Series[0].Points.Count > 200)
                {
                    //chart1.Series[0].Points.Select(x=>x.y);
                    var p = chart1.Series[0].Points;
                    
                    double max = ydata.Max();
                    double min  = ydata.Min();

                    chart1.ChartAreas[0].AxisY.Maximum = max;
                    chart1.ChartAreas[0].AxisY.Minimum = min;
                    chart1.Series[0].Points.RemoveRange(0,1);

                    Min_Lab.Text=min.ToString("F0");
                    Max_Lab.Text=max.ToString("F0");
                    if (false)
                    {
                        using (StreamWriter sw = new StreamWriter("D:\\fource.txt"))
                        {
                            for (int i = 0; i < ydata.Count; i++)
                            { sw.WriteLine(ydata[i].ToString()); }
                        }
                    }

                }
                ydata.Add(newData);
                chart1.Series[0].Points.AddY(newData); 
            }));
        }


        /// <summary>
        /// 显示物镜的名称
        /// </summary>
        public void ShowObjectName()
        {
            sb[0].Enabled = CGlobal.cObjectConfig.Pos1Object.ObjectName != "Null";
            sb[0].ObjectiveName = CGlobal.cObjectConfig.Pos1Object.ObjectName;
            sb[1].Enabled = CGlobal.cObjectConfig.Pos2Object.ObjectName != "Null";
            sb[1].ObjectiveName = CGlobal.cObjectConfig.Pos2Object.ObjectName;
            sb[2].Enabled = CGlobal.cObjectConfig.Pos3Object.ObjectName != "Null";
            sb[2].ObjectiveName = CGlobal.cObjectConfig.Pos3Object.ObjectName;
            sb[3].Enabled = CGlobal.cObjectConfig.Pos4Object.ObjectName != "Null";
            sb[3].ObjectiveName = CGlobal.cObjectConfig.Pos4Object.ObjectName;
            sb[4].Enabled = CGlobal.cObjectConfig.Pos5Object.ObjectName != "Null";
            sb[4].ObjectiveName = CGlobal.cObjectConfig.Pos5Object.ObjectName;
        }
        
    }
}
