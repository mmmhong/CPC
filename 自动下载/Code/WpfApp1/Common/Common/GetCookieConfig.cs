using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class GetCookieConfig
    {
        public string GetCookie()
        {
            string json = File.ReadAllText("..\\..\\Config\\Config.json", Encoding.Default);
            JObject jo = JObject.Parse(json);
            string cookie = jo["Cookie"].ToString();
            return cookie;
        }
    }
}
