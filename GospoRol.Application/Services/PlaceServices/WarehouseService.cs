using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.Services.PlaceServices
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
            var warehouses = _warehouseRepository.GetAllWarehouses(userId)
                .ProjectTo<WarehouseForListVm>(_mapper.ConfigurationProvider).ToList();
            var warehouseList = new ListWarehouseForListVm()
            {
                Count = warehouses.Count,
                Warehouses = warehouses,
                

            };
            return warehouseList;
        }

        public WarehouseVm GetWarehouseById(int warehouseId)
        {
            var warehouse = _warehouseRepository.GetWarehouseById(warehouseId);
            var warehouseVm = _mapper.Map<WarehouseVm>(warehouse);
            return warehouseVm;
        }

        public void UpdateWarehouse(NewWarehouseVm model)
        {
            var warehouse = _mapper.Map<Warehouse>(model);
            _warehouseRepository.UpdateWarehouse(warehouse);
        }

        public void DeleteWarehouse(int warehouseId)
        {
            _warehouseRepository.DeleteWarehouse(warehouseId);
        }

        public WarehouseForListVm GetWarehouseAndCountProductsById(int warehouseId)
        {
            var warehouses = _warehouseRepository.GetAllWarehouses(warehouseId)
                .ProjectTo<WarehouseForListVm>(_mapper.ConfigurationProvider).FirstOrDefault();

            int countProduct = warehouses.Seeds.Count+warehouses.Yields.Count+warehouses.Pesticides.Count+warehouses.Fertilizers.Count;
            warehouses.CountProducts = countProduct;
            return warehouses;
        }
    }
}