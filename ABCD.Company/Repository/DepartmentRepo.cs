using ABCD.Company.Data;
using ABCD.Company.Filter;
using ABCD.Company.Models;
using ABCD.Company.Services;
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
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new SaveToDatabaseException("Failed to save changes to the database and continue to see informaion about it.", ex);
            } 
        }

    }
}
