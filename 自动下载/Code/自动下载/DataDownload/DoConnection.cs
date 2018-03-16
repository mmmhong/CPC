using DataDownload.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DataDownload
{
    public class DoConnection
    {
        public string GetStr(string postUrl, string postString)
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
            return responseString;
        }

        public string getToken(string responseString)
        {
            Body b = JsonConvert.DeserializeObject<Body>(responseString);

            return b.Data;
        }

        public List<int> getID(string responseString)
        {
            List<int> list = new List<int>();
            EmergencyArchiveses p = JsonConvert.DeserializeObject<EmergencyArchiveses>(responseString);
            foreach(Patient i in p.Data.List)
            {
                list.Add(i.ArchivesID);
            }
            return list;
        }
    }
}
