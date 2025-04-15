using System.ComponentModel.DataAnnotations;
using ABCD.Company.Data;
using ABCD.Company.ViewModel;

namespace ABCD.Company.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            var context = (AppDBcontext)validationContext.GetService(typeof(AppDBcontext))!;

            var uniqueName = value.ToString();
            var existingEmp = context.Employees.FirstOrDefault(e => e.Name == uniqueName);

            if (existingEmp != null)
            {
                return new ValidationResult("Name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
