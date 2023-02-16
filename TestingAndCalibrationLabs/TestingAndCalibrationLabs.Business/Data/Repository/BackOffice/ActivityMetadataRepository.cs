
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For Activity Metadata
    /// </summary>
    public class ActivityMetadataRepository : IActivityMetadataRepository
        {
        private readonly IConnectionFactory _connectionFactory;
        public ActivityMetadataRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// To Get All Activity Metadata
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="workflowStageId"></param>
        /// <returns></returns>
        public List<ActivityMetadataModel> Get(int activityId, int workflowStageId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            return con.Query<ActivityMetadataModel>(@"select * from ActivityMetadata
                                                        where ActivityId = @activityId  
                                                        and WorkflowStageId = @workflowStageId", new { activityId, workflowStageId }).ToList();
           
        }
    }
}
