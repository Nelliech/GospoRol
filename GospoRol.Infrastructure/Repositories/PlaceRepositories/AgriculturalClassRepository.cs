using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Infrastructure.Repositories.PlaceRepositories
{
    public class AgriculturalClassRepository : IAgriculturalClassRepository
    {
        private readonly Context _context;

        public AgriculturalClassRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<AgriculturalClass> GetAgriculturalClasses()
        {
            return _context.AgriculturalClasses;
        }
    }
}