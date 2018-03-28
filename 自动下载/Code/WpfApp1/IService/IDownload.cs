using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.IService
{
    public interface IDownload
    {
        /// <summary>
        /// 下载患者列表
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        bool downloadPatient(string cookie,string connStr);

        /// <summary>
        /// 下载患者病历
        /// </summary>
        /// <returns></returns>
        bool downloadRecord();

        /// <summary>
        /// TEST
        /// </summary>
        /// <returns></returns>
        string test();
    }
}
