using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Validation 
    /// </summary>
    public interface IUiPageValidationRepository
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
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        int Create(UiPageValidationModel uiPageValidationModel);
        /// <summary>
        /// Update Record In Ui Page Validation 
        /// </summary>
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        int Update(UiPageValidationModel uiPageValidationModel);
        /// <summary>
        /// Delete Record From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
