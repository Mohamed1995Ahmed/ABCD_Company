using ABCD.Company.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ABCD.Company.Data.Configrations
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id); //PK
            builder.Property(e => e.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(30);
            builder.Property(x=>x.Salary).IsRequired(false).HasColumnType("int");

        }
    }
}
