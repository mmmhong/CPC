using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.IRepository
{
    public interface IDAL
    {
        List<Patient> GetPatientList();

        /// <summary>
        /// 存储患者列表
        /// </summary>
        /// <returns></returns>
        bool SavePatientList(List<string> patiList);

        /// <summary>
        /// 存储患者病历
        /// </summary>
        /// <returns></returns>
        bool SavePatientRecord(List<KeyValuePair<string, string>> list, string id, string redordName);

        /// <summary>
        /// TEST
        /// </summary>
        /// <returns></returns>
        string test();
    }
}
