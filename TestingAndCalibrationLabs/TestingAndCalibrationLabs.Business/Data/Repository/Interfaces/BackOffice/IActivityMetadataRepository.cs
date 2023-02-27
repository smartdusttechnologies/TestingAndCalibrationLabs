using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface For ActivityMetadataRepository
    /// </summary>
    public interface IActivityMetadataRepository
    {
        /// <summary>
        /// Get All From ActivityMetadata
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        List<ActivityMetadataModel> Get(int activityId, int workflowStageId);
    }
}
