using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IActivityMetadataService
    {
        List<ActivityMetadataModel> GetAll(int activityId);
        ActivityMetadataModel GetById (int id); 
        RequestResult<bool> Update(ActivityMetadataModel activityMetadata);
        RequestResult<bool> Create(ActivityMetadataModel activityMetadata);

    }
}
