using System.ComponentModel.DataAnnotations.Schema;

namespace ABCD.Company.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public string JobTitle { get; set; }

        public string ImageURL { get; set; }

        public string? Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; } //this is foregnkey for Department class to relation ont to amny

        public virtual Department Department { get; set; }
    }
}
