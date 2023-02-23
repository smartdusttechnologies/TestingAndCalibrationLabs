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


        List<WorkflowStageModel> Get();

        WorkflowStageModel GetById(int id);

        int Create(WorkflowStageModel workflowStageModel);

        int Update(WorkflowStageModel workflowStageModel);

        bool Delete(int id);


    }
}
