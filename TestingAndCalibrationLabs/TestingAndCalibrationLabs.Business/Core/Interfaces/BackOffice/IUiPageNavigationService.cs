using System.Collections.Generic;
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
    }
}
