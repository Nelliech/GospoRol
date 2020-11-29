using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels;
using GospoRol.Domain.Models;

namespace GospoRol.Application.Interfaces.PlaceInterfaces
{
    public interface IFieldService
    {
        int AddField(NewFieldVm newField, int landId, string userId);
        ListFieldForListVm GetAllFieldForList(string userId);
        ListFieldForListVm GetAllFieldForList(int landId);
        void DeleteField(int id);
        NewFieldVm GetFieldById(int id);
        void UpdateField(NewFieldVm model);
    }
}