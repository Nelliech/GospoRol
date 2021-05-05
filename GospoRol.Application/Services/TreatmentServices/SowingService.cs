using AutoMapper;
using GospoRol.Application.Interfaces.TreatmentInterfaces;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Treatments;
using System;

namespace GospoRol.Application.Services.TreatmentServices
{
    public class SowingService : ISowingService
    {
        private readonly ISowingRepository _sowingRepository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;

        public SowingService(ISowingRepository sowingRepository,IFieldRepository fieldRepository, IMapper mapper)
        {
            _sowingRepository = sowingRepository;
            _fieldRepository = fieldRepository;
            _mapper = mapper;
        }
        public int AddSowing(NewSowingVm newSowing, string userId)
        {
            var sowing = _mapper.Map<Sowing>(newSowing);
            sowing.UserId = userId;
            sowing.TypeTreatmentId = 5;
            Sowing newestSowing = _sowingRepository.GetNewestSowingDateTimeInField(sowing.FieldId);
            DateTime newestDateSowing = newestSowing.DateTreatment;
            DateTime oldDateSowing = sowing.DateTreatment;

            int sowingId = _sowingRepository.AddSowing(sowing);

            if (newestDateSowing< oldDateSowing)
            {
                _fieldRepository.ChangeCultivatedPlant(sowing.FieldId, sowing.CultivatedPlant, sowing.PlantVariety);
            }
            return sowingId;
        }

        public ListSowingForListVm GetAllSowingByUserIdForList(string userId)
        {
            throw new System.NotImplementedException();
        }

        public NewSowingVm GetShowingById(int sowingId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSowing(int sowingId)
        {
            throw new System.NotImplementedException();
        }
    }
}