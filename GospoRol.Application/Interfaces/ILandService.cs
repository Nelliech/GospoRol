using System.Collections.Generic;
using System.Linq;
using GospoRol.Application.ViewModels;

namespace GospoRol.Application.Interfaces
{
    public interface ILandService
    {
        int AddLand(NewLandVm land,string userId);
        ListLandForListVm GetAllLandForList(string userId);
        ListLandNameForListVm GetAllLandForListDrop(string userId);
        NewLandVm GetLandById(int landId);
    }
}