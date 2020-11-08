using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GospoRol.Application.Interfaces;
using GospoRol.Application.ViewModels;
using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Models;

namespace GospoRol.Application.Services
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
        
    }
}