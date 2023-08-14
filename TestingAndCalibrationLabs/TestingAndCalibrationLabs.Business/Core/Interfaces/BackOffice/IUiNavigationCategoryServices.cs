using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Navigation Category
    /// </summary>
    public interface IUiNavigationCategoryServices
    {
        // <summary>
        /// Get All Records From Ui Navigation Category
        /// </summary>
        /// <returns></returns>
        List<UiNavigationCategoryModel> Get();
        /// <summary>
        /// Get Record By Id From Ui Navigation Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiNavigationCategoryModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Navigation Category
        /// <param name="uiNavigationCategoryModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiNavigationCategoryModel uiNavigationCategoryModel);
        /// <summary>
        /// Edit Record From Ui Navigation Category
        /// </summary>
        /// <param name="uiNavigationCategoryModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, UiNavigationCategoryModel uiNavigationCategoryModel);
        /// <summary>
        /// Delete Record From Ui Navigation Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}