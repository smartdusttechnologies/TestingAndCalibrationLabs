using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for common Operations of configurable UI pages.
    /// </summary>
    public interface ICommonRepository
    {
        int Insert(RecordModel record);
        List<UiPageDataModel> GetUiPageDataByUiPageId(int uiPageId);
        List<UiPageDataModel> GetUiPageDataByModuleId(int moduleId);
        List<UiPageMetadataModel> GetUiPageMetadata(int uiPageId);
        List<UiPageValidationModel> GetUiPageValidations(int uiPageId);
        List<UiPageMetadataModel> GetUiPageMetadataByModuleId(int moduleId);
        int GetPageIdBasedOnCurrentWorkflowStage(int uiControlTypeId, int moduleId,int recordId);
        int GetPageIdBasedOnOrder(int moduleId);
        bool Save(RecordModel recordModel);
    }
}
