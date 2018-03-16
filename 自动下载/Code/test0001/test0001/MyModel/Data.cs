using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace test0001
{
    public class Data
    {
        [Key]
        public int DataID { get; set; }
        public int FieldID { get; set; }
        public string PatientID { get; set; }
        public string FieldValue { get; set; }
    }
}
