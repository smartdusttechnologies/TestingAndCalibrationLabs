using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.common
{
    public class CommonRepository: ICommonRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public CommonRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Connecting with database Via connectionfactory for displaying data
        /// </summary>  
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UiPageDataModel> GetUiPageDataByUiPageId(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageDataModel>("Select upd.* From [UiPageData] upd INNER JOIN  [Record] r ON upd.RecordId = r.Id and r.IsDeleted = 0 where upd.UiPageId=@uiPageId and upd.IsDeleted=0", new { uiPageId }).ToList();
        }

        public List<UiPageValidation> GetUiPageValidations(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidation>(@"Select upv.Id, upv.UiPageId, upv.UiPageMetadataId, upvt.Name, upv.UiPageValidationTypeId ,upvt.Value
                                            From [UiPageValidation] upv 
                                            INNER JOIN  [UiPageValidationType] upvt ON upv.UiPageValidationTypeId = upvt.Id 
                                                AND upv.IsDeleted = 0 
                                                AND upvt.IsDeleted = 0 
                                            WHERE upv.UiPageId=@uiPageId", new { uiPageId }).ToList();
        }

        public RecordModel GetUiPageMetadata(int uiPageId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var metadata = db.Query<UiPageMetadataModel>(@"Select upm.Id, upm.UiPageTypeId, upt.[Name] as UiPageName, upm.IsRequired, upm.UiControlTypeId, uct.[Name] as UiControlType, upm.UiControlDisplayName
                                                    From [UiPageMetadata] upm
                                                    inner join [UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id 
                                                where upm.UiPageTypeId=@uiPageId 
                                                    and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0", new { uiPageId }).ToList();
            return new RecordModel { UiPageId = uiPageId, Fields = metadata };
        }

        /// <summary>
        /// Inserting data to Database
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int Insert(RecordModel record)
        {
            var p = new DynamicParameters();
            p.Add("RecordId", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@UiPageId", record.UiPageId);

            string recordInsertQuery = @"Insert into [Record](UiPageId) 
                values (@UiPageId);
                SELECT @RecordId = @@IDENTITY";

            string uiPageMetadataInsertQuery = @"Insert into [UiPageData](UiControlId, Value, UiPageId, RecordId) 
                values (@UiControlId, @Value, @UiPageId, @RecordId)";

            using IDbConnection db = _connectionFactory.GetConnection;
            using var transaction = db.BeginTransaction();
            db.Execute(recordInsertQuery, p, transaction);

            int insertedRecordId = p.Get<int>("@RecordId");

            var uiPageMetaData = record.FieldValues.Select(x => new { RecordId = insertedRecordId, UiPageId = record.UiPageId, UiControlId = x.UiControlId, Value = x.Value }).ToList();
            ;
            db.Execute(uiPageMetadataInsertQuery, uiPageMetaData, transaction);

            transaction.Commit();

            return insertedRecordId;
        }

        #endregion
    }
}

