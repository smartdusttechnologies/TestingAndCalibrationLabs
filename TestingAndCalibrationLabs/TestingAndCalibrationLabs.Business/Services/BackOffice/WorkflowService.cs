using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Data Type
    /// </summary>
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;
        private readonly IGenericRepository<WorkflowModel> _genericRepository;
        public WorkflowService(IGenericRepository<WorkflowModel> genericRepository, IWorkflowRepository workflowRepository)
        {
            _genericRepository = genericRepository;
            _workflowRepository = workflowRepository;
        }
        //public WorkflowService(IWorkflowRepository workflowRepository)
        //{
        //    _workflowRepository = workflowRepository;
        //}
        /// <summary>
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        public WorkflowModel GetByModuleId(int moduleId)
        {
            return _workflowRepository.GetByModuleId(moduleId);
        }

        ////////////
        ///
        public List<WorkflowModel> Get()
        {
            return _workflowRepository.Get();
        }
        //public RequestResult<int> Create(WorkflowModel workflowModel)
        //{
        //    _workflowRepository.Insert(workflowModel);
        //    return new RequestResult<int>(1);
        //}
        public RequestResult<int> Create(WorkflowModel workflowModel)
        {
            int id = _workflowRepository.Create(workflowModel);
            return new RequestResult<int>(1);
        }
        public RequestResult<int> Update(int id ,WorkflowModel workflowModel)
        {
            _workflowRepository.Update(workflowModel);
            return new RequestResult<int>(1);
        }
        public WorkflowModel GetById(int id)
        {
            return _workflowRepository.GetById(id);
        }
        
        public bool Delete(int id)
        {
            return _workflowRepository.Delete(id);
        }

        //public RequestResult<int> Update(int id, WorkflowModel workflowModel)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
