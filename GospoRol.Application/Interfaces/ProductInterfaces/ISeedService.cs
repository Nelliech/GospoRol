using GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels;


namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface ISeedService
    {
        int AddSeed(NewSeedVm newSeed, string userId);
        ListSeedFotListVm GetAllSeedForList(string userId);
        ListSeedFotListVm GetAllSeedForList(int warehouseId);
        void DeleteSeed(int seedId);
        void UpdateSeed(NewSeedVm seed);
        NewSeedVm GetSeedById(int id);
    }
}