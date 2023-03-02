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
       
    }
}
