using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace test0001
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("PatientContext")
        {
        }
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(null);//EF不修改数据库
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

        public DbSet<FieldTable> FieldTable { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<FieldRelationship> FieldRelationship { get; set; }
    }
}
