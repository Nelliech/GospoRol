using System.Collections.Generic;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels.TypeSowingViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Interfaces.TreatmentInterfaces
{
    public interface ITypeSowingService
    {
        ListTypeSowingForListVm GetAllTypeSowingForList();
        List<SelectListItem> GetAllTypeSowingFotSelectList();
    }
}