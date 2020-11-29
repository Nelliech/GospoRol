using System.Linq;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Interfaces.TreatmentInterfaces
{
    public interface IHarvestRepository
    {
        int AddHarvest(Harvest harvest);
        void DeleteHarvest(int harvestId);
        void UpdateHarvest(Harvest harvest);
        Harvest GeHarvestById(int harvestId);
        IQueryable<Harvest> GetAllHarvest(int harvestId);


    }
}