using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Cui
{
    public class UiPageValidationRepo : IUiPageValidationRepo
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageValidationRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(UiPageValidationModel pageVal)
        {
            string query = @"Insert into [UiPageValidation] (UiPageId,UiPageMetadataId,UiPageValidationTypeId)
                                values (@UiPageId,@UiPageMetadataId,@UiPageValidationId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, pageVal);
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
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageId, upt.[Name] as UiPageName, upm.[Id] as UiPageMetadataId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataName,
                                                    upvt.[Id] as UiPageValidationId, upvt.[Name] as UiPageValidationName
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
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageId, upt.[Name] as UiPageName, upm.[Id] as UiPageMetadataId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataName,
                                                    upvt.[Id] as UiPageValidationId, upvt.[Name] as UiPageValidationName
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

        public int Update(UiPageValidationModel pageVal)
        {
            string query = @"update [UiPageValidation] Set  
                                UiPageId = @UiPageId,
                                UiPageMetadataId = @UiPageMetadataId,
                                UiPageValidationTypeId = @UiPageValidationId
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, pageVal);
        }
    }
}
