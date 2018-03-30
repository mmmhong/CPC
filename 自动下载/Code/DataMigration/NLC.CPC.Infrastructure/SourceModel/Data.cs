using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure.SourceModel
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
