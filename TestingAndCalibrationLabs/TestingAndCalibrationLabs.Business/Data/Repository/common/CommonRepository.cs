using Dapper;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
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
            //return db.Query<UiPageDataModel>(@"Select upd.Id,upd.RecordId,upd.SubRecordId,upd.UiPageMetadataId,upd.UiPageTypeId , updst.Value From [UiPageData] upd 
            //    INNER JOIN  [Record] r ON upd.RecordId = r.Id
            //    INNER JOIN [UiPageDataStringType] updst on upd.UiPageMetadataId = updst.UiPageDataId

            //    and r.IsDeleted = 0
            //where r.ModuleId=@moduleId and upd.IsDeleted=0", new { moduleId }).ToList();

            return db.Query<UiPageDataModel>(@" Select upd.Id,upd.RecordId,upd.SubRecordId,upd.UiPageMetadataId,upd.UiPageTypeId , updst.Value From[UiPageData] upd
                INNER JOIN[Record] r ON upd.RecordId = r.Id
                INNER JOIN[UiPageStringType] updst on r.Id = updst.RecordId


                and r.IsDeleted = 0
            where r.ModuleId=ModuleId  and updst.RecordId = r.Id

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
                                                    From [UiPageMetadataModuleBridge] mmb
			                                  
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
													and mmb.IsDeleted = 0
                                                    and ucct.IsDeleted = 0", new { moduleId }).ToList();
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
            //p.Add("@fieldvalue", record.FieldValues);

            //string recordInsertQuery = @"Insert into [Record](ModuleId,WorkflowStageId) 
            //    values (@ModuleId,@WorkflowStageId);
            //    SELECT @RecordId = @@IDENTITY";
            ////string singleValueDataInsertQuery = @"Insert into [UiPageData](UiPageMetadataId, RecordId,UiPageTypeId) 
            ////    values (@UiPageMetadataId, @RecordId,@UiPageTypeId)";

            using IDbConnection db = _connectionFactory.GetConnection;
            //using var transaction = db.BeginTransaction();
            //db.Execute(recordInsertQuery, p, transaction);

            // int insertedRecordId = p.Get<int>("@RecordId");

            //    var subRecordId = GenerateNewSubRecordId(insertedRecordId);
            //  var singlePageData = record.FieldValues.Where(x => x.MultiValueControl != true).Select(x => new { RecordId = insertedRecordId, UiPageMetadataId = x.UiPageMetadataId, UiPageTypeId = x.UiPageTypeId }).ToList();
            //var multiValueData = record.FieldValues.Where(x => x.MultiValueControl == true).Select(x => new { SubRecordId = subRecordId, RecordId = insertedRecordId, UiPageMetadataId = x.UiPageMetadataId, Value = x.Value, UiPageTypeId = x.UiPageTypeId }).ToList();
            //db.Execute(singleValueDataInsertQuery, singlePageData, transaction);
            // transaction.Commit();

          
            using (var command = new System.Data.SqlClient.SqlCommand("store_proc_Record", (System.Data.SqlClient.SqlConnection)db))
            { 
               var SingleData=record.FieldValues.GroupBy(x=>x.UiPageMetadataId).Select(x=> new { UiPageMetadataId = x.Key,UiPageTypeId = x.First().UiPageTypeId, Value = x.First().Value }).ToList();

               // var singleData = record.FieldValues.Distinct().Select(x => new { }).ToList();

                var MultiData  = record.FieldValues.Select(x => new { UiPageMetadataId = x.UiPageMetadataId, Value = x.Value }).ToList();
                command.CommandType = CommandType.StoredProcedure;
      
                command.Parameters.AddWithValue("@WorkflowStageId", record.WorkflowStageId);
                command.Parameters.AddWithValue("@ModuleId", record.ModuleId);
                command.Parameters.AddWithValue("@UiPageDataTVP", GetDataTable(SingleData));
               // command.Parameters.AddWithValue("@UiPageDataTVP", GetDataTable(singleData));
                command.Parameters.AddWithValue("@ChildTvp", GetDataTable(MultiData));
                command.ExecuteNonQuery();
              
                //try { command.ExecuteNonQuery(); }
                //catch (Exception ex)
                //{
                //    var err = ex.Message;
                //}

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
            using IDbConnection db = _connectionFactory.GetConnection;
            //var subRecordId = GenerateNewSubRecordId(recordModel.Id);
            //var insertList = recordModel.FieldValues.Where(x => x.Id == 0 && x.MultiValueControl != true).ToList();
            //var multiValueInsert = recordModel.FieldValues.Where(x => x.Id == 0 && x.MultiValueControl == true)
            //    .Select(x=> new UiPageDataModel{ UiPageMetadataId =x.UiPageMetadataId, RecordId =x.RecordId, Value = x.Value, UiPageTypeId =x.UiPageTypeId,SubRecordId = subRecordId}).ToList();
            //var updateList = recordModel.FieldValues.Where(x => x.Id != 0).ToList();
            //string recordInsertQuery = @"Update [Record] Set
            //                                    UpdatedDate = @UpdatedDate ,
            //                                    WorkflowStageId = @WorkflowStageId
            //                                Where Id = @Id";
            //var insertQuery = @"Insert Into [UiPageData] (UiPageMetadataId,RecordId,Value,UiPageTypeId)
            //                            Values (@UiPageMetadataId,@RecordId,@Value,@UiPageTypeId)";
            //var multiInsertQuery = @"Insert Into [UiPageData] (UiPageMetadataId,RecordId,Value,UiPageTypeId,SubRecordId)
            //                            Values (@UiPageMetadataId,@RecordId,@Value,@UiPageTypeId,@SubRecordId)";
            //var updateQurey = @"Update [UiPageData] Set
            //                        UiPageMetadataId = @UiPageMetadataId,
            //                        RecordId = @RecordId,
            //                        UiPageTypeId = @UiPageTypeId,
            //                        Value = @Value
            //                    Where Id = @Id";
            //IDbTransaction transaction = db.BeginTransaction();
            //db.Execute(recordInsertQuery, recordModel, transaction);
            //if (insertList.Count > 0)
            //{
            //    db.Execute(insertQuery, insertList, transaction);
            //}
            //if (multiValueInsert.Count > 0)
            //{
            //    db.Execute(multiInsertQuery, multiValueInsert, transaction);
            //}
            //if (updateList.Count > 0)
            //{
            //    db.Execute(updateQurey, updateList, transaction);
            //}
            using (var command = new System.Data.SqlClient.SqlCommand("update_store_proc_Recor", (System.Data.SqlClient.SqlConnection)db))
            {
                var SingleData = recordModel.FieldValues.GroupBy(x => x.UiPageMetadataId).Select(x => new { Id = x.First().Id, UiPageMetadataId = x.Key, ChildId = x.First().ChildId, RecordId = x.First().RecordId, Value = x.First().Value }).ToList();

                // var singleData = record.FieldValues.Distinct().Select(x => new { }).ToList();

               // var MultiData = recordModel.FieldValues.Select(x => new { UiPageMetadataId = x.UiPageMetadataId, Value = x.Value }).ToList();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ModuleId", recordModel.ModuleId);
                command.Parameters.AddWithValue("@WorkflowStageId", recordModel.WorkflowStageId);
                command.Parameters.AddWithValue("@RecordId", recordModel.Id);
                command.Parameters.AddWithValue("@UpdatedDate", recordModel.UpdatedDate);
                command.Parameters.AddWithValue("@@ChildTvp", GetDataTable(SingleData));
                // command.Parameters.AddWithValue("@UiPageDataTVP", GetDataTable(singleData));
               // command.Parameters.AddWithValue("@ChildTvp", GetDataTable(MultiData));
                command.ExecuteNonQuery();

               
            }


          //  db.Execute("store_pro_uipagedata", insertQuery,commandType:CommandType.StoredProcedure);
            

           // transaction.Commit();

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
            //return db.Query<UiPageDataModel>(@"select upd.* from [Record] r 
            //                                        inner join [WorkflowStage] ws on r.WorkflowStageId = ws.Id
            //                                        inner join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
            //                                        inner join [UiPageData] upd on r.Id = upd.RecordId
            //                                   where upd.UiPageMetadataId in (mmb.UiPageMetadataId)
            //                                        and r.Id = @id and r.IsDeleted = 0 
            //                                        and mmb.MultiValueControl != 'true'
            //                                        and ws.IsDeleted = 0
            //                                        and mmb.IsDeleted = 0 
            //                                        and upd.IsDeleted = 0", new { id }).ToList();
            return db.Query<UiPageDataModel>(@"SELECT t1.UiPageMetadataId, t2.UiPageDataId, t2.Value
                                               FROM UiPageData t1
                                                  JOIN [UiPageStringType] t2 ON t1.Id = t2.UiPageDataId
                                                WHERE t1.RecordId = @Id
                                                  UNION All
                                                SELECT t3.UiPageMetadataId, t4.Id, CAST(t4.Value AS varchar)t
                                               FROM UiPageData t3
                                             JOIN [UiPageIntType] t4 ON t3.Id = t4.UiPageDataId
                                               WHERE t3.RecordId = @Id
                                                   UNION All
                                             SELECT t3.UiPageMetadataId, t4.UiPageDataId, CAST(t4.Value AS varchar)t
                                                     FROM UiPageData t3
                                                   JOIN [UiPageFileAttachType] t4 ON t3.Id = t4.UiPageDataId
                                           WHERE t3.RecordId = @Id

                                        ", new { id }).ToList();
        }

        public List<UiPageDataModel> GetUiPageDataById(int uiPageDataId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@" SELECT t1.UiPageMetadataId,'UiPageFileAttachType' As uiPageType, t2.UiPageDataId, t2.Value
                                               FROM UiPageData t1
                                                  JOIN[UiPageStringType] t2 ON t1.Id = t2.UiPageDataId
                                                WHERE t1.Id = @uiPageDataId
                                                  UNION All
                                                SELECT t3.UiPageMetadataId,'UiPageIntType' , t4.UiPageDataId, CAST(t4.Value AS varchar)t
                                               FROM UiPageData t3
                                             JOIN[UiPageIntType] t4 ON t3.Id = t4.UiPageDataId
                                               WHERE t3.Id = @uiPageDataId
                                                   UNION All
                                             SELECT t3.UiPageMetadataId,'UiPageFileAttachType' , t4.UiPageDataId, CAST(t4.Value AS varchar)t
                                                     FROM UiPageData t3
                                                   JOIN[UiPageFileAttachType] t4 ON t3.Id = t4.UiPageDataId
                                           WHERE t3.Id = @uiPageDataId
                                        ", new { uiPageDataId }).ToList();
        }

        /// <summary>
        /// Get All Page Data Based On Multi Controls
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageDataModel> GetMultiPageData(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>(@"select upd.* from [Record] r 
                                                    inner join [WorkflowStage] ws on r.WorkflowStageId = ws.Id
                                                    inner join [UiPageMetadataModuleBridge] mmb on ws.UiPageTypeId = mmb.UiPageTypeId
                                                    inner join [UiPageData] upd on r.Id = upd.RecordId
                                               where upd.UiPageMetadataId in (mmb.UiPageMetadataId)
                                                    and r.Id = @id and mmb.MultiValueControl = 'true'
                                                    and r.IsDeleted = 0 
                                                    and ws.IsDeleted = 0
                                                    and mmb.IsDeleted = 0 
                                                    and upd.IsDeleted = 0", new { id }).ToList();
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
            var result = con.Query<int>($"select ISNULL(Max(SubRecordId),0)from UiPageData where RecordId = {recordId}").First();
            return result + 1;
        }

        public List<int> GenerateUiDataId(int recordId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            return con.Query<int>($"select Id from UiPageData where RecordId = {recordId}").ToList();
            
        }
     

        public int getLatestRecordId() {
            using IDbConnection con = _connectionFactory.GetConnection;
            return con.Query<int>($"SELECT Id FROM Record WHERE id = (SELECT MAX(id) FROM Record)").First();

        }
        /// <summary>
        /// Delete Multi Record Values
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool DeleteMultiValue(RecordModel record)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string recordInsertQuery = @"Update [Record] Set
                                                UpdatedDate = @UpdatedDate
                                            Where Id = @Id";
            var updateQurey = @"Update [UiPageData] Set
                                    IsDeleted = 1
                                Where RecordId = @RecordId And SubRecordId = @SubRecordId";
            IDbTransaction transaction = db.BeginTransaction();
            db.Execute(recordInsertQuery, record, transaction);
            db.Execute(updateQurey, record.FieldValues, transaction);
            transaction.Commit();
            return true;
        }
        #endregion
        
    }
}

