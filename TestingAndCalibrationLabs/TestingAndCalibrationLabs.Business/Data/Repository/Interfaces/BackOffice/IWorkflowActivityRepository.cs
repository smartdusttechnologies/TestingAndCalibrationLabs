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
        /// Get All Records From WorkflowActivity
        /// </summary>
        /// <returns></returns>
        List<WorkflowActivityModel> GetByWorkflowStageId(int uiPageTypeId);
        /// <summary>
        /// Get All Records From WorkflowActivity
        /// </summary>
        /// <returns></returns>
        List<WorkflowActivityModel> Get();
        /// <summary>
        /// Get Record By Id From WorkflowActivity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkflowActivityModel GetById(int id);
        /// <summary>
        /// Insert Record In WorkflowActivity
        /// </summary>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        int Create(WorkflowActivityModel workflowActivityModel);
        /// <summary>
        /// Update Record In WorkflowActivity
        /// </summary>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        int Update(WorkflowActivityModel workflowActivityModel);
    }
}
