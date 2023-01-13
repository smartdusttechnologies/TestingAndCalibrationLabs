using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class WorkflowActivityRepository : IWorkflowActivityRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowActivityRepository(IConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }
        public List<WorkflowActivityModel> GetByWorkflowStageId(int stageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowActivityModel>(@"select wa.Id, wa.ActivityId , wa.Name , a.Name as ActivityName,wa.WorkflowStageId
                                                    From [WorkflowActivity] wa 
                                                         inner join [Activity] a on wa.ActivityId = a.Id
			                                             where wa.WorkflowStageId = @stageId", new {stageId}).ToList();
        }
    }
}
