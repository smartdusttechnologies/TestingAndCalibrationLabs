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
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        List<WorkflowStageModel> GetByWorkflowId(int workflowId);
        /// <summary>
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        WorkflowModel GetByModuleId(int moduleId);
        /// <summary>
        /// Get All Records From WorkflowStage
        /// </summary>
        /// <returns></returns>
        List<WorkflowStageModel> Get();
        /// <summary>
        /// Get Record By Id From WorkflowStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkflowStageModel GetById(int id);
        /// <summary>
        /// Insert Record In WorkflowStage
        /// </summary>
        /// <param name="workflowStageModel"></param>
        /// <returns></returns>
        int Create(WorkflowStageModel workflowStageModel);
        /// <summary>
        /// Update Record In WorkflowStage
        /// </summary>
        /// <param name="workflowStageModel"></param>
        /// <returns></returns>
        int Update(WorkflowStageModel workflowStageModel);
        /// <summary>
        /// To Get UiPageTypeId Based On WorkflowStageId
        /// </summary>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        WorkflowStageModel GetPageIdBasedOnCurrentWorkflowStage(int workflowStageId);
        /// <summary>
        /// Get UiPageTypeId Based On ModuleId 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        WorkflowStageModel GetPageIdBasedOnOrder(int moduleId);
        /// <summary>
        /// Get the Workflow record Based On ModuleId 
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        List<WorkflowStageModel> GetbyModuleId(int ModuleId);


    }
}
