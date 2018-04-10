using Autofac;
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
            ShowConfig();
            Register();//调用注册方法
        }

        /// <summary>
        /// 下载患者列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_DownloadPatient_Click(object sender, RoutedEventArgs e)
        {
            if (Cookie.Text.Trim() == "" || sDBUserName.Text.Trim() == "" || sDBPwd.Password.Trim() == "" || sDBName.Text.Trim() == "" || sDBSource.Text.Trim() == "")
            {
                MessageBox.Show("都填全了吗！！");
            }
            //存储配置
            SaveAppSettings();
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
                          if (d.downloadPatient())//调用下载Service层下载患者列表方法
                          {
                              return "患者列表下载完成！";
                          }
                          else
                          {
                              return "下载出错";
                          }
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
            if (Cookie.Text.Trim() == "" || sDBUserName.Text.Trim() == "" || sDBPwd.Password.Trim() == "" || sDBName.Text.Trim() == "" || sDBSource.Text.Trim() == "")
            {
                MessageBox.Show("都填全了吗！！");
                return;
            }
            //存储配置
            SaveAppSettings();

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
                    if (d.downloadRecord())
                    {
                        return "病历下载完成";
                    }
                    else
                    {
                        return "病历下载失败";
                    }
                }
                catch(Exception e)
                {
                    return e.Message;
                }
            });
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {
            SaveAppSettings();
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
        /// 从Config文件中读取配置信息显示在屏幕上
        /// </summary>
        public void ShowConfig()
        {
            string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
            JObject jo = JObject.Parse(json);

            JObject tempJo = JObject.Parse(jo["SourceDB"].ToString());
            Cookie.Text = jo["Cookie"].ToString();
            sDBName.Text = tempJo["DBName"].ToString();
            sDBPwd.Password = tempJo["DBPwd"].ToString();
            sDBUserName.Text = tempJo["DBUserName"].ToString();
            sDBSource.Text = tempJo["DBSource"].ToString();
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

        /// <summary>
        /// 存储配置信息
        /// </summary>
        public void SaveAppSettings()
        {
            try
            {
                string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
                JObject jo = JObject.Parse(json);
                JObject temp = JObject.Parse(jo["SourceDB"].ToString());
                temp["DBName"] = sDBName.Text;
                temp["DBPwd"] = sDBPwd.Password;
                temp["DBUserName"] = sDBUserName.Text;
                temp["DBSource"] = sDBSource.Text;
                jo["SourceDB"] = temp;


                File.WriteAllText("..\\..\\Config\\DownloadConfig.json", jo.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
