using System.Collections.Generic;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels;

namespace GospoRol.Application.Interfaces.TreatmentInterfaces
{
    public interface ISowingService
    {
        int AddSowing(NewSowingVm newSowing, string userId);
        ListSowingForListVm GetAllSowingByUserIdForList(string userId);
        NewSowingVm GetShowingById(int sowingId);
        void DeleteSowing(int sowingId);
    }
}