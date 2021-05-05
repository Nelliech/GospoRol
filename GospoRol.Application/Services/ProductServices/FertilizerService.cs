using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Interfaces;

namespace GospoRol.Application.Services.ProductServices
{
    public class FertilizerService : IFertilizerService
    {
        private readonly IFertilizerRepository _fertilizerRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public FertilizerService(IFertilizerRepository fertilizerRepository, IGenericRepository genericRepository, IMapper mapper)
        {
            _fertilizerRepository = fertilizerRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public void AddFertilizer(NewFertilizerVm model, string userId)
        {
            var fertilizer = _mapper.Map<Fertilizer>(model);
            fertilizer.TypeProductId = 1;
            fertilizer.UserId = userId;
            fertilizer.CurrentAmount = fertilizer.Capacity;

            _genericRepository.Add<Fertilizer>(fertilizer);
            
        }

        public ListFertilizerForListVm GetAllFertilizerForList(string userId)
        {
            var fertilizer = _fertilizerRepository.GetAllFertilizersByUserId(userId)
                .ProjectTo<FertilizerForListVm>(_mapper.ConfigurationProvider).ToList();
            var fertilizerList = new ListFertilizerForListVm()
            {
                Fertilizers = fertilizer,
                Count = fertilizer.Count
            };

            return fertilizerList;
        }

        public ListFertilizerForListVm GetAllFertilizerForList(int warehouseId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFertilizer(int fertilizerId)
        {
            _genericRepository.Delete<Fertilizer>(fertilizerId);
        }

        public void UpdateFertilizer(NewFertilizerVm fertilizer)
        {
            throw new System.NotImplementedException();
        }

        public NewFertilizerVm GetFertilizerById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}