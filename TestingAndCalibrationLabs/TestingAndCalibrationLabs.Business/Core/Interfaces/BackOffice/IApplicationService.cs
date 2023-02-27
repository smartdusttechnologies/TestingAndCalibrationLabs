using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Application
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Get All Records From Application
        /// </summary>
        /// <returns></returns>
        List<ApplicationModel> Get();
        /// <summary>
        /// Get Record By Id From Application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApplicationModel GetById(int id);
        /// <summary>
        /// Insert Record In Application
        /// </summary>
        /// <param name="applicationModel"></param>
        /// <returns></returns>

        RequestResult<int> Create(ApplicationModel applicationModel);
        /// <summary>
        /// Update Record In Application
        /// </summary>    
        /// <param name="applicationModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(ApplicationModel applicationModel);
        /// <summary>
        /// Delete Record Application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}