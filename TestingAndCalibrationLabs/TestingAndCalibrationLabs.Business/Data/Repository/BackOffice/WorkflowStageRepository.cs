﻿using TestingAndCalibrationLabs.Business.Infrastructure;
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
        /// Get Record Based On WorkflowId
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        //public List<WorkflowStageModel> GetByWorkflowId(int workflowId)
        //{
        //    using IDbConnection db = _connectionFactory.GetConnection;
        //    return db.Query<WorkflowStageModel>(@"select * from WorkflowStage where WorkflowId = @WorkflowId", new { WorkflowId = workflowId }).ToList();
        //}

        public int Create(WorkflowStageModel workflowStageModel)
        {
            string query = @"Insert into [WorkflowStage] (WorkflowId,Name,UiPageTypeId,Orders)
                                                  values (@WorkflowId,@Name,@UiPageTypeId,@Orders)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, workflowStageModel);
        }

        public List<WorkflowStageModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"Select   wfs.Id,
                                                            wfs.UiPageTypeId,
                                                            upt.[Name] as UiPageTypeName, 
                                                            wfs.WorkflowId,          
                                                            wf.[Name] as WorkflowName, 
                                                            wfs.Name,
                                                            wfs.Orders                                                        
                                                    From [WorkflowStage] wfs
                                                    inner join [UiPageType] upt on wfs.UiPageTypeId = upt.Id
                                                    inner join [Workflow] wf on  wfs.WorkflowId = wf.Id

                                                where 
                                                    wfs.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and  wf.IsDeleted = 0").ToList();
        }

        public WorkflowStageModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var workflowStageById = db.Query<WorkflowStageModel>(@"Select wfs.Id,
                                                       wfs.UiPageTypeId,     
													 upt.[Name] as UiPageTypeName,
													wfs.WorkflowId, 
													 wf.[Name] as WorkflowName,
                                                     wfs.Name,
                                                     wfs.Orders
                                                    From [WorkflowStage] wfs
													
                                                    inner join [UiPageType] upt on wfs.UiPageTypeId = upt.Id
                                                    inner join [Workflow] wf on wfs.WorkflowId = wf.Id
                                                   
                                                where 
                                                        wfs.Id=@Id
                                                     and wfs.IsDeleted = 0 
                                                    and upt.IsDeleted = 0", new { Id = id }).FirstOrDefault();

            return workflowStageById;
        }

        public int Update(WorkflowStageModel workflowStageModel)
        {
            string query = @"update [WorkflowStage] Set  
                                UiPageTypeId = @UiPageTypeId,
                                WorkflowId = @WorkflowId,  
                                Name = @Name,
                               Orders=@Orders
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            //workflowStageModel.ControlCategoryId = null;
            return db.Execute(query, workflowStageModel);
        }
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [WorkflowStage] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }

}
