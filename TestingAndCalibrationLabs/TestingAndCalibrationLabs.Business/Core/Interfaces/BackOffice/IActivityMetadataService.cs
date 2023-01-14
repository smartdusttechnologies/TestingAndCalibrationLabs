using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface For Activity Metadata Service
    /// </summary>
    public interface IActivityMetadataService
    {
        /// <summary>
        /// Get All From Activity Metadata
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        List<ActivityMetadataModel> GetAll(int activityId ,int workflowStageId);
       

    }
}
