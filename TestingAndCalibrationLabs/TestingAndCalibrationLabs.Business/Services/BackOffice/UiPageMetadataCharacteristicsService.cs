using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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

        public UiPageMetadataCharacteristicsModel Get(int metadataId)
        {
           return _PageMetadataCharacteristicsRepository.Get(metadataId);
        }
    }
}
