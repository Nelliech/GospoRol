using System.Linq;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Infrastructure.Repositories.TreatmentRepositories
{
    public class TypeSowingRepository : ITypeSowingRepository
    {
        private readonly Context _context;

        public TypeSowingRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<TypeSowing> GetAllTypeSowing()
        {
            return _context.TypeSowings;
        }
    }
}