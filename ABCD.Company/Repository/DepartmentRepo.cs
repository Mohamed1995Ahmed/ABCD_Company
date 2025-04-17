using ABCD.Company.Data;
using ABCD.Company.Filter;
using ABCD.Company.Models;
using ABCD.Company.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCD.Company.Repository
{
    public class DepartmentRepo:IDepartmentRepo
    {
        AppDBcontext context;
        public DepartmentRepo(AppDBcontext _context)
        {
            context = _context;
        }
        
        public void Add(Department department)
        {

            context.Add(department);
            

        }
        public void Update(Department department) {
            context.Update(department);
        
        }
        public void Delete(int id)
        {
            // Get the department by id
            Department dept = GetById(id);

            // If the department doesn't exist, do nothing
            if (dept == null)
                return;

            // Check if there are any employees in the department
            if (dept.Emps != null && dept.Emps.Any())
            {
                // If employees exist, throw an exception to prevent deletion
                throw new InvalidOperationException("Cannot delete department has employees.");
            }

            // Otherwise, remove the department
            context.Remove(dept);
        }
        public void Delete1(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);

        }


        public List<Department> GetAll()
        {
            return context.Departments.ToList();

        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);

        }

        public void Save()
        {
           
                context.SaveChanges();
            
            
        }
      //  [HttpGet]
        public List<string> DisplayNamesOfDepartments()
        {
            var names = context.Departments
                .Select(d => d.Name)
                .Distinct()
                .ToList();
            //var deps = context.Departments.ToList();
            //var names1 = deps.DistinctBy(x=>x.Name);

            return names;
        }
       // [HttpPost]
        public List<string> TakeDeptAndReturnEmps(string Dept)
        {
            var EmpsName = context.Employees.Where(x => x.Department.Name == Dept)
                .Select(x => x.Name).ToList();
            return EmpsName;
        }
       


    }
}
