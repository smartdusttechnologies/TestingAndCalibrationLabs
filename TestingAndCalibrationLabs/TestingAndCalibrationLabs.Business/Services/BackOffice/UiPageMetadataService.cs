using System.Collections.Generic;
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
        private readonly IGenericRepository<UiPageMetadataModel> _genericRepository;
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        public UiPageMetadataService(IUiPageMetadataRepository uiPageMetadataRepository,IGenericRepository<UiPageMetadataModel> genericRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _genericRepository = genericRepository;
        }

        #region Public methods
        /// <summary>
        /// Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            _uiPageMetadataRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
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
        /// Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel pageControl)
        {
            _uiPageMetadataRepository.Update(pageControl);
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
        #endregion

        #region Private Methods

        #endregion
    }
}
