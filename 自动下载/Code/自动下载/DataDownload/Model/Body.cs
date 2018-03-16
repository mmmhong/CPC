using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDownload.Model
{
    /// <summary>
    /// 登录后返回的数据
    /// </summary>
    public class Body
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public string Data { get; set; }//token值
        public int Total { get; set; }
        public Int64 Servertime { get; set; }

        public override string ToString()
        {
            return $"Code:{Code}\nMsg:{Msg}\nData:{Data}\nTotal:{Total}\nServertime:{Servertime}\n";
        }
    }
}
