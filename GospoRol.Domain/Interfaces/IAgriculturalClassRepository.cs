using System.Linq;
using GospoRol.Domain.Models;

namespace GospoRol.Domain.Interfaces
{
    public interface IAgriculturalClassRepository
    {
        IQueryable<AgriculturalClass> GetAgriculturalClasses();

    }
}