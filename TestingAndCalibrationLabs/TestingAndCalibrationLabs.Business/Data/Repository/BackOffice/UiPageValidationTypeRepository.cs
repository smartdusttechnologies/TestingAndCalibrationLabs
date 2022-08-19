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
    public class UiPageValidationTypeRepository : IUiPageValidationTypeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageValidationTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(UiPageValidationModel uiPageValidationModel)
        {
            string query = @"Insert into [UiPageValidation] (UiPageId,UiPageMetadataId,UiPageValidationTypeId)
                                values (@UiPageTypeId,@UiPageMetadataTypeId,@UiPageValidationTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageValidationModel);
        }

        public bool Delete(int id)
        {
            string query = @"Update [UiPageValidation] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;
        }

        public List<UiPageValidationModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.[Id] as UiPageMetadataTypeId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataTypeName,
                                                    upvt.[Id] as UiPageValidationTypeId, upvt.[Name] as UiPageValidationTypeName
                                                From[UiPageValidation] upv
                                                    inner join[UiPageType] upt on upv.UiPageId = upt.Id
                                                    inner join[UiPageMetadata] upm on upv.UiPageMetadataId = upm.Id
                                                    inner join[UiPageValidationType] upvt on upv.UiPageValidationTypeId = upvt.Id
                                                Where    
                                                    upv.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and upvt.isDeleted = 0").ToList();
        }

        public UiPageValidationModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.[Id] as UiPageMetadataTypeId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataTypeName,
                                                    upvt.[Id] as UiPageValidationTypeId, upvt.[Name] as UiPageValidationTypeName
                                                From[UiPageValidation] upv
                                                    inner join[UiPageType] upt on upv.UiPageId = upt.Id
                                                    inner join[UiPageMetadata] upm on upv.UiPageMetadataId = upm.Id
                                                    inner join[UiPageValidationType] upvt on upv.UiPageValidationTypeId = upvt.Id
                                                Where   
                                                    upv.Id = @Id
                                                    and upv.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and upvt.isDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }

        public int Update(UiPageValidationModel uiPageValidationModel)
        {
            string query = @"update [UiPageValidation] Set  
                                UiPageId = @UiPageTypeId,
                                UiPageMetadataId = @UiPageMetadataTypeId,
                                UiPageValidationTypeId = @UiPageValidationTypeId
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageValidationModel);
        }
    }
}
