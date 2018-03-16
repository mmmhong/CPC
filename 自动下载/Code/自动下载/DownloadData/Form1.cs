using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadData
{
    public partial class Form1 : Form
    {
        public static string cookies =
"UM_distinctid=161bc832b1f56d-027920c2ba8b24-45450b2c-144000-161bc832b2094d; acw_tc=AQAAALsBASLzRAsArNlNMSJuDjVwzVF/; ASP.NET_SessionId=0tevfasy400bln2vfpouoeud; __RequestVerificationToken=e0kJsmNoxyEgzLWNke7_3IbMgUVfOR1WSxyIEZ10l4rTkQKpf6iMrxzmfosbfJVTXh-ZfUSMZyOBVzyZX-rvvSCVpdsVnOSRVI79I7loeVM1; CNZZDATA1261146931=387356287-1519344973-http%253A%252F%252Fdata.chinacpc.org%252F%7C1520313743";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string picurl = "http://data.chinacpc.org/_MvcCaptcha/MvcCaptchaImage?561d36c9830349e3a7272309c8bce1b8";
            DownloadPicture(picurl, "D:\\a.gif", 500000);
        }

        public string GetContentFromUrl(string URL)
        {
            try
            {
                string strBuff = "";
                int byteRead = 0;
                char[] cbuffer = new char[256];
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(URL));
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                Stream respStream = httpResp.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, System.Text.Encoding.UTF8);
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
                while (byteRead != 0)
                {
                    string strResp = new string(cbuffer, 0, byteRead);
                    strBuff += strResp;
                    byteRead = respStreamReader.Read(cbuffer, 0, 256);
                }
                respStream.Close();
                return strBuff;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        /// <summary>
        /// 下载验证码
        /// </summary>
        /// <param name="picUrl">验证码URL</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public static bool DownloadPicture(string picUrl, string savePath, int timeOut)
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
            return value;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CookieContainer cookie = new CookieContainer();
            string url = "http://data.chinacpc.org/";
            string postString = "__RequestVerificationToken=Ok6LTbeYqlis-4bDehwevJSSzCd8Lqlnx6su3EoQOTXDuGI_q7rdgnIvavjB9wK21xT3kyP8YirCTyFzz_RtI6uA2mZgg7IPaTnBezv7eMU1&UserName=7017&Password=cpp7017&_mvcCaptchaText=qlcz&_mvcCaptchaGuid=561d36c9830349e3a7272309c8bce1b8&RememberMe=checkbox";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = cookie;
            request.Method = "POST";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch(WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            GetContent(cookie, "http://data.chinacpc.org/home/index");
            //string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        static string GetContent(CookieContainer cookie, string url)
        {
            string content;
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.CookieContainer = cookie;
            httpRequest.Referer = url;
            httpRequest.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
            httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (Stream responsestream = httpResponse.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(responsestream, System.Text.Encoding.UTF8))
                {
                    content = sr.ReadToEnd();
                }
            }
            return content;
        }


    }
}
