namespace E_Commerce_Api.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<bool> DeleteAsync(int id);
        //Task Save();

    }
}
