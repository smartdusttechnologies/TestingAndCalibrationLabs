using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{ 
     /// <summary>
     /// Service interface for Activity
     /// </summary>

    public interface IActivityService
    {
        /// <summary>
        /// Get All Records From Activity
        /// </summary>
        /// <returns></returns>
        List<ActivityModel> Get();
        /// <summary>
        /// Get Record By Id From Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ActivityModel GetById(int id);
        /// <summary>
        /// Insert Record In Activity
        /// </summary>
        /// <param name="activityModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(ActivityModel activityModel);
        /// <summary>
        /// Update Record In Activity
        /// </summary>    
        /// <param name="activityModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(ActivityModel activityModel);
        /// <summary>
        /// Delete Record Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}