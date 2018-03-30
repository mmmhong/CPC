using Common.Context;
using Common.Model;
using NLC.CPC.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Repository
{
    public class DAL : IDAL
    {
        /// <summary>
        /// 获取患者列表
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatientList()
        {
            using (var d = new MyContext())
            {
                return d.Patient.ToList();
            }
        }

        /// <summary>
        /// 存储患者列表
        /// </summary>
        /// <param name="patientList"></param>
        /// <returns></returns>
        public bool SavePatientList(List<string> patientList)
        {
            try
            {
                using (var myDBContext = new MyContext())
                {
                    var list = myDBContext.Patient.Where(p => p.SaveState > -1).ToList();
                    foreach (var l in list)
                    {
                        myDBContext.Patient.Remove(l);
                    }
                    myDBContext.SaveChanges();
                    foreach (string s in patientList)
                    {
                        myDBContext.Patient.Add(new Patient
                        {
                            PatientID = s,
                            SaveState = 0
                        });
                        myDBContext.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                //插入重复值
            }
            return true;
        }

        /// <summary>
        /// 存储患者病历
        /// </summary>
        /// <returns></returns>
        public bool SavePatientRecord(List<KeyValuePair<string, string>> list, string id, string recorddName)
        {
            using (var context = new MyContext())
            {
                var temp = from r in context.RecordType
                           where r.RecordName == recorddName
                           select r.TypeID;
                List<int> recordID = temp.ToList();
                int d = recordID[0];

                foreach (var v in list)
                {
                    temp = from f in context.FieldTable
                           where f.Name == v.Key
                           where f.RecordID == d
                           select f.ID;
                    var fieldID = temp.ToList();


                    context.Data.Add(new Data
                    {
                        FieldID = fieldID[0],
                        PatientID = id,
                        FieldValue = v.Value
                    });
                    context.SaveChanges();
                }
            }


            return true;

        }

        /// <summary>
        /// TEST
        /// </summary>
        /// <returns></returns>
        public string test()
        {
            return "aaa";
        }
    }
}
