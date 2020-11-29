using System.Linq;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Interfaces.PlaceInterfaces
{
    public interface IWarehouseRepository
    {
        int AddWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int warehouseId);
        void UpdateWarehouse(Warehouse warehouse);
        Warehouse GetWarehouseById(int warehouseId);
        IQueryable<Warehouse> GetAllWarehouses(string userId);
        IQueryable<Warehouse> GetAllWarehouses(int warehouseId);
        int HowManyProducts(int warehouseId);
    }
}