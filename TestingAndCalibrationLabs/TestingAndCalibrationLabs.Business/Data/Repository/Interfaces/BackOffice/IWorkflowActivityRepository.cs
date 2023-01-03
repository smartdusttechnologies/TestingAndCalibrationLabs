using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IWorkflowActivityRepository
    {
     /// <summary>
     /// Get All Records From 
     /// </summary>
     /// <returns></returns>
     List<WorkflowActivityModel> GetByWorkflowStageId(int uiPageTypeId);
       
    }
}
