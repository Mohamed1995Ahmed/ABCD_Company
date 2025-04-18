namespace ABCD.Company.Services
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetPaged(int page, int pageSize); 
        int Count(); 
        void Save();
    }


}
