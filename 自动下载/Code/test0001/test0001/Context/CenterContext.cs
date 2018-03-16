using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace test0001
{
    public class CenterContext : DbContext
    {
        public CenterContext() : base("CenterContext")
        {
           // Database.SetInitializer<MyDbContext>(new MigrateDatabaseToLatestVersion<MyDbContext,ReportingDbMigrationsConfiguration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除负数表名的契约
        }

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<MyDbContext>
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
