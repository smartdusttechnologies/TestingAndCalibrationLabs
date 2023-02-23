using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface For WorkflowRepository
    /// </summary>
    public interface IWorkflowRepository
    {
     /// <summary>
     /// Get All Records From 
     /// </summary>
     /// <returns></returns>
     WorkflowModel GetByModuleId(int moduleId);

        List<WorkflowModel> Get();

        WorkflowModel GetById(int id);

        int Create(WorkflowModel workflowModel);

        int Update(WorkflowModel workflowModel);

        bool Delete(int id);
    }
}
