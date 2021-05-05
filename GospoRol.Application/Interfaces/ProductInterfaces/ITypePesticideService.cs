using System.Collections.Generic;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels.TypePesticideViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface ITypePesticideService
    {
        ListTypePesticideForListVm GetAllTypePesticideForList();
        List<SelectListItem> GetAllTypePesticideForSelectList();
    }
}