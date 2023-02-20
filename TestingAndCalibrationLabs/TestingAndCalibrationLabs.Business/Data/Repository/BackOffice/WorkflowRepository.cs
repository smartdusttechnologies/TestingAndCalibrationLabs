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
    /// Repostiory Class For Workflow 
    /// </summary>
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get Record By ModuleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public WorkflowModel GetByModuleId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowModel>(@"select * from Workflow where ModuleId = @ModuleId and IsDeleted = 0", new { ModuleId = moduleId }).FirstOrDefault();
        }
    }

}
