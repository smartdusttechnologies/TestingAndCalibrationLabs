using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Page Type
    /// </summary>
    /// <returns></returns>
    public interface IUiPageMetadataModuleBridgeService
    {
        /// <summary>
        /// Get All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        List<UiPageMetadataModuleBridgeModel> Get();
        /// <summary>
        /// Get Record from generic By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModuleBridgeModel GetById(int id);
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageMetadataModuleBridgeModel GetBy(int id);
        /// <summary>
        /// Insert Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageMetadataModuleBridgeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridgeModel);
        /// <summary>
        /// Edit Record From Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridgeModel);
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
