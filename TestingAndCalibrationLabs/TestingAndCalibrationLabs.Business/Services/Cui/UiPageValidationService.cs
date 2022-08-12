using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageVal;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Business.Services.Cui
{
    public class UiPageValidationService : IUiPageValidationService
    {
        public readonly IUiPageValidationRepo _uiPageValidationRepo;
        public UiPageValidationService(IUiPageValidationRepo uiPageValidationRepo)
        {
            _uiPageValidationRepo = uiPageValidationRepo;
        }
        public RequestResult<int> Create(UiPageValidationModel pageControl)
        {
            _uiPageValidationRepo.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageValidationRepo.Delete(id);
        }

        public List<UiPageValidationModel> GetAll()
        {
            return _uiPageValidationRepo.GetAll();
        }

        public UiPageValidationModel GetById(int id)
        {
            return _uiPageValidationRepo.GetById(id);
        }

        public RequestResult<int> Update(int id, UiPageValidationModel pageControl)
        {
            _uiPageValidationRepo.Update(pageControl);
            return new RequestResult<int>(1);
        }
    }
}
