using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repostiory Class For Workflow Stage
    /// </summary>
        public class WorkflowStageRepository : IWorkflowStageRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowStageRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get Record Based On WorkflowId
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        public List<WorkflowStageModel> GetByWorkflowId(int workflowId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"select * from WorkflowStage where WorkflowId = @WorkflowId", new { WorkflowId = workflowId }).ToList();
        }
    }
    
}
