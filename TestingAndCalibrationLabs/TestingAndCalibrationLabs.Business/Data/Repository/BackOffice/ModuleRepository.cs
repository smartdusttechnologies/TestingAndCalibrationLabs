using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        
        public ModuleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Dictionary<int, string>> GetValues(int moduleId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            var query = @"select r.Id as Keys , upd.Value as [Values] From Record r 
                            Inner Join UiPageData upd on r.Id = upd.RecordId
                        where r.ModuleId = @moduleId and upd.UiPageMetadataId = 3014 and r.IsDeleted = 0 and upd.IsDeleted = 0";
            var df = con.Query<Dictionary<int, string>>(query, new { moduleId }).ToList();
            return df;
        }

        public int Create(ModuleModel moduleModel)
        {
            string query = @"Insert into [Module] (ApplicationId,Name)
                                                  values (@ApplicationId,@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, moduleModel);
        }
        public List<ModuleModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ModuleModel>(@"Select   m.Id,
                                                            m.ApplicationId,
                                                            a.[Name] as ApplicationName, 
                                                            
                                                            m.Name
                                                                                                                   
                                                    From [Module] m
                                                    inner join [Application] a on m.ApplicationId = a.Id
                                                    
                                                where 
                                                    m.IsDeleted = 0 
                                                    and a.IsDeleted = 0").ToList();
        }
        public ModuleModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var moduleById = db.Query<ModuleModel>(@"Select m.Id,
                                                       m.ApplicationId,     
													 a.[Name] as ApplicationName, 								
                                                     m.Name
                                                    From [Module] m													
                                                   inner join [Application] a on m.ApplicationId = a.Id                                              
                                                where 
                                                        m.Id=@Id
                                                     and m.IsDeleted = 0 
                                                    and a.IsDeleted = 0", new { Id = id }).FirstOrDefault();

            return moduleById;
        }
        public int Update(ModuleModel moduleModel)
        {
            string query = @"update [Module] Set  
                                ApplicationId = @ApplicationId,                                
                                Name = @Name                              
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            //workflowStageModel.ControlCategoryId = null;
            return db.Execute(query, moduleModel);
        }
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [Module] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }

    }
}