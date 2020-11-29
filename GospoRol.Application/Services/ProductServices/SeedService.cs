using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.Services.ProductServices
{
    public class SeedService : ISeedService
    {
        private readonly ISeedRepository _seedRepository;
       
        private readonly IMapper _mapper;
        public SeedService(ISeedRepository seedRepository, IMapper mapper)
        {
            _seedRepository = seedRepository;
            _mapper = mapper;
        }
        public int AddSeed(NewSeedVm newSeed, string userId)
        {
            var seed = _mapper.Map<Seed>(newSeed);
            seed.TypeProductId = 2;
            seed.UserId = userId;
            seed.CurrentAmount = seed.Capacity;

            var seedId = _seedRepository.AddSeed(seed);
            return seedId;
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
            throw new System.NotImplementedException();
        }

        public void UpdateSeed(NewSeedVm seed)
        {
            throw new System.NotImplementedException();
        }

        public NewSeedVm GetSeedById(int id)
        {
            var seed = _seedRepository.GetSeedById(id);
            var seedVm = _mapper.Map<NewSeedVm>(seed);
            return seedVm;
        }
    }
}