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
        public List<WorkflowActivityModel> GetByWorkflowStageId(int uiPageTypeId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowActivityModel>(@"select wa.Id , wa.Name, a.[Id] as ActivityId, a.[Name] as ActivityName
                                                        ,ws.[Id] as WorkflowStageId ,ws.[Name] as WorkflowStageName
                                                     from [WorkflowActivity] wa inner join [Activity] a on wa.ActivityId = a.Id 
                                                        inner join [WorkflowStage] ws on wa.WorkflowStageId = ws.Id
                                                        where ws.UiPageTypeId = @uiPageTypeId
                                                        AND ws.IsDeleted = 0
                                                        AND a.IsDeleted = 0
                                                        AND wa.IsDeleted = 0",new {uiPageTypeId}).ToList();
        }
    }
}
