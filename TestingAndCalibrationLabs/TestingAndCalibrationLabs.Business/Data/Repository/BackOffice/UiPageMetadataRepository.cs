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
            string query = @"Insert into [UiPageMetadata] (UiPageTypeId,UiControlTypeId,DataTypeId,IsRequired,UiControlDisplayName)
                                values (@UiPageTypeId,@UiControlTypeId,@DataTypeId,@IsRequired,@UiControlDisplayName)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageMetadataModel);
        }

        /// <summary>
        /// Getting All Records From Ui Page Metadata 
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
           return db.Query<UiPageMetadataModel>(@"Select upm.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[Id] as DataTypeId, udt.[Name] as DataTypeName,
                                                    uct.[Name] as UiControlTypeName, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[DataType] udt on upm.DataTypeId = udt.Id
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
            return db.Query<UiPageMetadataModel>(@"Select upm.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[Id] as DataTypeId, udt.[Name] as DataTypeName,
                                                    uct.[Name] as UiControlTypeName, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[DataType] udt on upm.DataTypeId = udt.Id
                                                where
                                                    upm.Id = @Id and
                                                     upm.IsDeleted = @isDeleted
                                                    and upt.IsDeleted = @isDeleted
                                                    and uct.IsDeleted = @isDeleted
                                                    and udt.isDeleted = @isDeleted", new { isDeleted = 0, Id = id }).FirstOrDefault();
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
