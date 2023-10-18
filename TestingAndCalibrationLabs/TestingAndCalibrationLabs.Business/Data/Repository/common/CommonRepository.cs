﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;
using static Dapper.SqlMapper;

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
        /// <summary>
        /// Get Ui Page Data Based On Record Id For Grid
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<UiPageDataModel> GetUiPageDataByModuleId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@" Select upd.Id,upd.RecordId,upd.SubRecordId,upd.UiPageMetadataId,upd.UiPageTypeId , updst.Value From[UiPageData] upd
                 INNER JOIN[Record] r ON upd.RecordId = r.Id
                 INNER JOIN[UiPageStringType] updst on r.Id = updst.RecordId
                 where r.ModuleId=@moduleId  
                 and updst.RecordId = r.Id
                 and r.IsDeleted = 0
                 and upd.IsDeleted=0", new { moduleId }).ToList();
        }
        /// <summary>
        /// Get All Validations Based On UiPageTypeId
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        public List<UiPageValidationModel> GetUiPageValidations(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upv.UiPageTypeId, upv.UiPageMetadataId, upvt.Name, upv.UiPageValidationTypeId
                                            From [UiPageValidation] upv
                                            INNER JOIN  [UiPageValidationType] upvt ON upv.UiPageValidationTypeId = upvt.Id
                                       
                                                AND upv.IsDeleted = 0 
                                                AND upvt.IsDeleted = 0 
                                            WHERE upv.UiPageTypeId=@uiPageId", new { uiPageId }).ToList();
        }
        /// <summary>
        /// Get All UiPageMetadata based On UiPageTypeId
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetUiPageMetadata(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var metadata = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        mmb.UiPageTypeId,
														mmb.Orders,
                                                        mmb.MultiValueControl,
														mmb.ParentId,
														upm.ModuleLayoutId,
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
                                                    From [UiPageMetadataModuleBridge] mmb
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
													and mmb.IsDeleted = 0
                                                    and ucct.IsDeleted = 0", new { uiPageId }).ToList();
            return metadata;
        }
        /// <summary>
        /// Get Ui Page Metadata Based On Module Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetUiPageMetadataByModuleId(int modulelayoutId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var metadata = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        mmb.UiPageTypeId,
														mmb.Orders,
                                                        mmb.MultiValueControl,
														mmb.ParentId,
														upm.ModuleLayoutId,
                                                      
													     
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
                                                    From [UiPageMetadataModuleBridge] mmb
													inner join [UiPageMetadata] upm on mmb.UiPageMetadataId = upm.Id
                                                    inner join [UiPageType] upt on mmb.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
													inner join [ModuleLayout] ml on ml.Id = upm.ModuleLayoutId
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													left join [UiPageMetadataCharacteristics] upmc on upmc.UiPageMetadataId = upm.Id and upmc.IsDeleted = 0
													left join [LookupCategory] lc on lc.Id = upmc.LookupCategoryId
                                                where ml.ModuleId = @modulelayoutId
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
													and mmb.IsDeleted = 0
                                                    and ucct.IsDeleted = 0", new { modulelayoutId }).ToList();
            return metadata;
        }
        /// <summary>
        /// Inserting data to Database
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int Insert(RecordModel record)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            using (var command = new System.Data.SqlClient.SqlCommand("store_proc_Record", (System.Data.SqlClient.SqlConnection)db))
            {
                var storesingleval = record.FieldValues.GroupBy(x => x.UiPageMetadataId).Select(x => new { UiPageMetadataId = x.Key, UiPageTypeId = x.First().UiPageTypeId, Value = x.First().Value }).ToList();
                var storemultiVal = record.FieldValues.Select(x => new { UiPageMetadataId = x.UiPageMetadataId, Value = x.Value }).ToList();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@WorkflowStageId", record.WorkflowStageId);
                command.Parameters.AddWithValue("@ModuleId", record.ModuleId);
                command.Parameters.AddWithValue("@UpdatedDate", record.UpdatedDate);
                command.Parameters.AddWithValue("@UiPageDataTVP", GetDataTable(storesingleval));
                command.Parameters.AddWithValue("@ChildTvp", GetDataTable(storemultiVal));
                command.ExecuteNonQuery();
            }
            return 1;
        }
        public static DataTable GetDataTable<T>(IEnumerable<T> list)
        {
            var table = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, System.Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// Get Page Id Based On Current Workflow Stage 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public int GetPageIdBasedOnCurrentWorkflowStage(int stageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<int>(@"select Top(1) ws.UiPageTypeId
                                                          From  WorkflowStage ws 
                                                   where ws.IsDeleted = 0 and ws.Id = @Id", new { Id = stageId }).First();
        }
        /// <summary>
        /// Get Page Id Based On Order And Module Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get Workflow Stage Based on Order And Module Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Save Record
        /// </summary>
        /// <param name="recordModel"></param>
        /// <returns></returns>
        public bool Save(RecordModel recordModel)
        {
            var datalist = recordModel.FieldValues;
            using IDbConnection db = _connectionFactory.GetConnection;
            using (var command = new System.Data.SqlClient.SqlCommand("update_store_proc_Record", (System.Data.SqlClient.SqlConnection)db))
            {
                var collectionofdata = recordModel.FieldValues.Select(x => new { Id = x.Id, UiPageMetadataId = x.UiPageMetadataId, ChildId = x.ChildId, RecordId = x.RecordId, UiPageTypeId = x.UiPageTypeId, Value = x.Value }).ToList();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ModuleId", recordModel.ModuleId);
                command.Parameters.AddWithValue("@WorkflowStageId", recordModel.WorkflowStageId);
                command.Parameters.AddWithValue("@RecordId", recordModel.Id);
                command.Parameters.AddWithValue("@UpdatedDate", recordModel.UpdatedDate);
                command.Parameters.AddWithValue("@ChildTvp", GetDataTable(collectionofdata));
                command.ExecuteNonQuery();
            }
            return true;
        }
        /// <summary>
        /// Get All Page Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageDataModel> GetPageData(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@"SELECT t1.UiPageMetadataId, t1.Id , t2.Value, t2.Id as ChildId,t7.Id as RecordId ,t1.UiPageTypeId
                                                     FROM UiPageData t1
                                                        JOIN [UiPageStringType] t2 ON t1.Id = t2.UiPageDataId
														Join [Record] t7 ON t7.Id  = t2.RecordId
                                                           WHERE t1.RecordId = @Id
														      and   t7.Id = @Id
															  and t1.IsDeleted = 0
															  and t7.IsDeleted = 0
                                                        UNION All
                                                      SELECT t3.UiPageMetadataId, t3.Id, CAST(t4.Value AS varchar) AS Value, t4.Id as ChildId ,t6.Id as RecordId ,t3.UiPageTypeId
                                                    FROM UiPageData t3
                                                       JOIN [UiPageIntType] t4 ON t3.Id = t4.UiPageDataId
													   Join [Record] t6 ON t6.Id  = t3.RecordId
                                                          WHERE t3.RecordId = @Id
														    and t6.Id = @Id
															and t3.IsDeleted = 0
															and t6.IsDeleted = 0
                                                            UNION All
                                                       SELECT t5.UiPageMetadataId, t5.Id, t6.Value, t6.Id as ChildId ,t8.Id as RecordId ,t5.UiPageTypeId
                                                            FROM UiPageData t5
                                                            JOIN [UiPageFileAttachType] t6 ON t5.Id = t6.UiPageDataId
															Join [Record] t8 ON t8.Id  = t5.RecordId
                                                      WHERE t5.RecordId = @Id
													    and t8.Id = @Id
														and t5.IsDeleted = 0
															and t8.IsDeleted = 0
														  UNION All
														     SELECT t5.UiPageMetadataId, t5.Id, CAST(t9.Value AS varchar) AS Value, t9.Id as ChildId ,t8.Id as RecordId,t5.UiPageTypeId 
                                                            FROM UiPageData t5
                                                            JOIN [UiPageDateType] t9 ON t5.Id = t9.UiPageDataId
															Join [Record] t8 ON t8.Id  = t5.RecordId
                                                          WHERE t5.RecordId = @Id
													      and t8.Id = @Id 
														  and t5.IsDeleted = 0
															and t8.IsDeleted = 0", new { id }).ToList();
														   
        }

        /// <summary>
        /// Get All Page Data Based On Multi Controls
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageDataModel> GetMultiPageData(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@"SELECT t1.UiPageMetadataId, t1.Id , t2.Value, t2.Id as ChildId,t7.Id as RecordId ,t1.UiPageTypeId
                                                     FROM UiPageData t1
                                                        JOIN [UiPageStringType] t2 ON t1.Id = t2.UiPageDataId
														Join [Record] t7 ON t7.Id  = t2.RecordId
														join [WorkflowStage] ws on t7.WorkflowStageId = ws.Id
                                                     join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                           WHERE t1.UiPageMetadataId in (mmb.UiPageMetadataId)
														     and  t1.RecordId = @id and mmb.MultiValueControl = 'true'
														      and   t7.Id = @id
															  and t1.IsDeleted = 0
															  and t7.IsDeleted = 0
															  and mmb.IsDeleted = 0
															  and ws.IsDeleted = 0
                                                        UNION All
                                                      SELECT t3.UiPageMetadataId, t3.Id, CAST(t4.Value AS varchar) AS Value, t4.Id as ChildId ,t6.Id as RecordId ,t3.UiPageTypeId
                                                    FROM UiPageData t3
                                                       JOIN [UiPageIntType] t4 ON t3.Id = t4.UiPageDataId
													   Join [Record] t6 ON t6.Id  = t3.RecordId
													   	join [WorkflowStage] ws on t6.WorkflowStageId = ws.Id
                                                     join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                          WHERE t3.UiPageMetadataId in (mmb.UiPageMetadataId)
														 and t3.RecordId = @id and mmb.MultiValueControl = 'true'
														    and t6.Id = @id
															and t3.IsDeleted = 0
															and t6.IsDeleted = 0
															and mmb.IsDeleted = 0
															  and ws.IsDeleted = 0
                                                            UNION All
                                                       SELECT t5.UiPageMetadataId, t5.Id, t6.Value, t6.Id as ChildId ,t8.Id as RecordId ,t5.UiPageTypeId
                                                            FROM UiPageData t5
                                                            JOIN [UiPageFileAttachType] t6 ON t5.Id = t6.UiPageDataId
															Join [Record] t8 ON t8.Id  = t5.RecordId
														    join [WorkflowStage] ws on t8.WorkflowStageId = ws.Id
                                                           join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                      WHERE t5.UiPageMetadataId in (mmb.UiPageMetadataId)
													  and t5.RecordId = @id and mmb.MultiValueControl = 'true'
													    and t8.Id = @id
														and t5.IsDeleted = 0
															and t8.IsDeleted = 0
															and mmb.IsDeleted = 0
															  and ws.IsDeleted = 0
														  UNION All
														     SELECT t5.UiPageMetadataId, t5.Id, CAST(t9.Value AS varchar) AS Value, t9.Id as ChildId ,t8.Id as RecordId,t5.UiPageTypeId 
                                                            FROM UiPageData t5
                                                            JOIN [UiPageDateType] t9 ON t5.Id = t9.UiPageDataId
															Join [Record] t8 ON t8.Id  = t5.RecordId
														join [WorkflowStage] ws on t8.WorkflowStageId = ws.Id
                                                     join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                          WHERE  t5.UiPageMetadataId in (mmb.UiPageMetadataId)
														  and t5.RecordId = @id and mmb.MultiValueControl = 'true'
													      and t8.Id = @id 
														  and t5.IsDeleted = 0
															and t8.IsDeleted = 0
															and mmb.IsDeleted = 0
															  and ws.IsDeleted = 0", new { id }).ToList();
        }
        /// <summary>
        /// Get All Metadata Based On Multi Control
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetMultiControlMetadata(int recordId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        mmb.UiPageTypeId,
														mmb.Orders,
                                                        mmb.MultiValueControl,
														mmb.ParentId,
														upm.ModuleLayoutId,
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
                                                       From [Record] r 
													inner join [WorkflowStage] ws on r.WorkflowStageId = ws.Id
													inner join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
													inner join [UiPageMetadata] upm on mmb.UiPageMetadataId = upm.Id
                                                    inner join [UiPageType] upt on mmb.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													left join [UiPageMetadataCharacteristics] upmc on upmc.UiPageMetadataId = upm.Id and upmc.IsDeleted = 0
													left join [LookupCategory] lc on lc.Id = upmc.LookupCategoryId
                                                    where r.Id = @recordId and mmb.MultiValueControl = 'true'
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
													and mmb.IsDeleted = 0
                                                    and ucct.IsDeleted = 0", new { recordId }).ToList();
        }
        /// <summary>
        /// Generate New SubRecordId Based On Previous SubRecordId
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public int GenerateNewSubRecordId(int recordId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            var result = con.Query<int>($"select ISNULL(Max(SubRecordId),0)from UiPageData where RecordId = {recordId} and IsDeleted = 0").First();
            return result + 1;
        }
        public List<int> GenerateUiDataId(int recordId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            return con.Query<int>($"select Id from UiPageData where RecordId = {recordId} and IsDeleted = 0").ToList();
        }
        /// <summary>
        /// Delete Multi Record Values
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool DeleteMultiValue(RecordModel record)
        {
            var innerList = record.FieldValues;
            using IDbConnection db = _connectionFactory.GetConnection;

            string recordInsertQuery = @"Update [Record] Set
                                UpdatedDate = @UpdatedDate
                            Where Id = @Id";

            var updateQuery = @"Update [UiPageData] Set
                        IsDeleted = 1
                    Where RecordId = @RecordId And Id = @Id";

            IDbTransaction transaction = db.BeginTransaction();
            db.Execute(recordInsertQuery, record, transaction);
                foreach (var item in innerList)
                {
                    db.Execute(updateQuery, new { RecordId = item.RecordId, Id = item.Id }, transaction);
                }
            transaction.Commit();
            return true;
        }
        /// <summary>
        /// Image Upload in Database
        /// </summary>
        public int FileUpload(FileUploadModel File)
        {
            string query = @" INSERT INTO [ImageUpload] (Name, FileType, DataFiles, CreatedOn) OUTPUT INSERTED.ID  VALUES (@Name, @FileType, @DataFiles, @CreatedOn)";


            using IDbConnection db = _connectionFactory.GetConnection;
            return  db.Query<int>(query, File).FirstOrDefault();
        }
        /// <summary>
        /// Image download in Your Local System
        /// </summary>
        public FileUploadModel ImageDownload(int ImageValue)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            return con.Query<FileUploadModel>(@"select * from [ImageUpload] where Id = @Name ", new { Name = ImageValue }).FirstOrDefault();
        }
        

         public bool FileUpload(int id, FileUploadModel File)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            string query = @"UPDATE [ImageUpload]  SET Name = @Name, FileType = @FileType, DataFiles = @DataFiles, CreatedOn = @CreatedOn  WHERE Id = @Id";
            var parameters = new
            {
                Id = id, 
                Name = File.Name,
                FileType = File.FileType,
                DataFiles = File.DataFiles,
                CreatedOn = DateTime.Now, 
            };

            if (db.Execute(query, parameters) > 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
