using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://data.chinacpc.org/EVENT/GetDiagnosisTreatment?_=1521112559000&registerId=1eab4d86-ae14-4c63-8f31-01610b680784";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Cookie", ".ASPXAUTH=19D4A14EE89D3F5F63FDB80192FC6230C10C6C17E4E2D78C73673871090661F6D416B32B1D0162F5CE49260EA725BB3E53F0DA986BD127FA1433B0D709144DCB93B03E95E17F506589889B844891CFFFF7064CCFBEC2F6B09E380124AE7432F9");


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





            JObject obj = JObject.Parse(responseString);

            //foreach (var x in obj)
            //{
            //    if (x.Key.Equals("Result"))
            //    {
            //        responseString = x.Value.ToString();
            //    }
            //}
            //obj = JObject.Parse(responseString);

            foreach (var x in obj)
            {
                List<KeyValuePair<string, string>> field = new List<KeyValuePair<string, string>>();
                foreach (var y in (JObject)x.Value)
                {
                    if (y.Value.ToString() == "")
                    {
                        field.Add(new KeyValuePair<string, string>(y.Key, null));
                    }
                    else
                    {
                        field.Add(new KeyValuePair<string, string>(y.Key, y.Value.ToString()));
                    }
                }




            }










        }
    }
}
