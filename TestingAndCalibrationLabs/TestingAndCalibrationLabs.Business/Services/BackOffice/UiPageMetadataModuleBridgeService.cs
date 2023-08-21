using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Type
    /// </summary>
    public class UiPageMetadataModuleBridgeService : IUiPageMetadataModuleBridgeService
    {
        private readonly IUiPageMetadataModuleBridgeRepository _uiPageMetadataModuleBridgeRepository;

        private readonly IGenericRepository<UiPageMetadataModuleBridgeModel> _genericRepository;
        public UiPageMetadataModuleBridgeService(IUiPageMetadataModuleBridgeRepository uiPageMetadataModuleBridgeRepository)
        {
            _uiPageMetadataModuleBridgeRepository = uiPageMetadataModuleBridgeRepository;
        }

        #region Public methods
        /// <summary>
        /// Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModuleBridgeModel uiPageTypeModel)
        {
            _uiPageMetadataModuleBridgeRepository.Insert(uiPageTypeModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageMetadataModuleBridgeRepository.Delete(id);
        }

        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiPageMetadataModuleBridgeModel uiPageTypeModel)
        {
            _uiPageMetadataModuleBridgeRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModuleBridgeModel> Get()
        {
            return _uiPageMetadataModuleBridgeRepository.Get();
        }

        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModuleBridgeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        public UiPageMetadataModuleBridgeModel GetBy(int id)
        {
            return _uiPageMetadataModuleBridgeRepository.GetById(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}

