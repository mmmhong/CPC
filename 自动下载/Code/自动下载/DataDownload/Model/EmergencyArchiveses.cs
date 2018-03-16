using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDownload.Model
{
    /// <summary>
    /// 急诊档案
    /// </summary>
    public class EmergencyArchiveses
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public Data Data { get; set; }//存储所有患者数据
        public int Total { get; set; }
        public Int64 Servertime { get; set; }
    }
}
