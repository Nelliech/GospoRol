using System.Linq;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Infrastructure.Repositories.PlaceRepositories
{
    public class TypeFertilizerRepository :ITypeFertilizerRepository
    {
        private readonly Context _context;

        public TypeFertilizerRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<TypeFertilizer> GetAllTypeFertilizers()
        {
            return _context.TypeFertilizers;
        }
    }
}