using NLC.CPC.DBUtility.Context;
using NLC.CPC.DBUtility.Model;
using NLC.CPC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NLC.CPC.Repository
{
    public class DAL : IDAL
    {
        public bool SavePatientList(List<string> patiList)
        {

            //using (var c = new MyDBContext())
            //{
            //    List<Patient> a = c.Patient.ToList();
            //}
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
