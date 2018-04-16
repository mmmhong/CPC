using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Producter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DemoTask : BSF.BaseService.TaskManager.BaseDllTask
    {
        public ProducterProvider mq;

        public DemoTask()
        {
            mq = ProducterPoolHelper.GetPool(new BusinessMQConfig()
            {
                ManageConnectString = "server=192.168.4.87;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456"
            }, "maohong");
        }
        public override void Run()
        {
            mq.SendMessage("abc");
        }
    }
}
