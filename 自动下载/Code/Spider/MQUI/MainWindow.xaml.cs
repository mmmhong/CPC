using Autofac;
using IService;
using NLC.CPC.IRepository;
using NLC.CPC.Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MQUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IContainer Container { get; set; }
         
        public MainWindow()
        {
            InitializeComponent();
            Register();
        }

        private void DoMigration_Click(object sender, RoutedEventArgs e)
        {
            string str = DoMigration.Content.ToString();
            if (str.Equals("启动消息队列"))
            {
                var d = Container.Resolve<IMigration>();
                d.DoMigration();
                //启动消息队列
                DoMigration.Content = "已启动";
            }
            else
            {
                DoMigration.Content = "启动消息队列";
            }
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 注册所需的类型
        /// </summary>
        public void Register()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<DAL>().As<IDAL>();//注册接口IDAL的实例DAL
                builder.RegisterType<Migration>().As<IMigration>();
                Container = builder.Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
