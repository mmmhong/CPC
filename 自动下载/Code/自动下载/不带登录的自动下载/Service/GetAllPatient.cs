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
            request.Headers.Add("Cookie", "UM_distinctid=161ffe358475a8-0887a8ee52bf5f-722c6137-7d400-161ffe35849272; acw_tc=AQAAAHJNkx8Z1QsA+OlNMRfetHv2yyhu; __RequestVerificationToken=SQre0f65JAoa-eH17I-ong5zfz9SICVdslfHFf56KgBfnsaW6oQHltvXN7wediSYmmuHyx8gnt-RrkQf7f-O3ys44g825WtJ9oR-69sq-dA1; CNZZDATA1261146931=643416402-1520413279-%7C1522216960; ASP.NET_SessionId=te0xjfb4z1hronza3phtbion; .ASPXAUTH=B7EB6BB0917E97F1D90F9CF2BB65CBD6FFD49F6F6AA8E1D76D606A5F8882E4DE6AFAF122B859DE756794C6B384517D5F2415E4F630E8679FCBAC6CE7EDC9D2214C2E0ADCB4CBDB321B36E383DA1C99D0312AD8404314256BC43E07F173C52323");//填写Cookie
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
