using System.Linq;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Interfaces.Treatments
{
    public interface IFertilizationRepository
    {
        int AddFertilization(Fertilization fertilization);
        void DeleteFertilization(int fertilizationId);
        void UpdateFertilization(Fertilization fertilization);
        Fertilization GetFertilizationById(int fertilizationId);
        IQueryable<Fertilization> GetAllFertilizations();
    }
}