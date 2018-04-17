using NLC.CPC.Infrastructure.Model;
using NLC.CPC.Infrastructure.SourceModel;
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
        /// 获取字段关系表
        /// </summary>
        /// <returns></returns>
        List<HelpModel> GetFieldRelation();

        /// <summary>
        /// 通过ID获取患者病历
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldRelation"></param>
        /// <returns></returns>
        string GetDataByID(string id, List<HelpModel> fieldRelation);

        /// <summary>
        /// 保存患者病历
        /// </summary>
        /// <param name="record"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool SaveData(string record, string id);

        /// <summary>
        /// 修改已迁移的用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ChangeState(string id);

        /// <summary>
        /// 获取用户是否迁移的状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetState(string id);
    }
}
