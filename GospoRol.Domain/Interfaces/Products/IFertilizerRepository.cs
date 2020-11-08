using System.Linq;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.Products
{
    public interface IFertilizerRepository
    {
        int AddFertilizer(Fertilizer fertilizer);
        void DeleteFertilizer(int fertilizerId);
        void UpdateFertilizer(Fertilizer fertilizer);
        Fertilizer GetFertilizerById(int fertilizerId);
        IQueryable<Fertilizer> GetAllFertilizers(); // ?
    }
}