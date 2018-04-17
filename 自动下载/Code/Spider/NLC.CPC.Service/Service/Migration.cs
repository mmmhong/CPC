using IService;
using NLC.CPC.IRepository;
using System;

namespace Service
{
    public class Migration : IMigration
    {
        private IDAL _idal;

        public Migration(IDAL dal)
        {
            this._idal = dal;
        }

        /// <summary>
        /// 根据患者ID进行转移
        /// </summary>
        /// <param name="id"></param>
        public string MirgrationById(string id)
        {
            try
            {
                var relation = _idal.GetFieldRelation();  //获取关系字段表
                string recoid = _idal.GetDataByID(id, relation);  //根据ID获取病历数据
                if (recoid.Equals("{"))  //获取到空的情况，不存储
                {
                    return "false";
                }
                _idal.SaveData(recoid, id);  //存储病历
                _idal.ChangeState(id);      //修改已存储的状态
                return "true";
            }
            catch (Exception e)
            {
                BSF.Log.ErrorLog.Write("MirgrationById", e);
                return "MirgrationById:" + e.Message;
            }
        }
    }
}
