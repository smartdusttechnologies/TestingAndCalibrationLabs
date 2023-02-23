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
            return db.Query<WorkflowModel>(@"select * from Workflow where ModuleId = @ModuleId", new { ModuleId = moduleId }).FirstOrDefault();
        }

        public int Create(WorkflowModel workflowModel)
        {
            string query = @"Insert into [Workflow] (Name,ModuleId)
                                                  values (@Name,@ModuleId)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, workflowModel);
        }

        public List<WorkflowModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowModel>(@"Select   wf.Id,
                                                            wf.ModuleId,
                                                            m.[Name] as ModuleName, 
                                                            
                                                            wf.Name
                                                                                                                   
                                                    From [Workflow] wf
                                                    
                                                   inner join [Module] m on wf.ModuleId = m.Id
                                                where 
                                                    wf.IsDeleted = 0 
                                                    and m.IsDeleted = 0").ToList();
        }
        public WorkflowModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var WorkflowById = db.Query<WorkflowModel>(@"Select wf.Id,
                                                       wf.ModuleId,     
													 m.[Name] as ModuleName, 								
                                                     wf.Name
                                                    From [Workflow] wf													
                                                   inner join [Module] m on wf.ModuleId = m.Id                                              
                                                where 
                                                        wf.Id=@Id
                                                     and wf.IsDeleted = 0 
                                                    and m.IsDeleted = 0", new { Id = id }).FirstOrDefault();

            return WorkflowById;
        }
        public int Update(WorkflowModel WorkflowModel)
        {
            string query = @"update [Workflow] Set  
                                ModuleId = @ModuleId,                                
                                Name = @Name                              
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            //workflowStageModel.ControlCategoryId = null;
            return db.Execute(query, WorkflowModel);
        }
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [Workflow] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }

}
