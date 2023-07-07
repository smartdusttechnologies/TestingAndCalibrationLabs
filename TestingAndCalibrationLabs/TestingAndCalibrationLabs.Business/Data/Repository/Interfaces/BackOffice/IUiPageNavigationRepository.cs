using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Navigation
    /// </summary>
    public interface IUiPageNavigationRepository
    {
        /// <summary>
        /// Get All Records From Ui Page Navigation 
        /// </summary>
        /// <returns></returns>
        List<UiPageNavigationModel> Get();

        /// <summary>
        /// Get Record By Id From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageNavigationModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Page navigation
        /// </summary>
        /// <param name="UiPageNavigationModel"></param>
        /// <returns></returns>
        int Create(UiPageNavigationModel UiPageNavigationModel);
        /// <summary>
        /// Update Record In Ui Page Validation 
        /// </summary>
        /// <param name="uiPageNavigationModel"></param>
        /// <returns></returns>
        int Update(UiPageNavigationModel UiPageNavigationModel);
    }
}
