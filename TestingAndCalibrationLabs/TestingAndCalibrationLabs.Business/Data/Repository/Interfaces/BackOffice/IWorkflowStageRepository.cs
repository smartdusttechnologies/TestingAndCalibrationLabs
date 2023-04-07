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
          //List<WorkflowStageModel> GetByWorkflowId(int workflowId);

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
        /// Delete Record From WorkflowStage By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      //  bool Delete(int id);


    }
}
