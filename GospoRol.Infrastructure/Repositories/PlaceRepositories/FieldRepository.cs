using System.Linq;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Infrastructure.Repositories.PlaceRepositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly Context _context;

        public FieldRepository(Context context)
        {
            _context = context;
        }
        public int AddField(Field field)
        {
            _context.Fields.Add(field);
            _context.SaveChanges();
            return field.Id;
        }
        public void DeleteField(int fieldId)
        {
            var field = _context.Fields.Find(fieldId);
            if (field != null)
            {
                _context.Fields.Remove(field);
                _context.SaveChanges();
            }
        }
        public void UpdateField(Field field)
        {
            _context.Attach(field);
            _context.Entry(field).Property("FieldName").IsModified = true;
            _context.Entry(field).Property("Acreage").IsModified = true;
            _context.Entry(field).Property("CultivatedPlant").IsModified = true;
            _context.Entry(field).Property("Variety").IsModified = true;
            _context.Entry(field).Property("AgriculturalClassId").IsModified = true;
            _context.Entry(field).Property("DistanceToWarehouse").IsModified = true;

            _context.SaveChanges();
        }
        public Field GetFieldById(int fieldId)
        {
            return _context.Fields.Find(fieldId);
        }

        public IQueryable<Field> GetAllFields(string userId)
        {
            return _context.Fields.Where(p => p.UserId == userId);
        }

        public IQueryable<Field> GetAllFields(int landId)
        {
            return _context.Fields.Where(p => p.LandId == landId);
        }
    }
}