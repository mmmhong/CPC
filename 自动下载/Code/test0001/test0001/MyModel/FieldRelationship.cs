using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace test0001
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
