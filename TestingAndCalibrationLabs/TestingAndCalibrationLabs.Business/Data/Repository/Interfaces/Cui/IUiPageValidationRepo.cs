using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageValidation;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui
{
    public interface IUiPageValidationRepo
    {
        List<UiPageValidationModel> GetAll();
        UiPageValidationModel GetById(int id);
        int Create(UiPageValidationModel pageVal);
        int Update(UiPageValidationModel pageVal);
        bool Delete(int id);
    }
}
