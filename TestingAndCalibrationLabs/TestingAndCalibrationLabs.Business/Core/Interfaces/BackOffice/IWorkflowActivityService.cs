using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface For WorkflowActivityService
    /// </summary>
    public interface IWorkflowActivityService
    {
        /// <summary>
        /// Get All Records From WorkflowActivityService
        /// </summary>
        /// <returns></returns>
        List<WorkflowActivityModel> Get();
        /// <summary>
        /// Get Record By Id From WorkflowActivityService
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkflowActivityModel GetById(int id);
        /// <summary>
        /// Insert Record In WorkflowActivityService
        /// </summary>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(WorkflowActivityModel workflowActivityModel);
        /// <summary>
        /// Update Record In WorkflowActivityService
        /// </summary>   
        /// <param name="id"></param>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, WorkflowActivityModel workflowActivityModel);
        /// <summary>
        /// Delete Record WorkflowActivityService
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
