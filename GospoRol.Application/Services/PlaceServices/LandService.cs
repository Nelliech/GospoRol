﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Mapping;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.LandViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Application.Services.PlaceServices
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

        public NewLandVm GetLandById(int landId)
        {
            var land = _landRepository.GetLandById(landId);
            var landVm = _mapper.Map<NewLandVm>(land);
            return landVm;
        }

        public void UpdateLand(NewLandVm model,decimal oldAcreage, decimal oldAcreageFree)
        {
            var newLand = _mapper.Map<Land>(model);
            if (newLand.Acreage>oldAcreage)
            {
                newLand.AcreageFree = newLand.AcreageFree + (newLand.Acreage - oldAcreage);
            }
            else
            {
                newLand.AcreageFree = newLand.AcreageFree - (oldAcreage - newLand.Acreage);
            }
            _landRepository.UpdateLand(newLand);

        }

        public void DeleteLand(int landId)
        {
            _landRepository.DeleteLand(landId);
        }
    }
}