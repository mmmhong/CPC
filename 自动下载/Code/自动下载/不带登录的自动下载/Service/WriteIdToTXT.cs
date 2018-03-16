using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 不带登录的自动下载
{
    public class WriteIdToTXT
    {
        public List<string> Do(string str)
        {
            string fullPath2 = "D:\\ID.txt";
            StreamWriter sw2 = new StreamWriter(fullPath2, false, Encoding.Default);
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            
            JObject obj = JObject.Parse(str);//将字符串转为JObject格式

            foreach (var x in obj)//遍历JObject,获取每个Key值
            {
                if (x.Key.Equals("Result"))//用户的信息存储在Result中
                {
                    foreach (var y in x.Value)//遍历Result的每一个Value值
                    {
                        list.Add(y.ToString());//将每个值以字符串形式写入list中
                    }
                }
            }

            foreach (string s in list)//遍历list，取出所有的ID
            {
                obj = JObject.Parse(s);
                foreach (var x in obj)
                {
                    if (x.Key.Equals("ID"))
                    {
                        sw2.WriteLine(x.Value + "\n");
                        list2.Add(x.Value.ToString());
                    }
                }
            }
            sw2.Close();
            return list2;
        }
    }
}
