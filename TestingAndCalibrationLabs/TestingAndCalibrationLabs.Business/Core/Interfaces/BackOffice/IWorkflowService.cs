using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IWorkflowService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        WorkflowModel GetByModuleId(int moduleId);
    }
}
