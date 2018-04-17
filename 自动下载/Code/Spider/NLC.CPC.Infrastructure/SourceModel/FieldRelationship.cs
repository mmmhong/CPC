using System.ComponentModel.DataAnnotations;

namespace NLC.CPC.Infrastructure.SourceModel
{
    public class FieldRelationship
    {
        [Key]
        public int FRID { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string ChineseName { get; set; }
    }
}
