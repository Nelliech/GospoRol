using System.Linq;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Interfaces.PlaceInterfaces
{
    public interface IAgriculturalClassRepository
    {
        IQueryable<AgriculturalClass> GetAgriculturalClasses();

    }
}