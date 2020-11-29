using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;

namespace GospoRol.Application.Interfaces.ProductInterfaces
{
    public interface IFertilizerService
    {
        int AddFertilizer(NewFertilizerVm model, string userId);
        ListFertilizerForListVm GetAllFertilizerForList(string userId);
        ListFertilizerForListVm GetAllFertilizerForList(int warehouseId);
        void DeleteFertilizer(int fertilizerId);
        void UpdateFertilizer(NewFertilizerVm fertilizer);
        NewFertilizerVm GetFertilizerById(int id);

    }
}