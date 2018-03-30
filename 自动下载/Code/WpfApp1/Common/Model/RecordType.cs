using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class RecordType
    {
        [Key]
        public int TypeID { get; set; }
        public string RecordName { get; set; }
    }
}
