using System.Collections.Generic;
using System.Linq;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Interfaces.PlaceInterfaces
{
    public interface ILandRepository
    {
        //int AddLand(Land land);
        //void DeleteLand(int landId);
        void UpdateLand(Land land);
        void ChangeAcreageOccupied(decimal acreageFields, int landId);
        Land GetLandById(int landId);
        IQueryable<Land> GetAllLand(string userId);


    }
}