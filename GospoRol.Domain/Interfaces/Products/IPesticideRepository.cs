using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Interfaces.Products
{
    public interface IPesticideRepository
    {
        int AddPesticide(Pesticide pesticide);
        void DeletePesticide(int pesticideId);
        void UpdatePesticide(Pesticide pesticide);
    }
}