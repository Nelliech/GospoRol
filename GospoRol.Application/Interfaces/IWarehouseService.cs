using GospoRol.Application.ViewModels.WarehouseViews;

namespace GospoRol.Application.Interfaces
{
    public interface IWarehouseService
    {
        int AddWarehouse(NewWarehouseVm newWarehouse, string userId);
        ListWarehouseForListVm GetAllWarehouseForList(string userId);

    }
}