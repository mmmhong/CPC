using NLC.CPC.Infrastructure.Common;
using NLC.CPC.Infrastructure.TargetModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.Infrastructure.Context
{
    public class TargetDBContext : DbContext
    {
        public TargetDBContext() : base(GetConfig.GetTargetDBConnStr())
        {
           
        }
        static TargetDBContext()
        {
            Database.SetInitializer<TargetDBContext>(null);//EF不修改数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除负数表名的契约
        }

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<TargetDBContext>
        {
            public ReportingDbMigrationsConfiguration()
            {
                AutomaticMigrationsEnabled = true;//任何ModelClass的修改会直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }
        public DbSet<TbCaseReportFormData> TbCaseReportFormData { get; set; }
    }
}
