using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Service
{
    public class Migration : IMigration
    {
        private IDAL _idal;
        public MQHelper MQ = new MQHelper();

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
                }); MQ.Run();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public void MirgrationById(string id)
        {
            _idal.GetDataById(id);
        }

        public void test()
        {
            this._idal.GetFieldRelation();
        }
    }
}
