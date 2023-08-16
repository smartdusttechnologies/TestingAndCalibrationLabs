using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Activity
    /// </summary>
    public class ActivityService : IActivityService
    {
        private readonly IGenericRepository<ActivityModel> _genericRepository;
        public ActivityService(IGenericRepository<ActivityModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In Activity
        /// </summary>
        /// <param name="activityModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(ActivityModel activityModel)
        {
            _genericRepository.Insert(activityModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record From Activity
        /// </summary>
        /// <param name="activityModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(ActivityModel activityModel)
        {
            _genericRepository.Update(activityModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From Activity
        /// </summary>
        /// <returns></returns>
        public List<ActivityModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get Record by Id For Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion 
    }
}