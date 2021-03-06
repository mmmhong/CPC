﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLC.CPC.Infrastructure.TargetModel
{
    public class TbCaseReportFormData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }
        public string CaseReportFormData { get; set; }
        public string CreateName { get; set; }
        public long CreateID { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateName { get; set; }
        public long UpdateID { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
