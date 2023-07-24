using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Page Navigation Service
    /// </summary>
    public interface IUiPageNavigationService
    {
        /// <summary>
        /// Get All Record From Ui Page Navigation Service
        /// </summary>
        List<UiPageNavigationModel> Get();

        /// <summary>
        /// Get Record By Id From Ui Page Navigation Services
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageNavigationModel GetById(int id);
        /// <summary>
        /// Insert Record In Ui Page Navigation
        /// </summary>
        /// <param name="uiPageNavigationModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageNavigationModel uiPageNavigationModel);
        /// <summary>
        /// Edit Record From Ui Page Navigation
        /// </summary>
        /// <param name="uiPageNavigationModel"></param>
        /// <param Id="id"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, UiPageNavigationModel uiPageNavigationModel);
        /// <summary>
        /// Delete Record From Ui Page Navigation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
       
    }
}

