using System.Collections.Generic;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels.TypeFertilizerViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface ITypeFertilizerService
    {
        ListTypeFertilizerForListVm GetAllTypeFertilizerForList();
        List<SelectListItem> GetAllTypeFertilizerFoSelectList();
    }
}