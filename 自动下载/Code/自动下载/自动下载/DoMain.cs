using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 自动下载.Model;

namespace 自动下载
{
    class DoMain
    {
        private string token;
        static void Main()
        {
            Console.WriteLine("程序开始");
            string loginstr = "{\"UserName\":\"cpc\",\"UserPwd\":\"202cb962ac59075b964b07152d234b70\"}";
            GetStr(loginstr, "http://192.168.1.249:30090/OpenAPI//UserAccount/UserLogin");
            Console.ReadKey();
            string Url = "http://192.168.1.249:30090/OpenAPI//EmergencyArchives/GetEmergencyArchives?token=e0a0b888938d452886ee1856bb21505b";
            string postString = "{\"ArchivesID\":\"149\"}";
            GetPatients(Url,postString);
            Console.ReadKey();

        }


        public static void GetStr(string postString, string postUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(postUrl);

            var postData = postString;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
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
            string responseString = new StreamReader(res.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
            Body b = JsonConvert.DeserializeObject<Body>(responseString);
            Console.WriteLine(b.ToString());
        }
        

        public static void GetPatients(string postUrl,string postString)
        {
            //string postUrl = "http://192.168.1.249:30090/OpenAPI//EmergencyArchives/GetEmergencyArchiveses";
            //string postString = "{\"Condition\":{\"IsBypassEmergency\":-1,\"IsBypassCCU\":-1,\"IsHaveThrombolysis\":-1,\"IsRemoteECGTrans\":-1},\"PageIndex\":1,\"PageSize\":20}";
            var request = (HttpWebRequest)WebRequest.Create(postUrl);

            var postData = postString;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
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
            string responseString = new StreamReader(res.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
        }
    }
}