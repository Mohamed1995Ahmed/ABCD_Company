using ABCD.Company.Data;
using ABCD.Company.Models;
using ABCD.Company.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController():base()
        {
            
        }
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
        public IActionResult Details(int id)
         {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            ViewData["Message"] = $"Hello {employee.Name}";
            ViewData["Temp"] = 35;

            List<string> Branches = new List<string> { "Cairo", "Aswan", "Sohag" };
            ViewData["Branches"] = Branches;

            return View("Details", employee);
        }
        public IActionResult DetailsVM(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            List<string> Branches = new List<string> { "Cairo", "Aswan", "Sohag" };
            EmpDeptDetails empDeptDetails = new EmpDeptDetails();
            empDeptDetails.EmpName = employee.Name;
            empDeptDetails.DeptName = employee.Department.Name;
            empDeptDetails.Message = $"Hello {employee.Name} ";
            empDeptDetails.Temp = 15;
            empDeptDetails.Branches=Branches;
            empDeptDetails.ImageUrl=employee.ImageURL;
            empDeptDetails.Color = "red";

           
            

            return View("DetailsVM", empDeptDetails);
        }
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            var empDepartmentList = new EmpDepartmentList
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = (int)emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentId = emp.DepartmentId,
                Departments = context.Departments.ToList() // For dropdown
            };

            return View("Edit", empDepartmentList);
        }

        public IActionResult saveEdit(EmpDepartmentList EditEmployee,int id)
        {
            
           if(EditEmployee.Name != null)
            {
                var emp = context.Employees.FirstOrDefault(x => x.Id == id);
                emp.Name = EditEmployee.Name;
                emp.Salary = EditEmployee.Salary;
                emp.DepartmentId = EditEmployee.DepartmentId;
                emp.Address = EditEmployee.Address;
                emp.ImageURL = EditEmployee.ImageURL;
                emp.JobTitle = EditEmployee.JobTitle;
                context.Employees.Update(emp);
                context.SaveChanges();
                return RedirectToAction("index");
            }
           EditEmployee.Departments=context.Departments.ToList();
           return View("edit",EditEmployee);
        }
        public IActionResult Add()
        {
            var empDepartmentList = new EmpDepartmentList
            {
                Departments = context.Departments.ToList()
            };

            return View("Add", empDepartmentList);
        }


        [HttpPost]
        public IActionResult SaveAdd(EmpDepartmentList newdepartment)
        {
            if (!string.IsNullOrEmpty(newdepartment.Name))
            {
                var emp = new Employee();
                emp.Name = newdepartment.Name;
                emp.Salary = newdepartment.Salary;
                emp.DepartmentId = newdepartment.DepartmentId;
                emp.Address= newdepartment.Address;
                emp.JobTitle= newdepartment.JobTitle;
                emp.ImageURL= newdepartment.ImageURL;
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            newdepartment.Departments = context.Departments.ToList(); ;

            return View("Add", newdepartment);
        }
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            context.Employees.Remove(emp);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        //public IActionResult Search(string keyword)
        //{
        //    var result = context.Employees
        //        .Where(e => e.Name.Contains(keyword) || e.JobTitle.Contains(keyword))
        //        .ToList();

        //    return View("DisplayAllEmployee", result);
        //}
        public IActionResult Search1(string keyword)
        {
            var result = context.Employees
                .Where(e => e.Name.Contains(keyword) || e.JobTitle.Contains(keyword))
                .ToList();

            ViewBag.Keyword = keyword; // <-- pass it back

            return View("DisplayAllEmployee", result);
        }



    }
}
