using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Page Type
    /// </summary>
    /// <returns></returns>
    public interface IUiPageTypeService
    {
        /// <summary>
        /// Get All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        List<UiPageTypeModel> Get();
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageTypeModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// Edit Record From Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
