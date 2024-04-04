using Dapper;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For Ui Page Metadata
    /// </summary>
    public class UiPageMetadataRepository : IUiPageMetadataRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageMetadataRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record in Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int Create(UiPageMetadataModel uiPageMetadataModel)
        {
            string queryParent = @"INSERT INTO [UiPageMetadata] (Name, UiControlTypeId, DataTypeId, IsRequired, UiControlDisplayName, UiControlCategoryTypeId, ModuleLayoutId)
                        VALUES (@Name, @UiControlTypeId, @DataTypeId, @IsRequired, @UiControlDisplayName, @UiControlCategoryTypeId, @ModuleLayoutId);
                        SELECT SCOPE_IDENTITY();";
            string queryChild = @"INSERT INTO [UiPageMetadataModuleBridge] (UiPageMetadataId, UiPageTypeId, ParentId,Orders,UiControlDisplayName,MultiValueControl)
                                                                           VALUES (@UiPageMetadataId, @UiPageTypeId, @ParentId,@Orders,@UiControlDisplayName,@MultiValueControl);";
            using IDbConnection db = _connectionFactory.GetConnection;
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        if (uiPageMetadataModel.UiPageMetadataId == 0)
                        {

                            int parentId = db.ExecuteScalar<int>(queryParent, uiPageMetadataModel, transaction: transaction);
                            var childModel = new UiPageMetadataModel
                            {
                                UiPageMetadataId = parentId,
                                UiPageTypeId = uiPageMetadataModel.UiPageTypeId,
                                ParentId = uiPageMetadataModel.ParentId,
                                Orders = uiPageMetadataModel.Orders,
                                UiControlDisplayName = uiPageMetadataModel.UiControlDisplayName,
                                MultiValueControl = uiPageMetadataModel.MultiValueControl,
                            };
                            db.Execute(queryChild, childModel, transaction: transaction);

                            transaction.Commit();
                            return parentId;
                        }
                        db.Execute(queryChild, uiPageMetadataModel, transaction: transaction);
                        transaction.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Insert Pages and UiPageMetadata and UiPageMetadataModuleBridge and Update in WorkflowStage
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int CreateUsingPages(UiPageMetadataModel uiPageMetadataModel, int StagesCount)
        {
            string queryParent = @"INSERT INTO [UiPageMetadata] (Name, UiControlTypeId, DataTypeId, IsRequired, UiControlDisplayName, UiControlCategoryTypeId, ModuleLayoutId)
                        VALUES (@Name, @UiControlTypeId, @DataTypeId, @IsRequired, @UiControlDisplayName, @UiControlCategoryTypeId, @ModuleLayoutId);
                        SELECT SCOPE_IDENTITY();";

            string insertuipage = @"INSERT INTO [UiPageType] (Name)
                                            VALUES (@Name);
                                         SELECT SCOPE_IDENTITY();";

            string UPDATESTAGE = @"UPDATE [WorkflowStage] SET  
                            UiPageTypeId = @UiPageTypeId                                
                            WHERE Id = @WorkflowStageId";

            string queryDisplaynames = @"SELECT upm.Id, upm.UiControlTypeId, upm.UiControlDisplayName, l.Name
                                    FROM [UiPageMetadata] upm
                                    INNER JOIN [UiControlCategoryType] ucct ON ucct.Id = upm.UiControlCategoryTypeId
                                    INNER JOIN [UiControlType] uct ON uct.id = ucct.UiControlTypeId
                                    INNER JOIN [Lookup] l ON l.Id = uct.ControlCategoryId
                                    WHERE upm.ModuleLayoutId = @ModuleLayoutId 
                                    AND l.Name != 'DataControl'
                                    AND upm.IsDeleted = 0 
                                    AND ucct.IsDeleted = 0
                                    AND uct.IsDeleted = 0
                                    AND l.IsDeleted = 0";

           
            var getGetcurrentStagedetails = @"select ws.Id, ws.Name,ws.Orders,ws.UiPageTypeId
		                                            From WorkflowStage ws
		                                             inner join Workflow w on  w.Id = ws.WorkflowId
		                                             Where w.ModuleId = @moduleId
		                                             and w.IsDeleted=0
		                                             and ws.IsDeleted=0";

            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        if (uiPageMetadataModel.UiPageMetadataId == 0)
                        {
                            int parentId = db.ExecuteScalar<int>(queryParent, uiPageMetadataModel, transaction: transaction);

                            int uiPageTypeId = db.ExecuteScalar<int>(insertuipage, new { Name = uiPageMetadataModel.UiControlDisplayName }, transaction: transaction);

                            db.Execute(UPDATESTAGE, new { UiPageTypeId = uiPageTypeId, WorkflowStageId = uiPageMetadataModel.WorkflowStageId }, transaction: transaction);
                            transaction.Commit();

                            var DetailsMetatadata = db.Query<UiPageMetadataModel>(queryDisplaynames, new { ModuleLayoutId = uiPageMetadataModel.ModuleLayoutId }, transaction: transaction).ToList();
                            var Detailsstage = db.Query<WorkflowStageModel>(getGetcurrentStagedetails, new { moduleId = uiPageMetadataModel.ModuleId }, transaction: transaction).ToList();
                            
                            List<int?> listpages = new List<int?>();
                            foreach (var items in Detailsstage)
                            {
                                listpages.Add(items.UiPageTypeId);

                            }
                            string sql = @"
                                            SELECT upm.UiPageTypeId, COUNT(*) AS Count
                                            FROM [UiPageMetadataModuleBridge] upm
                                            WHERE upm.UiPageTypeId IN @UiPageTypeIds
                                            AND upm.IsDeleted = 0
                                            GROUP BY upm.UiPageTypeId";

                            var counts = db.Query(sql, new { UiPageTypeIds = listpages })
                                            .ToDictionary(row => (int)row.UiPageTypeId, row => (int)row.Count);
                            var allmodule = @"
                                                SELECT upm.UiPageTypeId,
                                                       upm.UiPageMetadataId,
                                                       upm.ParentId
                                                FROM [UiPageMetadataModuleBridge] upm
                                                WHERE upm.UiPageTypeId IN @UiPageTypeIds
                                                AND upm.IsDeleted = 0
                                                GROUP BY upm.UiPageTypeId, upm.UiPageMetadataId, upm.ParentId";

                            var DetailsMetatadatas = db.Query<UiPageMetadataModel>(allmodule, new { UiPageTypeIds = listpages }, transaction: transaction).ToList();

                            var groupbybasedonMetadataId = DetailsMetatadatas
                                .GroupBy(x => x.UiPageMetadataId)
                                .ToList();
                            var groupbypageId = DetailsMetatadatas
                                .GroupBy(x => x.UiPageTypeId)
                                .ToList();
                            List<UiPageMetadataModel> valuesgetList = new List<UiPageMetadataModel>();
                            List<UiPageMetadataModel> controlsWithUiControlTypeId25 = new List<UiPageMetadataModel>();

                            if (DetailsMetatadata.Count - 1 == StagesCount)
                            {
                                controlsWithUiControlTypeId25 = DetailsMetatadata
                                    .Where(control => control.UiControlTypeId == (int)UiControlTypeId.uiControlTypeId)
                                    .ToList();

                                DetailsMetatadata.RemoveAll(control => control.UiControlTypeId == (int)UiControlTypeId.uiControlTypeId);

                                int parentIdFor25 = controlsWithUiControlTypeId25[0].Id;
                                int j = 0;
                                int k = 0;
                                foreach (var Detail in DetailsMetatadata)
                                {
                                        // Check if Detailsstage[k].UiPageTypeId is not available in groupby.key
                                        if (!groupbybasedonMetadataId.Any(g => g.Key == Detail.Id))
                                        {
                                            if (controlsWithUiControlTypeId25[0].UiControlTypeId == (int)UiControlTypeId.uiControlTypeId)
                                            {
                                                UiPageMetadataModel Valuesget = new UiPageMetadataModel();
                                                Valuesget.UiPageMetadataId = controlsWithUiControlTypeId25[0].Id;
                                                Valuesget.UiPageTypeId = Detailsstage[j].UiPageTypeId;
                                                Valuesget.ParentId = 0;
                                                Valuesget.Orders = 0;
                                                Valuesget.UiControlDisplayName = Detail.Name;
                                                Valuesget.MultiValueControl = false;
                                                valuesgetList.Add(Valuesget);
                                                
                                            }
                                        }

                                    if (!groupbybasedonMetadataId.Any(g => g.Key == Detail.Id))
                                    {
                                        for (int i = 0; i < StagesCount; i++)
                                        {
                                            UiPageMetadataModel Valuesget = new UiPageMetadataModel();
                                            Valuesget.UiPageMetadataId = DetailsMetatadata[i].Id;
                                            Valuesget.UiPageTypeId = Detailsstage[j].UiPageTypeId;
                                            Valuesget.ParentId = parentIdFor25;
                                            Valuesget.Orders = i + 1;
                                            Valuesget.UiControlDisplayName = Detailsstage[i].Name;
                                            Valuesget.MultiValueControl = false;

                                            valuesgetList.Add(Valuesget);
                                        }
                                    }
                                    k++;
                                    j++;
                                }
                                foreach (var daetails in groupbypageId)
                                {
                                    if (daetails.Count() - 1 != StagesCount)
                                    {
                                        int i = daetails.Count() - 1;
                                        for (; i < StagesCount; i++)
                                        {
                                            var getdetails = daetails.First();
                                            UiPageMetadataModel Valuesget = new UiPageMetadataModel();
                                            Valuesget.UiPageMetadataId = DetailsMetatadata[i].Id;
                                            Valuesget.UiPageTypeId = getdetails.UiPageTypeId;
                                            Valuesget.ParentId = parentIdFor25;
                                            Valuesget.Orders = i + 1;
                                            Valuesget.UiControlDisplayName = Detailsstage[i].Name;
                                            Valuesget.MultiValueControl = false;

                                            valuesgetList.Add(Valuesget);
                                        }
                                    }
                                }
                                var parameters = valuesgetList.Select(item => new
                                {
                                    UiPageMetadataId = item.UiPageMetadataId,
                                    UiPageTypeId = item.UiPageTypeId,
                                    ParentId = item.ParentId,
                                    Orders = item.Orders,
                                    UiControlDisplayName = item.UiControlDisplayName,
                                    MultiValueControl = item.MultiValueControl
                                }).ToList();

                                string bulkInsertQuery = @"INSERT INTO [UiPageMetadataModuleBridge] 
                                        (UiPageMetadataId, UiPageTypeId, ParentId, Orders, UiControlDisplayName, MultiValueControl) 
                                        VALUES 
                                        (@UiPageMetadataId, @UiPageTypeId, @ParentId, @Orders, @UiControlDisplayName, @MultiValueControl);";

                              
                                int rowsAffected = db.Execute(bulkInsertQuery, parameters, transaction: transaction);

                            }

                            return parentId;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Getting All Records From Ui Page Metadata 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetDisplayName(int moduleLayoutId,int ModuleIds)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var Displaynames = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                           
                                                        upm.UiControlDisplayName,
														l.Name
                                                     
                                                    From [UiPageMetadata] upm
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													inner join [UiControlType] uct on uct.id=ucct.UiControlTypeId
													inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiPageMetadataModuleBridge] upmmb on upmmb.UiPageMetadataId=upm.Id
                                                where upm.ModuleLayoutId=@moduleIds and l.Name !='DataControl' and upmmb.UiPageTypeId=@ModuleLayoutId
                                                 and   upm.IsDeleted = 0 
												 and ucct.IsDeleted=0
												 and uct.IsDeleted=0
												 and l.IsDeleted=0
                                                    ", new { ModuleLayoutId = moduleLayoutId, moduleIds = ModuleIds }).ToList();
            return Displaynames;
        }
        /// <summary>
        /// Getting All Existing From Ui Page Metadata based on moduleLayoutId 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetExistingMetadata(int moduleLayoutId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var Displaynames = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                      uct.DisplayName as ControlTypeName
                                                    From [UiPageMetadata] upm
													inner join [UiControlType] uct on uct.id = upm.UiControlTypeId
                                                   where upm.ModuleLayoutId = @ModuleLayoutId
                                                   and upm.IsDeleted = 0
                                                   and uct.IsDeleted = 0", new { ModuleLayoutId = moduleLayoutId }).ToList();


            return Displaynames;
        }
        /// <summary>
        /// Getting All Pages based on moduleLayoutId 
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> GetPages (int moduleLayoutId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var Pages = db.Query<UiPageTypeModel>(@"Select up.Id,
                                                      up.Name	
                                                    From [ModuleLayout] ml
													inner join [Workflow] w on w.ModuleId=ml.ModuleId
													inner join [WorkflowStage] ws on ws.WorkflowId	=  w.Id
													inner join [UiPageType] up on up.Id=ws.UiPageTypeId
                                                   where ml.Id = @ModuleLayoutId
                                                   and ws.IsDeleted = 0
                                                   and w.IsDeleted = 0
												   and up.IsDeleted=0
												   and ml.IsDeleted=0", new { ModuleLayoutId = moduleLayoutId}).ToList();

            return Pages;
        }

        /// <summary>
        /// Getting All Records From Ui Page Metadata  and UiPageMetadataCharacteristics
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.DisplayName as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.DataTypeId,
														upt.Name as UiPageTypeName,
														upmmb.UiPageTypeId,
														upm.Name,
														upmmb.Orders,
														upmmb.ParentId,
														up.UiControlDisplayName as ParentDisplayName,
														upmmb.Id as MetadataModuleBridgeId,
                                                        dt.Name as DataTypeName,
                                                        ml.Name as ModuleLayoutName,
														upm.ModuleLayoutId,
														ucct.Id as UiControlCategoryTypeId,
                                                        ucct.Name as UiControlCategoryTypeName
                                                    From [UiPageMetadata] upm
													inner join [ModuleLayout] ml on ml.Id = upm.ModuleLayoutId
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [UiPageMetadataModuleBridge] upmmb on upm.Id = upmmb.UiPageMetadataId 
													 inner join [UiPageType] upt on upt.Id = upmmb.UiPageTypeId 
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													inner join [UiPageMetadata] up on up.Id = upmmb.ParentId
													--left join [UiPageMetadataCharacteristics] l on l.UiPageMetadataId = upm.Id and l.IsDeleted = 0
													--left join [LookupCategory] lc on lc.Id = l.LookupCategoryId and lc.IsDeleted = 0
                                                where 
                                                    upm.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    and ml.IsDeleted = 0
                                                    and ucct.IsDeleted = 0
                                                    and upmmb.IsDeleted = 0
                                                    and upt.IsDeleted = 0
													and up.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id  and uiPageTypeId,metadataModuleBridgeId For Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetByUiPageTypeId(int id, int uiPageTypeId, int metadataModuleBridgeId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            var uiPageMetadataById = db.Query<UiPageMetadataModel>(@" Select  upm.Id,
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        upm.UiControlDisplayName,
                                                        upm.DataTypeId,
														upm.Name,
														upm.UiControlCategoryTypeId,
														upm.ModuleLayoutId,
														uct.Name as UiControlTypeName,
														dt.Name as DataTypeName,
													    ml.Name as ModuleLayoutName,
														ucct.Name as UiControlCategoryTypeName,
														upmdb.MultiValueControl,
														upmdb.Orders,
														upmdb.UiControlDisplayName,
														upmdb.ParentId,
														upmdb.UiPageTypeId,
														upm.UiControlDisplayName as ParentName,
														upt.Name as UiPageTypeName,
                                                        upmdb.Id as MetadataModuleBridgeId
                                                    From [UiPageMetadata] upm
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [ModuleLayout] ml on upm.ModuleLayoutId = ml.Id
													inner join [UiControlCategoryType] ucct on upm.UiControlCategoryTypeId = ucct.Id 
													inner join [UiPageMetadataModuleBridge] upmdb on upmdb.UiPageMetadataId=upm.Id
													inner join [UiPageType] upt on upmdb.UiPageTypeId = upt.Id
                                                where upm.Id  = @Id and upmdb.UiPageTypeId = @UiPageTypeId and  upmdb.Id = @MetadataModuleBridgeId
                                                   and upm.IsDeleted = 0 
                                                   and uct.IsDeleted = 0
                                                   and dt.IsDeleted = 0
                                                   and upt.IsDeleted =0
												   and ml.IsDeleted =0
												   and ucct.IsDeleted=0
												   and upmdb.IsDeleted=0
                                                   and ucct.IsDeleted = 0 ", new { id, uiPageTypeId, metadataModuleBridgeId }).FirstOrDefault();
            return uiPageMetadataById;
        }
        public UiPageMetadataModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiPageMetadataById = db.Query<UiPageMetadataModel>(@" Select upm.Id,
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.DataTypeId,
														upm.Name,
                                                        dt.Name as DataTypeName,
														ucct.Id as UiControlCategoryTypeId,ucct.Name as UiControlCategoryTypeName
                                                    From [UiPageMetadata] upm
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													--left join [UiPageMetadataCharacteristics] l on l.UiPageMetadataId = upm.Id and l.IsDeleted = 0
													--left join [LookupCategory] lc on lc.Id = l.LookupCategoryId and lc.IsDeleted = 0
                                                where upm.Id  = @Id
                                                    and upm.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    --and lc.IsDeleted = 0
                                                    and ucct.IsDeleted = 0
                                                    --and l.IsDeleted = 0 ", new { Id = id }).FirstOrDefault();

            return uiPageMetadataById;
        }
        /// <summary>
        /// Edit Record For Ui Page Metadata 
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int Update(UiPageMetadataModel uiPageMetadataModel)
        {
            string updateQueryParent = @"UPDATE [UiPageMetadata]
                             SET Name = @Name,
                                 
                                 UiControlDisplayName = @UiControlDisplayName
                                 
                             WHERE Id = @Id ";
            string updateQueryChild = @"UPDATE [UiPageMetadataModuleBridge]
                            SET UiPageTypeId = @UiPageTypeId,
                                  
                                ParentId = @ParentId,
                                Orders = @Orders,
                                UiControlDisplayName = @UiControlDisplayName,
                                MultiValueControl = @MultiValueControl
                            WHERE  UiPageMetadataId = @Id and Id =@MetadataModuleBridgeId";

            using IDbConnection db = _connectionFactory.GetConnection;
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        if (uiPageMetadataModel.UiPageMetadataId == 0)
                        {
                            int parentId = db.ExecuteScalar<int>(updateQueryParent, uiPageMetadataModel, transaction: transaction);
                            var childModel = new UiPageMetadataModel
                            {

                                UiPageTypeId = uiPageMetadataModel.UiPageTypeId,
                                ParentId = uiPageMetadataModel.ParentId,
                                Orders = uiPageMetadataModel.Orders,
                                UiControlDisplayName = uiPageMetadataModel.UiControlDisplayName,
                                MultiValueControl = uiPageMetadataModel.MultiValueControl,
                            };
                            db.Execute(updateQueryChild, childModel, transaction: transaction);

                            transaction.Commit();
                            return parentId;
                        }
                        else
                        {
                            // Update parent and child based on condition
                            uiPageMetadataModel.UiPageMetadataId = db.Execute(updateQueryParent, uiPageMetadataModel, transaction: transaction);
                            db.Execute(updateQueryChild, uiPageMetadataModel, transaction: transaction);

                            transaction.Commit();
                            return uiPageMetadataModel.UiPageMetadataId;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Delete Record From Ui PageMetadata And UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id, int metadataModuleBridgeId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(@"UPDATE [UiPageMetadata] SET IsDeleted = 1 WHERE Id = @Id", new { Id = id });
            // Update in UiPageMetadataModuleBridge table
            db.Execute(@"UPDATE [UiPageMetadataModuleBridge] SET IsDeleted = 1 WHERE UiPageMetadataId = @Id and Id =@metadataModuleBridgeId", new { MetadataModuleBridgeId = metadataModuleBridgeId, Id = id });
            return true;
        }
    }
}
