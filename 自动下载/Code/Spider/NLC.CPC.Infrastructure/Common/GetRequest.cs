﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NLC.CPC.Infrastructure.Common
{
    public class GetRequest
    {
        /// <summary>
        /// 配置获取患者列表的request请求
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest GetPatientRequest()
        {
            HttpWebRequest request = null;

            //Request配置
            request = (HttpWebRequest)HttpWebRequest.Create("http://data.chinacpc.org/patient/getPatientList");
            request.Accept = "application/json,text/plain,*/*";
            // request.Headers.Add("Cookie", GetConfig.Cookie);//填写Cookie

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ConfigCenter.json";
            string json = File.ReadAllText(path, Encoding.Default);
            request.Headers.Add("Cookie", (JObject.Parse(json))["Cookie"].ToString());//config文件获取

            request.ContentType = "application/json;charset=UTF-8";
            request.Method = "POST";
            request.Host = "data.chinacpc.org";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";
            request.Referer = "http://data.chinacpc.org/Patient/PatientList";

            //poststring从json文件中获取

            //string postString = GetConfig.PostString;
            string postString = (JObject.Parse(json))["postString"].ToString();

            var data = Encoding.ASCII.GetBytes(postString);
            request.ContentLength = data.Length;
            using (var stream1 = request.GetRequestStream())
            {
                stream1.Write(data, 0, data.Length);
            }
            return request;
        }

        /// <summary>
        /// 根据ID配置获取患者病历的request请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<HttpWebRequest> GetRecordRequestById(string id)
        {
            List<HttpWebRequest> requestList = new List<HttpWebRequest>();

            List<string> urlList = new List<string>();
            urlList.Add("http://data.chinacpc.org/EVENT/Emergency?Id=" + id + "&_=1521112559000");
            urlList.Add("http://data.chinacpc.org/EVENT/Outcome?Id=" + id + "&_=1521112559000");
            urlList.Add("http://data.chinacpc.org/EVENT/GetDiagnosisTreatment?_=1521112559000&registerId=" + id);

            foreach (var str in urlList)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(str);
                request.Method = "GET";
                request.Accept = "application/json, text/plain, */*";
                request.KeepAlive = true;

                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ConfigCenter.json";
                string json = File.ReadAllText(path, Encoding.Default);
                request.Headers.Add("Cookie", (JObject.Parse(json))["Cookie"].ToString());
                //request.Headers.Add("Cookie", GetConfig.Cookie);

                request.Host = "data.chinacpc.org";
                request.Referer = "http://data.chinacpc.org/patient/crfplane?patientId=1384d418-be23-48ad-b503-b7f45517f924";
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Mobile Safari/537.36";

                requestList.Add(request);
            }
            return requestList;
        }
    }
}
