using Autofac;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.MQ;
using NLC.CPC.Repository;
using NLC.CPC.Service;
using System;
using System.Windows;

namespace DataMigration
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

        private void Btn_DownloadPatient_Click(object sender, RoutedEventArgs e)
        {
            var d = Container.Resolve<IMigration>();
            d.DoMigration();
        }

        private void Btn_DownloadRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Register()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<DAL>().As<IDAL>();
                builder.RegisterType<Migration>().As<IMigration>();
                Container = builder.Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var d = Container.Resolve<IMigration>();
            d.test();
        }
    }
}
