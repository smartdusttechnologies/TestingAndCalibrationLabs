using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Metadata
    /// </summary>
    public class UiPageMetadataService : IUiPageMetadataService
    {
        private readonly IUiPageMetadataCharacteristicsRepository _uiPageMetadataCharacteristicsRepository;
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        public UiPageMetadataService(IUiPageMetadataRepository uiPageMetadataRepository,IGenericRepository<UiPageMetadataModel> genericRepository, IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel uiPageMetadataModel)
        {
            int id = _uiPageMetadataRepository.Create(uiPageMetadataModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id, int uiPageTypeId, int metadataModuleBridgeId)
        {
            return _uiPageMetadataRepository.Delete(id,  uiPageTypeId, metadataModuleBridgeId);
        }
        /// <summary>
        /// Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            return _uiPageMetadataRepository.GetById(id);
        }
        /// <summary>
        /// Get Record by Id and uiPageTypeId ,metadataModuleBridgeId For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetByPageId(int id, int uiPageTypeId , int metadataModuleBridgeId)
        {

            return _uiPageMetadataRepository.GetByPageId(id, uiPageTypeId,metadataModuleBridgeId);
        }
        /// <summary>
        /// Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel uiPageMetadataModel, int metadataModuleBridgeId)
        {
            _uiPageMetadataRepository.Update(uiPageMetadataModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            return _uiPageMetadataRepository.Get();
        }
        /// <summary>
        /// Get All Records by moduleLayoutId From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetResult( int moduleLayoutId)
        {

            return _uiPageMetadataRepository.GetExisting(moduleLayoutId);
        }
        /// <summary>
        /// Get All UIDisplayName  From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetDisplayName()
        {
            return _uiPageMetadataRepository.GetDisplayName();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
