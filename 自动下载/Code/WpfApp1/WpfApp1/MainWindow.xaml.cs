using Autofac;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using NLC.CPC.Repository;
using NLC.CPC.Service;
using System;
using System.Configuration;
using System.Windows;
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IContainer Container { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string DBConnStr = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            Cookie.Text = Convert.ToString(ConfigurationManager.AppSettings["Cookie"]);
            DBName.Text = Convert.ToString(ConfigurationManager.AppSettings["DBName"]);
            DBPwd.Password = Convert.ToString(ConfigurationManager.AppSettings["DBPwd"]);
            DBUserName.Text = Convert.ToString(ConfigurationManager.AppSettings["DBUserName"]);
            DBSource.Text = Convert.ToString(ConfigurationManager.AppSettings["DBSource"]);

            Register();//调用注册方法
        }

        /// <summary>
        /// 下载患者列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DownloadPatient_Click(object sender, RoutedEventArgs e)
        {
            if (Cookie.Text.Trim() == "" || DBUserName.Text.Trim() == "" || DBPwd.Password.Trim() == "" || DBName.Text.Trim() == "")
            {
                MessageBox.Show("都填全了吗！！");
                return;
            }
            //存储配置
            SaveAppSettings();

            //创建一个新的生命周期范围
            using (var scope = Container.BeginLifetimeScope())
            {
                var d = scope.Resolve<IDownload>();//解析接口的实例
                //MessageBox.Show($"{a.test()}");
                if(d.downloadPatient())//调用下载Service层下载患者列表方法
                {
                    MessageBox.Show("患者列表下载完成！");
                }
            }
        }

        /// <summary>
        /// 下载病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DownloadRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Cookie.Text.Trim() == "" || DBUserName.Text.Trim() == "" || DBPwd.Password.Trim() == "" || DBName.Text.Trim() == "")
            {
                MessageBox.Show("都填全了吗！！");
                return;
            }
            //存储配置
            SaveAppSettings();
            var d = Container.Resolve<IDownload>();
            if (d.downloadRecord())
            {
                MessageBox.Show("病历下载完成");
            }

        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {

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
        /// 注册所需的类型
        /// </summary>
        public void Register()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<Download>().As<IDownload>();//注册接口IDowmload的实例Download
                builder.RegisterType<DAL>().As<IDAL>();//注册接口IDAL的实例DAL
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
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Cookie"].Value = Cookie.Text;
                config.AppSettings.Settings["DBName"].Value = DBName.Text;
                config.AppSettings.Settings["DBPwd"].Value = DBPwd.Password;
                config.AppSettings.Settings["DBUserName"].Value = DBUserName.Text;
                config.Save(ConfigurationSaveMode.Modified); ConfigurationManager.RefreshSection("appSettings");
                DBConnStr = $"Data Source={DBSource.Text};Initial Catalog={DBName.Text};Persist Security Info=True;User ID={DBUserName.Text};Password={DBPwd.Password}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
