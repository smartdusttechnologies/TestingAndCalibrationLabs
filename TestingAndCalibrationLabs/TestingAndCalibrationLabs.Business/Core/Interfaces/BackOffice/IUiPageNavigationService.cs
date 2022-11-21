using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Navigation Category
    /// </summary>
    public interface IUiPageNavigationService
    {
        /// <summary>
        /// Get All Record From Ui Navigaiton Category 
        /// </summary>
        List<UiPageNavigationModel> Get();
        /// <summary>
        /// Get All Pages With Navigation Category Record From Ui Page Type 
        /// </summary>

    }
}
