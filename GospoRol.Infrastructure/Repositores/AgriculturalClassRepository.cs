using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Infrastructure.Repositores
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