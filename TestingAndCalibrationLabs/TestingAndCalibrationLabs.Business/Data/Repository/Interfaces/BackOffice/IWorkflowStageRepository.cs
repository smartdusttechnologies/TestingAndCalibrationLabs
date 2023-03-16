using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface For WorkflowStageRepository
    /// </summary>
    public interface IWorkflowStageRepository
    {
        /// <summary>
        /// To Get UiPageTypeId Based On WorkflowStageId
        /// </summary>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        WorkflowStageModel GetPageIdBasedOnCurrentWorkflowStage(int workflowStageId);
        /// <summary>
        /// Get Get UiPageTypeId Based On ModuleId 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        WorkflowStageModel GetPageIdBasedOnOrder(int moduleId);
        /// <summary>
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        List<WorkflowStageModel> GetByWorkflowId(int workflowId);
       
    }
}
