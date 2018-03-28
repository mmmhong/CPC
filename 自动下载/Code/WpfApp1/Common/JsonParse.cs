using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure
{
    public class JsonParse
    {
        public List<string> PatientListParse(string patientString)
        {
            List<string> list = new List<string>();
            List<string> IDList = new List<string>();

            JObject obj = JObject.Parse(patientString);//先将字符串转为JObject格式
            foreach (var x in obj)//遍历JObject,获取他们的KEY值来做判断
            {
                if (x.Key.Equals("Result"))//患者的信息存储在KEY为result中
                {
                    foreach (var y in x.Value) //遍历result的每一个value值
                    {
                        list.Add(y.ToString());//将Value值存储起来用作下次遍历
                    }
                }
            }

            foreach (string s in list)
            {
                obj = JObject.Parse(s);
                foreach (var x in obj)
                {
                    if (x.Key.Equals("ID"))
                    {
                        IDList.Add(x.Value.ToString());
                    }
                }
            }
            return IDList;
        }
    }
}
