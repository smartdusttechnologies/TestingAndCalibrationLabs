using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.common
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public CommonRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        public List<UiPageDataModel> GetUiPageDataByModuleId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>("Select upd.* From [UiPageData] upd INNER JOIN  [Record] r ON upd.RecordId = r.Id and r.IsDeleted = 0 where r.ModuleId=@moduleId and upd.IsDeleted=0", new { moduleId }).ToList();
        }
        public List<UiPageValidationModel> GetUiPageValidations(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upv.UiPageTypeId, upv.UiPageMetadataId, upvt.Name, upv.UiPageValidationTypeId ,upvt.Value
                                            From [UiPageValidation] upv 
                                            INNER JOIN  [UiPageValidationType] upvt ON upv.UiPageValidationTypeId = upvt.Id 
                                                AND upv.IsDeleted = 0 
                                                AND upvt.IsDeleted = 0 
                                            WHERE upv.UiPageTypeId=@uiPageId", new { uiPageId }).ToList();
        }
        public List<UiPageMetadataModel> GetUiPageMetadata(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var metadata = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        mmb.UiPageTypeId,
														mmb.Orders,
                                                        mmb.MultiValueControl,
														mmb.ParentId,
														mmb.ModuleId,
                                                        mmb.[UiControlDisplayName] as MetadataModuleBridgeUiControlDisplayName,
                                                        upt.[Name] as UiPageTypeName,
                                                         upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.DataTypeId,
                                                        dt.Name as DataTypeName,
                                                        uct.ControlCategoryId,
                                                        lc.Id as LookupCategoryId,
                                                        l.Name as ControlCategoryName,
														ucct.Template as UiControlCategoryTypeTemplate
                                                    From [MetadataModuleBridge] mmb
													inner join [UiPageMetadata] upm on mmb.UiPageMetadataId = upm.Id
                                                    inner join [UiPageType] upt on mmb.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													left join [UiPageMetadataCharacteristics] upmc on upmc.UiPageMetadataId = upm.Id and upmc.IsDeleted = 0
													left join [LookupCategory] lc on lc.Id = upmc.LookupCategoryId
                                                where mmb.UiPageTypeId = @uiPageId
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    and l.IsDeleted = 0
													and mmb.IsDeleted = 0", new { uiPageId }).ToList();
            return metadata;
        }
        public List<UiPageMetadataModel> GetUiPageMetadataByModuleId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var metadata = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        mmb.UiPageTypeId,
														mmb.Orders,
                                                        mmb.MultiValueControl,
														mmb.ParentId,
														mmb.ModuleId,
                                                        upt.[Name] as UiPageTypeName,
                                                         upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.DataTypeId,
                                                        dt.Name as DataTypeName,
                                                        uct.ControlCategoryId,
                                                        lc.Id as LookupCategoryId,
                                                        l.Name as ControlCategoryName,
														ucct.Template as UiControlCategoryTypeTemplate
                                                    From [MetadataModuleBridge] mmb
													inner join [UiPageMetadata] upm on mmb.UiPageMetadataId = upm.Id
                                                    inner join [UiPageType] upt on mmb.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													left join [UiPageMetadataCharacteristics] upmc on upmc.UiPageMetadataId = upm.Id and upmc.IsDeleted = 0
													left join [LookupCategory] lc on lc.Id = upmc.LookupCategoryId
                                                where mmb.ModuleId = @moduleId
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    and l.IsDeleted = 0
													and mmb.IsDeleted = 0", new { moduleId }).ToList();
            return metadata;
        }
        /// <summary>
        /// Inserting data to Database
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int Insert(RecordModel record)
        {
            var p = new DynamicParameters();
            p.Add("RecordId", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@ModuleId", record.ModuleId);
            p.Add("@WorkflowStageId", record.WorkflowStageId);
            string recordInsertQuery = @"Insert into [Record](ModuleId,WorkflowStageId) 
                values (@ModuleId,@WorkflowStageId);
                SELECT @RecordId = @@IDENTITY";
            string uiPageMetadataInsertQuery = @"Insert into [UiPageData](UiPageMetadataId, Value, RecordId) 
                values (@UiPageMetadataId, @Value, @RecordId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            using var transaction = db.BeginTransaction();
            db.Execute(recordInsertQuery, p, transaction);
            int insertedRecordId = p.Get<int>("@RecordId");
            var uiPageMetaData = record.FieldValues.Select(x => new { RecordId = insertedRecordId, UiPageMetadataId = x.UiPageMetadataId, Value = x.Value }).ToList();
            db.Execute(uiPageMetadataInsertQuery, uiPageMetaData, transaction);
            transaction.Commit();
            return insertedRecordId;
        }
        public  int GetPageIdBasedOnCurrentWorkflowStage(int stageId )
        {
            using IDbConnection db = _connectionFactory.GetConnection;
                       return db.Query<int>(@"select Top(1) ws.UiPageTypeId
                                                          From  WorkflowStage ws 
                                                   where IsDeleted = 0 and ws.Id = @Id", new {Id = stageId}).First();
        }
        public int GetPageIdBasedOnOrder(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<int>(@"Select  ws.UiPageTypeId
                                                    From [Module] m
													inner join Workflow w on m.Id = w.ModuleId
													inner join [WorkflowStage] ws on w.Id = ws.WorkflowId
                                                where m.Id = @moduleId
												and ws.Orders = 0
                                                    and m.IsDeleted = 0 
													and w.IsDeleted = 0
													and ws.IsDeleted = 0", new { moduleId }).FirstOrDefault();
        }
        public int GetWorkflowStageBasedOnOrder(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<int>(@"Select  ws.Id
                                                    From [Module] m
													inner join Workflow w on m.Id = w.ModuleId
													inner join [WorkflowStage] ws on w.Id = ws.WorkflowId
                                                where m.Id = @moduleId
												and ws.Orders = 0 
                                                    and m.IsDeleted = 0 
													and w.IsDeleted = 0
													and ws.IsDeleted = 0", new { moduleId }).FirstOrDefault();
        }
        public bool Save(RecordModel recordModel)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var insertList = recordModel.FieldValues.Where(x=>x.Id == 0).ToList();
            var updateList = recordModel.FieldValues.Where(x=>x.Id != 0).ToList();
            string recordInsertQuery = @"Update [Record] Set
                                                UpdatedDate = @UpdatedDate ,
                                                WorkflowStageId = @WorkflowStageId
                                            Where Id = @Id";
            var insertQuery = @"Insert Into [UiPageData] (UiPageMetadataId,RecordId,Value)
                                        Values (@UiPageMetadataId,@RecordId,@Value)";
            var updateQurey = @"Update [UiPageData] Set
                                    UiPageMetadataId = @UiPageMetadataId,
                                    RecordId = @RecordId,
                                    Value = @Value
                                Where Id = @Id";
            IDbTransaction transaction = db.BeginTransaction();
            db.Execute(recordInsertQuery, recordModel, transaction);
            if (insertList.Count > 0)
            {
                db.Execute(insertQuery, insertList, transaction);
            }
            if (updateList.Count >0)
            {
                db.Execute(updateQurey, updateList, transaction);
            }
            transaction.Commit();

            return true;
        }

        public List<UiPageDataModel> GetPageData(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@"select upd.* from [Record] r 
                                                    inner join [WorkflowStage] ws on r.WorkflowStageId = ws.Id
                                                    inner join [MetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                    inner join [UiPageData] upd on r.Id = upd.RecordId
                                               where upd.UiPageMetadataId in (mmb.UiPageMetadataId)
                                                    and r.Id = @id", id).ToList();
        }
        #endregion
    }
}

