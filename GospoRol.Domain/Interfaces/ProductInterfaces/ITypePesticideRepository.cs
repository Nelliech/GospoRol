using System.Linq;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.ProductInterfaces
{
    public interface ITypePesticideRepository
    {
        IQueryable<TypePesticide> GetAllTypePesticides();
    }
}