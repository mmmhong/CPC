using System.ComponentModel.DataAnnotations;

namespace NLC.CPC.Infrastructure.SourceModel
{
    public class FieldTable
    {
        [Key]
        public int ID { get; set; }
        public int RecordID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
