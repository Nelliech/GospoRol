using GospoRol.Application.ViewModels;

namespace GospoRol.Application.Interfaces
{
    public interface IFieldService
    {
        int AddField(NewFieldVm newField, int landId, string userId);
        ListFieldForListVm GetAllFieldForList(string userId);
        ListFieldForListVm GetAllFieldForList(int landId);
        void DeleteField(int id);
    }
}