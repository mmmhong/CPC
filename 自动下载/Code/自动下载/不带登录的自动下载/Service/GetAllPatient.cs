using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace 不带登录的自动下载
{
    public class GetAllPatient
    {
        /// <summary>
        /// 获取所有的用户ID
        /// </summary>
        /// <returns></returns>
        public string Do()
        {
            //Request配置
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://data.chinacpc.org/patient/getPatientList");
            request.Accept = "application/json,text/plain,*/*";
            request.Headers.Add("Cookie", "");//填写Cookie
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
            //读取response
            string responseString = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            return responseString;
        }
    }
}
