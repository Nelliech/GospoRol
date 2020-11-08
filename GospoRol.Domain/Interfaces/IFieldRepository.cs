using System.Linq;
using GospoRol.Domain.Models;

namespace GospoRol.Domain.Interfaces
{
    public interface IFieldRepository
    {
        int AddField(Field field);
        void DeleteField(int fieldId);
        void UpdateField(Field field);
        Field GetFieldById(int fieldId);
        IQueryable<Field> GetAllFields(string userId);
    }
}