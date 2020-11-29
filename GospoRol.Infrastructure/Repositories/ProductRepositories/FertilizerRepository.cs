using System.Linq;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Infrastructure.Repositories.ProductRepositories
{
    public class FertilizerRepository : IFertilizerRepository 
    {
        private readonly Context _context;

        public FertilizerRepository(Context context)
        {
            _context = context;
        }
        public int AddFertilizer(Fertilizer fertilizer)
        {
            _context.Fertilizers.Add(fertilizer);
            _context.SaveChanges();
            return fertilizer.Id;
        }

        public void DeleteFertilizer(int fertilizerId)
        {
            var fertilizer = _context.Fertilizers.Find(fertilizerId);
            if (fertilizer != null)
            {
                _context.Fertilizers.Remove(fertilizer);
                _context.SaveChanges();
            }
        }

        public void UpdateFertilizer(Fertilizer fertilizer)
        {
            _context.Attach(fertilizer); 
            _context.Entry(fertilizer).Property("Producer").IsModified = true;
            _context.Entry(fertilizer).Property("FertilizerComposition").IsModified = true;
            _context.Entry(fertilizer).Property("Concentration").IsModified = true;
            _context.Entry(fertilizer).Property("Capacity").IsModified = true;
            _context.Entry(fertilizer).Property("CurrentAmount").IsModified = true;
            _context.Entry(fertilizer).Property("Price").IsModified = true;
            _context.Entry(fertilizer).Property("AdditionalInformation").IsModified = true;
        }

        public Fertilizer GetFertilizerById(int fertilizerId)
        {
            return _context.Fertilizers.FirstOrDefault(p=>p.Id==fertilizerId);
        }

        public IQueryable<Fertilizer> GetAllFertilizersByUserId(string userId)
        {
            return _context.Fertilizers.Where(p => p.UserId == userId);
        }

        public IQueryable<Fertilizer> GetAllFertilizersByWarehouseId(int wareHouseId)
        {
            return _context.Fertilizers.Where(p => p.Id == wareHouseId);
        }
    }
}