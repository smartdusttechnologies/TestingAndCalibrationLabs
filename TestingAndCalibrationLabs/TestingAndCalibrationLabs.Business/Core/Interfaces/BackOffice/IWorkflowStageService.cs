using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IWorkflowStageService
    {
        WorkflowStageModel GetStage(int moduleId, int stageId);
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        List<WorkflowStageModel> GetByWorkflowId(int workflowId);
    }
}
