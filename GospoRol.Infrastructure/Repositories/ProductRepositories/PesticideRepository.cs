using System.Linq;
using GospoRol.Domain.Interfaces.ProductInterfaces;

using GospoRol.Domain.Models.Products;

namespace GospoRol.Infrastructure.Repositories.ProductRepositories
{
    public class PesticideRepository : IPesticideRepository
    {
        private readonly Context _context;

        public PesticideRepository(Context context)
        {
            _context = context;
        }
        public int AddPesticide(Pesticide pesticide)
        {
            _context.Pesticides.Add(pesticide);
            _context.SaveChanges();
            return pesticide.Id;
        }

        public void DeletePesticide(int pesticideId)
        {
            var pesticide = _context.Pesticides.Find(pesticideId);
            if (pesticide != null)
            {
                _context.Pesticides.Remove(pesticide);
                _context.SaveChanges();
            }
        }

        public Pesticide GetPesticideById(int pesticideId)
        {
            return _context.Pesticides.FirstOrDefault(p => p.Id == pesticideId);
        }

        public void UpdatePesticide(Pesticide pesticide)
        {
            _context.Attach(pesticide);
            _context.Entry(pesticide).Property("Producer").IsModified = true;
            _context.Entry(pesticide).Property("Name").IsModified = true;
            _context.Entry(pesticide).Property("PesticideComposition").IsModified = true;
            _context.Entry(pesticide).Property("Capacity").IsModified = true;
            _context.Entry(pesticide).Property("CurrentAmount").IsModified = true;
            _context.Entry(pesticide).Property("Price").IsModified = true;
            _context.Entry(pesticide).Property("AdditionalInformation").IsModified = true;
            _context.Entry(pesticide).Property("TypePesticideId").IsModified = true;
            _context.Entry(pesticide).Property("WarehouseId").IsModified = true;

            _context.SaveChanges();
        }


        public IQueryable<Pesticide> GetAllPesticideByUserId(string userId)
        {
            return _context.Pesticides.Where(p => p.UserId == userId);
        }
    }
}