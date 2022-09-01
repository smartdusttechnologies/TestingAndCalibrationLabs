using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Data Type
    /// </summary>
    public interface IUiNavigationCategoryService
    {
        /// <summary>
        /// Get All Record From Data Type
        /// </summary>
        List<UiNavigationCategoryModel> Get();
    }
}
