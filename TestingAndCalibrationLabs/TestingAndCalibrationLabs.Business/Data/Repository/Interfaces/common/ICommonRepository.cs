using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for common Operations of configurable UI pages.
    /// </summary>
    public interface ICommonRepository
    {
        int GetRecordId(int ModuleId,int  WorkflowStageId);
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RecordModel Insert(RecordModel record);
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
        /// </summary>
        /// <param name="recordId"
        /// <returns></returns>
        List<UiPageDataModel> GetPageData(int recordId);
        /// <summary>
        /// Get all Grid data
        /// <param name="id"></param>
        /// <param name="uiMetadata"></param>
        /// <returns></returns>
        List<UiPageDataModel> GetMultiPageData(int id,int uiMetadata);
        /// <summary>
        /// Get All UiPageMetadata Based On moduleLayoutId and UiPageTypeId
        /// </summary>
        /// <param name="moduleLayoutId"></param>
        /// <param name="UiPageTypeId"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetMultiControlMetadata(int moduleLayoutId, int UiPageTypeId);
        /// <summary>
        /// Delete Multi Value Records
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool DeleteMultiValue(RecordModel record);
        // <summary>
        // Image Upload in database
        //</summary>
        int FileUpload(FileUploadModel File);
        // <summary>
        // Image Download  in database
        //</summary>
        FileUploadModel ImageDownload(string ImageValue);
        // <summary>
        // Get SubrecordId  
        //</summary>
        int Getkey();
    }
}