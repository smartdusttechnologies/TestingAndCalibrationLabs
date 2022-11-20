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
        /// Insert Record in Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public int Create(UiPageMetadataModel uiPageMetadataModel)
        {
            string query = @"Insert into [UiPageMetadata] (UiPageTypeId,Name,LookupCategoryId,UiControlTypeId,DataTypeId,IsRequired,UiControlDisplayName,UiControlCategoryTypeId,ParentId)
                                                  values (@UiPageTypeId,@Name,@LookupCategoryId,@UiControlTypeId,@DataTypeId,@IsRequired,@UiControlDisplayName,@UiControlCategoryTypeId,@ParentId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            
            return db.Execute(query, uiPageMetadataModel);
        }
        /// <summary>
        /// Getting All Records From Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        upm.UiPageTypeId,
                                                        upt.[Name] as UiPageTypeName,
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.ParentId,
                                                        upm.DataTypeId,
														l.Id as LookupCategoryId,
														upm.Name,
														lc.Name as lookupCategoryName,
                                                        dt.Name as DataTypeName,
                                                        uct.ControlCategoryId,
														ucct.Id as UiControlCategoryTypeId,ucct.Name as UiControlCategoryTypeName
                                                    From [UiPageMetadata] upm
                                                    inner join [UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
													left join [UiPageMetadataCharacteristics] l on l.UiPageMetadataId = upm.Id and l.IsDeleted = 0
													left join [LookupCategory] lc on lc.Id = l.LookupCategoryId and lc.IsDeleted = 0
                                                where 
                                                    upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0").ToList();
        }
        /// <summary>
        /// Getting Record By Id For Ui Page Metadata And Ui Page MetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiPageMetadataById = db.Query<UiPageMetadataModel>(@"Select upm.Id,
                                                        upm.UiPageTypeId,
                                                        upt.[Name] as UiPageTypeName,
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,
                                                        upm.ParentId,
                                                        upm.DataTypeId,
														upm.Name,
                                                        dt.Name as DataTypeName,
                                                        uct.ControlCategoryId,
                                                        l.Name as ControlCategoryName,
														ucct.Id as UiControlCategoryTypeId,ucct.Name as UiControlCategoryTypeName
                                                    From [UiPageMetadata] upm
                                                    inner join [UiPageType] upt on upm.UiPageTypeId = upt.Id
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id
                                                    inner join [Lookup] l on l.Id = uct.ControlCategoryId
													inner join [UiControlCategoryType] ucct on ucct.Id = upm.UiControlCategoryTypeId
                                                where upm.Id = @Id
											     	and upm.IsDeleted = 0 
                                                    and upt.IsDeleted = 0 
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                    and l.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
           
            return uiPageMetadataById;
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
                                UiControlDisplayName = @UiControlDisplayName,
                                Name = @Name,
                                UiControlCategoryTypeId = @UiControlCategoryTypeId,
                                ParentId = @ParentId
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
           
                uiPageMetadataModel.ControlCategoryId = null;
              return  db.Execute(query, uiPageMetadataModel);
        }
        /// <summary>
        /// Delete Record From Ui PageMetadata And UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            
            db.Execute(@"update [UiPageMetadata] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }
}
