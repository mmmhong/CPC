using System.IO;
using System.Net;
using System.Text;

namespace NLC.CPC.Infrastructure.Common
{
    public class SimulationRequest
    {
        /// <summary>
        /// 获取response解析后的字符串
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetResponseString(HttpWebRequest request)
        {
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }
            string responseString = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            return responseString;
        }
    }
}
