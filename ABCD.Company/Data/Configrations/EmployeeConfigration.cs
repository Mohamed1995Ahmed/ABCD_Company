using ABCD.Company.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ABCD.Company.Data.Configrations
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id); //PK
            builder.Property(e => e.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(30);
            builder.HasOne(x=>x.Department).WithMany(x=>x.Emps).OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
