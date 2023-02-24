using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface For WorkflowActivityRepository
    /// </summary>
    public interface IWorkflowActivityRepository
    {
     /// <summary>
     /// Get All Records From 
     /// </summary>
     /// <returns></returns>
     List<WorkflowActivityModel> GetByWorkflowStageId(int uiPageTypeId);
        List<WorkflowActivityModel> Get();

        WorkflowActivityModel GetById(int id);

        int Create(WorkflowActivityModel workflowActivityModel);

        int Update(WorkflowActivityModel workflowActivityModel);

        bool Delete(int id);

    }
}
