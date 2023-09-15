using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        /// Getting All Records From Ui Page Metadata 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetDisplayName()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var Displaynames = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                       
                                                        upm.UiControlDisplayName
                                                     
                                                    From [UiPageMetadata] upm

                                                    
                                                where 
                                                    upm.IsDeleted = 0 
                                                    ").ToList();
            return Displaynames;
        }
        /// <summary>
        /// Getting All Existing From Ui Page Metadata based on moduleLayoutId 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetExisting(int moduleLayoutId)
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
													and up.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id  and uiPageTypeId,metadataModuleBridgeId For Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetByPageId(int id, int uiPageTypeId, int metadataModuleBridgeId)
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
                                 UiControlTypeId = @UiControlTypeId,
                                 DataTypeId = @DataTypeId,
                                 IsRequired = @IsRequired,
                                 UiControlDisplayName = @UiControlDisplayName,
                                 UiControlCategoryTypeId = @UiControlCategoryTypeId,
                                 ModuleLayoutId = @ModuleLayoutId
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
        public bool Delete(int id, int uiPageTypeId, int metadataModuleBridgeId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(@"UPDATE [UiPageMetadata] SET IsDeleted = 1 WHERE Id = @Id", new { Id = id });
            // Update in UiPageMetadataModuleBridge table
            db.Execute(@"UPDATE [UiPageMetadataModuleBridge] SET IsDeleted = 1 WHERE UiPageMetadataId = @Id and Id =@metadataModuleBridgeId", new { MetadataModuleBridgeId = metadataModuleBridgeId, Id = id });
            return true;
        }
    }
}
