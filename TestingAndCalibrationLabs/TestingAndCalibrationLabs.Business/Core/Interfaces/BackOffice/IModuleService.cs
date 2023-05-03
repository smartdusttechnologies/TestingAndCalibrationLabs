using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        List<ModuleModel> Get();
    }
}
