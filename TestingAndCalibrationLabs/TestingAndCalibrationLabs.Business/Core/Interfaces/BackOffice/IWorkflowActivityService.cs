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
       bool WorkflowActivity(RecordModel recordModel);
    }
}
