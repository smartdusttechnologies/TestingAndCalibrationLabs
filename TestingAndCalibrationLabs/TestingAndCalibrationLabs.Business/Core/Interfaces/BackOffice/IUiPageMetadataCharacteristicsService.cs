using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For UiPageMetadataCharacteristics
    /// </summary>
    public interface IUiPageMetadataCharacteristicsService
    {
        /// <summary>
        /// Get Records By UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id);
        /// <summary>
        /// Get All Record From Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataCharacteristicsModel> Get();
        /// <summary>
        /// Get All Record From Ui Page Metadata Characteristics based on metadataId
        /// </summary>
        /// <returns></returns>
        UiPageMetadataCharacteristicsModel Get(int metadataId);
        /// <summary>
        /// Get All Record From Ui Page Metadata Characteristics based on id
        /// </summary>
        /// <returns></returns>
        UiPageMetadataCharacteristicsModel GetById(int id);
        /// <summary>
        /// Update Record In UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel);
        /// <summary>
        /// Insert Record In UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel);
        /// <summary>
        /// Delete Record From UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
