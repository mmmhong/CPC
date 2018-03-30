using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure
{
    public class GetRequest
    {

        public HttpWebRequest GetPatientRequest()
        {
            HttpWebRequest request = null;
            try
            {
                //Request配置
                request = (HttpWebRequest)HttpWebRequest.Create("http://data.chinacpc.org/patient/getPatientList");
                request.Accept = "application/json,text/plain,*/*";
                string cookie = Convert.ToString(ConfigurationManager.AppSettings["Cookie"]);
                request.Headers.Add("Cookie", cookie);//填写Cookie
                request.ContentType = "application/json;charset=UTF-8";
                request.Method = "POST";
                request.Host = "data.chinacpc.org";
                request.KeepAlive = true;
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
                request.Referer = "http://data.chinacpc.org/Patient/PatientList";

                //poststring从json文件中获取
                string postString = string.Empty;
                FileStream fs = new FileStream("..\\..\\Config\\GetPatientList.json", FileMode.Open, FileAccess.Read);
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
                return request;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<HttpWebRequest> GetRecordRequestById(string id)
        {
            List<HttpWebRequest> requestList = new List<HttpWebRequest>();

            List<string> urlList = new List<string>();
            urlList.Add("http://data.chinacpc.org/EVENT/Emergency?Id=" + id + "&_=1521112559000");
            urlList.Add("http://data.chinacpc.org/EVENT/Outcome?Id=" + id + "&_=1521112559000");
            urlList.Add("http://data.chinacpc.org/EVENT/GetDiagnosisTreatment?_=1521112559000&registerId=" + id);

            foreach (var str in urlList)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(str);
                    request.Method = "GET";
                    request.Accept = "application/json, text/plain, */*";
                    request.KeepAlive = true;
                    request.Headers.Add("Cookie", Convert.ToString(ConfigurationManager.AppSettings["Cookie"]));
                    request.Host = "data.chinacpc.org";
                    request.Referer = "http://data.chinacpc.org/patient/crfplane?patientId=1384d418-be23-48ad-b503-b7f45517f924";
                    request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";

                    requestList.Add(request);
                }
                catch(Exception)
                {

                }
            }
            return requestList;
        }
    }
}
