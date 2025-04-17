using ABCD.Company.Data;
using ABCD.Company.Models;
using ABCD.Company.Repository;
using ABCD.Company.Services;
using ABCD.Company.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ABCD.Company.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo employeeRepo;
        IDepartmentRepo departmentRepo;
        
        AppUser appUser=new AppUser();
        
        public EmployeeController(IEmployeeRepo _employeeRepo,IDepartmentRepo _departmentRepo):base()
        {
            employeeRepo = _employeeRepo;
            departmentRepo = _departmentRepo;
            
        }
       // AppDBcontext context=new AppDBcontext();
        public IActionResult Index()
        {
            
            var employee = employeeRepo.GetAll(); //context.Employees.ToList();
            return View("DisplayAllEmployee", employee);
            
        }
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(x => x.Id == id);
            return View("GetEmployeeById", employee);
        }
        public IActionResult Details(int id)
         {
            var employee = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(x => x.Id == id);
            ViewData["Message"] = $"Hello {employee.Name}";
            ViewData["Temp"] = 35;

            List<string> Branches = new List<string> { "Cairo", "Aswan", "Sohag" };
            ViewData["Branches"] = Branches;

            return View("Details", employee);
        }
        public IActionResult DetailsVM(int id)
        {
            var employee = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(x => x.Id == id);
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
            var emp = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(x => x.Id == id);

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
                Departments = departmentRepo.GetAll().DistinctBy(x => x.Name).ToList()//context.Departments.ToList() // For dropdown
            };

            return View("Edit", empDepartmentList);
        }

        public IActionResult saveEdit(EmpDepartmentList EditEmployee,int id)
        {
        
           if(EditEmployee.Name != null)
            {
                var emp = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(x => x.Id == id);
                emp.Name = EditEmployee.Name;
                emp.Salary = EditEmployee.Salary;
                emp.DepartmentId = EditEmployee.DepartmentId;
                emp.Address = EditEmployee.Address;
                emp.ImageURL = EditEmployee.ImageURL;
                emp.JobTitle = EditEmployee.JobTitle;
                employeeRepo.Update(emp); //context.Employees.Update(emp);
                employeeRepo.Save();    //context.SaveChanges();
                return RedirectToAction("index");
            }
            EditEmployee.Departments = departmentRepo.GetAll().DistinctBy(x => x.Name).ToList();//context.Departments.ToList();
            return View("edit",EditEmployee);
        }
        public IActionResult Add()
        {
            var empDepartmentList = new EmpDepartmentList
            {
                Departments = departmentRepo.GetAll().DistinctBy(x=>x.Name).ToList() //context.Departments.ToList()
            };

            return View("Add", empDepartmentList);
        }


        [HttpPost]
        public IActionResult SaveAdd(EmpDepartmentList newEmployee)
        {
            if (ModelState.IsValid)
            {
                if (newEmployee.DepartmentId != 0)
                {

                    var emp = new Employee();
                    emp.Name = newEmployee.Name;
                    emp.Salary = newEmployee.Salary;
                    emp.DepartmentId = newEmployee.DepartmentId;
                    emp.Address = newEmployee.Address;
                    emp.JobTitle = newEmployee.JobTitle;
                    emp.ImageURL = newEmployee.ImageURL;
                    employeeRepo.Add(emp);//context.Employees.Add(emp);
                    employeeRepo.Save();//context.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                }
            }
            newEmployee.Departments = departmentRepo.GetAll().DistinctBy(x => x.Name).ToList(); // context.Departments.ToList(); ;

            return View("Add", newEmployee);
        }
        public IActionResult Delete(int id)
        {
            var emp = employeeRepo.GetById(id); //context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            employeeRepo.Delete(id); //context.Employees.Remove(emp);
            employeeRepo.Save();//context.SaveChanges();

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
            var result = employeeRepo.GetAll()
                .Where(e => e.Name.Contains(keyword) || e.JobTitle.Contains(keyword))
                .ToList();

            ViewBag.Keyword = keyword; // <-- pass it back

            return View("DisplayAllEmployee", result);
        }
        public IActionResult StartsWithA(string Name)
        {
            if (Name.StartsWith("a", StringComparison.OrdinalIgnoreCase))
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Delete3(int id)
        {
            return View("Delete", employeeRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var employee = employeeRepo.GetById(id);
            if (employee != null)
            {
                employeeRepo.Delete(id);
                employeeRepo.Save();
            }

            return RedirectToAction("Index");
        }





    }
}
