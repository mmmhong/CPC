using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.IRepository
{
    public interface IDAL
    {
        /// <summary>
        /// 存储患者列表
        /// </summary>
        /// <returns></returns>
        bool SavePatientList(List<string> patiList);

        /// <summary>
        /// 存储患者病历
        /// </summary>
        /// <returns></returns>
        bool SavePatientRecord();

        /// <summary>
        /// TEST
        /// </summary>
        /// <returns></returns>
        string test();
    }
}
