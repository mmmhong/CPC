using NLC.CPC.Infrastructure.Context;
using NLC.CPC.Infrastructure.Model;
using NLC.CPC.Infrastructure.SourceModel;
using NLC.CPC.Infrastructure.TargetModel;
using NLC.CPC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            using (var d = new SourceDBContext())
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
            using (var myDBContext = new SourceDBContext())
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
            return true;
        }

        /// <summary>
        /// 存储患者病历
        /// </summary>
        /// <returns></returns>
        public bool SavePatientRecord(List<KeyValuePair<string, string>> list, string id, string recorddName)
        {
            using (var context = new SourceDBContext())
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

                    if (fieldID.Count != 0)
                    {
                        context.Data.Add(new Data
                        {
                            FieldID = fieldID[0],
                            PatientID = id,
                            FieldValue = v.Value
                        });
                        context.SaveChanges();
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 根据字段关系表解析患者病历
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldRelation"></param>
        /// <returns></returns>
        public string GetDataByID(string id, List<HelpModel> fieldRelation)
        {
            string str = "{";
            using (var sContext = new SourceDBContext())
            {
                var temp = from f in sContext.FieldTable
                           where f.RecordID == 1
                           select f.ID;
                List<int> l = temp.ToList();

                var t = from d in sContext.Data
                        join f in sContext.FieldTable
                        on d.FieldID equals f.ID
                        where d.PatientID == id
                        //where l.Contains(d.FieldID)
                        orderby d.FieldID
                        select new { f.Name, d.FieldValue };
                foreach (var s in t)
                {
                    foreach (var v in fieldRelation)
                    {
                        if (v.Name1.Equals(s.Name))
                        {
                            str += $"\"{v.Name2}\":\"{s.FieldValue}\",";
                        }
                    }
                }
                str = str.Remove(str.Length - 1);
                str += "}";
                return str;
            }
        }

        /// <summary>
        /// 患者病历保存到迁移数据库
        /// </summary>
        /// <param name="record"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SaveData(string record, string id)
        {
            long t = DateTime.Now.Ticks;
            long t2 = Convert.ToInt64(("8" + (t.ToString()).Substring((t.ToString()).Length - 12)));
            using (var tContext = new TargetDBContext())
            {
                tContext.TbCaseReportFormData.Add(new TbCaseReportFormData
                {
                    ID = t2--,
                    CaseReportFormData = record,
                    CreateName = "雷锋",
                    CreateID = 123456789456,
                    CreateTime = DateTime.Now,
                    UpdateName = "雷小峰",
                    UpdateID = 123456,
                    UpdateTime = DateTime.Now,
                    IsDeleted = false
                });
                tContext.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// 获取字段关系表
        /// </summary>
        /// <returns></returns>
        public List<HelpModel> GetFieldRelation()
        {
            List<HelpModel> relation = new List<HelpModel>();
            using (var sContext = new SourceDBContext())
            {
                var temp = from fr in sContext.FieldRelationship
                           select new { fr.Name1, fr.Name2 };
                foreach (var s in temp)
                {
                    relation.Add(new HelpModel(s.Name1, s.Name2));
                }
            }
            return relation;
        }

        /// <summary>
        /// 修改已经迁移的ID状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ChangeState(string id)
        {
            SourceDBContext sContext = new SourceDBContext();
            Patient p = sContext.Patient.Where(d => d.PatientID == id).FirstOrDefault();
            p.SaveState = 1;
            sContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// 获取当前ID号的状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetState(string id)
        {
            SourceDBContext sContext = new SourceDBContext();
            var temp = from p in sContext.Patient
                       where p.PatientID == id
                       select p.SaveState;
            return Convert.ToInt32(temp);
        }

        /// <summary>
        /// 存储字典类型数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveDataAsCPC(string id, string data)
        {
            using (var context = new SourceDBContext())
            {
                context.CPCData.Add(new CPCData
                {
                    Id = id,
                    Data = data
                });
                context.SaveChanges();
            }
            return true;
        }
    }
}
