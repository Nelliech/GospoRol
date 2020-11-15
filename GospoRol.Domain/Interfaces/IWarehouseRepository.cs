using System.Linq;
using GospoRol.Domain.Models;

namespace GospoRol.Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        int AddWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int warehouseId);
        void UpdateWarehouse(Warehouse warehouse);
        Warehouse GetWarehouseById(int warehouseId);
        IQueryable<Warehouse> GettAllWarehouses(string userId);
        int HowManyProducts(int warehouseId);
    }
}