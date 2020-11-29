using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;
using GospoRol.Domain.Interfaces.ProductInterfaces;

namespace GospoRol.Application.Services.ProductServices
{
    public class PesticideService : IPesticideService
    {
        private readonly IPesticideRepository _pesticideRepository;
        private readonly IMapper _mapper;

        public PesticideService(IPesticideRepository pesticideRepository, IMapper mapper)
        {
            _pesticideRepository = pesticideRepository;
            _mapper = mapper;
        }
        public ListPesticideForListVm GetAllPesticideForList(string userId)
        {
            var pesticide = _pesticideRepository.GetAllPesticideByUserId(userId)
                .ProjectTo<PesticideForListVm>(_mapper.ConfigurationProvider).ToList();
            var pesticideList = new ListPesticideForListVm()
            {
                Pesticides = pesticide,
                Count = pesticide.Count
            };
            return pesticideList;
        }
    }
}