using Common.Context;
using Common.Model;
using NLC.CPC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Repository
{
    public class DAL : IDAL
    {
        public bool SavePatientList(List<string> patiList)
        {
            List<Patient> PatientList = new List<Patient>();

            using (var c = new MyContext())
            {
                PatientList = c.Patient.ToList();
            }
            //using (var myDBContext = new MyDBContext())
            //{
            //    foreach(string s in patiList)
            //    {
            //        myDBContext.Patient.Add(new Patient
            //        {
            //            PatientID = s
            //        });
            //        myDBContext.SaveChanges();
            //    }
            //}
            return true;
        }

        public bool SavePatientRecord()
        {
            throw new NotImplementedException();
        }

        public string test()
        {
            return "aaa";
        }
    }
}
