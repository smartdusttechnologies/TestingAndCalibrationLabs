using System.Collections.Generic;
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
        /// Get All Records From Ui Page Metadata
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModel> GetAll();
        /// <summary>
        /// Get Record By Id From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModel GetById(int id);
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
        RequestResult <int> Update(int id , UiPageMetadataModel uiPageMetadataModel);
        /// <summary>
        /// Delete Record From Ui Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
