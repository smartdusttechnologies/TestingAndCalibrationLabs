using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Page Type
    /// </summary>
    /// <returns></returns>
    public interface IActivityService
    {

        List<ActivityModel> Get();

        ActivityModel GetById(int id);

        RequestResult<int> Create(ActivityModel activityModel);

        RequestResult<int> Update(ActivityModel activityModel);

        bool Delete(int id);

    }
}