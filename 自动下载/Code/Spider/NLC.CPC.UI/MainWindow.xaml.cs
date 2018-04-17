using Autofac;
using BSF.BaseService.ConfigManager;
using IService;
using Newtonsoft.Json.Linq;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.Repository;
using NLC.CPC.Service;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace DownloadUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Autofac.IContainer Container { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string DBConnStr = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
            Register();//调用注册方法
        }

        /// <summary>
        /// 下载患者列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_DownloadPatient_Click(object sender, RoutedEventArgs e)
        {
          
            string str = await DownloadPatient();
            MessageBox.Show(str);
        }

        /// <summary>
        /// 自定义下载患者列表方法
        /// </summary>
        /// <returns></returns>
        public async Task<string> DownloadPatient()
        {
            return await Task.Run(() =>
              {
                  try
                  {
                      MessageBox.Show("已开始下载患者");
                      //创建一个新的生命周期范围
                      using (var scope = Container.BeginLifetimeScope())
                      {
                          Thread.Sleep(100);
                          var d = scope.Resolve<IDownload>();//解析接口的实例
                          d.downloadPatient();//调用下载Service层下载患者列表方法
                          return "患者列表下载完成！";
                      }
                  }
                  catch (Exception e)
                  {
                      return e.Message;
                  }
              });
        }

        /// <summary>
        /// 下载病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_DownloadRecord_Click(object sender, RoutedEventArgs e)
        {
            
            string str = await DownloadRecord();
            MessageBox.Show(str);
        }

        /// <summary>
        /// 自定义下载病历方法
        /// </summary>
        /// <returns></returns>
        public async Task<string> DownloadRecord()
        {
            return await Task.Run(() =>
            {
                try
                {
                    MessageBox.Show("已开始下载病历");
                    var d = Container.Resolve<IDownload>();
                    d.downloadRecord();
                    return "病历下载完成";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            });
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region 自定义方法

        /// <summary>
        /// 从Config文件中读取配置中心配置字符串，再从配置中心读取配置显示在屏幕上
        /// </summary>
        public void LoadConfig()
        {
            BSF.Config.BSFConfig.ProjectName = "Spider";
            BSF.Config.BSFConfig.ConfigManagerConnectString = "server = 192.168.4.87; Initial Catalog = dyd_bs_configmanager; User ID = sa; Password = 123456; ";
        }

        /// <summary>
        /// 注册所需的类型
        /// </summary>
        public void Register()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<Download>().As<IDownload>();//注册接口IDowmload的实例Download
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

        #endregion

    }
}
