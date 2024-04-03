using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Metadata Type
    /// </summary>
    public interface IUiPageMetadataRepository
    {
        /// <summary>
        /// Get All Records From Ui Page Metadata
        /// </summary>
        /// <returns></returns>
        List <UiPageMetadataModel> Get();
        /// <summary>
        /// Get Record By Id From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModel GetById(int id);
        /// <summary>
        /// Get Record By Id and uiPageTypeId,metadataModuleBridgeId From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModel GetByUiPageTypeId(int id, int uiPageTypeId, int metadataModuleBridgeId);
        /// <summary>
        /// Insert Record In Ui Metadata
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        int Create(UiPageMetadataModel uiPageMetadataModel);
        /// <summary>
        /// Update Record In Ui Page Metadata
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        int Update(UiPageMetadataModel uiPageMetadataModel);
        /// <summary>
        /// Delete Record From Ui Page Metadata By Id and metadataModuleBridgeId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id,int metadataModuleBridgeId);
        /// <summary>
        /// Get UiDisplayName From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetDisplayName(int moduleLayoutId, int ModuleIds);
        /// <summary>
        /// Existing Record In Ui Page Metadata based on moduleLayoutId
        /// </summary>
        /// <param name="moduleLayoutId"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetExistingMetadata(int moduleLayoutId);
        /// <summary>
        /// Get all pages based on moduleLayoutId
        /// </summary>
        /// <param name="moduleLayoutId"></param>
        /// <returns></returns>
        List<UiPageTypeModel> GetPages(int moduleLayoutId);
        /// <summary>
        /// Create Pages in Metadata and UiPageMetadataModuleBridge
        /// </summary>
        /// <param name="StagesCount"></param>
        /// <returns></returns>
        int CreateUsingPages(UiPageMetadataModel uiPageMetadataModel, int StagesCount);


    }
}
