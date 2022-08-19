using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageTypeService : IUiPageTypeService
    {
        public readonly IUiPageTypeRepository _uiPageTypeRepository;
        public UiPageTypeService(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            _uiPageTypeRepository.Create(uiPageTypeModel);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageTypeRepository.Delete(id);
        }

        public RequestResult<int> Edit(int id, UiPageTypeModel uiPageTypeModel)
        {
            _uiPageTypeRepository.Edit(uiPageTypeModel);
            return new RequestResult<int>(1);
        }

        public List<UiPageTypeModel> GetAll()
        {
            return _uiPageTypeRepository.GetAll();
        }
        
        public List<DataTypeModel> GetDataType()
        {
            return _uiPageTypeRepository.GetDataType();
        }
        
        public List<UiControlTypeModel> GetUiControlType()
        {
            return _uiPageTypeRepository.GetUiControlType();
        }
        
        public List<UiPageValidationTypeModel> GetUiPageValType()
        {
            return _uiPageTypeRepository.GetUiPageValType();
        }
        
        public List<UiPageMetadataModel> GetUiPageMetadataType()
        {
            return _uiPageTypeRepository.GetUiPageMetadataType();
        }

        public UiPageTypeModel GetById(int id)
        {
            return _uiPageTypeRepository.GetById(id);
        }
    }
}
