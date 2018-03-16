using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDownload.Model
{
    /// <summary>
    /// 急诊档案中的患者列表
    /// </summary>
    public class Data
    {
        public List<Patient> List { get; set; }//患者列表
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
