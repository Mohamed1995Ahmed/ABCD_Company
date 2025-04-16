using ABCD.Company.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABCD.Company.Data
{
    public class AppDBcontext:IdentityDbContext<AppUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AppUser> User { get; set; }
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var config = new ConfigurationBuilder()
            //             .SetBasePath(Directory.GetCurrentDirectory())
            //             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //             .Build();
            //string connectionString = config.GetConnectionString("constr");
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString,
            //    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
