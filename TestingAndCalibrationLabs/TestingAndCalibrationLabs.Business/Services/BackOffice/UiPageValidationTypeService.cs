using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageValidationTypeService : IUiPageValidationTypeService
    {
        public readonly IUiPageValidationTypeRepository _uiPageValidationTypeRepository;
        public UiPageValidationTypeService(IUiPageValidationTypeRepository uiPageValidationTypeRepository)
        {
            _uiPageValidationTypeRepository = uiPageValidationTypeRepository;
        }
        public RequestResult<int> Create(UiPageValidationModel pageControl)
        {
            _uiPageValidationTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageValidationTypeRepository.Delete(id);
        }

        public List<UiPageValidationModel> GetAll()
        {
            return _uiPageValidationTypeRepository.GetAll();
        }

        public UiPageValidationModel GetById(int id)
        {
            return _uiPageValidationTypeRepository.GetById(id);
        }

        public RequestResult<int> Update(int id, UiPageValidationModel pageControl)
        {
            _uiPageValidationTypeRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }
    }
}
