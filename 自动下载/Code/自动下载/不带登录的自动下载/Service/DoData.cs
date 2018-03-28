using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using 不带登录的自动下载.DAL;

namespace 不带登录的自动下载
{
    public class DoData
    {
        /// <summary>
        /// 获取单个用户的所有病历列表
        /// </summary>
        /// <param name="id">患者ID</param>
        public void Do(string id)
        {
            List<string> urlString = new List<string>();
            urlString.Add("http://data.chinacpc.org/EVENT/Emergency?Id=" + id + "&_=1521112559000");
            urlString.Add("http://data.chinacpc.org/EVENT/Outcome?Id=" + id + "&_=1521112559000");
            urlString.Add("http://data.chinacpc.org/EVENT/GetDiagnosisTreatment?_=1521112559000&registerId=" + id);
             
            foreach (var str in urlString)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(str);
                request.Method = "GET";
                request.Accept = "application/json, text/plain, */*";
                request.KeepAlive = true;
                request.Headers.Add("Cookie", "");//填写Cookie
                request.Host = "data.chinacpc.org";
                request.Referer = "http://data.chinacpc.org/patient/crfplane?patientId=1384d418-be23-48ad-b503-b7f45517f924";
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";

                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                }
                string responseString = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();

                string recordName = null;
                if (str.Contains("Diagnosis"))
                {
                    recordName = "DiagTreatModel";
                }
                else if (str.Contains("Outcome"))
                {
                    recordName = "OutModel";
                }
                JieXi(responseString, id, recordName);
            }
        }

        /// <summary>
        /// 解析病历
        /// </summary>
        /// <param name="str">病历数据</param>
        /// <param name="id">患者ID</param>
        /// <param name="recordName">病历名称</param>
        public void JieXi(string str, string id, string recordName)
        {
            JObject obj = JObject.Parse(str);

            foreach (var x in obj)
            {
                if (x.Key.Equals("Result"))
                {
                    str = x.Value.ToString();
                }
            }
            obj = JObject.Parse(str);
            SqlDAL sql = new SqlDAL();
            List<KeyValuePair<string, string>> field = new List<KeyValuePair<string, string>>();

            if (recordName == null)
            {
                foreach (var x in obj)
                {
                    if (x.Key.Equals("DiagTreatModel") || x.Key.Equals("OutModel"))
                    {
                        continue;
                    }
                    field = new List<KeyValuePair<string, string>>();
                    foreach (var y in (JObject)x.Value)
                    {
                        if (y.Value.ToString() == "")
                        {
                            field.Add(new KeyValuePair<string, string>(y.Key, null));
                        }
                        else
                        {
                            field.Add(new KeyValuePair<string, string>(y.Key, y.Value.ToString()));
                        }
                    }
                    sql.SaveData(field, id, x.Key);//存数数据
                }
            }
            else
            {
                foreach (var x in obj)
                {
                    if (x.Value.ToString() == "")
                    {
                        field.Add(new KeyValuePair<string, string>(x.Key, null));
                    }
                    else
                    {
                        field.Add(new KeyValuePair<string, string>(x.Key, x.Value.ToString()));
                    }
                }
                sql.SaveData(field, id, recordName);//存数数据
            }
        }
    }
}
