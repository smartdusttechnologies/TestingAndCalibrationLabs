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
    /// Repository Class For Workflow 
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
            return db.Query<WorkflowModel>(@" Select   wf.Id,
                                                       wf.ModuleId,
					                                   wf.Name                                                                                                                 
											           From [Workflow] wf                                                  
											          inner join [ModuleLayout]ml on wf.ModuleId = ml.ModuleId
											        where ml.Id = @ModuleId 
											        and wf.IsDeleted = 0 
											        and ml.IsDeleted = 0 ", new { ModuleId = moduleId }).FirstOrDefault();
                                                   
        }
        /// <summary>
        /// Insert Record in Workflow
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        public int Create(WorkflowModel workflowModel)
        {
            string query = @"Insert into [Workflow] (Name,ModuleId)
                                                  values (@Name,@ModuleId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, workflowModel);
        }
        /// <summary>
        /// Getting All Records From Workflow
        /// </summary>
        /// <returns></returns>
        public List<WorkflowModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowModel>(@"Select         wf.Id,
                                                            wf.ModuleId,
                                                            m.[Name] as ModuleName,                                                          
                                                            wf.Name                                                                                                                 
                                                    From [Workflow] wf                                                  
                                                   inner join [Module] m on wf.ModuleId = m.Id
                                                where 
                                                    wf.IsDeleted = 0 
                                                    and m.IsDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id Workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorkflowModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var workflowById = db.Query<WorkflowModel>(@"Select wf.Id,
                                                       wf.ModuleId,     
													 m.[Name] as ModuleName, 								
                                                     wf.Name
                                                    From [Workflow] wf													
                                                   inner join [Module] m on wf.ModuleId = m.Id                                              
                                                where 
                                                        wf.Id=@Id
                                                     and wf.IsDeleted = 0 
                                                    and m.IsDeleted = 0", new { Id = id }).FirstOrDefault();
            return workflowById;
        }
        /// <summary>
        /// Edit Record For Workflow 
        /// </summary>
        /// <param name="workflowModel"></param>
        /// <returns></returns>
        public int Update(WorkflowModel workflowModel)
        {
            string query = @"update [Workflow] Set  
                                ModuleId = @ModuleId,                                
                                Name = @Name                              
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;        
            return db.Execute(query, workflowModel);
        }
    }
}
