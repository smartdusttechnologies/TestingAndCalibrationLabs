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
            string query = @"Insert into [UiPageMetadata] (Name,UiControlTypeId,DataTypeId,IsRequired,UiControlDisplayName,UiControlCategoryTypeId)
                                                  values (@Name,@UiControlTypeId,@DataTypeId,@IsRequired,@UiControlDisplayName,@UiControlCategoryTypeId)";
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
                                                        upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,                                                      
                                                        upm.DataTypeId,
													   dt.Name as DataTypeName,
														upm.Name,
                                                        upm.UiControlCategoryTypeId,
                                                        ucct.Name as UiControlCategoryTypeName,											                                                     
                                                        uct.ControlCategoryId													
                                                    From [UiPageMetadata] upm
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id                                              
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id                                                   
													inner join [UiControlCategoryType] ucct on upm.UiControlCategoryTypeId = ucct.Id												
                                                where 
                                                    upm.IsDeleted = 0 
                                                    
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                 
                                                    and ucct.IsDeleted = 0
                                                    ").ToList();
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
                                                       upm.IsRequired,
                                                        upm.UiControlTypeId,
                                                        uct.[Name] as UiControlTypeName,
                                                        upm.UiControlDisplayName,                                                      
                                                        upm.DataTypeId,
													   dt.Name as DataTypeName,
														upm.Name,
                                                        upm.UiControlCategoryTypeId,
                                                        ucct.Name as UiControlCategoryTypeName,											                                                     
                                                        uct.ControlCategoryId
                                                  
													
                                                       From [UiPageMetadata] upm
                                                    inner join [UiControlType] uct on upm.UiControlTypeId = uct.Id                                              
                                                    inner join [DataType] dt on upm.DataTypeId = dt.Id                                                   
													inner join [UiControlCategoryType] ucct on upm.UiControlCategoryTypeId = ucct.Id												
                                                where 
													
                                                 upm.Id = @Id
                                                     
                                                  
                                                    and uct.IsDeleted = 0
                                                    and dt.IsDeleted = 0
                                                  and ucct.IsDeleted=0
													", new { Id = id }).FirstOrDefault();
           
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
                                
                                UiControlTypeId = @UiControlTypeId,
                                IsRequired = @IsRequired,
                                DataTypeId = @DataTypeId,
                                UiControlDisplayName = @UiControlDisplayName,
                                Name = @Name,
                                UiControlCategoryTypeId = @UiControlCategoryTypeId
                             
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
