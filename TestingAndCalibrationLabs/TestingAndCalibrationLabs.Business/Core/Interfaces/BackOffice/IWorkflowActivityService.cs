using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IWorkflowActivityService
    {
       bool WorkflowActivityByPageId(int pageId);
    }
}
