using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace test0001
{
    public class TbFormField
    {
        [Key]
        public long ID { get; set; }
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }
        public int FieldValueType { get; set; }
        public int RequiredType { get; set; }
        public long VisibleRuleID { get; set; }
        public int HasDefaultValue { get; set; }
        public string DefaultValue { get; set; }

    }
}
