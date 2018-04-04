using Common.SourceModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Context
{
    public class SourceDBContext : DbContext
    {
        public SourceDBContext() : base("SourceContext")
        {
            var d = Database;
        }
        static SourceDBContext()
        {
            Database.SetInitializer<SourceDBContext>(null);//EF不修改数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除复数表名的契约
        }

        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<SourceDBContext>
        {
            public ReportingDbMigrationsConfiguration()
            {
                AutomaticMigrationsEnabled = true;//任何ModelClass的修改会直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<FieldTable> FieldTable { get; set; }
        public DbSet<RecordType> RecordType { get; set; }
        public DbSet<FieldRelationship> FieldRelationship { get; set; }
    }
}
