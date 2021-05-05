using System.Linq;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Interfaces.PlaceInterfaces
{
    public interface IFieldRepository
    {
        //int AddField(Field field);
        //void DeleteField(int fieldId);
        void UpdateField(Field field);
        void ChangeCultivatedPlant(int fieldId, string cultivatedPlant, string variety);
        Field GetFieldById(int fieldId);
        IQueryable<Field> GetAllFields(string userId);
        IQueryable<Field> GetAllFields(int landId);

    }
}