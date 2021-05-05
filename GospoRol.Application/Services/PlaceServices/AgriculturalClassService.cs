using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels.PlaceViewModels.AgriculturalClassViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.PlaceServices
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

        public List<SelectListItem> GetAllAgriculturalClassForSelectList()
        {
            var modelAgrClass = GetAllAgriculturalClassForList().Classes;
            var agrClassSelectList =
                modelAgrClass.Select(f => new SelectListItem(f.Class, Convert.ToString(f.Id))).ToList();

            return agrClassSelectList;
        }
    }
}