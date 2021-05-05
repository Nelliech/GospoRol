using System;
using System.Linq;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Infrastructure.Repositories.TreatmentRepositories
{
    public class SowingRepository : ISowingRepository
    {
        private readonly Context _context;

        public SowingRepository(Context context)
        {
            _context = context;
        }
        public int AddSowing(Sowing sowing)
        {
            _context.Sowings.Add(sowing);
            _context.SaveChanges();
            return sowing.Id;
        }

        public void DeleteSowing(int sowingId)
        {
            var sowing = _context.Sowings.Find(sowingId);
            if (sowing != null)
            {
                _context.Sowings.Remove(sowing);
                _context.SaveChanges();
            }
        }

        public void UpdateSowing(Sowing sowing)
        {
            throw new System.NotImplementedException();
        }

        public Sowing GetSowingById(int sowingId)
        {
            return _context.Sowings.FirstOrDefault(p => p.Id == sowingId);
        }

        public IQueryable<Sowing> GetAllSowingsByUserId(string userId)
        {
            return _context.Sowings.Where(p => p.UserId == userId);
        }

        public Sowing GetNewestSowingDateTimeInField(int fieldId)
        {
            return _context.Sowings.Where(p => p.FieldId == fieldId).OrderByDescending(p => p.DateTreatment).FirstOrDefault();
        }
    }
}