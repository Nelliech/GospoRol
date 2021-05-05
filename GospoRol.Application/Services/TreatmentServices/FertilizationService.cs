using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.TreatmentInterfaces;
using GospoRol.Application.ViewModels.TreatmentViewModels.FertilizationViewModels;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Treatments;
using System.Linq;

namespace GospoRol.Application.Services.TreatmentServices
{
    public class FertilizationService : IFertilizationService
    {
        private readonly IFertilizationRepository _fertilizationRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public FertilizationService(IFertilizationRepository fertilizationRepository,IGenericRepository genericRepository, IMapper mapper)
        {
            _fertilizationRepository = fertilizationRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public void AddFertilization(NewFertilizationVm newFertilization, string userId, int fieldId)
        {
            var fertilization = _mapper.Map<Fertilization>(newFertilization);
            fertilization.TypeFertilizationId = 2;
            fertilization.UserId = userId;
            fertilization.FieldId = fieldId;

            _genericRepository.Add<Fertilization>(fertilization);
        }

        public ListFertilizationForListVm GetAllFertilizationsForList(string userId)
        {
            var fertilization = _fertilizationRepository.GetAllFertilizationsByUserId(userId);
            var q = fertilization.ProjectTo<FertilizationForListVm>(_mapper.ConfigurationProvider).ToList(); ///////////////////////
            var fertilizationList = new ListFertilizationForListVm()
            {
                Count = q.Count,
                Fertilizations=q
            };
            return fertilizationList;
        }

        public ListFertilizationForListVm GetAllFertilizationsForListByFieldId(int fieldId)
        {
            var fertilization = _fertilizationRepository.GetAllFertilizationsByFieldId(fieldId);
            var q = fertilization.ProjectTo<FertilizationForListVm>(_mapper.ConfigurationProvider).ToList(); ///////////////////////
            var fertilizationList = new ListFertilizationForListVm()
            {
                Count = q.Count,
                Fertilizations = q
            };
            return fertilizationList;
        }

        public NewFertilizationVm GetFertilizationById(int id)
        {
            var fertilization = _fertilizationRepository.GetFertilizationById(id);
            var fertilizationVm = _mapper.Map<NewFertilizationVm>(fertilization);
            return fertilizationVm;
        }
    }
}