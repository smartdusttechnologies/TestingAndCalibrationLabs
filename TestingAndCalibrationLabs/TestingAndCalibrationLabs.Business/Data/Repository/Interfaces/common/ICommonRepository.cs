﻿using System.Collections.Generic;
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
    }
}
