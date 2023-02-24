using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{

    public class ActivityService : IActivityService
    {
        private readonly IGenericRepository<ActivityModel> _genericRepository;
        public ActivityService(IGenericRepository<ActivityModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods

        public RequestResult<int> Create(ActivityModel activityModel)
        {
            _genericRepository.Insert(activityModel);
            return new RequestResult<int>(1);
        }


        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }


        public RequestResult<int> Update(ActivityModel activityModel)
        {
            _genericRepository.Update(activityModel);
            return new RequestResult<int>(1);
        }


        public List<ActivityModel> Get()
        {
            return _genericRepository.Get();
        }


        public ActivityModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}