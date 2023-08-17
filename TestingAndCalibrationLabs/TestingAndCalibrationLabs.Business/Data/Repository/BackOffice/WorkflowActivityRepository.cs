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
    /// Repository Class For Workflow Activity
    /// </summary>
    public class WorkflowActivityRepository : IWorkflowActivityRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public WorkflowActivityRepository(IConnectionFactory connectionFactory)
        {
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
                                                         AND a.IsDeleted = 0", new { stageId }).ToList();
        }
        /// <summary>
        /// Insert Record in WorkflowActivity
        /// </summary>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        public int Create(WorkflowActivityModel workflowActivityModel)
        {
            string query = @"Insert into [WorkflowActivity] (Name,WorkflowStageId,ActivityId)
                                                  values (@Name,@WorkflowStageId,@ActivityId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, workflowActivityModel);
        }
        /// <summary>
        /// Getting All Records From WorkflowActivity
        /// </summary>
        /// <returns></returns>
        public List<WorkflowActivityModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowActivityModel>(@"Select   wfa.Id,
                                                            wfa.WorkflowStageId,
                                                            wfs.[Name] as WorkflowStageName,
                                                            wfa.ActivityId,
                                                            a.[Name] as ActivityName,                                                         
                                                            wfa.Name                                                                                                                  
                                                    From [WorkflowActivity] wfa
                                                   inner join [WorkflowStage] wfs on wfa.WorkflowStageId = wfs.Id
                                                   inner join [Activity] a on wfa.ActivityId = a.Id
                                                where 
                                                    wfa.IsDeleted = 0 
                                                    and wfs.IsDeleted = 0
                                                    and a.IsDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id WorkflowActivity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorkflowActivityModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var workflowActivityById = db.Query<WorkflowActivityModel>(@"Select wfa.Id,
                                                       wfa.WorkflowStageId,     
													  wfs.[Name] as WorkflowStageName, 
                                                       wfa.ActivityId,
                                                       a.[Name] as ActivityName,  
                                                     wfa.Name
                                                    From [WorkflowActivity] wfa													
                                                 inner join [WorkflowStage] wfs on wfa.WorkflowStageId = wfs.Id 
                                                  inner join [Activity] a on wfa.ActivityId = a.Id
                                                where 
                                                        wfa.Id=@Id
                                                     and wfs.IsDeleted = 0 
                                                    and a.IsDeleted = 0", new { Id = id }).FirstOrDefault();
            return workflowActivityById;
        }
        /// <summary>
        /// Edit Record For WorkflowActivity 
        /// </summary>
        /// <param name="workflowActivityModel"></param>
        /// <returns></returns>
        public int Update(WorkflowActivityModel workflowActivityModel)
        {
            string query = @"update [WorkflowActivity] Set  
                                WorkflowStageId = @WorkflowStageId,
                                ActivityId=@ActivityId,
                                Name = @Name                              
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;          
            return db.Execute(query, workflowActivityModel);
        }     
    }
}
