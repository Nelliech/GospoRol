using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Application.Services.PlaceServices
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly ILandRepository _landRepository;
        private readonly IMapper _mapper;

        public FieldService(IFieldRepository fieldRepository,ILandRepository landRepository, IMapper mapper)
        {
            _fieldRepository = fieldRepository;
            _landRepository = landRepository;
            _mapper = mapper;
            
        }

        public int AddField(NewFieldVm newField, int landId, string userId)
        {
            var field = _mapper.Map<Field>(newField);
            field.LandId = landId;
            field.UserId = userId;
            var fieldId=_fieldRepository.AddField(field);
            _landRepository.ChangeAcreageOccupied(field.Acreage,landId);
            return fieldId;
        }

        public ListFieldForListVm GetAllFieldForList(string userId)
        {
            var fields = _fieldRepository.GetAllFields(userId).ProjectTo<FieldForListVm>(_mapper.ConfigurationProvider).ToList();
            var fieldList = new ListFieldForListVm()
            {
                Count = fields.Count,
                Fields = fields
            };
            return fieldList;
        }

        public ListFieldForListVm GetAllFieldForList(int landId)
        {
            var fields = _fieldRepository.GetAllFields(landId).ProjectTo<FieldForListVm>(_mapper.ConfigurationProvider).ToList();
            var fieldList = new ListFieldForListVm()
            {
                Count = fields.Count,
                Fields = fields
            };
            return fieldList;
        }

        public void DeleteField(int fieldId)
        {
            var field = _fieldRepository.GetFieldById(fieldId);
            var landId = field.LandId;
            _fieldRepository.DeleteField(fieldId);
            _landRepository.ChangeAcreageOccupied(-field.Acreage, landId);

        }

        public NewFieldVm GetFieldById(int id)
        {
            var field = _fieldRepository.GetFieldById(id);
            var fieldVm = _mapper.Map<NewFieldVm>(field);
            return fieldVm;
        }

        public void UpdateField(NewFieldVm model)
        {
            var field = _mapper.Map<Field>(model);
            _fieldRepository.UpdateField(field);

        }
    }
}