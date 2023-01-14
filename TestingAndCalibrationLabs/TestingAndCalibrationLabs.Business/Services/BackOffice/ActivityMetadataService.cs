using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service class For Activity Metadata 
    /// </summary>
    public class ActivityMetadataService : IActivityMetadataService
    {
        private readonly IActivityMetadataRepository _activityMetadataRepository;
        public ActivityMetadataService(IActivityMetadataRepository activityMetadataRepository)
        {
           _activityMetadataRepository= activityMetadataRepository;
        }
        /// <summary>
        /// Get all From Activity Metadata
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        public List<ActivityMetadataModel> GetAll(int activityId,int workflowStageId)
        {
            return _activityMetadataRepository.Get(activityId,workflowStageId);
        }

    }
}
