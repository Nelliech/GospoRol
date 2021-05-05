using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.TreatmentInterfaces;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels.TypeSowingViewModels;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.TreatmentServices
{
    public class TypeSowingService : ITypeSowingService
    {
        private readonly ITypeSowingRepository _typeSowingRepository;
        private readonly IMapper _mapper;

        public TypeSowingService(ITypeSowingRepository typeSowingRepository, IMapper mapper)
        {
            _typeSowingRepository = typeSowingRepository;
            _mapper = mapper;
        }
        public ListTypeSowingForListVm GetAllTypeSowingForList()
        {
            
            var typeSowing = _typeSowingRepository.GetAllTypeSowing()
                .ProjectTo<TypeSowingForListVm>(_mapper.ConfigurationProvider).ToList();

            var typSowingList = new ListTypeSowingForListVm()
            {
                TypeSowing = typeSowing
            };

            return typSowingList;
        }

        public List<SelectListItem> GetAllTypeSowingFotSelectList()
        {
            var modelTypeSowing = GetAllTypeSowingForList().TypeSowing;
            var typeSowingSelectList = modelTypeSowing
                .Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList().ToList();
            return typeSowingSelectList;
        }
    }
}