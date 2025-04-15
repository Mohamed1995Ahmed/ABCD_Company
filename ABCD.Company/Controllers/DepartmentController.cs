using ABCD.Company.Data;
using ABCD.Company.Models;
using ABCD.Company.Repository;
using ABCD.Company.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCD.Company.Controllers
{
    public class DepartmentController : Controller
    {
        //AppDBcontext context=new AppDBcontext();
        IDepartmentRepo departmentRepo;
        public DepartmentController(IDepartmentRepo _departmentRepo):base()
        {
            departmentRepo = _departmentRepo;
            
        }

        public IActionResult Index()
        {
            
            var department=departmentRepo.GetAll();
        //departmentRepo.asd();
            return View("DisplayAllDepartment", department);
        }
        public IActionResult GetDepartmentById(int id)
        {
            var department = departmentRepo.GetById(id);
            return View("GetDepartmentById", department);
        }
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpGet]
        public IActionResult getemp1()
        {
            var departments = departmentRepo.GetAll();

            foreach (var department in departments)
            {
                if (department.Name == "IT")
                {
                    foreach (var emp in department.Emps)
                    {
                        Console.WriteLine(emp.Name); 
                    }
                }
            }
            return Content("ok");
        }


            [HttpPost]
        public IActionResult SaveAdd(Department newdepartment)
        {
           
            if (!string.IsNullOrEmpty(newdepartment.Name))
            {
                departmentRepo.Add(newdepartment);//context.Departments.Add(newdepartment);
                departmentRepo.Save();
                return RedirectToAction("Index");
            }

            return View("Add", newdepartment);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                // Attempt to delete the department
                departmentRepo.Delete(id);
                departmentRepo.Save();

                // Redirect to the index page after successful deletion
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                // If an error occurs (e.g. the department has employees), display an error message
                TempData["Error"] = $"Department with ID {id} cannot be deleted: {ex.Message}";
                return RedirectToAction("Index");
            }
        }



    }
}
