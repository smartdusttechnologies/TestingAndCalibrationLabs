using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using PagedList;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Creating Interface for SampleRepository
    /// </summary>
    public interface ISampleRepository
    {
        int Insert(RecordModel record);
        List<UiPageDataModel> GetUiPageDataByUiPageId(int uiPageId);
        RecordModel GetUiPageMetadata(int uiPageId);
        List<UiPageValidation> GetUiPageValidations(int uiPageId);
    }
}
