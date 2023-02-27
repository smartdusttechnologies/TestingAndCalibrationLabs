using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Application
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        private readonly IGenericRepository<ApplicationModel> _genericRepository;
        public ApplicationService(IGenericRepository<ApplicationModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods
        /// <summary>
        /// Insert Record In Application
        /// </summary>
        /// <param name="applicationModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(ApplicationModel applicationModel)
        {
            _genericRepository.Insert(applicationModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Delete Record From Application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        /// <summary>
        /// Edit Record From Application
        /// </summary>
        /// <param name="applicationModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(ApplicationModel applicationModel)
        {
            _genericRepository.Update(applicationModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get All Records From Application
        /// </summary>
        /// <returns></returns>
        public List<ApplicationModel> Get()
        {
            return _genericRepository.Get();
        }

        /// <summary>
        /// Get Record by Id For Application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}