using GospoRol.Application.ViewModels.TreatmentViewModels.FertilizationViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GospoRol.Application.Interfaces.TreatmentInterfaces
{
    interface IFertilizationService
    {
        ListFertilizationForListVm GetAllFertilizationsForList(string userId);
        ListFertilizationForListVm GetAllFertilizationsForListByFieldId(int fieldId);

        void AddFertilization(NewFertilizationVm model, string userId, int fieldId);
        NewFertilizationVm GetFertilizationById(int id);
    }
}
