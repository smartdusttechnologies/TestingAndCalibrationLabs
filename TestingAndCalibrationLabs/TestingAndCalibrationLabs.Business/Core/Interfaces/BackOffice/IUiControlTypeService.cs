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
        UiControlTypeModel GetById(int id);
        /// <summary>
        /// Get All Records From UiControlType
        /// </summary>
        /// <returns></returns>
        List<UiControlTypeModel> Get();
        /// <summary>
        /// Get All Records From  UiControlType Name
        /// </summary>
        /// <returns></returns>
        List<UiControlTypeModel> GetControl();
        /// <summary>
        /// Edit Record In UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Update( UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Insert Record In UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Delete Record From UiControlType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
