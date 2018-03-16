using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDownload.Model
{
    /// <summary>
    /// 患者数据
    /// </summary>
    public class Patient
    {
        public int ArchivesID { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public string PatientAge { get; set; }
        public string ComingWay { get; set; }
        public string ArriveHospitalTime { get; set; }
        public string CreateTime { get; set; }
        public string FMCTime { get; set; }
        public string PreliDiagnosisResult { get; set; }
        public string PatientID { get; set; }
        public string AmbulantClinicID { get; set; }
        public string HospitalizationID { get; set; }
        public string Status { get; set; }
        public int IsStandard { get; set; }
    }

}
