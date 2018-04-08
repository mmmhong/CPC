using System.ComponentModel.DataAnnotations;

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
