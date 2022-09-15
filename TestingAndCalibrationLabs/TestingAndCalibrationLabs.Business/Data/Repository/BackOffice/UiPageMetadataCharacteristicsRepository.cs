using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UiPageMetadataCharacteristicsRepository : IUiPageMetadataCharacteristicsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UiPageMetadataCharacteristicsRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
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
