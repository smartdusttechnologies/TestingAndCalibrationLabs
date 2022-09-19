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
        /// Insert Record in Ui Page Metadata 
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int Create(UiPageMetadataModel uiPageMetadataModel)
        {
           
            var p = new DynamicParameters();
            p.Add("Id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@UiPageTypeId", uiPageMetadataModel.UiPageTypeId);
            p.Add("@UiControlTypeId", uiPageMetadataModel.UiControlTypeId);
            p.Add("@DataTypeId", uiPageMetadataModel.DataTypeId);
            p.Add("@IsRequired", uiPageMetadataModel.IsRequired);
            p.Add("@UiControlDisplayName", uiPageMetadataModel.UiControlDisplayName);
            p.Add("@LookupCategoryId", uiPageMetadataModel.LookupCategoryId);
            string query = @"Insert into [UiPageMetadata] (UiPageTypeId,UiControlTypeId,DataTypeId,IsRequired,UiControlDisplayName,LookupCategoryId)
                                values (@UiPageTypeId,@UiControlTypeId,@DataTypeId,@IsRequired,@UiControlDisplayName,@LookupCategoryId)
                            SELECT @Id = @@IDENTITY";

            string metadataCharacteristicsQuery = @"Insert into [UiPageMetadataCharacteristics](UiPageMetadataId, LookupId)
                                                        values (@UiPageMetadataId, @LookupId)";


            using IDbConnection db = _connectionFactory.GetConnection;
            using var transaction = db.BeginTransaction();
            db.Execute(query, p, transaction);
            int insertedMetadataId = p.Get<int>("@Id");
            uiPageMetadataModel.uiPageMetadataCharacteristics.ForEach(x=>x.UiPageMetadataId=insertedMetadataId);
            db.Execute(metadataCharacteristicsQuery,uiPageMetadataModel.uiPageMetadataCharacteristics, transaction);
            transaction.Commit();
            return insertedMetadataId;
        }
        /// <summary>
        /// Getting All Records From Ui Page Metadata 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>(@"Select upm.Id,lct.[Name] as LookupCategoryName,lct.[Id] as LookupCategoryId, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[Id] as DataTypeId, udt.[Name] as DataTypeName,
                                                    uct.[Name] as UiControlTypeName, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[DataType] udt on upm.DataTypeId = udt.Id
                                                    inner join[LookupCategory] lct on upm.LookupCategoryId = lct.Id
                                                where
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and uct.IsDeleted = 0
                                                    and udt.isDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id For Ui Page Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiPageMetadataById = db.Query<UiPageMetadataModel>(@"Select upm.Id,lct.[Name] as LookupCategoryName,lct.[Id] as LookupCategoryId, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[Id] as DataTypeId, udt.[Name] as DataTypeName,
                                                    uct.[Name] as UiControlTypeName, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[DataType] udt on upm.DataTypeId = udt.Id
                                                    inner join[LookupCategory] lct on upm.LookupCategoryId = lct.Id
                                                where
                                                    upm.Id = @Id and
                                                     upm.IsDeleted = @isDeleted
                                                    and upt.IsDeleted = @isDeleted
                                                    and uct.IsDeleted = @isDeleted
                                                    and udt.isDeleted = @isDeleted", new { isDeleted = 0, Id = id }).FirstOrDefault();
            var pageMetadataCharacteristicsList = db.Query<UiPageMetadataCharacteristicsModel>(@"select * from 
                                                                                        [UiPageMetadataCharacteristics] 
                                                                                    where
                                                                                        UiPageMetadataId = @Id ", new { Id = id }).ToList();
            uiPageMetadataById.uiPageMetadataCharacteristics = pageMetadataCharacteristicsList;
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
            return db.Execute(query, uiPageMetadataModel);
        }
    }
}
