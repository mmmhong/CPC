using BSF.BaseService.BusinessMQ.Common;
using BSF.BaseService.BusinessMQ.Producter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.MQ
{
    public class MQHelper
    {
        public ProducterProvider mq;
        public MQHelper()
        {
            mq= ProducterPoolHelper.GetPool(new BusinessMQConfig()
            {
                ManageConnectString = "server=192.168.4.48;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456;"
            }, "maohong");
        }
    }
}
