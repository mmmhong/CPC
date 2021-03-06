﻿using NLC.CPC.IRepository;
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
            var relation = _idal.GetFieldRelation();
            string recoid = _idal.GetDataByID(id, relation);
            _idal.SaveData(recoid, id);
            _idal.ChangeState(id);
        }

        public void test()
        {
            try
            {
                MQ.Run();
                MQ.Consumer.RegisterReceiveMQListener<string>((r) =>
                {
                    test2(r.ObjMsg);
                    r.MarkFinished();
                }); MQ.Run();
            }
            catch (Exception ex)
            {
            }
        }

        public void test2(string id)
        {
            string str = id;
        }


    }
}
