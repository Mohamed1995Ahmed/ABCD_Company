using ABCD.Company.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCD.Company.ViewModel
{
    public class EmpDepartmentList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [UniqueName]
        [Remote(action: "StartsWithA", controller:"employee" ,ErrorMessage =" Name Do not strat with A")]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Job Title must be between 5 and 50 characters.")]
        public string JobTitle { get; set; }

        public string ImageURL { get; set; }

        [RegularExpression("(Alex|Cairo)", ErrorMessage = "Address must be either 'Alex' or 'Cairo'.")]
        public string? Address { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
       

        public List<Department>? Departments { get; set; }
    }
}
