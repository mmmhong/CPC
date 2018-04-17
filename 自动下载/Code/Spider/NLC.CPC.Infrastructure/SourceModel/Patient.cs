using System.ComponentModel.DataAnnotations;

namespace NLC.CPC.Infrastructure.SourceModel
{
    public class Patient
    {
        [Key]
        public string PatientID { get; set; }
        public int SaveState { get; set; }
    }
}
