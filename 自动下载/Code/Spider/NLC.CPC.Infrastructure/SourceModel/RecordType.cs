using System.ComponentModel.DataAnnotations;

namespace NLC.CPC.Infrastructure.SourceModel
{
    public class RecordType
    {
        [Key]
        public int TypeID { get; set; }
        public string RecordName { get; set; }
    }
}
