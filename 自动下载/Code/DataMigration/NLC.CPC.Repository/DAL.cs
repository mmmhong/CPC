using NLC.CPC.Infrastructure.Context;
using NLC.CPC.Infrastructure.Model;
using NLC.CPC.Infrastructure.SourceModel;
using NLC.CPC.Infrastructure.TargetModel;
using NLC.CPC.IRepository;
using NLC.CPC.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Repository
{
    public class DAL : IDAL
    {
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
        /// 获取患者病历解析格式
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
        /// 保存患者病历
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
                    CreateID=123456789456,
                    CreateTime=DateTime.Now,
                    UpdateName = "雷小峰",
                    UpdateID=123456,
                    UpdateTime=DateTime.Now,
                    IsDeleted=false
                });
                tContext.SaveChanges();
            }

                return true;
        }

        public bool ChangeState(string id)
        {
            SourceDBContext sContext = new SourceDBContext();
            Patient p = sContext.Patient.Where(d => d.PatientID == id).FirstOrDefault();
            p.SaveState = 1;
            sContext.SaveChanges();

            return true;
        }
    }
}
