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
    }
}
