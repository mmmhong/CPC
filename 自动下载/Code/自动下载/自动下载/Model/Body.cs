using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自动下载.Model
{
    public class Body
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public string Data { get; set; }
        public int Total { get; set; }
        public Int64 Servertime { get; set; }

        public override string ToString()
        {
            return $"Code:{Code}\nMsg:{Msg}\nData:{Data}\nTotal:{Total}\nServertime:{Servertime}\n";
        }
    }
}
