using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Type
    /// </summary>
    public interface IUiPageTypeRepository
    {
        List<UiPageTypeModel> GetAll();
        List<DataTypeModel> GetDataType();
        List<UiPageValidationTypeModel> GetUiPageValidationType();
        UiPageTypeModel GetById(int id);
        int Create(UiPageTypeModel uiPageTypeModel);
        int Edit(UiPageTypeModel uiPageTypeModel);
        bool Delete(int id);
    }
}
