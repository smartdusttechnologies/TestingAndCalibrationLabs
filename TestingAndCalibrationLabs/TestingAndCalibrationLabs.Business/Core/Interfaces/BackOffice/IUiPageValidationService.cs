using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface for Ui Page Validation
    /// </summary>
    public interface IUiPageValidationService
    {
        /// <summary>
        /// Get All Records From Ui Page Validation
        /// </summary>
        /// <returns></returns>
        List<UiPageValidationModel> GetAll();
        /// <summary>
        /// Get Record By Id From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageValidationModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Page Vlaidation
        /// </summary>
        /// <param name="uiPageMetadataMode"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageValidationModel uiPageMetadataMode);
        /// <summary>
        /// Update Record In Ui Page Validation 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, UiPageValidationModel uiPageValidationModel);
        /// <summary>
        /// Delete Record From Ui Page Validation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
