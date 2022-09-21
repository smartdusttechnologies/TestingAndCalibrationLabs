using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageMetadataCharacteristicsService : IUiPageMetadataCharacteristicsService
    {
        private readonly IUiPageMetadataCharacteristicsRepository   _PageMetadataCharacteristicsRepository;
        public UiPageMetadataCharacteristicsService(IUiPageMetadataCharacteristicsRepository pageMetadataCharacteristicsRepository)
        {
            _PageMetadataCharacteristicsRepository = pageMetadataCharacteristicsRepository;
        }

        public List<UiPageMetadataCharacteristicsModel> Get(int id)
        {
            return _PageMetadataCharacteristicsRepository.Get(id);
        }

        public List<UiPageMetadataCharacteristicsModel> Get()
        {
            return _PageMetadataCharacteristicsRepository.Get();
        }

        public List<UiPageMetadataCharacteristicsModel> GetByMetadataId(int id)
        {
            return _PageMetadataCharacteristicsRepository.GetByMetadataId(id);
        }
    }
}
