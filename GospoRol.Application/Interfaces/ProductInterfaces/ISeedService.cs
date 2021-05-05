using System.Collections.Generic;
using GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface ISeedService
    {
        void AddSeed(NewSeedVm newSeed, string userId);
        ListSeedFotListVm GetAllSeedForList(string userId);
        ListSeedFotListVm GetAllSeedForList(int warehouseId);
        void DeleteSeed(int seedId);
        void UpdateSeed(NewSeedVm editSeed);
        NewSeedVm GetSeedById(int id);
        List<SelectListItem> GetSeedNWarehouseToSelectList(string userId);
    }
}