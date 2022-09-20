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
    /// 
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
            return db.Query<UiPageMetadataCharacteristicsModel>(@"Select upm.UiPageMetadataId , upt.[Name] as Value, upt.Category 
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[Lookup] upt on upm.LookupId = upt.Id
                                                where
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    ").ToList();
        }
        /// <summary>
        /// Get Ui PageMetadata Characteristics Record By Ui PageMetadata Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageMetadataCharacteristicsModel> GetByMetadataId(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataCharacteristicsModel>(@"select * from [UiPageMetadataCharacteristics] where UiPageMetadataId = @Id And IsDeleted = @isDeleted", new { Id = id, isDeleted = false }).ToList();
        }
        /// <summary>
        /// Get Ui Page Metadata Characteristics Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataCharacteristicsModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataCharacteristicsModel>(@"Select upm.UiPageMetadataId , upt.[Name] as Value, upt.Category 
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[Lookup] upt on upm.LookupId = upt.Id
                                                where
                                                     upm.UiPageMetadataId = @Id and
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    ", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
    }
}
