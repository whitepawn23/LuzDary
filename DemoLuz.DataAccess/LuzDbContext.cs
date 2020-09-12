using DemoLuz.Core.Environment;
using DemoLuz.DataAccess.Core.EF.Base;
using DemoLuz.DataAccess.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DemoLuz.DataAccess
{
    public class LuzDbContext : BaseContext
    {
        public LuzDbContext(IApplicationEnvironment ae) : base(ae)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Logger> Logger { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Company>().ToTable("Companies")
              .HasMany(e => e.Employees)
              .WithRequired(e => e.Company)
              .HasForeignKey(e => e.CompanyId);
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Logger>().ToTable("Logger");
        }
    }
}
