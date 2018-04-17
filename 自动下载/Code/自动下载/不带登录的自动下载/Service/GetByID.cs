using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using 不带登录的自动下载.DAL;

namespace 不带登录的自动下载
{
    public class GetByID
    {
        /// <summary>
        /// 通过ID获取该患者病历
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Do(string id)
        {
            string Url = "http://data.chinacpc.org/EVENT/Emergency?Id="+id+"&_=1520473200000";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Method = "GET";
            request.Accept = "application/json, text/plain, */*";
            request.KeepAlive = true;
            request.Headers.Add("Cookie", "UM_distinctid=1628401d1d7496-08ad63d8ccd751-3a614f0b-144000-1628401d1d84da; acw_tc=AQAAAB5KnSI4ZwcAAO5NMRse7eH4MbGQ; __RequestVerificationToken=vWTOBDyKy6aqiKL81LgO-1hQdKkGWeGBAJ2YIPilOmHzQ4OZwatimHa4d-66_1FdVlbWIRN8xLIz_O49aZluOuU64E4-xx3N4GMf0JKa_ao1; CNZZDATA1261146931=1669548485-1522745789-%7C1528680477; ASP.NET_SessionId=05si5ewv0ddq1ay110lzzfq2; .ASPXAUTH=07A9181CC0AD7BDBC570B12560C05C196B9A0F2B0AA63177BD684FB6CAEBEDF745C7A616A89B808499A1E8698CF117C299EBB3A8D7F64EA413BFA6D5BF65A02D7070291F94AA12DE6E02E7A3C8719D806795EBC8341F683A33E5D9DAA460CD4B");//填写Cookie
            request.Host = "data.chinacpc.org";
            request.Referer = "http://data.chinacpc.org/patient/crfplane?patientId=1384d418-be23-48ad-b503-b7f45517f924";
            request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";

            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)request.GetResponse();
            }
            catch(WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }
            string responseString = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            return responseString;

        }

        /// <summary>
        /// 解析单个患者的病历
        /// </summary>
        /// <param name="str"></param>
        public void JieXiBingLi(string str,string id,bool SaveData)
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

            foreach (var x in obj)
            {
                List<KeyValuePair<string, string>> field = new List<KeyValuePair<string, string>>();
                foreach (var y in (JObject)x.Value)
                {
                    if (y.Value.ToString() == "")
                    {
                        field.Add(new KeyValuePair<string, string>(y.Key,null));
                    }
                    else
                    {
                        field.Add(new KeyValuePair<string, string>(y.Key, y.Value.ToString()));
                    }
                }
                SqlDAL sql = new SqlDAL();

                if(SaveData)
                {
                    sql.SaveData(field, id, x.Key);//存数数据
                }
                else
                {
                    sql.SaveField(field,x.Key);//存储字段
                }
            }
        }
    }
}
