using NLC.CPC.DBUtility.Model;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NLC.CPC.DBUtility.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("PatientContext")
        {
        }
        static MyDBContext()
        {
            Database.SetInitializer<MyDBContext>(null);//EF不修改数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除复数表名的契约
        }

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<MyDBContext>
        {
            public ReportingDbMigrationsConfiguration()
            {
                AutomaticMigrationsEnabled = true;//任何ModelClass的修改会直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        public DbSet<Patient> Patient { get; set; }

    }

}
