using NLC.CPC.Infrastructure.Context;
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
        public void GetDataById(string id)
        {
            TbCaseReportFormData tbData = new TbCaseReportFormData();
            using (var sContext = new SourceDBContext())
            {
                // var temp = 
            }
        }

        public void GetFieldRelation()
        {
            List<KeyValuePair<string, string>> relation = new List<KeyValuePair<string, string>>();
            using (var sContext = new SourceDBContext())
            {
                var temp = from fr in sContext.FieldRelationship
                           select new { fr.Name1, fr.Name2 };
                foreach (var s in temp)
                {
                    relation.Add(new KeyValuePair<string, string>(s.Name1, s.Name2));
                }
            }
        }
    }
}
