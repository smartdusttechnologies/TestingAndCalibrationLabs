using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For WorkflowStage
    /// </summary>
    public class WorkflowStageService : IWorkflowStageService
    {
        private readonly IWorkflowStageRepository _workflowStageRepository;
        private readonly IGenericRepository<WorkflowStageModel> _genericRepository;
        private readonly IWorkflowService _workflowService;

        public WorkflowStageService(IWorkflowStageRepository workflowStageRepository, IGenericRepository<WorkflowStageModel> genericRepository, IWorkflowService workflowService)
        {
            _workflowStageRepository = workflowStageRepository;
            _genericRepository = genericRepository;
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
        /// <summary>
        /// Insert Record In WorkflowStage
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(WorkflowStageModel pageControl)
        {
            int id = _workflowStageRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From WorkflowStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record by Id For WorkflowStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorkflowStageModel GetById(int id)
        {
            return _workflowStageRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record From WorkflowStage
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workflowStageModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, WorkflowStageModel workflowStageModel)
        {
            _workflowStageRepository.Update(workflowStageModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From WorkflowStage
        /// </summary>
        /// <returns></returns>
        public List<WorkflowStageModel> Get()
        {
            return _workflowStageRepository.Get();
        }
    }
}
