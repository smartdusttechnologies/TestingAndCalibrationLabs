using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IWorkflowStageRepository
    {
     /// <summary>
     /// Get All Records From 
     /// </summary>
     /// <returns></returns>
     List<WorkflowStageModel> GetByWorkflowId(int workflowId);
       
    }
}
