using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

      

        public WorkflowModel GetByModuleId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowModel>(@"select * from Workflow where ModuleId = @ModuleId", new { ModuleId = moduleId }).FirstOrDefault();
        }
    }
    
}
