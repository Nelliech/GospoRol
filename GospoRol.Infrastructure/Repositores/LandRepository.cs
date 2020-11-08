using System.Collections.Generic;
using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Infrastructure.Repositores
{
    
    public class LandRepository : ILandRepository
    {

        private readonly Context _context;

        public LandRepository(Context context)
        {
            _context = context;
        }
        public int AddLand(Land land)
        {
            _context.Lands.Add(land);
            _context.SaveChanges();
            return land.Id;
        }
        public void DeleteLand(int landId)
        {
            var land = _context.Lands.Find(landId);
            if (land != null)
            {
                _context.Lands.Remove(land);
                _context.SaveChanges();
            }
        }
        public void ChangeAcreageOccupied(double acreageFields, int landId)
        {
            var land = _context.Lands.Find(landId);
            land.AcreageOccupied = land.AcreageOccupied + acreageFields;
            land.AcreageFree = land.AcreageFree - acreageFields;
            _context.Lands.Update(land);
            _context.SaveChanges();

        }
        public void UpdateLand(Land land)
        {
            throw new System.NotImplementedException();
        }
        public Land GetLandById(int landId)
        {
            return _context.Lands.FirstOrDefault(p => p.Id == landId);
        }

        public IQueryable<Land> GetAllLand(string userId)
        {
            return _context.Lands.Where(p => p.UserId == userId);
        }

    }
}