using System.Collections.Generic;
using System.Linq;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.LandViewModels;
using GospoRol.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface ILandService
    {
        void AddLand(NewLandVm land,string userId);
        ListLandForListVm GetAllLandForList(string userId);
        List<SelectListItem> GetAllLandForSelectList(string userId);
        NewLandVm GetLandById(int landId);
        void UpdateLand(NewLandVm model, decimal oldAcreage, decimal oldAcreageFree);
        void DeleteLand(int landId);
    }
}