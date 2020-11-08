using GospoRol.Domain.Models;

namespace GospoRol.Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        int AddWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int warehouseId);
        void UpdateWarehouse(Warehouse warehouse);
        Warehouse GetWarehouseById(int warehouseId);
    }
}