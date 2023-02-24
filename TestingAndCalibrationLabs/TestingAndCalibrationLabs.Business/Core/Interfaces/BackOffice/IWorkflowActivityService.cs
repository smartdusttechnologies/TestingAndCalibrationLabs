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
        /// To Run All Activity here Which Are Given To A Stage
        /// </summary>
        /// <param name="recordModel"></param>
        /// <returns></returns>
        //bool WorkflowActivity(RecordModel recordModel);



        List<WorkflowActivityModel> Get();

        WorkflowActivityModel GetById(int id);

        RequestResult<int> Create(WorkflowActivityModel workflowActivityModel);

        RequestResult<int> Update(int id, WorkflowActivityModel workflowActivityModel);

        bool Delete(int id);
    }
}
