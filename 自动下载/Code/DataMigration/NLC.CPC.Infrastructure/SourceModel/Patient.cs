using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure.SourceModel
{
    public class Patient
    {
        [Key]
        public string PatientID { get; set; }
        public int SaveState { get; set; }
    }
}
