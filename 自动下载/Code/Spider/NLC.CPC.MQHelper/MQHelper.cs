using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Consumer;
using BSF.BaseService.BusinessMQ.Producter;
using NLC.CPC.Infrastructure.Common;
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
                ManageConnectString = GetConfig.GetManagerConnectStr()
            }, GetConfig.GetMqPath());
        }
    }

    public class MQReceive : BSF.BaseService.TaskManager.BaseDllTask
        
    {
        public ConsumerProvider Consumer;

        public override void Run()
        {
            try
            {
                if (Consumer == null)
                {
                    Consumer = new ConsumerProvider();
                    Consumer.Client = "DataMove";
                    Consumer.ClientName = "MoveMove";

                    Consumer.Config = new BusinessMQConfig()
                    {
                        ManageConnectString = GetConfig.GetManagerConnectStr()
                    };
                    Consumer.MaxReceiveMQThread = 1;
                    Consumer.MQPath = GetConfig.GetMqPath();
                    Consumer.PartitionIndexs = new List<int>() { 1 };
                }
            }
            catch (Exception e)
            {
                string str = e.Message;
            }
        }

        /// <summary>
        /// 关闭消息队列
        /// </summary>
        public void CloseReceiveMessage()
        {
            try
            {
                if (Consumer != null)
                {
                    Consumer.Dispose();
                    Consumer = null;
                }
                base.Dispose();
            }
            catch (Exception e)
            {
                string str = e.Message;
                Consumer = null;
            }
        }
    }
}
