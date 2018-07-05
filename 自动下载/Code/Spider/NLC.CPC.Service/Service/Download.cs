using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLC.CPC.Infrastructure.Common;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.MQ;
using System.Collections.Generic;
using System.Net;

namespace NLC.CPC.Service
{
    public class Download : IDownload
    {
        private IDAL _idal;
        GetRequest getRequest = new GetRequest();
        JsonParse jsonParse = new JsonParse();
        SimulationRequest SR = new SimulationRequest();
        //  MQSend MQ = new MQSend();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sqlDAL"></param>
        public Download(IDAL sqlDAL)
        {
            this._idal = sqlDAL;
        }

        /// <summary>
        /// 下载患者列表并存储到数据库
        /// </summary>
        public void downloadPatient()
        {
            HttpWebRequest request = getRequest.GetPatientRequest();
            string responseString = SR.GetResponseString(request);
            List<string> IDList = jsonParse.PatientListParse(responseString);//调用解析方法
            this._idal.SavePatientList(IDList);//调用存储方法
        }

        /// <summary>
        /// 下载患者病历存储为字典
        /// </summary>
        public void downloadDataToDictionary()
        {
            GetRequest getRequest = new GetRequest();
            var patientList = this._idal.GetPatientList();//获取患者ID列表

            foreach (var v in patientList)//遍历ID列表
            {
                string data = string.Empty;
                List<HttpWebRequest> request = getRequest.GetRecordRequestById(v.PatientID);
                if (request.Count != 0)
                {
                    foreach (var r in request)
                    {
                        string resStr = SR.GetResponseString(r);
                        string temp = GetJsonFromStr(resStr);
                        data = string.IsNullOrEmpty(data) ? temp : data.Replace('}', ',') + temp.Substring(1);
                    }
                }
                _idal.SaveDataAsCPC(v.PatientID, data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resStr"></param>
        /// <returns></returns>
        public string GetJsonFromStr(string resStr)
        {
            JObject resObj = JObject.Parse(resStr);

            foreach (var x in resObj)
            {
                if (x.Key.Equals("Result"))
                {
                    resStr = x.Value.ToString();
                    break;
                }
            }
            resObj = JObject.Parse(resStr);

            string data = string.Empty;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var v in resObj)
            {
                if (resObj.Count > 10) break;
                if (v.Key.ToLower().Equals("emergenmodel"))
                {
                    data = string.IsNullOrEmpty(data) ? data : data.Replace('}', ',') + v.Value.ToString().Substring(1);
                }
                else if (v.Key.ToLower().Equals("regmodel"))
                {
                    data = string.IsNullOrEmpty(data) ? v.Value.ToString() : data.Replace('}', ',') + v.Value.ToString().Substring(1);
                }
            }
            if (string.IsNullOrEmpty(data))
            {
                data = resObj.ToString();
            }
            return data;
        }

        /// <summary>
        /// 下载患者病历并存储到数据库
        /// </summary>
        public void downloadRecord()
        {
            GetRequest getRequest = new GetRequest();
            var patientList = this._idal.GetPatientList();
            foreach (var v in patientList)
            {
                List<HttpWebRequest> request = getRequest.GetRecordRequestById(v.PatientID);
                if (request.Count == 3)
                {
                    foreach (var r in request)
                    {
                        string resStr = SR.GetResponseString(r);
                        string recordName = null;

                        if (r.Address.ToString().Contains("Diagnosis"))
                        {
                            recordName = "DiagTreatModel";
                        }
                        else if (r.Address.ToString().Contains("Outcome"))
                        {
                            recordName = "OutModel";
                        }

                        var recordList = jsonParse.RecordParse(resStr, recordName);
                        if (recordName == null)
                        {
                            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                            foreach (var l in recordList)
                            {
                                if (recordList.IndexOf(l) < 48)
                                {
                                    list.Add(l);
                                }
                                else if (recordList.IndexOf(l) == 48)
                                {
                                    this._idal.SavePatientRecord(list, v.PatientID, "Regmodel");
                                    list = new List<KeyValuePair<string, string>>();
                                    list.Add(l);
                                }
                                else
                                {
                                    list.Add(l);
                                }
                            }
                            this._idal.SavePatientRecord(list, v.PatientID, "EmergenModel");
                        }
                        else
                        {
                            this._idal.SavePatientRecord(recordList, v.PatientID, recordName);
                        }
                    }
                }
                // MQ.mq.SendMessage(v.PatientID);//将保存好的患者ID发送到消息队列
            }
        }
    }
}
