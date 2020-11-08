using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.ViewModels.AgriculturalClassViews;
using GospoRol.Domain.Interfaces;

namespace GospoRol.Application.Services
{
    public class AgriculturalClassService : IAgriculturalClassService
    {
        private readonly IAgriculturalClassRepository _agriculturalClassRepository;
        private readonly IMapper _mapper;
        public AgriculturalClassService(IAgriculturalClassRepository agriculturalClassRepository, IMapper mapper)
        {
            _agriculturalClassRepository = agriculturalClassRepository;
            _mapper = mapper;
        }
        public ListAgrClassForListVm GetAllAgriculturalClassForList()
        {
            var agrClasses = _agriculturalClassRepository.GetAgriculturalClasses()
                .ProjectTo<AgrClassForListVm>(_mapper.ConfigurationProvider).ToList();
            var agrClassesList = new ListAgrClassForListVm()
            {
                Classes = agrClasses
            };
            return agrClassesList;
        }
    }
}