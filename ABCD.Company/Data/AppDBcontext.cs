using ABCD.Company.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCD.Company.Data
{
    public class AppDBcontext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDBcontext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .Build();
            string connectionString = config.GetConnectionString("constr");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
