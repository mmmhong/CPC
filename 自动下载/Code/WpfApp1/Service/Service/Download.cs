using Autofac;
using NLC.CPC.Infrastructure;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
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
        public bool downloadPatient(string cookie,string connStr)
        {
            string responseString = getRequest.GetPatientRequest(cookie);
            List<string> IDList =  jsonParse.PatientListParse(responseString);
            this._idal.SavePatientList(IDList);

            return true;
        }

        /// <summary>
        /// 下载患者病历并存储到数据库
        /// </summary>
        /// <returns></returns>
        public bool downloadRecord()
        {
            GetRequest getRequest = new GetRequest();

            //HttpWebRequest request = getRequest.GetRecordRequest();
            return true;
        }
    }
}
