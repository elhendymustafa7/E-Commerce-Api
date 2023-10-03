
namespace E_Commerce_Api.Repository
{
    public interface IUnitOfWork
    {
        public IBaseRepository<Category> Categories { get; }
        public IBaseRepository<Product> Products { get; }
        public IBaseRepository<Seller> Sellers { get; }
        void Save();
        Task SaveAsync();
        //bool EntityExists(int id, ApplicationDbContext type);
    }
}
