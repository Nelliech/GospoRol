using System.Collections.Generic;
using System.Linq;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.LandViewModels;
using GospoRol.Domain.Models;

namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface ILandService
    {
        int AddLand(NewLandVm land,string userId);
        ListLandForListVm GetAllLandForList(string userId);
        ListLandNameForListVm GetAllLandForListDrop(string userId);
        NewLandVm GetLandById(int landId);
        void UpdateLand(NewLandVm model, decimal oldAcreage, decimal oldAcreageFree);
        void DeleteLand(int landId);
    }
}