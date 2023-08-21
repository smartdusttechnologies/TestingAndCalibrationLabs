
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
        /// Get Records By id from uiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id);
        UiPageMetadataCharacteristicsModel Get(int id);
        /// <summary>
        /// Get Record By Id From uiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        UiPageMetadataCharacteristicsModel GetById(int id);
        /// <summary>
        /// Insert Record In uiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Create(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel);
        /// <summary>
        /// Update Record In uiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Update(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel);
        /// <summary>
        /// Delete Record From uiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
