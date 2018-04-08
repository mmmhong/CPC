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
        public MQReceive MQ = new MQReceive();

        public Migration(IDAL dal)
        {
            this._idal = dal;
        }

        /// <summary>
        /// 进行数据迁移
        /// </summary>
        /// <returns></returns>
        public bool DoMigration()
        {
            try
            {
                MQ.Run();
                MQ.Consumer.RegisterReceiveMQListener<string>((r) =>
                {
                    MirgrationById(r.ObjMsg);
                    r.MarkFinished();
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据患者ID进行转移
        /// </summary>
        /// <param name="id"></param>
        public void MirgrationById(string id)
        {
            var relation = _idal.GetFieldRelation();
            string recoid = _idal.GetDataByID(id, relation);
            _idal.SaveData(recoid, id);
            _idal.ChangeState(id);
        }

        /// <summary>
        /// 清空消息队列
        /// </summary>
        /// <returns></returns>
        public bool ClearMQ()
        {
            try
            {
                MQ.Run();
                MQ.Consumer.RegisterReceiveMQListener<string>((r) =>
                {
                    string str = r.ObjMsg;
                    r.MarkFinished();
                });
                MQ.CloseReceiveMessage();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
