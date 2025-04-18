using ABCD.Company.Models;

namespace ABCD.Company.ViewModel
{
    public class EmployeePagedViewModel
    {
        public List<Employee> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Keyword { get; set; }  // Added for search functionality
    }


}
