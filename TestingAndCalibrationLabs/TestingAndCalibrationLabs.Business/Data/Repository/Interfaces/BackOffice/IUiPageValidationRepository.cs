using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Validation 
    /// </summary>
    public interface IUiPageValidationRepository
    {
        List<UiPageValidationModel> GetAll();
        UiPageValidationModel GetById(int id);
        int Create(UiPageValidationModel uiPageValidationModel);
        int Update(UiPageValidationModel uiPageValidationModel);
        bool Delete(int id);
    }
}
