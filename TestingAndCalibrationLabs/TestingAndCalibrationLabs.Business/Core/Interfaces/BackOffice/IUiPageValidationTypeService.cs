using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Page Validation Type
    /// </summary>
    public interface IUiPageValidationTypeService
    {
        /// <summary>
        /// Get All Records From Ui Page Validation Type
        /// </summary>
        /// <returns></returns>
        List<UiPageValidationTypeModel> Get();
    }
}
