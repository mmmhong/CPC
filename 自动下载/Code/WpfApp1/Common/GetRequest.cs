using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure
{
    public class GetRequest
    {

        public string GetPatientRequest(string cookie)
        {
            HttpWebRequest request = null;
            try
            {
                //Request配置
                request = (HttpWebRequest)HttpWebRequest.Create("http://data.chinacpc.org/patient/getPatientList");
                request.Accept = "application/json,text/plain,*/*";
                request.Headers.Add("Cookie", cookie);//填写Cookie
                request.ContentType = "application/json;charset=UTF-8";
                request.Method = "POST";
                request.Host = "data.chinacpc.org";
                request.KeepAlive = true;
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
                request.Referer = "http://data.chinacpc.org/Patient/PatientList";

                //poststring从txt文件中获取
                string postString = string.Empty;
                FileStream fs = new FileStream("D:\\GetPatientList.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str1 = sr.ReadLine();
                while (str1 != null)
                {
                    postString += str1 + "\n";
                    str1 = sr.ReadLine();
                }
                sr.Close();
                fs.Close();


                var data = Encoding.ASCII.GetBytes(postString);
                request.ContentLength = data.Length;
                using (var stream1 = request.GetRequestStream())
                {
                    stream1.Write(data, 0, data.Length);
                }
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
                return responseString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<HttpWebRequest> GetRecordRequest()
        {
            List<HttpWebRequest> list = new List<HttpWebRequest>();

            HttpWebRequest request = null;

            list.Add(request);


            return list;
        }
    }
}
