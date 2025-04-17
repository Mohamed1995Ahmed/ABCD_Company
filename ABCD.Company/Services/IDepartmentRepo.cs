using ABCD.Company.Models;

namespace ABCD.Company.Services
{
    public interface IDepartmentRepo : IGenericRepository<Department>
    {
        void Delete1(int id);
        public List<string> DisplayNamesOfDepartments();
        public List<string> TakeDeptAndReturnEmps(string Dept);
       // public List<Employee> GetEmpsByDept(int id);


    }
}
