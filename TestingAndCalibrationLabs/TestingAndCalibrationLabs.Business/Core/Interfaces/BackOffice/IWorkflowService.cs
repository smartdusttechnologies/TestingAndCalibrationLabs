using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface For Workflow
    /// </summary>
    public interface IWorkflowService
    {
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
        RequestResult<int> Create(WorkflowModel workflowModel);
        /// <summary>
        /// Update Record In Workflow
        /// </summary>   
        /// <param name="id"></param>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, WorkflowModel workflowModel);
        /// <summary>
        /// Delete Record Workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
