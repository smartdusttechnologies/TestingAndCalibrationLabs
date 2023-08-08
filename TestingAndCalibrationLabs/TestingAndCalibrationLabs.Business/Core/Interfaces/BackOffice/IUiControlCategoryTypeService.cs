using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Data Type
    /// </summary>
    public interface IUiControlCategoryTypeService
    {
        /// <summary>
        /// Get All Record From Ui Control Category Type
        /// </summary>
        List<UiControlCategoryTypeModel> Get();
        /// <summary>
        /// Get Record by Id From Ui Control Category Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlCategoryTypeModel Get(int id);
        /// <summary>
        /// Update Record In Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Insert Record In Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiControlCategoryTypeModel uiControlCategoryTypeModel);
        /// <summary>
        /// Delete Record From Ui Control Category Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        UiControlCategoryTypeModel GetById(int id);

    }
}
