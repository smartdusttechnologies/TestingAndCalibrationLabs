using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    /// <summary>
    /// Repostiory Class For Workflow Activity
    /// </summary>
    public class WorkflowActivityRepository : IWorkflowActivityRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowActivityRepository(IConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// To Get Record Based On WorkflowStageId
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public List<WorkflowActivityModel> GetByWorkflowStageId(int stageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowActivityModel>(@"select wa.Id, wa.ActivityId , wa.Name , a.Name as ActivityName,wa.WorkflowStageId
                                                    From [WorkflowActivity] wa 
                                                         inner join [Activity] a on wa.ActivityId = a.Id
			                                             where wa.WorkflowStageId = @stageId
                                                         AND wa.IsDeleted = 0 
                                                         And a.IsDeleted = 0", new {stageId}).ToList();
        }
    }
}
