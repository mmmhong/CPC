using BSF.BaseService.ConfigManager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure.Common
{
    public class GetConfig
    {


        /// <summary>
        /// 获取Cookie配置
        /// </summary>
        /// <returns></returns>
        public static string GetCookie
        {
            get { return ConfigManagerHelper.Get<string>("Cookie"); }
        }

        /// <summary>
        /// 获取源数据库连接配置
        /// </summary>
        /// <returns></returns>
        public static string GetSourceDBConnStr
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

        /// <summary>
        /// 获取目标数据库连接配置
        /// </summary>
        /// <returns></returns>
        public static string GetTargetDBConnStr
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
        /// 获取消息队列连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetManagerConnectStr
        {
            get { return ConfigManagerHelper.Get<string>("ManagerConnectionString"); }
        }

        public static string GetMqPath
        {
            get { return ConfigManagerHelper.Get<string>("mqpath"); }
        }

        public static string GetPostString
        {
            get { return ConfigManagerHelper.Get<string>("postString"); }
        }
    }
}
