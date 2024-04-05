﻿using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;
using System;
using System.Reflection;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For Workflow Stage
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



        public List<WorkflowStageModel> GetbyModuleId(int ModuleId)
        {
            using IDbConnection db= _connectionFactory.GetConnection;
            return db.Query<WorkflowStageModel>(@"select ws.Id, ws.Name,ws.Orders,ws.UiPageTypeId
		                                            From WorkflowStage ws
		                                             inner join Workflow w on  w.Id = ws.WorkflowId
		                                             Where w.ModuleId = @moduleId
		                                             and w.IsDeleted=0
		                                             and ws.IsDeleted=0
                                                         ", new { moduleId = ModuleId }).ToList();

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
        /// <summary>
        /// Insert Record in Workflow Stage
        /// </summary>
        /// <param name="workflowStageModel"></param>
        /// <returns></returns>
        public int Create(WorkflowStageModel workflowStageModel)
        {
            string query = @"Insert into [WorkflowStage] (WorkflowId,Name,UiPageTypeId,Orders)
                                                  values (@WorkflowId,@Name,@UiPageTypeId,@Orders)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, workflowStageModel);
        }
       

        /// <summary>
        /// Getting All Records From Workflow Stage
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Getting Record By Id Workflow Stage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Edit Record For Workflow Stage 
        /// </summary>
        /// <param name="workflowStageModel"></param>
        /// <returns></returns>
        public int Update(WorkflowStageModel workflowStageModel)
        {
            string query = @"update [WorkflowStage] Set  
                                UiPageTypeId = @UiPageTypeId,
                                WorkflowId = @WorkflowId,  
                                Name = @Name,
                               Orders=@Orders
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, workflowStageModel);
        }    
    }
}
