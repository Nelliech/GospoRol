using System;
using System.Collections.Generic;
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.PlaceServices
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IGenericRepository genericRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public void AddWarehouse(NewWarehouseVm newWarehouse, string userId)
        {
            var warehouse = _mapper.Map<Warehouse>(newWarehouse);
            warehouse.UserId = userId;
            _genericRepository.Add<Warehouse>(warehouse);            
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

        public List<SelectListItem> GetAllWarehouseForSelectList(string userId)
        {
            var modelWarehouse =GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouse.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();
            return warehouseSelectList;
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
            _genericRepository.Delete<Warehouse>(warehouseId);
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