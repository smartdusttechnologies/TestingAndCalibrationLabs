using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IWorkflowStageService
    {
       
      // List<WorkflowStageModel> GetByWorkflowId(int workflowId);

        List<WorkflowStageModel> Get();
      
        WorkflowStageModel GetById(int id);
       
        RequestResult<int> Create(WorkflowStageModel workflowStageModel);
        
        RequestResult<int> Update(int id, WorkflowStageModel workflowStageModel);
       
        bool Delete(int id);
    }
}
