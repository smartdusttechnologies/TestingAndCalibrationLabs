using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiPageValidationTypeService
    {
        List<UiPageValidationModel> GetAll();
        UiPageValidationModel GetById(int id);
        RequestResult<int> Create(UiPageValidationModel uiPageMetadataMode);
        RequestResult<int> Update(int id, UiPageValidationModel uiPageValidationModel);
        bool Delete(int id);
    }
}
