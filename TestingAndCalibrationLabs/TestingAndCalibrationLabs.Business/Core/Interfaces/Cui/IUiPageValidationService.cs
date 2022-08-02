using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageValidation;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Cui
{
    public interface IUiPageValidationService
    {
        List<UiPageValidationModel> GetAll();
        UiPageValidationModel GetById(int id);
        RequestResult<int> Create(UiPageValidationModel pageControl);
        RequestResult<int> Update(int id, UiPageValidationModel pageControl);
        bool Delete(int id);
    }
}
