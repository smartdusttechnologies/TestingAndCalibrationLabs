using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for UiControlType
    /// </summary>
    public interface IUiControlTypeRepository
    {
        /// <summary>
        /// Get All Records From UiControlType
        /// </summary>
        /// <returns></returns>
        List<UiControlTypeModel> Get();
        /// <summary>
        /// Get Record By Id From UiControlType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlTypeModel GetById(int id);
        /// <summary>
        /// Get Record From ControlTypeName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UiControlTypeModel> GetControl();
        /// <summary>
        /// Insert Record In UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Create(UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Update Record In UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        int Update(UiControlTypeModel uiControlTypeModel);
        /// <summary>
        /// Delete Record From UiControlType By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}