using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels.TypePesticideViewModels;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.ProductServices
{
    public class TypePesticideService : ITypePesticideService
    {
        private readonly ITypePesticideRepository _pesticideRepository;
        private readonly IMapper _mapper;

        public TypePesticideService(ITypePesticideRepository pesticideRepository, IMapper mapper)
        {
            _pesticideRepository = pesticideRepository;
            _mapper = mapper;
        }


        public ListTypePesticideForListVm GetAllTypePesticideForList()
        {
            var typePesticide = _pesticideRepository.GetAllTypePesticides()
                .ProjectTo<TypePesticideForListVm>(_mapper.ConfigurationProvider).ToList();
            var typePesticideList = new ListTypePesticideForListVm()
            {
                TypePesticide = typePesticide
            };

            return typePesticideList;
        }

        public List<SelectListItem> GetAllTypePesticideForSelectList()
        {
            var modelTypePesticide =GetAllTypePesticideForList().TypePesticide;
            var typePesticideSelectList = modelTypePesticide
                .Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList().ToList();

            return typePesticideSelectList;
        }
    }
}