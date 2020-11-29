using System.Dynamic;
using System.Linq;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.PlaceInterfaces
{
    public interface ITypeFertilizerRepository
    {
        IQueryable<TypeFertilizer> GetAllTypeFertilizers();
    }
}