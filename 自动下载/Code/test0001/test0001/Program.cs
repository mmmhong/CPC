using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace test0001
{
    class Program
    {
        public static List<Patient> PatientList = null;
        public static List<HelpModel> Relation = new List<HelpModel>();
        public static long t = DateTime.Now.Ticks;
        public static long Id = Convert.ToInt64(("8" + (t.ToString()).Substring((t.ToString()).Length - 12)));
        static void Main(string[] args)
        {
            GetPatient();
            Console.WriteLine("已获取所有用户");
            GetFieldsRelation();
            Console.WriteLine("已获取新老字段关系");
            PatientList.ForEach(p =>
            {
                string str = GetData(p.PatientID);
                WriteIN(str);
            });
            Console.WriteLine("数据已转移");
            Console.ReadKey();
        }

        public static void WriteIN(string str)
        {
            using (var centerContext = new CenterContext())
            {
                centerContext.TbCaseReportFormData.Add(new TbCaseReportFormData
                {
                    ID = Id--,
                    CaseReportFormData = str,
                    CreateName = "管理员",
                    CreateID = 300900001,
                    CreateTime = DateTime.Now,
                    UpdateName = "管理员",
                    UpdateID = 300900001,
                    UpdateTime = DateTime.Now,
                    IsDeleted = false
                });
                centerContext.SaveChanges();
            }
        }


        public static string GetData(string patientID)
        {
            TbCaseReportFormData tbData = new TbCaseReportFormData();

            string str = "{";
            using (var dbContext = new MyDbContext())
            {
                var temp = from f in dbContext.FieldTable
                           where f.RecordID == 1
                           select f.ID;
                List<int> l = temp.ToList();

                var t = from d in dbContext.Data
                        join f in dbContext.FieldTable
                        on d.FieldID equals f.ID
                        where d.PatientID == patientID
                        //where l.Contains(d.FieldID)
                        orderby d.FieldID
                        select new { f.Name, d.FieldValue };
                foreach (var s in t)
                {
                   // bool flag = true;
                    foreach (var v in Relation)
                    {
                        //if (flag == false)
                           // break;
                        if (v.Name1.Equals(s.Name))
                        {
                           // flag = false;
                            str += $"\"{v.Name2}\":\"{s.FieldValue}\",";
                        }
                    }
                    //if (flag == true)
                    //{
                    //    str += $"\"{s.Name}\":\"{s.FieldValue}\",";
                    //}
                    //Console.WriteLine(s.Name+":"+s.FieldValue);
                }
                str = str.Remove(str.Length - 1);
                str += "}";
                // Console.WriteLine(str);
                return str;
            }
        }

        /// <summary>
        /// 获取病人
        /// </summary>
        public static void GetPatient()
        {
            using (var dbContext = new MyDbContext())
            {

                PatientList = dbContext.Patient.ToList();
            }
        }

        public static void GetFieldsRelation()
        {
            using (var dbContext = new MyDbContext())
            {
                var temp = from fr in dbContext.FieldRelationship
                           select new { fr.Name1, fr.Name2 };

                foreach (var s in temp)
                {
                    Relation.Add(new HelpModel(s.Name1, s.Name2));
                    Console.WriteLine(s.Name1 + ":" + s.Name2);
                }
            }
        }
    }
}
