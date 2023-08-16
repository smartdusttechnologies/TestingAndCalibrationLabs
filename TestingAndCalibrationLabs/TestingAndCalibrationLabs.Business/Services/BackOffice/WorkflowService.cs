using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Workflow
    /// </summary>
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;
        private readonly IGenericRepository<WorkflowModel> _genericRepository;

        public WorkflowService( IWorkflowRepository workflowRepository, IGenericRepository<WorkflowModel> genericRepository)
        {
           
            _workflowRepository = workflowRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        public WorkflowModel GetByModuleId(int moduleId)
        {
            return _workflowRepository.GetByModuleId(moduleId);
        }
        /// <summary>
        /// Get All Records From Workflow
        /// </summary>
        /// <returns></returns>
        public List<WorkflowModel> Get()
        {
            return _workflowRepository.Get();
        }
        /// <summary>
        /// Insert Record In Workflow
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(WorkflowModel workflowModel)
        {
            int id = _workflowRepository.Create(workflowModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Edit Record From Workflow
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id ,WorkflowModel workflowModel)
        {
            _workflowRepository.Update(workflowModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get Record by Id For Workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorkflowModel GetById(int id)
        {
            return _workflowRepository.GetById(id);
        }
        /// <summary>
        /// Delete Record From Workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
    }
}
