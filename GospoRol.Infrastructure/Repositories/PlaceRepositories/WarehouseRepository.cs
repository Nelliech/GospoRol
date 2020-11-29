using System;
using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Infrastructure.Repositories.PlaceRepositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly Context _context;

        public WarehouseRepository(Context context)
        {
            _context = context;
        }
        public int AddWarehouse(Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
            return warehouse.Id;
        }

        public void DeleteWarehouse(int warehouseId)
        {
            var warehouse = _context.Warehouses.Find(warehouseId);
            _context.Remove(warehouse);
            _context.SaveChanges();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            _context.Attach(warehouse);
            _context.Entry(warehouse).Property("Name").IsModified = true;
            _context.Entry(warehouse).Property("Acreage").IsModified = true;
            _context.SaveChanges();
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            return _context.Warehouses.FirstOrDefault(p => p.Id == warehouseId);
        }

        public IQueryable<Warehouse> GetAllWarehouses(string userId)
        {
            return _context.Warehouses.Where(p => p.UserId == userId);
        }

        public IQueryable<Warehouse> GetAllWarehouses(int warehouseId)
        {
            return _context.Warehouses.Where(p => p.Id==warehouseId);


        }

        public int HowManyProducts(int warehouseId)
        {
            var warehouse = _context.Warehouses.FirstOrDefault(p => p.Id == warehouseId);
            
            
            

            return 1;
        }
    }
}