using System.Collections.Generic;
using System.Linq;
using GospoRol.Domain.Models;

namespace GospoRol.Domain.Interfaces
{
    public interface ILandRepository
    {
        int AddLand(Land land);
        void DeleteLand(int landId);
        void UpdateLand(Land land);
        void ChangeAcreageOccupied(double acreageFields, int landId);
        Land GetLandById(int landId);
        IQueryable<Land> GetAllLand(string userId);


    }
}