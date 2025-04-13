using ABCD.Company.Data;
using ABCD.Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class DepartmentController : Controller
    {
        AppDBcontext context=new AppDBcontext();

        public IActionResult Index()
        {
            var department=context.Departments.ToList();
            return View("DisplayAllDepartment", department);
        }
        public IActionResult GetDepartmentById(int id)
        {
            var department = context.Departments.FirstOrDefault(x=>x.Id==id);
            return View("GetDepartmentById", department);
        }
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Department newdepartment)
        {
            if (!string.IsNullOrEmpty(newdepartment.Name))
            {
                context.Departments.Add(newdepartment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Add", newdepartment);
        }


    }
}
