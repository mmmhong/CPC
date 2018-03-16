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
using 不带登录的自动下载.DAL;

namespace 不带登录的自动下载
{
    public partial class Form1 : Form
    {
        List<string> PatientList = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllPatient getPatient = new GetAllPatient();
            string responseString = getPatient.Do();

          //  WriteIdToTXT write = new WriteIdToTXT();
           // PatientList = write.Do(responseString);
            Print();

        }

        /// <summary>
        /// 存储用户ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if(PatientList.Count<=0)
            {
                MessageBox.Show("请先获取所有用户");
            }
            SqlDAL dal = new SqlDAL();
            dal.SaveId(PatientList);
            MessageBox.Show("数据库用户列表已更新");
        }

        /// <summary>
        /// 获取病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(PatientList == null)
            {
                MessageBox.Show("请先获取所有用户");
                return;
            }
            GetByID getByID = new GetByID();
            DoData dodata = new DoData();
            foreach (string s in PatientList)
            {
                dodata.Do(s);
                //string str = getByID.Do(s);
                //getByID.JieXiBingLi(str,s,true);
            }
            MessageBox.Show("已获取所有用户病例");
        }

        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            GetByID get = new GetByID();
            string str = get.Do("abc");
            get.JieXiBingLi(str, "abc", false);
            MessageBox.Show("所有字段已导入数据库");
        }

        /// <summary>
        /// 打印ID
        /// </summary>
        public void Print()
        {
            if(PatientList==null)
            {
                MessageBox.Show("患者列表为空!!");
                return;
            }
            foreach (string s in PatientList)
            {
                textBox1.Text += s + "\r\n";
            }
            textBox1.Text += $"total:{PatientList.Count}";
            MessageBox.Show("患者获取完成，总数" + PatientList.Count);
        }
    }
}
