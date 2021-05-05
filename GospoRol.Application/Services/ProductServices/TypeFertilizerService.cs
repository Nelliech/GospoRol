using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels.TypeFertilizerViewModels;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Services.ProductServices
{
    class TypeFertilizerService : ITypeFertilizerService
    {
        private readonly ITypeFertilizerRepository _typeFertilizerRepository;
        private readonly IMapper _mapper;
        public TypeFertilizerService(ITypeFertilizerRepository typeFertilizerRepository, IMapper mapper)
        {
            _typeFertilizerRepository = typeFertilizerRepository;
            _mapper = mapper;
        }
        public ListTypeFertilizerForListVm GetAllTypeFertilizerForList()
        {
            var typeFertilizerList = _typeFertilizerRepository.GetAllTypeFertilizers()
                .ProjectTo<TypeFertilizerForListVm>(_mapper.ConfigurationProvider).ToList();
            var typeFertilizerVm = new ListTypeFertilizerForListVm()
            {
                TypeFertilizer = typeFertilizerList
            };
            return typeFertilizerVm;
        }

        public List<SelectListItem> GetAllTypeFertilizerFoSelectList()
        {
            var modelTypeFertilizer = GetAllTypeFertilizerForList().TypeFertilizer;
            var typeFertilizerSelectList = modelTypeFertilizer
                .Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList().ToList();
            return typeFertilizerSelectList;
        }
    }
}
