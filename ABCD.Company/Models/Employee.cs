using System.ComponentModel.DataAnnotations.Schema;

namespace ABCD.Company.Models
{
    public class Employee
    {
        public int Id { get; set; }//1

        public string Name { get; set; }//2

        public int Salary { get; set; }//3

        public string JobTitle { get; set; }//4

        public string ImageURL { get; set; }//5

        public string? Address { get; set; }//6

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; } // 7 this is foregnkey for Department class to relation ont to amny

        public virtual Department Department { get; set; }//8
    }
}
