using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Type
    /// </summary>
    public interface IUiPageTypeRepository
    {
        /// <summary>
        /// Get All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        List<UiPageTypeModel> Get();
        /// <summary>
        /// Insert Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        int Insert(UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// Update Record In Ui Page Type 
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        int Update(UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageTypeModel GetById(int id);
    }
}
