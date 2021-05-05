using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface IPesticideService
    {
        ListPesticideForListVm GetAllPesticideForList(string userId);
        void AddPesticide(NewPesticideVm newPesticide, string userId);
        void DeletePesticide(int pesticideId);
        NewPesticideVm GetPesticideById(int pesticideId);
        void UpdatePesticide(NewPesticideVm editPesticide);
    }
}