using Autofac;
using BSF.BaseService.BusinessMQ.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 哎呦我去任务调度底层错误错个头啊
{
    class Program
    {
        static void Main(string[] args)
        {


        private static IContainer Container { get; set; }

        public ConsumerProvider Consumer;

      
            Register();
            Receive();
            ConfigCenter();
            var d = Container.Resolve<IMigration>();

            this.OpenOperator.Log("Run");
            try
            {
                Consumer.RegisterReceiveMQListener<string>((r) =>
                {
                    string str = r.ObjMsg;

                    this.OpenOperator.Log("获取消息：" + str);

                    str = d.MirgrationById(str);

                    this.OpenOperator.Log("运行结果：" + str);

                    r.MarkFinished();
                });
            }
            catch (Exception e)
            {
                this.OpenOperator.Error("错误：", new Exception(e.Message));
            }
   

        public void Register()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<DAL>().As<IDAL>();//注册接口IDAL的实例DAL
                builder.RegisterType<Migration>().As<IMigration>();
                Container = builder.Build();
            }
            catch (Exception e)
            {
                this.OpenOperator.Error("错误日志：", new Exception(e.Message));
            }
        }

        public void Receive()
        {
            try
            {
                if (Consumer == null)
                {
                    Consumer = new ConsumerProvider();
                    Consumer.Client = "DataMove";
                    Consumer.ClientName = "MoveMove";

                    //string path = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ConfigCenter.json";
                    //string json = File.ReadAllText(path, Encoding.Default);

                    Consumer.Config = new BusinessMQConfig()
                    {
                        ManageConnectString = "server=192.168.4.91;Initial Catalog=dyd_bs_MQ_manage;User ID=sa;Password=123456;"
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

        private void ConfigCenter()
        {
            BSF.Config.BSFConfig.ProjectName = "Spider";
            BSF.Config.BSFConfig.ConfigManagerConnectString = "server =192.168.4.91; Initial Catalog = dyd_bs_configmanager; User ID = sa; Password = 123456; ";
        }
    }
}
