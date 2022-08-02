using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageControl;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Cui
{
    public class UiPageControlRepo : IUiPageControlRepo
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageControlRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(UiPageControlModel pageCon)
        {
            string query = @"Insert into [UiPageMetadata] (UiPageTypeId,UiControlTypeId,UiDataTypeId,IsRequired,UiControlDisplayName)
                                values (@UiPageTypeId,@UiControlTypeId,@UiDataTypeId,@IsRequired,@UiControlDisplayName)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, pageCon);
        }

        public bool Delete(int id)
        {
            string query = @"Update [UiPageMetaData] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;
        }

        public List<UiPageControlModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
           // string Query = "Select* From[UiPageMetadata] where IsDeleted = 0 SELECT UiPageMetaData.Id, UiPageType.Name, UiControlType.Name FROM((UiPageMetadata INNER JOIN UiPageType ON UiPageMetadata.Id = UiPageType.Id)INNER JOIN UiControlType ON UiPageMetadata.Id = UiControlType.Id);";
            return db.Query<UiPageControlModel>(@"Select upm.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[DataTypeId] as UiDataTypeId, udt.[DataTypeName] as UiDataTypeName,
                                                    uct.[Name] as UiControlType, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[UiDataType] udt on upm.UiDataTypeId = udt.DataTypeId
                                                where
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and uct.IsDeleted = 0
                                                    and udt.isDeleted = 0").ToList();
        }

        public UiPageControlModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageControlModel>(@"Select upm.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageName, upm.IsRequired, uct.[Id] as UiControlTypeId,
                                                    udt.[DataTypeId] as UiDataTypeId, udt.[DataTypeName] as UiDataTypeName,
                                                    uct.[Name] as UiControlType, upm.UiControlDisplayName
                                                From[UiPageMetadata] upm
                                                    inner join[UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join[UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join[UiDataType] udt on upm.UiDataTypeId = udt.DataTypeId
                                                where

                                                    upm.Id = @Id and
                                                     upm.IsDeleted = @isDeleted
                                                    and upt.IsDeleted = @isDeleted
                                                    and uct.IsDeleted = @isDeleted
                                                    and udt.isDeleted = @isDeleted", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }

        public int Update(UiPageControlModel pageCon)
        {
            string query = @"update [UiPageMetadata] Set  
                                UiPageTypeId = @UiPageTypeId,
                                UiControlTypeId = @UiControlTypeId,
                                IsRequired = @IsRequired,
                                UiDataTypeId = @UiDataTypeId,
                                UiControlDisplayName = @UiControlDisplayName
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, pageCon);
        }
    }
}
