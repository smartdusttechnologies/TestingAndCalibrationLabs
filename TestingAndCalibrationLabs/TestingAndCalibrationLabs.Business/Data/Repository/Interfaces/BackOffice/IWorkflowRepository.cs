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

        /// <summary>
        /// Get All Records From Workflow
        /// </summary>
        /// <returns></returns>
        List<WorkflowModel> Get();
        /// <summary>
        /// Get Record By Id From Workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkflowModel GetById(int id);
        /// <summary>
        /// Insert Record In Workflow
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        int Create(WorkflowModel workflowModel);
        /// <summary>
        /// Update Record In Module
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        int Update(WorkflowModel workflowModel);
        /// <summary>
        /// Delete Record From Workflow By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
