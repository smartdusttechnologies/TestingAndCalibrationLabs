using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{

    public class ApplicationService : IApplicationService
    {
        private readonly IGenericRepository<ApplicationModel> _genericRepository;
        public ApplicationService(IGenericRepository<ApplicationModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods

        public RequestResult<int> Create(ApplicationModel applicationModel)
        {
            _genericRepository.Insert(applicationModel);
            return new RequestResult<int>(1);
        }


        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }


        public RequestResult<int> Update(ApplicationModel applicationModel)
        {
            _genericRepository.Update(applicationModel);
            return new RequestResult<int>(1);
        }


        public List<ApplicationModel> Get()
        {
            return _genericRepository.Get();
        }


        public ApplicationModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}