using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Metadata Type
    /// </summary>
    public interface IUiPageMetadataModuleBridgeRepository
    {

        /// <summary>
        /// Get All Records From Ui Page Metadata
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModuleBridgeModel> Get();
        /// <summary>
        /// Get Record By Id From Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiPageMetadataModuleBridgeModel> GetControl();

        UiPageMetadataModuleBridgeModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Metadata
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Insert(UiPageMetadataModuleBridgeModel uiControlTypeModel);
        /// <summary>
        /// Update Record In Ui Page Metadata
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Update(UiPageMetadataModuleBridgeModel uiControlTypeModel);
        /// <summary>
        /// Delete Record From Ui Page Metadata By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}