using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiPageTypeService
    {
        /// <summary>
        /// Service Interface For Ui Page Type
        /// </summary>
        /// <returns></returns>
        List<UiPageTypeModel> GetAll();
        List<DataTypeModel> GetDataType();
        List<UiPageValidationTypeModel> GetUiPageValidationType();
        UiPageTypeModel GetById(int id);
        RequestResult<int> Create(UiPageTypeModel uiPageTypeModel);
        RequestResult <int> Edit(int id ,UiPageTypeModel uiPageTypeModel);
        bool Delete(int id);

    }
}
