using System.Collections.Generic;
using GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface IWarehouseService
    {
        void AddWarehouse(NewWarehouseVm newWarehouse, string userId);
        ListWarehouseForListVm GetAllWarehouseForList(string userId);
        List<SelectListItem> GetAllWarehouseForSelectList(string userId);
        WarehouseVm GetWarehouseById(int warehouseId);
        void UpdateWarehouse(NewWarehouseVm model);
        void DeleteWarehouse(int warehouseId);
        WarehouseForListVm GetWarehouseAndCountProductsById(int warehouseId);
    }
}