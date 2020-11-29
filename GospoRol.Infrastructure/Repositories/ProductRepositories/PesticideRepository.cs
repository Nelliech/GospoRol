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
            throw new System.NotImplementedException();
        }

        public void DeletePesticide(int pesticideId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePesticide(Pesticide pesticide)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Pesticide> GetAllPesticideByUserId(string userId)
        {
            return _context.Pesticides.Where(p => p.UserId == userId);
        }
    }
}