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
    /// Repository Class For Ui Page Metadata Characteristics
    /// </summary>
    public class UiPageMetadataCharacteristicsRepository : IUiPageMetadataCharacteristicsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UiPageMetadataCharacteristicsRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get All Record From Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataCharacteristicsModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataCharacteristicsModel>(@"
												  Select upmc.Id,upmc.LookupCategoryId, lc.[Name] as LookupCategoryName,upmc.UiPageMetadataId, upm.UiControlDisplayName 
                                                From[UiPageMetadataCharacteristics] upmc
                                                    inner join [UiPageMetadata] upm on upmc.UiPageMetadataId = upm.Id
                                                    inner join[LookupCategory] lc on upmc.LookupCategoryId = lc.Id
                                                where
                                                     upmc.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and lc.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Get Ui Page Metadata Characteristics Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageMetadataCharacteristicsModel> GetByPageMetadataId(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataCharacteristicsModel>(@"Select upm.UiPageMetadataId , upt.[Name] as LookupName, upt.Id
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[Lookup] upt on upm.LookupId = upt.Id
                                                where
                                                     upm.UiPageMetadataId = @Id and
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    ", new { Id = id }).ToList();
        }
        /// <summary>
        /// Get  Record From Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        public UiPageMetadataCharacteristicsModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataCharacteristicsModel>(@"Select upm.UiPageMetadataId , upt.[Name] as LookupName, lc.[Name] as CategoryName 
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[LookupCategory] lc on upm.LookupCategoryId = lc.Id
                                                    inner join[Lookup] upt on lc.Id = upt.LookupCategoryId
                                                where
                                                    upm.UiPageMetadataId = @metadataId
                                                    and upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    and lc.IsDeleted = 0", new { metadataId = id }).First();
        }
        /// <summary>
        /// Insert into  Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        public int Create(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel)
        {
            string query = @"Insert into [UiPageMetadataCharacteristics] (UiPageMetadataId,LookupCategoryId)
                                                                  values (@UiPageMetadataId,@LookupCategoryId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageMetadataCharacteristicsModel);

        }
        /// <summary>
        /// Get  Record From Ui Page Metadata Characteristics 
        /// </summary>
        /// <returns></returns>
        public UiPageMetadataCharacteristicsModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiControlTypeById = db.Query<UiPageMetadataCharacteristicsModel>(@"Select upmc.Id,upmc.LookupCategoryId, lc.[Name] as LookupCategoryName,upmc.UiPageMetadataId, upm.UiControlDisplayName 
                                                From[UiPageMetadataCharacteristics] upmc
                                                    inner join [UiPageMetadata] upm on upmc.UiPageMetadataId = upm.Id
                                                    inner join[LookupCategory] lc on upmc.LookupCategoryId = lc.Id
                                                where upmc.id = @Id
                                                    and upmc.IsDeleted = 0
                                                    and upm.IsDeleted = 0
                                                    and lc.IsDeleted = 0", new { Id = id }).FirstOrDefault(); ;
            return uiControlTypeById;
        }
        /// <summary>
        /// Update into  Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        public int Update(UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel)
        {
            string query = @"update [UiPageMetadataCharacteristics] Set  
                                
                                UiPageMetadataId = @UiPageMetadataId,
                                LookupCategoryId = @LookupCategoryId
                                Where id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageMetadataCharacteristicsModel);
        }
        /// <summary>
        /// Delete into  Ui Page Metadata Characteristics
        /// </summary>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(@"update [UiPageMetadataCharacteristics] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }
}
