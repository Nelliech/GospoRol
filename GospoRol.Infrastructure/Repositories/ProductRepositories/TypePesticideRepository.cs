using System.Linq;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Infrastructure.Repositories.ProductRepositories
{
    public class TypePesticideRepository : ITypePesticideRepository
    {
        private readonly Context _context;

        public TypePesticideRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<TypePesticide> GetAllTypePesticides()
        {
            return _context.TypePesticides;
        }
    }
}