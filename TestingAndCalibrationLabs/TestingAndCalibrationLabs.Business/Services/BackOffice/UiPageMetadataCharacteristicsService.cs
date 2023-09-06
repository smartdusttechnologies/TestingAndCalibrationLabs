using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For UiPageMetadataCharacterisctis
    /// </summary>
    public class UiPageMetadataCharacteristicsService : IUiPageMetadataCharacteristicsService
    {
        private readonly IUiPageMetadataCharacteristicsRepository   _PageMetadataCharacteristicsRepository;
        
        public UiPageMetadataCharacteristicsService(IUiPageMetadataCharacteristicsRepository pageMetadataCharacteristicsRepository)
        {
            _PageMetadataCharacteristicsRepository = pageMetadataCharacteristicsRepository;
        }
        /// <summary>
        /// Get UiPageMetadataCharacteristics Record By PageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id)
        {
            return _PageMetadataCharacteristicsRepository.GetByPageMetadataId(id);
        }
        /// <summary>
        /// Get All UiPageMetadataCharacteristics Record
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataCharacteristicsModel> Get()
        {
            return _PageMetadataCharacteristicsRepository.Get();
        }
        /// <summary>
        /// Get All UiPageMetadataCharacteristics Record Based on metadataId
        /// </summary>
        /// <returns></returns>
        public UiPageMetadataCharacteristicsModel Get(int metadataId)
        {
           return _PageMetadataCharacteristicsRepository.Get(metadataId);
        }
        /// <summary>
        /// Get All Record For UiPageMetadataCharacteristics Record Based on Id
        /// </summary>
        /// <returns></returns>
        public UiPageMetadataCharacteristicsModel GetById(int id)
        {
            return _PageMetadataCharacteristicsRepository.GetById(id);
        }
        /// <summary>
        /// Update Record From UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataCharacteristicsModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel)
        {
            _PageMetadataCharacteristicsRepository.Update(uiPageMetadataCharacteristicsModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Insert Record In UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiPageMetadataCharacteristicsModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel)
        {
            _PageMetadataCharacteristicsRepository.Create(uiPageMetadataCharacteristicsModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From UiPageMetadataCharacteristics 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _PageMetadataCharacteristicsRepository.Delete(id);
        }


    }
}
