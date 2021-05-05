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
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public FieldService(IFieldRepository fieldRepository,ILandRepository landRepository, IGenericRepository genericRepository, IMapper mapper)
        {
            _fieldRepository = fieldRepository;
            _landRepository = landRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
            
        }

        public void AddField(NewFieldVm newField, int landId, string userId)
        {
            var field = _mapper.Map<Field>(newField);
            field.LandId = landId;
            field.UserId = userId;
            _genericRepository.Add<Field>(field);
            _landRepository.ChangeAcreageOccupied(field.Acreage,landId);           
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
            _genericRepository.Delete<Field>(fieldId);
            _landRepository.ChangeAcreageOccupied(-field.Acreage, landId);

        }

        public NewFieldVm GetFieldById(int id)
        {
            var field = _fieldRepository.GetFieldById(id);
            var fieldVm = _mapper.Map<NewFieldVm>(field);
            return fieldVm;
        }
        public EditFieldVm GetFieldForEditById(int id)
        {
            var field = _fieldRepository.GetFieldById(id);
            var fieldVm = _mapper.Map<EditFieldVm>(field);
            fieldVm.OldAcreage = fieldVm.Acreage;
            return fieldVm;
        }

        public void UpdateField(EditFieldVm model)
        {          
            
            var field = _mapper.Map<Field>(model);
            decimal acreageDifference;
            if (model.OldAcreage > model.Acreage)
            {
                acreageDifference = model.OldAcreage - model.Acreage;
                _landRepository.ChangeAcreageOccupied(-acreageDifference,model.LandId);
            }
            else
            {
                acreageDifference = model.Acreage - model.OldAcreage;
                _landRepository.ChangeAcreageOccupied(acreageDifference, model.LandId);

            }
            _fieldRepository.UpdateField(field);

        }

        public void UpdateField(NewFieldVm model)
        {
            var field = _mapper.Map<Field>(model);
            _fieldRepository.UpdateField(field);
        }
    }
}