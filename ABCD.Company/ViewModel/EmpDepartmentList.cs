using ABCD.Company.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCD.Company.ViewModel
{
    public class EmpDepartmentList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public string JobTitle { get; set; }

        public string ImageURL { get; set; }

        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
