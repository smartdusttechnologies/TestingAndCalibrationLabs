using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly IGenericRepository<LayoutMModel> _genericRepository;
        public LayoutService(IGenericRepository<LayoutMModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In layout
        /// </summary>
        /// <param name="layoutMModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(LayoutMModel layoutMModel)
        {
            _genericRepository.Insert(layoutMModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From layout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record From layout
        /// </summary>
        /// <param name="layoutMModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(LayoutMModel layoutMModel)
        {
            _genericRepository.Update(layoutMModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From layout
        /// </summary>
        /// <returns></returns>
        public List<LayoutMModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get Record by Id For layout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LayoutMModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion
    }
}
