using System.Linq;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Infrastructure.Repositories.ProductRepositories
{
    public class SeedRepository : ISeedRepository
    {
        private readonly Context _context;

        public SeedRepository(Context context)
        {
            _context = context;
        }
        public int AddSeed(Seed seed)
        {
            _context.Seeds.Add(seed);
            _context.SaveChanges();
            return seed.Id;
        }

        public void DeleteSeed(int seedId)
        {
            var seed=_context.Seeds.Find(seedId);
            if (seed != null)
            {
                _context.Seeds.Remove(seed);
                _context.SaveChanges();
            }
        }

        public void UpdateSeed(Seed seed)
        {
            _context.Attach(seed);
            _context.Entry(seed).Property("NamePlant").IsModified = true; 
            _context.Entry(seed).Property("PlantVariety").IsModified = true;
            _context.Entry(seed).Property("Producer").IsModified = true;
            _context.Entry(seed).Property("Capacity").IsModified = true;
            _context.Entry(seed).Property("CurrentAmount").IsModified = true;
            _context.Entry(seed).Property("Price").IsModified = true;
            _context.Entry(seed).Property("AdditionalInformation").IsModified = true;
            _context.Entry(seed).Property("WarehouseId").IsModified = true;


            _context.SaveChanges();
        }

        public Seed GetSeedById(int seedId)
        {
            return _context.Seeds.Find(seedId);
        }

        public IQueryable<Seed> GetAllSeedsByUserId(string userId)
        {
            return _context.Seeds.Where(p=>p.UserId==userId);
        }

        public IQueryable<Seed> GetAllSeedsByWarehouse(int warehouseId)
        {
            return _context.Seeds.Where(p => p.WarehouseId == warehouseId);
        }
    }
}