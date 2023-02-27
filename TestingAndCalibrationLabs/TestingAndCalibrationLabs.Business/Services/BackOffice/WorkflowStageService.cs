using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    
    public class WorkflowStageService : IWorkflowStageService
    {
        private readonly IWorkflowStageRepository _workflowStageRepository;
        private readonly IWorkflowService _workflowService;

        public WorkflowStageService(IWorkflowStageRepository workflowStageRepository, IWorkflowService workflowService)
        {
            _workflowStageRepository = workflowStageRepository;
            _workflowService = workflowService;
        }
       


        public RequestResult<int> Create(WorkflowStageModel pageControl)
        {
            int id = _workflowStageRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _workflowStageRepository.Delete(id);
        }

        public WorkflowStageModel GetById(int id)
        {

            return _workflowStageRepository.GetById(id);
        }

        public RequestResult<int> Update(int id, WorkflowStageModel workflowStageModel)
        {
            _workflowStageRepository.Update(workflowStageModel);
            return new RequestResult<int>(1);
        }

        public List<WorkflowStageModel> Get()
        {
            return _workflowStageRepository.Get();
        }
    }
}
