using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class ActivityMetadataService : IActivityMetadataService
    {
        private readonly IGenericRepository<ActivityMetadataModel> _genericRepository;
        public ActivityMetadataService(IGenericRepository<ActivityMetadataModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public RequestResult<bool> Create(ActivityMetadataModel activityMetadata)
        {
            throw new NotImplementedException();
        }

        public List<ActivityMetadataModel> GetAll(int activityId)
        {
            return _genericRepository.Get("ActivityId",activityId);
        }

        public ActivityMetadataModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestResult<bool> Update(ActivityMetadataModel activityMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
