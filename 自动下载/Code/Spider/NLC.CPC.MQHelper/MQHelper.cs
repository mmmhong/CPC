using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Consumer;
using BSF.BaseService.BusinessMQ.Producter;
using NLC.CPC.Infrastructure.Common;
using System;
using System.Collections.Generic;

namespace NLC.CPC.MQ
{
    public class MQSend
    {
        public ProducterProvider mq;

        public MQSend()
        {
            mq = ProducterPoolHelper.GetPool(new BusinessMQConfig()
            {
                ManageConnectString = GetConfig.ManagerConnectStr
            }, GetConfig.MqPath);
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
                        ManageConnectString = GetConfig.ManagerConnectStr
                    };
                    Consumer.MaxReceiveMQThread = 1;
                    Consumer.MQPath = GetConfig.MqPath;
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
