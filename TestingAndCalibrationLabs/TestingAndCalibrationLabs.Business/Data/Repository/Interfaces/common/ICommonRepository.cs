using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for common Operations of configurable UI pages.
    /// </summary>
    public interface ICommonRepository
    {
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        int Insert(RecordModel record);
        /// <summary>
        /// To Get Records Based on ModuleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<UiPageDataModel> GetUiPageDataByModuleId(int moduleId);
        /// <summary>
        /// to get UiPagemetadata Based On PageTypeId
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetUiPageMetadata(int uiPageId);
        /// <summary>
        /// To Get UiPageValidation Based On UiPageTypeId
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        List<UiPageValidationModel> GetUiPageValidations(int uiPageId);
        /// <summary>
        /// To Get UiPageMetadata Based on ModuleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetUiPageMetadataByModuleId(int moduleId);
        /// <summary>
        /// To Get UiPageTypeId Based On WorkflowStageId
        /// </summary>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        int GetPageIdBasedOnCurrentWorkflowStage(int workflowStageId);
        /// <summary>
        /// Get Get UiPageTypeId Based On ModuleId 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        int GetPageIdBasedOnOrder(int moduleId);
        /// <summary>
        /// To Save Record
        /// </summary>
        /// <param name="recordModel"></param>
        /// <returns></returns>
        bool Save(RecordModel recordModel);
        /// <summary>
        /// Get Workflow Stage Id Based On Module Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        int GetWorkflowStageBasedOnOrder(int moduleId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"
        /// <param name="uiPageTypeId"
        /// <returns></returns>
        List<UiPageDataModel> GetPageData(int recordId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeId"></param>
        /// <returns></returns>
        List<UiPageDataModel> GetMultiPageData(int id);
        /// <summary>
        /// Get All UiPageMetadata Based On Record Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetMultiControlMetadata(int recordId);
        /// <summary>
        /// Insert Multi Value Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool InsertMultiValue(RecordModel record);
        /// <summary>
        /// Update Multi Value Records
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool UpdateMultiValue(RecordModel record);
        /// <summary>
        /// Delete Multi Value Records
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool DeleteMultiValue(RecordModel record);
    }
}
