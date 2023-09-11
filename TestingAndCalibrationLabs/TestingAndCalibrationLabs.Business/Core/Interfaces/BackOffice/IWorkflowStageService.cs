using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for WorkflowStage
    /// </summary>
    public interface IWorkflowStageService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        List<WorkflowStageModel> GetByWorkflowId(int workflowId);
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
        RequestResult<int> Create(WorkflowStageModel workflowStageModel);
        /// <summary>
        /// Update Record In WorkflowStage
        /// </summary>   
        /// <param name="id"></param>
        /// <param name="workflowStage"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, WorkflowStageModel workflowStage);
        /// <summary>
        /// Delete Record WorkflowStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
