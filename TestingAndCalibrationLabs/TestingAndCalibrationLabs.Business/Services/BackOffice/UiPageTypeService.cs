using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Type
    /// </summary>
    public class UiPageTypeService : IUiPageTypeService
    {
        private readonly IGenericRepository<UiPageTypeModel> _genericRepository;
        public UiPageTypeService(IGenericRepository<UiPageTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods
        /// <summary>
        /// Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Insert(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}