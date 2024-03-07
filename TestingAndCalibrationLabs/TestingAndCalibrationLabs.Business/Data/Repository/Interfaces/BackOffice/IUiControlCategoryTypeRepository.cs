using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Control Category Type
    /// </summary>
    public interface IUiControlCategoryTypeRepository
    {
        /// <summary>
        /// Get All Records From Ui Control Category Type
        /// </summary>
        /// <returns></returns>
        List<UiControlCategoryTypeModel> Get();
        /// <summary>
        /// Insert Record In Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        int Create(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Update Record In Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        int Update(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Delete Record In Ui Control Category Type
        /// </summary>
        /// <param id="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Get Record By Id From Ui Control Category Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlCategoryTypeModel GetById(int id);
        List<UiControlCategoryTypeModel> GetControlCategoryType(int ControlId);
    }
}