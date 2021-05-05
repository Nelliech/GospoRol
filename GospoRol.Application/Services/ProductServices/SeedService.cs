using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.ProductServices
{
    public class SeedService : ISeedService
    {
        private readonly ISeedRepository _seedRepository;
        private readonly IWarehouseService _warehouseService;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        public SeedService(ISeedRepository seedRepository, IWarehouseService warehouseService,IGenericRepository genericRepository, IMapper mapper)
        {
            _seedRepository = seedRepository;
            _warehouseService = warehouseService;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public void AddSeed(NewSeedVm newSeed, string userId)
        {
            var seed = _mapper.Map<Seed>(newSeed);
            seed.TypeProductId = 2;
            seed.UserId = userId;
            seed.CurrentAmount = seed.Capacity;

            _genericRepository.Add<Seed>(seed);           
        }

        public ListSeedFotListVm GetAllSeedForList(string userId)
        {
            var seeds = _seedRepository.GetAllSeedsByUserId(userId).ProjectTo<SeedForListVm>(_mapper.ConfigurationProvider).ToList();
            var seedList = new ListSeedFotListVm()
            {
                Count = seeds.Count,
                Seeds = seeds
            };
            return seedList;
        }

        public ListSeedFotListVm GetAllSeedForList(int warehouseId)
        {
            var seeds = _seedRepository.GetAllSeedsByWarehouse(warehouseId).ProjectTo<SeedForListVm>(_mapper.ConfigurationProvider).ToList();
            var seedList = new ListSeedFotListVm()
            {
                Count = seeds.Count,
                Seeds = seeds
            };
            return seedList;
        }

        public void DeleteSeed(int seedId)
        {
            _genericRepository.Delete<Seed>(seedId);
        }

        public void UpdateSeed(NewSeedVm editSeed)
        {
            var seed = _mapper.Map<Seed>(editSeed);
            _seedRepository.UpdateSeed(seed);
        }

        public NewSeedVm GetSeedById(int id)
        {
            var seed = _seedRepository.GetSeedById(id);
            var seedVm = _mapper.Map<NewSeedVm>(seed);
            return seedVm;
        }

        public List<SelectListItem> GetSeedNWarehouseToSelectList(string userId)
        {
            var modelSeed = GetAllSeedForList(userId).Seeds;
            var warehouseList = _warehouseService.GetAllWarehouseForList(userId);
            var warehouseGroupList = new List<SelectListGroup>();
            foreach (var warehouse in warehouseList.Warehouses)
            {
                if (warehouse.Seeds.Count != 0)
                {
                    warehouseGroupList.Add(new SelectListGroup() { Name = warehouse.Name });
                }
            }

            var seedSelectList = new List<SelectListItem>();
            foreach (var seed in modelSeed)
            {
                seedSelectList.Add(new SelectListItem(seed.Producer + " " + seed.NamePlant + " " + seed.PlantVariety, Convert.ToString(seed.Id))
                    { Group = warehouseGroupList.Find(f => f.Name == seed.Warehouse.Name) });
            }

            return seedSelectList;
        }
    }
}