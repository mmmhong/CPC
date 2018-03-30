using Autofac;
using NLC.CPC.Infrastructure;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Service
{
    public class Download : IDownload
    {
        private IDAL _idal;
        GetRequest getRequest = new GetRequest();
        JsonParse jsonParse = new JsonParse();
        SimulationRequest SR = new SimulationRequest();
        MQHelper MQ = new MQHelper();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sqlDAL"></param>
        public Download(IDAL sqlDAL)
        {
            this._idal = sqlDAL;
        }

        public string test()
        {
            return this._idal.test() + "abc";
        }

        /// <summary>
        /// 下载患者列表并存储到数据库
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public bool downloadPatient()
        {
            try
            {
                HttpWebRequest request = getRequest.GetPatientRequest();
                string responseString = SR.GetResponseString(request);
                List<string> IDList = jsonParse.PatientListParse(responseString);//调用解析方法
                this._idal.SavePatientList(IDList);//调用存储方法
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载患者病历并存储到数据库
        /// </summary>
        /// <returns></returns>
        public bool downloadRecord()
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
                                else if(recordList.IndexOf(l)==48)
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
                MQ.mq.SendMessage(v.PatientID);//将保存好的患者ID发送到消息队列
            }




            return true;
        }
    }
}
