using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure.Common
{
    public class SimulationRequest
    {
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
