using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private CookieContainer cookie = new CookieContainer();

        public Form1()
        {
            InitializeComponent();
            string checkcodeUrl = "http://data.chinacpc.org/_MvcCaptcha/MvcCaptchaImage?65cf5e6220874155aca746ccc0a16dc8&1519812738775";

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(checkcodeUrl);

                request.CookieContainer = new CookieContainer();

                Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();

                cookie = request.CookieContainer;

                string cookiesstr = request.CookieContainer.GetCookieHeader(request.RequestUri);

                Image original = Image.FromStream(responseStream);

                Bitmap bitMap = new Bitmap(original);

                this.pictureBox1.Image = bitMap;

                responseStream.Close();

            }
            catch (Exception exception)
            {

                MessageBox.Show("ERROR:" + exception.Message);

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
