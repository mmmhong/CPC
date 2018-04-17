using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace NLC.CPC.Infrastructure.Common
{
    public class JsonParse
    {
        /// <summary>
        /// 解析患者列表
        /// </summary>
        /// <param name="patientString">JSON类型字符串</param>
        /// <returns></returns>
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

        /// <summary>
        /// 解析患者病历
        /// </summary>
        /// <param name="resStr">病历的JSON字符串</param>
        /// <param name="recordName">病历名称</param>
        public List<KeyValuePair<string,string>> RecordParse(string resStr,string recordName)
        {
            JObject resObj = JObject.Parse(resStr);

            foreach (var x in resObj)
            {
                if (x.Key.Equals("Result"))
                {
                    resStr = x.Value.ToString();
                    break;
                }
            }
            resObj = JObject.Parse(resStr);

            List<KeyValuePair<string, string>> fieldAndValueList = new List<KeyValuePair<string, string>>();//存储字段对应值

            if (recordName == null)
            {
                fieldAndValueList = new List<KeyValuePair<string, string>>();
                foreach (var x in resObj)
                {
                    if (x.Key.Equals("DiagTreatModel") || x.Key.Equals("OutModel"))
                    {
                        continue;
                    }
                    foreach (var y in (JObject)x.Value)
                    {
                        if (y.Value.ToString() == "")
                        {
                            fieldAndValueList.Add(new KeyValuePair<string, string>(y.Key, null));
                        }
                        else
                        {
                            fieldAndValueList.Add(new KeyValuePair<string, string>(y.Key, y.Value.ToString()));
                        }
                    }
                }
            }
            else
            {
                foreach (var x in resObj)
                {
                    if (x.Value.ToString() == "")
                    {
                        fieldAndValueList.Add(new KeyValuePair<string, string>(x.Key, null));
                    }
                    else
                    {
                        fieldAndValueList.Add(new KeyValuePair<string, string>(x.Key, x.Value.ToString()));
                    }
                }
            }
            return fieldAndValueList;
        }
    }
}
