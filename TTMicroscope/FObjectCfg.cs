using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMicroscope
{
    public partial class FObjectCfg : Form
    {
        public FObjectCfg()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            ///121000
            ///
        }


        #region Method
        #endregion

        private void FObjectCfg_Load(object sender, EventArgs e)
        {
            CGlobal.cObjectConfig.LoadObjectConfig();
            for (int i = 0; i < CGlobal.cObjectConfig.ObjectList.Count; i++)
            {
                Obj_Dgv.Rows.Add(new object[4] {
                CGlobal.cObjectConfig.ObjectList[i].ObjectName,
            CGlobal.cObjectConfig.ObjectList[i].WorkDistance,
            CGlobal.cObjectConfig.ObjectList[i].RunStep,
            CGlobal.cObjectConfig.ObjectList[i].Others,}); }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            CSignalObjectConfig cscf = new CSignalObjectConfig();
            Obj_Dgv.Rows.Add(new object[4]{
                cscf.ObjectName,
            cscf.WorkDistance,
            cscf.RunStep,
            cscf.Others,});
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
           int index= Obj_Dgv.CurrentRow.Index;
            if (index < 0) return;
            Obj_Dgv.Rows.RemoveAt(index);
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            List<CSignalObjectConfig> cfgList = new List<CSignalObjectConfig>();
            bool isHaveNull=false;
            for (int i = 0; i < Obj_Dgv.Rows.Count; i++)
            {
                CSignalObjectConfig cscf = new CSignalObjectConfig();
                cscf.ObjectName = (string)Obj_Dgv.Rows[i].Cells[0].Value;
                cscf.WorkDistance = float.Parse(((string)Obj_Dgv.Rows[i].Cells[1].Value.ToString()));
                cscf.RunStep = float.Parse(((string)Obj_Dgv.Rows[i].Cells[2].Value.ToString()));
                cscf.Others = (string)Obj_Dgv.Rows[i].Cells[3].Value.ToString();
                cfgList.Add(cscf);
                if (cscf.ObjectName == "Null") { isHaveNull = true; }
            }
            if (!isHaveNull)
            { cfgList.Add(new CSignalObjectConfig { ObjectName = "Null", WorkDistance = -1, RunStep = -1 }); }

            CGlobal.cObjectConfig.ObjectList = cfgList;
            CGlobal.cObjectConfig.SaveObjectConfig(CGlobal.cObjectConfig);
        }
    }
}
