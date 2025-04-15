namespace ABCD.Company.Services
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
       // void mohamed();
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
        void Save();
    }
}
