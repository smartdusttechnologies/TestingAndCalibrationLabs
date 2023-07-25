using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For UiPageMetadataCharacteristics
    /// </summary>
    public interface IUiPageMetadataCharacteristicsService
    {
        /// <summary>
        /// Get Records By UiPageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id);
        /// <summary>
        /// Get All Record From Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> Get();
    }
}
