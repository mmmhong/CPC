using NLC.CPC.DBUtility.Context;
using NLC.CPC.DBUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.DBUtility
{
    class Class1
    {
        static void Main(string[] args)
        {
            List<Patient> PatientList = new List<Patient>();
            using (var dbContext = new MyContext())
            {
                PatientList = dbContext.Patient.ToList();
            }
        }
    }
}
