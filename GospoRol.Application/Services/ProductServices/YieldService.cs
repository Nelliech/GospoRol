using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.YieldViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.Services.ProductServices
{
    public class YieldService : IYieldService
    {
        private readonly IYieldRepository _yieldRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public YieldService(IYieldRepository yieldRepository, IGenericRepository genericRepository, IMapper mapper)
        {
            _yieldRepository = yieldRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public ListYieldForListVm GetAllYieldForList(string userId)
        {
            var yield = _yieldRepository.GetAllYieldByUserId(userId);
            var q = yield.ProjectTo<YieldForListVm>(_mapper.ConfigurationProvider).ToList();
            var yieldList = new ListYieldForListVm()
            {
                Count = q.Count,
                Yields = q
            };
            return yieldList;
        }

        public void AddYield(NewYieldVm newYield, string userId)
        {
            var yield = _mapper.Map<Yield>(newYield);
            yield.TypeProductId = 2;
            yield.UserId = userId;

            _genericRepository.Add<Yield>(yield);
           
        }

        public NewYieldVm GetYieldById(int id)
        {
            var yield = _yieldRepository.GetAllYieldById(id);
            var yieldVm = _mapper.Map<NewYieldVm>(yield);
            return yieldVm;
        }

        public void UpdateYield(NewYieldVm editYield)
        {
            var yield = _mapper.Map<Yield>(editYield);
            _yieldRepository.UpdateYield(yield);
        }

        public void DeleteYield(int yieldId)
        {
            _genericRepository.Delete<Yield>(yieldId);
        }
    }
}