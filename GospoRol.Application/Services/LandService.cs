using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Mapping;
using GospoRol.Application.ViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Application.Services
{
    public class LandService : ILandService
    {
        private readonly ILandRepository _landRepository;
        private readonly IMapper _mapper;
        public LandService(ILandRepository landRepository, IMapper mapper)
        {
            _landRepository = landRepository;
            _mapper = mapper;
        }
        public int AddLand(NewLandVm newLand, string userId)
        {
            var land = _mapper.Map<Land>(newLand);
            land.AcreageFree = land.Acreage;
            land.AcreageOccupied = 0;
            land.UserId = userId;

            var id = _landRepository.AddLand(land);
            return id;

        }
        public int AddLand(NewLandVm land)
        {
            throw new System.NotImplementedException();
        }
        public ListLandForListVm GetAllLandForList(string userId)
        {
            var lands = _landRepository.GetAllLand(userId).ProjectTo<LandForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var landList = new ListLandForListVm()
            {
                Count = lands.Count,
                Lands = lands
            };
            return landList;
        }
        public ListLandNameForListVm GetAllLandForListDrop(string userId)
        {
            var lands = _landRepository.GetAllLand(userId).ProjectTo<LandNameToListVm>(_mapper.ConfigurationProvider).ToList();
            var landList = new ListLandNameForListVm()
            {
                Name = lands
            };
            return landList;
        }
    }
}