using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class ConfigString
    {
        public static string GetSourceDBConnectionString()
        {
            string json = File.ReadAllText("..\\..\\Config\\DownloadConfig.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            jo = JObject.Parse(jo["SourceDB"].ToString());

            string DBSource = jo["DBSource"].ToString();
            string DBUserName = jo["DBUserName"].ToString();
            string DBPwd = jo["DBPwd"].ToString();
            string DBName = jo["DBName"].ToString();
            return $"Data Source={DBSource};Initial Catalog={DBName};User ID={DBUserName};Password={DBPwd}";
        }
    }
}
