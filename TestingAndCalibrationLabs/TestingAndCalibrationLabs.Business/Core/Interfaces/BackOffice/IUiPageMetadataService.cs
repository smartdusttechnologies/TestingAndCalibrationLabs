using System.Collections.Generic;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Page Metadata Type
    /// </summary>
    public interface IUiPageMetadataService
    {
        /// <summary>
        /// Get All UIDisplayName From Ui Page Metadata
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModel> GetDisplayName();
        /// <summary>
        /// Get Record By moduleLayoutId From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataModel> GetResult(int moduleLayoutId);
        /// <summary>
        /// Get All Record From Ui Page Metadata
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModel> Get();
        /// <summary>
        /// Get Record By Id From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModel GetById(int id);
        /// <summary>
        /// Get Record By Id and uiPageTypeId,metadataModuleBridgeId  From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModel GetByPageId(int id, int uiPageTypeId,int metadataModuleBridgeId);
        /// <summary>
        /// Insert Record In Ui Metadata
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        RequestResult <int> Create(UiPageMetadataModel uiPageMetadataModel);
        /// <summary>
        /// Update Record In Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        RequestResult <int> Update(UiPageMetadataModel uiPageMetadataModel);
        /// <summary>
        /// Delete Record From Ui Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id, int metadataModuleBridgeId);
    }
}
