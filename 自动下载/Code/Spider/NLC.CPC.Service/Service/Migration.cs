using BSF.BaseService.BusinessMQ;
using IService;
using NLC.CPC.IRepository;
using NLC.CPC.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Migration : IMigration
    {
        private IDAL _idal;
       // public MQReceive MQ = new MQReceive();

        public Migration(IDAL dal)
        {
            this._idal = dal;
        }

        ///// <summary>
        ///// 进行数据迁移
        ///// </summary>
        ///// <returns></returns>
        //public string DoMigration()
        //{
        //    string str = string.Empty;
        //    try
        //    {
        //        MQ.Run();
        //        MQ.Consumer.RegisterReceiveMQListener<string>((r) =>
        //        {
        //            str = MirgrationById(r.ObjMsg);
        //            r.MarkFinished();
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return str + ":" + e.Message;
        //    }
        //    return "true";
        //}

        /// <summary>
        /// 根据患者ID进行转移
        /// </summary>
        /// <param name="id"></param>
        public string MirgrationById(string id)
        {
            string str = string.Empty;
            try
            {
                var relation = _idal.GetFieldRelation();
                string recoid = _idal.GetDataByID(id, relation);
                if (recoid.Equals("{"))
                {
                    return "false";
                }
                _idal.SaveData(recoid, id);
                _idal.ChangeState(id);
                return "true";
            }
            catch (Exception e)
            {
                BSF.Log.ErrorLog.Write("MirgrationById", e);
                return "MirgrationById:" + str + e.Message;
            }
        }

        ///// <summary>
        ///// 清空消息队列
        ///// </summary>
        ///// <returns></returns>
        //public bool ClearMQ()
        //{
        //    try
        //    {
        //        MQ.Run();
        //        MQ.Consumer.RegisterReceiveMQListener<string>((r) =>
        //        {
        //            string str = r.ObjMsg;
        //            r.MarkFinished();
        //        });
        //        MQ.CloseReceiveMessage();
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public string textre()
        {
            return "用于任务调度测试";
        }

        public string DoMigration()
        {
            throw new NotImplementedException();
        }

        public bool ClearMQ()
        {
            throw new NotImplementedException();
        }
    }
}
