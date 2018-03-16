using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Test
{
    public class TestCookie
    {
        public string cookies = "UM_distinctid=161bc832b1f56d-027920c2ba8b24-45450b2c-144000-161bc832b2094d; ";
        public string picUrl = "http://data.chinacpc.org/";

        public string GetCookies()
        {
            string[] c = a();

            foreach (string s in c)
            {
                string str = s.Substring(0, s.Length - 16);
                cookies += str;
            }
            b(picUrl, "D:\\pic.gif", 50000);
            return cookies;
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <returns></returns>
        public string[] a()
        {
            string url = "http://data.chinacpc.org/";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.KeepAlive = true;
            request.Headers.Add("Cookie", "UM_distinctid=161bc832b1f56d-027920c2ba8b24-45450b2c-144000-161bc832b2094d");
            request.Host = "data.chinacpc.org";
            request.Referer = "http://data.chinacpc.org/home/index";
            request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            string[] cookies = response.Headers.GetValues("Set-Cookie");

            GetPicUrl(response);
            return cookies;
        }

        public void GetPicUrl(HttpWebResponse response)
        {
            string responseStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
            string str1 = responseStr.Substring(responseStr.IndexOf("_MvcCaptcha/MvcCaptchaImage?"));
            picUrl += str1.Substring(0, str1.IndexOf("\""));
        }


        public void b(string picUrl, string savePath, int timeOut)
        {
            bool value = false;
            WebResponse response = null;
            Stream stream = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(picUrl);
                request.Method = "GET";

                request.Headers.Add(HttpRequestHeader.Cookie, cookies);
                request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
                request.Host = "data.chinacpc.org";
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
                request.Referer = "http://data.chinacpc.org/";
                if (timeOut != -1) request.Timeout = timeOut;
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/"))
                    value = SaveBinaryFile(response, savePath);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
        }

        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (File.Exists(savePath)) File.Delete(savePath);
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }
            return value;
        }



        public void TestLogin(string code)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://data.chinacpc.org/");
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.KeepAlive = true;
            request.ContentLength = 256;
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Headers.Add()
        }
    }
}
