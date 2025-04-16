using ABCD.Company.Models;

namespace ABCD.Company.Services
{
    public interface IDepartmentRepo : IGenericRepository<Department>
    {
        void Delete1(int id);

    }
}
