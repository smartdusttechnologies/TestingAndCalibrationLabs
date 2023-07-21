using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUiControlCategoryTypeRepository
    {
        /// <summary>
        /// Get All Records From UiControlCategory
        /// </summary>
        /// <returns></returns>
        List<UiControlCategoryTypeModel> Get();
        /// <summary>
        /// Insert Record In UiControlCategory
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        int Create(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Update Record In UiControlCategory
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        int Update(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Delete Record In UiControlCategory
        /// </summary>
        /// <param id="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Get Record By Id From UiControlCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlCategoryTypeModel GetById(int id);
    }
}