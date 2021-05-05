using System.Linq;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;


namespace GospoRol.Infrastructure.Repositories.ProductRepositories
{
    public class YieldRepository : IYieldRepository
    {
        private readonly Context _context;

        public YieldRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Yield> GetAllYieldByUserId(string userId)
        {
            return _context.Yields.Where(p => p.UserId == userId);
        }

        public int AddYield(Yield yield)
        {
            _context.Yields.Add(yield);
            _context.SaveChanges();
            return yield.Id;
        }
        public void DeleteYield(int yieldId)
        {
            var yield = _context.Yields.Find(yieldId);
            if (yield != null)
            {
                _context.Yields.Remove(yield);
                _context.SaveChanges();
            }
        }
        public Yield GetAllYieldById(int pesticideId)
        {
            return _context.Yields.FirstOrDefault(p => p.Id == pesticideId);
        }

        public void UpdateYield(Yield yield)
        {
            _context.Attach(yield);
            _context.Entry(yield).Property("NamePlant").IsModified = true;
            _context.Entry(yield).Property("PlantVariety").IsModified = true;
            _context.Entry(yield).Property("Count").IsModified = true;
            _context.Entry(yield).Property("YieldUnit").IsModified = true;
            _context.Entry(yield).Property("AdditionalInformation").IsModified = true;
            _context.Entry(yield).Property("WarehouseId").IsModified = true;

            _context.SaveChanges();
        }
    }
}