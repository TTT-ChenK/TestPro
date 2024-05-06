using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMicroscope
{
    public class CAnalysisPublic
    {
    }


    /// <summary>
    /// 分析数据
    /// </summary>
    public class CAnalysisData {

        public string FilePath { set; get; }="";
        List<AnalysisNodeData> NodeDatas { set; get; }
        public CAnalysisData(string _filePath  ) 
        { 
            FilePath = _filePath; 
            NodeDatas = new List<AnalysisNodeData>();
        }

    }



    /// <summary>
    /// 节点数据
    /// </summary>
    public class AnalysisNodeData
    {
        public int DataNodeLevel { set; get; } = 0;
        public int DataNodeNumber { set; get; } = 0;
        public int ParentDataNodeLevel { set; get; } = 0;
        public int ParentDataNodeNumber { set; get; } = 0;

        public List<object> Datas { set; get;}
        public AnalysisNodeData()
        {

            Datas = new List<object>();
        }
    }


    /// <summary>
    /// 分析配置
    /// </summary>
    [Serializable]
    public class AnalisisCfg
    {
        private float _xRolution = 0.025f;
        public float XRolution
        {
            set { _xRolution = value; }
            get { return _xRolution; }
        }
        private float _yRolution = 0.025f;
        public float YRolution
        {
            set { _yRolution = value; }
            get { return _yRolution; }
        }
        private float _zRolution = 0.025f;
        public float ZRolution
        {
            set { _zRolution = value; }
            get { return _zRolution; }
        }


        public AnalisisCfg()
        {
            XRolution=0.025f;
            ZRolution = 0.025f;
            YRolution = 0.025f;
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <returns></returns>
        public bool LoadAnalysisConfig()
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "analysisCfg.cfg");
            if (File.Exists(filePath))
            {
                AnalisisCfg obj = (AnalisisCfg)SerializeObject.FileToObject(filePath);
                if (obj == null) return false;
                XRolution = obj.XRolution;
                YRolution = obj.YRolution;
                ZRolution = obj.ZRolution;

                return true;
            }

            return false;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="cfgFold"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public bool SaveAnalysisConfig(AnalisisCfg cfg)
        {
            string filePath = Path.Combine(CGlobal.cfgFold, "analysisCfg.cfg");
            SerializeObject.ObjectToFile(cfg, filePath);
            return true;

        }
    }
}
