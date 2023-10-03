namespace E_Commerce_Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<Seller> Sellers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new BaseRepository<Category>(_context);
            Products = new BaseRepository<Product>(_context);
            Sellers = new BaseRepository<Seller>(_context);
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Save() => _context.SaveChanges();


    }
}
 