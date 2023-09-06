using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for UiPageMetadataModuleBridge
    /// </summary>
    public interface IUiPageMetadataModuleBridgeRepository
    {

        /// <summary>
        /// Get All Records From UiPageMetadataModuleBridge
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModuleBridgeModel> Get();
        /// <summary>
        /// Get Record  From Lookup
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModuleBridgeModel> GetControl();
        /// <summary>
        /// Get Record By Id From UiPageMetadataModuleBridge
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModuleBridgeModel GetById(int id);
        /// <summary>
        /// Insert Record In UiPageMetadataModuleBridge
        /// </summary>
        /// <param name="uiPageMetadataModuleBridge"></param>
        /// <returns></returns>
        int Insert(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridge);
        /// <summary>
        /// Update Record In UiPageMetadataModuleBridge
        /// </summary>
        /// <param name="uiPageMetadataModuleBridge"></param>
        /// <returns></returns>
        int Update(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridge);
        /// <summary>
        /// Delete Record From UiPageMetadataModuleBridge By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}