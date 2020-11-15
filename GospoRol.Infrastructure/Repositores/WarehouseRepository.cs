using System;
using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Infrastructure.Repositores
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

        public IQueryable<Warehouse> GettAllWarehouses(string userId)
        {
            return _context.Warehouses.Where(p => p.UserId == userId);
        }

        public int HowManyProducts(int warehouseId)
        {
            int productsCount;
            try
            {
                 productsCount = _context.Warehouses.FirstOrDefault(p => p.Id == warehouseId).Products.Count;
            }
            catch (NullReferenceException)
            {
                productsCount = 0;
            }

            return productsCount;
        }
    }
}