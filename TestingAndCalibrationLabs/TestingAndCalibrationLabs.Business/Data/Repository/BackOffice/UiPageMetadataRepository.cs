using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string query = @"Insert into [UiPageMetadata] (UiPageTypeId,UiControlTypeId,DataTypeId,IsRequired,UiControlDisplayName,ControlCategoryId)
                                values (@UiPageTypeId,@UiControlTypeId,@DataTypeId,@IsRequired,@UiControlDisplayName,@ControlCategoryId)
                            SELECT @Id = @@IDENTITY";

            string metadataCharacteristicsQuery = @"Insert into [UiPageMetadataCharacteristics](UiPageMetadataId, LookupId)
                                                        values (@UiPageMetadataId, @LookupId)";

            using IDbConnection db = _connectionFactory.GetConnection;

            if (uiPageMetadataModel.uiPageMetadataCharacteristics.Count > 0)
            {
                var p = new DynamicParameters();
                p.Add("Id", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("@UiPageTypeId", uiPageMetadataModel.UiPageTypeId);
                p.Add("@UiControlTypeId", uiPageMetadataModel.UiControlTypeId);
                p.Add("@DataTypeId", uiPageMetadataModel.DataTypeId);
                p.Add("@IsRequired", uiPageMetadataModel.IsRequired);
                p.Add("@UiControlDisplayName", uiPageMetadataModel.UiControlDisplayName);
                p.Add("@ControlCategoryId", uiPageMetadataModel.ControlCategoryId);
                using var transaction = db.BeginTransaction();
                db.Execute(query, p, transaction);
                int insertedMetadataId = p.Get<int>("@Id");
                uiPageMetadataModel.uiPageMetadataCharacteristics.ForEach(x => x.UiPageMetadataId = insertedMetadataId);
                db.Execute(metadataCharacteristicsQuery, uiPageMetadataModel.uiPageMetadataCharacteristics, transaction);
                transaction.Commit();
            }
            else
            {
                uiPageMetadataModel.ControlCategoryId = null;
                db.Execute(query, uiPageMetadataModel);
            }
            return 1;
        }
        /// <summary>
        /// Getting All Records From Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>(@"Select upm.Id,lct.[Name] as ControlCategoryName,lct.[Id] as ControlCategoryId, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[Id] as DataTypeId, udt.[Name] as DataTypeName,
                                                    uct.[Name] as UiControlTypeName, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[DataType] udt on upm.DataTypeId = udt.Id
                                                    LEFT OUTER join[LookupCategory] lct on upm.ControlCategoryId = lct.Id
                                                where
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and uct.IsDeleted = 0
                                                    and udt.isDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id For Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiPageMetadataById = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        upm.UiPageTypeId,
                                                        upt.[Name] as UiPageTypeName,
                                                         upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.ParentId,
                                                        upm.DataTypeId,
                                                        dt.Name as DataTypeName,
                                                        uct.ControlCategoryId,
                                                        l.Name as ControlCategoryName
                                                    From [UiPageMetadata] upm
                                                    inner join [UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
                                                where upm.Id=@Id 
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    and l.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
            if (uiPageMetadataById.ControlCategoryId != null)
            {
                var pageMetadataCharacteristicsList = db.Query<UiPageMetadataCharacteristicsModel>(@"select * from 
                                                                                        [UiPageMetadataCharacteristics] 
                                                                                    where
                                                                                        UiPageMetadataId = @Id
                                                                                    And 
                                                                                        IsDeleted = @isDeleted", new { Id = id, isDeleted = false }).ToList();
                uiPageMetadataById.uiPageMetadataCharacteristics = pageMetadataCharacteristicsList;
            }
            return uiPageMetadataById;
        }
        /// <summary>
        /// Edit Record For Ui Page Metadata 
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int Update(UiPageMetadataModel uiPageMetadataModel)
        {
            string query = @"update [UiPageMetadata] Set  
                                UiPageTypeId = @UiPageTypeId,
                                UiControlTypeId = @UiControlTypeId,
                                IsRequired = @IsRequired,
                                DataTypeId = @DataTypeId,
                                UiControlDisplayName = @UiControlDisplayName
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            if (uiPageMetadataModel.uiPageMetadataCharacteristics.Count > 0)
            {
                var p = new DynamicParameters();
                p.Add("Id", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("@UiPageTypeId", uiPageMetadataModel.UiPageTypeId);
                p.Add("@UiControlTypeId", uiPageMetadataModel.UiControlTypeId);
                p.Add("@DataTypeId", uiPageMetadataModel.DataTypeId);
                p.Add("@IsRequired", uiPageMetadataModel.IsRequired);
                p.Add("@UiControlDisplayName", uiPageMetadataModel.UiControlDisplayName);
                p.Add("@ControlCategoryId", uiPageMetadataModel.ControlCategoryId);
                
                string characteristicsQueryInsert = @"Insert into [UiPageMetadataCharacteristics](UiPageMetadataId, LookupId)
                                                        values (@UiPageMetadataId, @LookupId)";
                string characteristics = @"update [UiPageMetadataCharacteristics] Set 
                                        IsDeleted = 1
                                    Where 
                                        UiPageMetadataId = @UiPageMetadataId
                                    And
                                        LookupId = @LookupId";

                using var transaction = db.BeginTransaction();
                db.Execute(query, uiPageMetadataModel, transaction);
                foreach (var item in uiPageMetadataModel.uiPageMetadataCharacteristics)
                {
                    if (item.UiPageMetadataId != 0)
                    {
                        db.Execute(characteristicsQueryInsert, new { UiPageMetadataId = item.UiPageMetadataId, LookupId = item.LookupId }, transaction);
                    }
                    if (item.UiPageMetadataId == 0)
                    {
                        db.Execute(characteristics, new { UiPageMetadataId = uiPageMetadataModel.Id, LookupId = item.LookupId }, transaction);
                    }
                }
                transaction.Commit();
            }
            else
            {
                uiPageMetadataModel.ControlCategoryId = null;
                db.Execute(query, uiPageMetadataModel);
            }
            return 0;
        }
        /// <summary>
        /// Delete Record From Ui PageMetadata And UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"update [UiPageMetadata] Set 
                                    IsDeleted = 1
                                    Where Id = @Id";
            string characteristics = @"update [UiPageMetadataCharacteristics] Set 
                                    IsDeleted = 1
                                    Where UiPageMetadataId = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            using var transaction = db.BeginTransaction();
            db.Execute(query, new { Id = id },transaction);
            db.Execute(characteristics, new { Id = id },transaction);
            transaction.Commit();
            return true;
        }
    }
}
