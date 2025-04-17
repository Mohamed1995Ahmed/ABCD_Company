using ABCD.Company.Models;

namespace ABCD.Company.Services
{
    public interface IEmployeeRepo : IGenericRepository<Employee>
    {
       // public List<Employee> GetEmpsByDept(int id);
        public List<Employee> GetByDEptID(int deptID);

    }
}
