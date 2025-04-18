using ABCD.Company.Models;

namespace ABCD.Company.Services
{
    public interface IEmployeeRepo : IGenericRepository<Employee>
    {
       // public List<Employee> GetEmpsByDept(int id);
        public List<Employee> GetByDEptID(int deptID);
        public List<Employee> GetPaged(int page, int pageSize, string keyword)
        {
            var query = GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(keyword) ||
                    e.JobTitle.ToLower().Contains(keyword));
            }

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public int Count(string keyword)
        {
            var query = GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(keyword) ||
                    e.JobTitle.ToLower().Contains(keyword));
            }

            return query.Count();
        }



    }
}
