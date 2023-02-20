﻿using Dapper;
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
            return db.Query<UiPageMetadataCharacteristicsModel>(@"Select upm.UiPageMetadataId , upt.[Name] as Value, lc.[Name] as CategoryName 
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[Lookup] upt on upm.LookupId = upt.Id
                                                    inner join[LookupCategory] lc on upm.LookupId = lc.Id
                                                where
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    ").ToList();
        }

        /// <summary>
        /// Get Ui Page Metadata Characteristics Record By UiPageMetadataId
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
                                                    ", new { metadataId = id }).First();
        }
    }
}
