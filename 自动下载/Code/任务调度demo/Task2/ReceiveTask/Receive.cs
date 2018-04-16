using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveTask
{
    public class Receive : BSF.BaseService.TaskManager.BaseDllTask
    {
        public ConsumerProvider Consumer;

        public override void Run()
        {
            Consumer.RegisterReceiveMQListener<string>((r) =>
            {
                string str = r.ObjMsg;
                r.MarkFinished();
                this.OpenOperator.Log("获取消息：" + str);
            });
        }

        public Receive()
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
                        ManageConnectString = "server=192.168.4.87;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456"
                    };
                    Consumer.MaxReceiveMQThread = 1;
                    Consumer.MQPath = "maohong";
                    Consumer.PartitionIndexs = new List<int>() { 1 };
                }
            }
            catch (Exception e)
            {
                this.OpenOperator.Error("错误日志;", new Exception(e.Message));
            }
        }
    }
}
