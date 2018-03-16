using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace test0001
{
    public class RecordType
    {
        [Key]
        public int TypeID { get; set; }
        public string RecordName { get; set; }
    }
}
