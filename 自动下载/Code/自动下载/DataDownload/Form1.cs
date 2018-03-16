using DataDownload.Model;
using Newtonsoft.Json;
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

namespace DataDownload
{
    public partial class Form1 : Form
    {
        private List<int> IDList = null;

        public Form1()
        {
            InitializeComponent();
            button1.BringToFront();
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string postUrl = "http://192.168.1.249:30090/OpenAPI//UserAccount/UserLogin";
            string postString = "{\"UserName\":\"cpc\",\"UserPwd\":\"202cb962ac59075b964b07152d234b70\"}";
            ResultBox1.Text = new DoConnection().getToken((new DoConnection().GetStr(postUrl, postString)));
        }

        /// <summary>
        /// 获取所有用户的ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (ResultBox1.Text == "")
            {
                MessageBox.Show("清先获取Token!");
                return;
            }
            string postUrl = "http://192.168.1.249:30090/OpenAPI//EmergencyArchives/GetEmergencyArchiveses";
            string postString = "{\"Condition\":{\"IsBypassEmergency\":-1,\"IsBypassCCU\":-1,\"IsHaveThrombolysis\":-1,\"IsRemoteECGTrans\":-1},\"PageIndex\":1,\"PageSize\":1000}";
            string str = new DoConnection().GetStr(postUrl, postString);
            IDList = new DoConnection().getID(str);
            if (IDList.Count == 0)
            {
                MessageBox.Show("无患者信息");
                return;
            }
            ResultBox2.Text = "";
            foreach (int i in IDList)
            {
                ResultBox2.Text += i + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string postUrl = "http://data.chinacpc.org/ ";
            string postString = "{\"UserName\":\"cpc\",\"UserPwd\":\"202cb962ac59075b964b07152d234b70\"}";
        }

        private void Test_Click(object sender, EventArgs e)
        {
            string postUrl = "http://data.chinacpc.org/";
            string postString = "";


            var request = (HttpWebRequest)WebRequest.Create(postUrl);

            //var data = Encoding.ASCII.GetBytes(postString);

            request.Method = "GET";
            request.ContentType = "text/html; charset=utf-8";
            //request.ContentLength = data.Length;

            var response = (HttpWebResponse)request.GetResponse();
            var result = request.GetResponse();

            List<string> list = result.Headers.GetValues("Set-Cookie").ToList();



            //HttpWebResponse res;
            //try
            //{
            //    res = (HttpWebResponse)request.GetResponse();
            //}
            //catch (WebException ex)
            //{
            //    res = (HttpWebResponse)ex.Response;
            //}
            //string responseString = new StreamReader(res.GetResponseStream()).ReadToEnd();
            //var str = new StreamReader(res.GetResponseHeader(""));


            //Test b = JsonConvert.DeserializeObject<Test>(responseString);


            //ResultBox2.Text = responseString;
        }
    }
}
