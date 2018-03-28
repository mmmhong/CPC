using NLC.CPC.DBUtility.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.DBUtility.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("PatientContext")
        {
            var d = Database;
        }
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);//EF不修改数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除复数表名的契约
        }

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<MyContext>
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
