using System.Collections.Generic;
using System.Reflection;
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
        UiPageMetadataModel GetByPageId(int id, int uiPageTypeId, int metadataModuleBridgeId);
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
        List<UiPageMetadataModel> GetDisplayName();
        /// <summary>
        /// Existing Record In Ui Page Metadata based on moduleLayoutId
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetExisting(int moduleLayoutId);
    }
}
