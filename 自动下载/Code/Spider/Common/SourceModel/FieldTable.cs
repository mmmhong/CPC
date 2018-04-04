using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SourceModel
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
