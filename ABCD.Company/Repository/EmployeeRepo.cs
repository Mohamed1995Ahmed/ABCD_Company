using ABCD.Company.Data;
using ABCD.Company.Models;
using ABCD.Company.Services;

namespace ABCD.Company.Repository
{
    public class EmployeeRepo:IEmployeeRepo
    {
        AppDBcontext context;
        public EmployeeRepo(AppDBcontext _context)
        {
            context =_context ;
        }
        public void Add(Employee Employee)
        {
            context.Add(Employee);

        }
        public void Update(Employee Employee)
        {
            context.Update(Employee);

        }
        public void Delete(int id)
        {
            Employee Emp = GetById(id);
            context.Remove(Emp);

        }
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();

        }
        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);

        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<Employee> GetByDEptID(int deptID)
        {
            return context.Employees.Where(e => e.DepartmentId == deptID).ToList();
        }
    }
}
