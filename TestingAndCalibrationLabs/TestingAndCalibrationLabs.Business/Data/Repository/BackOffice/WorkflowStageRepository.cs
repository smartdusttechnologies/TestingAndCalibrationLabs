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
        /// Get Page Id Based On Current Workflow Stage 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public WorkflowStageModel GetPageIdBasedOnCurrentWorkflowStage(int recordId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"select ws.Id,ws.Name,ws.Orders,ws.UiPageTypeId,m.Name as ModuleName
                                                   From  Record r
                                                        inner join Module m on r.ModuleId = m.Id 
                                                        inner join WorkflowStage ws on ws.Id = r.WorkflowStageId
                                                   where r.IsDeleted = 0 and ws.IsDeleted = 0 and R.Id = @recordId", new { recordId }).First();
        }
        /// <summary>
        /// Get Page Id Based On Order And Module Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public WorkflowStageModel GetPageIdBasedOnOrder(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"Select  ws.UiPageTypeId as UiPageTypeId,ws.Id,ws.Name,ws.Orders,m.Name as ModuleName
                                                    From [Module] m
													inner join Workflow w on m.Id = w.ModuleId
													inner join [WorkflowStage] ws on w.Id = ws.WorkflowId
                                                where m.Id = @moduleId
												and ws.Orders = 0
                                                    and m.IsDeleted = 0 
													and w.IsDeleted = 0
													and ws.IsDeleted = 0", new { moduleId }).FirstOrDefault();
        }
        /// <summary>
        /// Get Record Based On WorkflowId
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        public List<WorkflowStageModel> GetByWorkflowId(int workflowId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"select * from WorkflowStage where WorkflowId = @WorkflowId and IsDeleted = 0", new { WorkflowId = workflowId }).ToList();
        }
    }
    
}
