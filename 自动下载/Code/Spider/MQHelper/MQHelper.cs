using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Consumer;
using BSF.BaseService.BusinessMQ.Producter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.MQ
{
    public class MQSend
    {
        public ProducterProvider mq;
        public MQSend()
        {
                mq = ProducterPoolHelper.GetPool(new BusinessMQConfig()
            {
                ManageConnectString = "server=192.168.4.87;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456;"
            }, "maohong");
        }
    }

    public class MQReceive : BSF.BaseService.TaskManager.BaseDllTask
    {
        public ConsumerProvider Consumer;

        public override void Run()
        {
            if (Consumer == null)
            {
                Consumer = new ConsumerProvider();
                Consumer.Client = "DataMove";
                Consumer.Client = "MoveMove";
                Consumer.Config = new BusinessMQConfig()
                {
                    ManageConnectString = "server=192.168.4.87;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456;"
                };
                Consumer.MaxReceiveMQThread = 1;
                Consumer.MQPath = "maohong";
                Consumer.PartitionIndexs = new List<int>() { 1 };
            }
        }
    }
}
