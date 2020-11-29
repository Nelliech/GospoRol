using System.Collections.Generic;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Interfaces.TreatmentInterfaces
{
    public interface ISprayingRepository
    {
        int AddSpraying(Spraying spraying);
        void DeleteSpraying(int sprayingId);
        void UpdateSpraying(Spraying spraying);
        Spraying GetSprayingById(int sprayingId);
        ICollection<Spraying> GetAllSprayings();
    }
}