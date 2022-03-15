using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;


namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// sampleService is implimenting the services from ISampleService
    /// </summary>
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        #region public methods

        public RequestResult<int> Add(SampleModel sample)
        {
            _sampleRepository.Insert(sample);
            return new RequestResult<int>(1);
        }
        public RequestResult<int> AddCollection(List<SampleModel> expenses)
        {
            _sampleRepository.InsertCollection(expenses);
            return new RequestResult<int>(1);
        }
        public bool Delete(int id)
        {
            _sampleRepository.Delete(id);
            return true;
        }
        public List<SampleModel> Get()
        {
            return _sampleRepository.Get();
        }
     
        public SampleModel Get(int id)
        {
            return _sampleRepository.Get(id);
        }

        public RequestResult<int> Update(int id, SampleModel sample)
        {
            _sampleRepository.Update(sample);
            return new RequestResult<int>(1);
        }
        #endregion
    }
}
