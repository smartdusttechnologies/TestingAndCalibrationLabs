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
    /// Repository Class For Ui Page Validation 
    /// </summary>
    public class UiPageValidationRepository : IUiPageValidationRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageValidationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In Ui Page Validation 
        /// </summary>
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        public int Create(UiPageValidationModel uiPageValidationModel)
        {
            string query = @"Insert into [UiPageValidation] (UiPageTypeId,UiPageMetadataId,UiPageValidationTypeId)
                                values (@UiPageTypeId,@UiPageMetadataId,@UiPageValidationTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageValidationModel);
        }
        /// <summary>
        /// Getting All Record From Ui Page Validation 
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.[Id] as UiPageMetadataId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataName,
                                                    upvt.[Id] as UiPageValidationTypeId, upvt.[Name] as UiPageValidationTypeName
                                                From[UiPageValidation] upv
                                                    inner join[UiPageType] upt on upv.UiPageTypeId = upt.Id
                                                    inner join[UiPageMetadata] upm on upv.UiPageMetadataId = upm.Id
                                                    inner join[UiPageValidationType] upvt on upv.UiPageValidationTypeId = upvt.Id
                                                Where    
                                                    upv.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and upvt.isDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id For Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageValidationModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationModel>(@"Select upv.Id, upt.[Id] as UiPageTypeId, upt.[Name] as UiPageTypeName, upm.[Id] as UiPageMetadataId,
                                                    upm.[UiControlDisplayName] as UiPageMetadataName,
                                                    upvt.[Id] as UiPageValidationTypeId, upvt.[Name] as UiPageValidationTypeName
                                                From[UiPageValidation] upv
                                                    inner join[UiPageType] upt on upv.UiPageTypeId = upt.Id
                                                    inner join[UiPageMetadata] upm on upv.UiPageMetadataId = upm.Id
                                                    inner join[UiPageValidationType] upvt on upv.UiPageValidationTypeId = upvt.Id
                                                Where   
                                                    upv.Id = @Id
                                                    and upv.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and upvt.isDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Update Record From Ui Page Validation 
        /// </summary>
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        public int Update(UiPageValidationModel uiPageValidationModel)
        {
            string query = @"update [UiPageValidation] Set  
                                UiPageTypeId = @UiPageTypeId,
                                UiPageMetadataId = @UiPageMetadataId,
                                UiPageValidationTypeId = @UiPageValidationTypeId
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageValidationModel);
        }
    }
}
