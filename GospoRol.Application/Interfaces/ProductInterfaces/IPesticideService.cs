using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface IPesticideService
    {
        ListPesticideForListVm GetAllPesticideForList(string userId);
    }
}