using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.Services.ProductServices
{
    public class FertilizerService : IFertilizerService
    {
        private readonly IFertilizerRepository _fertilizerRepository;
        private readonly IMapper _mapper;

        public FertilizerService(IFertilizerRepository fertilizerRepository, IMapper mapper)
        {
            _fertilizerRepository = fertilizerRepository;
            _mapper = mapper;
        }
        public int AddFertilizer(NewFertilizerVm model, string userId)
        {
            var fertilizer = _mapper.Map<Fertilizer>(model);
            fertilizer.TypeProductId = 1;
            fertilizer.UserId = userId;
            fertilizer.CurrentAmount = fertilizer.Capacity;

            var fertilizerId = _fertilizerRepository.AddFertilizer(fertilizer);
            return fertilizerId;
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
            throw new System.NotImplementedException();
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