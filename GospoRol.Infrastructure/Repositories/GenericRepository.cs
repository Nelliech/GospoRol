using GospoRol.Domain.Interfaces;

namespace GospoRol.Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Add<T>(T newItem) where T : class
        {
            _context.Set<T>().Add(newItem);
            _context.SaveChanges();
            
        }
        public void Delete<T>(int itemId) where T : class
        {
            var item = _context.Set<T>().Find(itemId);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
