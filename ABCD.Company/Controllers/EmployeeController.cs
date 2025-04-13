using ABCD.Company.Data;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class EmployeeController : Controller
    {
        AppDBcontext context=new AppDBcontext();
        public IActionResult Index()
        {
            var employee = context.Employees.ToList();
            return View("DisplayAllEmployee", employee);
            
        }
        public IActionResult GetEmployeeById(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            return View("GetEmployeeById", employee);
        }
    }
}
