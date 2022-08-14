using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for common Operations of configurable UI pages.
    /// </summary>
    public interface ICommonRepository
    {
        int Insert(RecordModel record);
        List<UiPageDataModel> GetUiPageDataByUiPageId(int uiPageId);
        RecordModel GetUiPageMetadata(int uiPageTypeId);
        List<UiPageValidation> GetUiPageValidations(int uiPageId);
    }
}
