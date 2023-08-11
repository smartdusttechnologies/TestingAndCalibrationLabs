using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly IGenericRepository<Layout2Model> _genericRepository;
        public LayoutService(IGenericRepository<Layout2Model> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In layout
        /// </summary>
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        public RequestResult<int> Create(Layout2Model layout2DTO)
        {
            _genericRepository.Insert(layout2DTO);
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
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        public RequestResult<int> Update(Layout2Model layout2DTO)
        {
            _genericRepository.Update(layout2DTO);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From layout
        /// </summary>
        /// <returns></returns>
        public List<Layout2Model> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get Record by Id For layout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Layout2Model GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
