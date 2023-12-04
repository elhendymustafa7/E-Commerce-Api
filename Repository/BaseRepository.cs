using E_Commerce_Api.Model;

namespace E_Commerce_Api.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> Get() => _context.Set<T>().AsNoTracking().ToList();
        public async Task<IEnumerable<T>> GetAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();
        public T GetById(int id) => _context.Set<T>().AsNoTracking().FirstOrDefault(t => EF.Property<int>(t, "ID") == id);
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => EF.Property<int>(t, "ID") == id);
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false; // not found
            }

            _context.Set<T>().Remove(entity);
            return true; // found and deleted
        }
    }
}
