using System.Linq;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Interfaces.TreatmentInterfaces
{
    public interface ITypeSowingRepository
    {
        IQueryable<TypeSowing> GetAllTypeSowing();
    }
}