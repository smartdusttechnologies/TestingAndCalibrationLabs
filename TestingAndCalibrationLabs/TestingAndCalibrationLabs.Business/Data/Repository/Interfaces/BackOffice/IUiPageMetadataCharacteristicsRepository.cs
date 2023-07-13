
using System.Collections.Generic;

using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repostiry Interface For Ui Page Metadata Characteristics
    /// </summary>
    public interface IUiPageMetadataCharacteristicsRepository
    {
        /// <summary>
        /// Get All Records Of Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> Get();
        /// <summary>
        /// Get Records By UiPageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id);
        UiPageMetadataCharacteristicsModel Get(int id);
    }
}
