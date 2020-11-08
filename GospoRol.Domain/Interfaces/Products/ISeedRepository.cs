using System.Linq;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.Products
{
    public interface ISeedRepository
    {
        int AddSeed(Seed seed);
        void DeleteSeed(int seedId);
        void UpdateSeed(Seed seed);
        Seed GetSeedById(int seedId);
        IQueryable<Seed> GetAllSeeds();
    }
}