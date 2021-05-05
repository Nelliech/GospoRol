using System.Collections.Generic;
using GospoRol.Application.ViewModels.PlaceViewModels.AgriculturalClassViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface IAgriculturalClassService
    {
        ListAgrClassForListVm GetAllAgriculturalClassForList();
        List<SelectListItem> GetAllAgriculturalClassForSelectList();
    }
}