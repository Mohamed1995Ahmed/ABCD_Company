using ABCD.Company.Models;

namespace ABCD.Company.ViewModel
{
    public class DepartmentPagedViewModel
    {
        public List<Department> Departments { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}
