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

        public void MirgrationById(string id)
        {
            //if(_idal.GetState(id)==1)
            //{
            //    return;
            //}
            var relation = _idal.GetFieldRelation();
            string recoid = _idal.GetDataByID(id, relation);
            _idal.SaveData(recoid, id);
            _idal.ChangeState(id);
        }

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
                MQ.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
