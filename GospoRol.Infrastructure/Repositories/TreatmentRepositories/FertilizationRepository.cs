using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GospoRol.Infrastructure.Repositories.TreatmentRepositories
{
    class FertilizationRepository : IFertilizationRepository
    {
        private readonly Context _context;
        public FertilizationRepository(Context context)
        {
            _context = context;
        }
        public int AddFertilization(Fertilization fertilization)
        {
            _context.Fertilizations.Add(fertilization);
            _context.SaveChanges();
            return fertilization.Id;
        }

        public void DeleteFertilization(int fertilizationId)
        {
            var fertilization = _context.Fertilizations.Find(fertilizationId);
            if (fertilization != null)
            {
                _context.Fertilizations.Remove(fertilization);
                _context.SaveChanges();
            }
        }

        public IQueryable<Fertilization> GetAllFertilizations(string userId)
        {
            return _context.Fertilizations.Where(p => p.UserId == userId);
        }

        public IQueryable<Fertilization> GetAllFertilizationsByFieldId(int fieldId)
        {
            return _context.Fertilizations.Where(p => p.FieldId == fieldId);
        }

        public IQueryable<Fertilization> GetAllFertilizationsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Fertilization GetFertilizationById(int fertilizationId)
        {
            return _context.Fertilizations.Find(fertilizationId);
        }

        public void UpdateFertilization(Fertilization fertilization)
        {
            throw new NotImplementedException();
            
        }
        
    }
}
