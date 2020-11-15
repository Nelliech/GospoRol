using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.ViewModels.WarehouseViews;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }
        public int AddWarehouse(NewWarehouseVm newWarehouse, string userId)
        {
            var warehouse = _mapper.Map<Warehouse>(newWarehouse);
            warehouse.UserId = userId;
            var warehouseId = _warehouseRepository.AddWarehouse(warehouse);
            return warehouseId;
        }

        public ListWarehouseForListVm GetAllWarehouseForList(string userId)
        {
            var warehouses = _warehouseRepository.GettAllWarehouses(userId)
                .ProjectTo<WarehouseForListVm>(_mapper.ConfigurationProvider).ToList();
            var warehouseList = new ListWarehouseForListVm()
            {
                Count = warehouses.Count,
                Warehouses = warehouses
            };
            return warehouseList;
        }
    }
}