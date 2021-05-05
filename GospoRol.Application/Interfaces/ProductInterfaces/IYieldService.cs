using GospoRol.Application.ViewModels.ProductsViewsModels.YieldViewModels;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface IYieldService
    {
        ListYieldForListVm GetAllYieldForList(string userId);
        void AddYield(NewYieldVm model, string userId);
        void DeleteYield(int yieldId);
        NewYieldVm GetYieldById(int id);
        void UpdateYield(NewYieldVm editYield);
    }
}