using BSF.BaseService.ConfigManager;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace NLC.CPC.Infrastructure.Common
{
    public class GetConfig
    {
        /// <summary>
        /// Cookie配置
        /// </summary>
        /// <returns></returns>
        public static string Cookie
        {
            get { return ConfigManagerHelper.Get<string>("Cookie"); }
        }

        /// <summary>
        /// 获取源数据库连接配置
        /// </summary>
        public static string SourceDBConnStr
        {
            get
            {
                string DBSource = ConfigManagerHelper.Get<string>("sDBSource");
                string DBName = ConfigManagerHelper.Get<string>("sDBName");
                string sDBUsername = ConfigManagerHelper.Get<string>("sDBUserName");
                string DBPwd = ConfigManagerHelper.Get<string>("sDBPwd");

                string connStr = $"Data Source={DBSource};Initial Catalog={DBName};User ID={sDBUsername};Password={DBPwd}";
                return connStr;
            }
        }

        public static string SourceDBConnStrInConfig
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ConfigCenter.json";
                string json = File.ReadAllText(path, Encoding.Default);

                string DBSource = (JObject.Parse(json))["sDBSource"].ToString();
                string DBName = (JObject.Parse(json))["sDBName"].ToString();
                string sDBUsername = (JObject.Parse(json))["sDBUserName"].ToString();
                string DBPwd = (JObject.Parse(json))["sDBPwd"].ToString();

                string connStr = $"Data Source={DBSource};Initial Catalog={DBName};User ID={sDBUsername};Password={DBPwd}";
                return connStr;
            }
        }


        /// <summary>
        /// 目标数据库连接配置
        /// </summary>
        public static string TargetDBConnStr
        {
            get
            {
                string DBSource = ConfigManagerHelper.Get<string>("tDBSource");
                string DBName = ConfigManagerHelper.Get<string>("tDBName");
                string sDBUsername = ConfigManagerHelper.Get<string>("tDBUserName");
                string DBPwd = ConfigManagerHelper.Get<string>("tDBPwd");

                string connStr = $"Data Source={DBSource};Initial Catalog={DBName};User ID={sDBUsername};Password={DBPwd}";
                return connStr;
            }
        }

        /// <summary>
        /// 消息队列连接字符串
        /// </summary>
        public static string ManagerConnectStr
        {
            get { return ConfigManagerHelper.Get<string>("ManagerConnectionString"); }
        }

        /// <summary>
        /// 消息队列名称
        /// </summary>
        public static string MqPath
        {
            get { return ConfigManagerHelper.Get<string>("mqpath"); }
        }

        /// <summary>
        /// 患者请求字符串
        /// </summary>
        public static string PostString
        {
            get { return ConfigManagerHelper.Get<string>("postString"); }
        }
    }
}
