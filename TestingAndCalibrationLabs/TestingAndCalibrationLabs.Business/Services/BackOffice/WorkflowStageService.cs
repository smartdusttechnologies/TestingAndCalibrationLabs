using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Data Type
    /// </summary>
    public class WorkflowStageService : IWorkflowStageService
    {
        private readonly IWorkflowStageRepository _workflowStageRepository;
        private readonly IWorkflowService _workflowService;
        public WorkflowStageService(IWorkflowStageRepository workflowStageRepository,IWorkflowService workflowService)
        {
            _workflowStageRepository = workflowStageRepository;
            _workflowService = workflowService;
        }
        /// <summary>
        /// To Get Metadata Based On Module Id And stageId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="stageId"></param>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        public WorkflowStageModel GetStage(int moduleId, int recordId)
        {
            var workflowStage = new WorkflowStageModel();
            //TODO: All this can be done in one call inside GetUiMetadata , one call to database
            if (recordId == 0)
            {
                workflowStage = _workflowStageRepository.GetPageIdBasedOnOrder(moduleId);
            }
            else
            {
                workflowStage = _workflowStageRepository.GetPageIdBasedOnCurrentWorkflowStage(recordId);
            }
            return workflowStage;
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<WorkflowStageModel> GetByWorkflowId(int moduleId)
        {
            var workflowData = _workflowService.GetByModuleId(moduleId);
            return _workflowStageRepository.GetByWorkflowId(workflowData.Id);
        }
    }
}
