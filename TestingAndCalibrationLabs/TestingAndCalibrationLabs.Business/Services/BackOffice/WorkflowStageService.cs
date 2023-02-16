﻿using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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
