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
        public static string GetCookie()
        {
            string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            string cookie = jo["Cookie"].ToString();
            return cookie;
        }

        /// <summary>
        /// 获取源数据库连接配置
        /// </summary>
        /// <returns></returns>
        public static string GetSourceDBConnStr()
        {
            string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            jo = JObject.Parse(jo["SourceDB"].ToString());
            string connStr = $"Data Source={jo["DBSource"].ToString()};Initial Catalog={jo["DBName"].ToString()};User ID={jo["DBUserName"].ToString()};Password={jo["DBPwd"].ToString()}";
            return connStr;
        }

        /// <summary>
        /// 获取目标数据库连接配置
        /// </summary>
        /// <returns></returns>
        public static string GetTargetDBConnStr()
        {
            string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            jo = JObject.Parse(jo["TargetDB"].ToString());
            string connStr = $"Data Source={jo["DBSource"].ToString()};Initial Catalog={jo["DBName"].ToString()};User ID={jo["DBUserName"].ToString()};Password={jo["DBPwd"].ToString()}";
            return connStr;
        }

        /// <summary>
        /// 获取消息队列连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetManagerConnectStr()
        {
            string json = File.ReadAllText("..\\..\\Config\\MQString.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            string str = jo["ManagerConnectionString"].ToString();
            return jo["ManagerConnectionString"].ToString();
        }

        public static string GetMqPath()
        {
            string json = File.ReadAllText("..\\..\\Config\\MQString.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            return jo["mqpath"].ToString();
        }
    }
}
