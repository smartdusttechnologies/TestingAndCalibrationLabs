using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiControlTypeService : IUiControlTypeService
    {
        public readonly IUiControlTypeRepository _uiControlTypeRepository;
        public UiControlTypeService(IUiControlTypeRepository uiControlTypeRepository)
        {
            _uiControlTypeRepository = uiControlTypeRepository;
        }
        public UiControlTypeModel Get(int id)
        {
            return _uiControlTypeRepository.Get(id);
        }
        public List<UiControlTypeModel> GetAll()
        {
            return _uiControlTypeRepository.GetAll();
        }
        public RequestResult<int> Edit(int id, UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Edit(uiControlTypeModel);
            return new RequestResult<int>(1);
        }

        public RequestResult<int> Create(UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Create(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        public bool Delete(int id)
        {
            return _uiControlTypeRepository.Delete(id);
        }
    }
}
