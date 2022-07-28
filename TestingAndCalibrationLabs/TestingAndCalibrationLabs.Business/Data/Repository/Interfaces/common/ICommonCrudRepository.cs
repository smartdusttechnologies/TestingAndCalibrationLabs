using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common
{
    /// <summary>
    /// Creating Interface for Generic Crud Operations
    /// </summary>
    public interface ICommonCrudRepository
    {
        int Insert(RecordModel record);
        List<UiPageDataModel> GetUiPageDataByUiPageId(int uiPageId);
        RecordModel GetUiPageMetadata(int uiPageId);
        List<UiPageValidation> GetUiPageValidations(int uiPageId);
    }
}
