using Autofac;
using IService;
using Newtonsoft.Json.Linq;
using NLC.CPC.IRepository;
using NLC.CPC.Repository;
using Service;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            ShowConfig();
            Register();
        }

        private void DoMigration_Click(object sender, RoutedEventArgs e)
        {
            SaveAppSettings();
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
                return;
            }
        }

        /// <summary>
        /// 清空消息队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearMQ_Click(object sender, RoutedEventArgs e)
        {
            var d = Container.Resolve<IMigration>();
            if (d.ClearMQ())
            {
                MessageBox.Show("消息队列已清空");
                Restart();
            }
            else
            {
                MessageBox.Show("消息队列错误");
            }
            Application.Current.Shutdown();
        }

        public void Restart()
        {
            Process p = new Process();
            p.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + "NLC.CPC.MQUI.exe";
            p.StartInfo.UseShellExecute = false;
            p.Start();
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

        /// <summary>
        /// 从Config文件中读取配置信息显示在屏幕上
        /// </summary>
        public void ShowConfig()
        {
            try
            {
                string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
                JObject jo = JObject.Parse(json);

                JObject tempJo = JObject.Parse(jo["SourceDB"].ToString());
                sDBName.Text = tempJo["DBName"].ToString();
                sDBPwd.Password = tempJo["DBPwd"].ToString();
                sDBUserName.Text = tempJo["DBUserName"].ToString();
                sDBSource.Text = tempJo["DBSource"].ToString();

                tempJo = JObject.Parse(jo["TargetDB"].ToString());
                tDBName.Text = tempJo["DBName"].ToString();
                tDBPwd.Password = tempJo["DBPwd"].ToString();
                tDBUserName.Text = tempJo["DBUserName"].ToString();
                tDBSource.Text = tempJo["DBSource"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                temp = JObject.Parse(jo["TargetDB"].ToString());
                temp["DBName"] = tDBName.Text;
                temp["DBPwd"] = tDBPwd.Password;
                temp["DBUserName"] = tDBUserName.Text;
                temp["DBSource"] = tDBSource.Text;
                jo["TargetDB"] = temp;
                File.WriteAllText("..\\..\\Config\\DownloadConfig.json", jo.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool JudgeInputNull()
        {

            return true;
        }


    }
}
