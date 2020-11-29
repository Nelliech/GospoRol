using GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels;


namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface IWarehouseService
    {
        int AddWarehouse(NewWarehouseVm newWarehouse, string userId);
        ListWarehouseForListVm GetAllWarehouseForList(string userId);
        NewWarehouseVm GetWarehouseById(int warehouseId);
        void UpdateWarehouse(NewWarehouseVm model);
        void DeleteWarehouse(int warehouseId);
        WarehouseForListVm GetWarehouseAndCountProductsById(int warehouseId);
    }
}