using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
   
    public interface IWorkflowService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>U
        //WorkflowModel GetByModuleId(int moduleId);
      
        List<WorkflowModel> Get();

        WorkflowModel GetById(int id);
        
        RequestResult<int> Create(WorkflowModel workflowModel);
        
        RequestResult<int> Update(int id, WorkflowModel workflowModel);
      
        bool Delete(int id);
    }
}
