using System.Linq;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.ProductInterfaces
{
    public interface IYieldRepository
    {
        IQueryable<Yield> GetAllYieldByUserId(string userId);
        int AddYield(Yield yield);
        Yield GetAllYieldById(int pesticideId);
        void UpdateYield(Yield yield);
        void DeleteYield(int yieldId);
    }
}