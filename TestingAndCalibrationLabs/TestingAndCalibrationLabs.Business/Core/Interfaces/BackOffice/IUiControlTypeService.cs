using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Control Type
    /// </summary>
    public interface IUiControlTypeService
    {
        /// <summary>
        /// Get Ui Control Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlTypeModel Get(int id);
        /// <summary>
        /// Get All Records From Ui Control Type
        /// </summary>
        /// <returns></returns>

        List<UiControlTypeModel> GetAll();
        /// <summary>
        /// Edit Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Edit( UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Insert Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Delete Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
