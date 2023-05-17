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
        /// Delete Record From Ui Page Metadata By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
