using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.Services.ProductServices
{
    public class PesticideService : IPesticideService
    {
        private readonly IPesticideRepository _pesticideRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public PesticideService(IPesticideRepository pesticideRepository, IGenericRepository genericRepository, IMapper mapper)
        {
            _pesticideRepository = pesticideRepository;
            _genericRepository = genericRepository;
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

        public void AddPesticide(NewPesticideVm newPesticide, string userId)
        {
            var pesticide = _mapper.Map<Pesticide>(newPesticide);
            pesticide.TypeProductId = 3;
            pesticide.UserId = userId;
            pesticide.CurrentAmount = pesticide.Capacity;

            _genericRepository.Add<Pesticide>(pesticide);
            
        }

        public void DeletePesticide(int pesticideId)
        {
            _genericRepository.Delete<Pesticide>(pesticideId);
        }

        public NewPesticideVm GetPesticideById(int pesticideId)
        {
            var pesticide = _pesticideRepository.GetPesticideById(pesticideId);
            var pesticideVm = _mapper.Map<NewPesticideVm>(pesticide);
            return pesticideVm;
        }

        public void UpdatePesticide(NewPesticideVm editPesticide)
        {
            var pesticide = _mapper.Map<Pesticide>(editPesticide);
            _pesticideRepository.UpdatePesticide(pesticide);
        }
    }
}