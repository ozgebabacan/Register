using Register.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repository
{
    public class EFDBContext : DbContext
    {
        #region CTor

        public EFDBContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDBContext, Migrations.Configuration>());
            Database.Connection.ConnectionString = "data source=DESKTOP-ICATKDO\\SQLEXPRESS;initial catalog=Register;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }

        //public EFDBContext() : base("EFDBContext") // For migration
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDBContext, Migrations.Configuration>());
        //    Configuration.LazyLoadingEnabled = true;
        //    Configuration.ProxyCreationEnabled = true;
        //}


        //public EFDBContext(string connectionString)
        //{
        //   // Database.Connection.ConnectionString = "Server=.; database=HR_BursBasvuru; User Id=btdev; Password=RDk=4z!2";
        //    Database.Connection.ConnectionString = connectionString;
        //    Configuration.LazyLoadingEnabled = true;
        //    Configuration.ProxyCreationEnabled = true;
        //}

        #endregion
        #region DbSets

        public DbSet<Student> Student { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
       
        #endregion

        #region Override Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFDBContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        #endregion
    }
}
