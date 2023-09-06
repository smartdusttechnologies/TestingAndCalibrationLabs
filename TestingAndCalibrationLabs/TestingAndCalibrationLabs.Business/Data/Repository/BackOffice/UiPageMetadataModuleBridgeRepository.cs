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
    /// Repository Class For UiPageMetadataModuleBridge
    /// </summary> 
    public class UiPageMetadataModuleBridgeRepository : IUiPageMetadataModuleBridgeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageMetadataModuleBridgeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert into  UiPageMetadataModuleBridge
        /// </summary>
        /// <returns></returns>
        public int Insert(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridgeModel)
        {
            string query = @" Insert into [UiPageMetadataModuleBridge] (UiPageMetadataId,UiPageTypeId,ModuleId,ParentId,Orders,UiControlDisplayName,MultiValueControl)
                                                  values (@UiPageMetadataId,@UiPageTypeId,@ModuleId,@ParentId,@Orders,@UiControlDisplayName,@MultiValueControl)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageMetadataModuleBridgeModel);

        }
        /// <summary>
        /// Get all Record  UiPageMetadataModuleBridge
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModuleBridgeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModuleBridgeModel>(@"	Select upmmb.Id,upmmb.UiPageMetadataId,upt.Name as UiPageTypeName,
                                                   upmmb.ParentId,     
                                                      upmmb.Orders,
													  upmmb.UiControlDisplayName,
													  upmmb.MultiValueControl
                                                    From [UiPageMetadataModuleBridge] upmmb

                                                    inner join[UiPageType] upt on upmmb.UiPageTypeId = upt.Id
                                                where 
                                                    upmmb.IsDeleted = 0 
                                                   And upt.IsDeleted = 0").ToList();

        }
        /// <summary>
        /// Get  ControlName from  Lookup
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModuleBridgeModel> GetControl()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var controlname = db.Query<UiPageMetadataModuleBridgeModel>(@"Select L.Id as ControlCategoryId,
                                                       L.Name as ControlCategoryName
                                                    From [Lookup]L
                                                    inner join [LookupCategory]Lc on Lc.Id = L.LookupCategoryId
                                                where   Lc.Id = 4
                                                   And Lc.IsDeleted = 0 
                                                   And L.IsDeleted = 0").ToList();

            return controlname;
        }
        /// <summary>
        /// Get all record into  UiPageMetadataModuleBridge based on Id
        /// </summary>
        /// <returns></returns>
        public UiPageMetadataModuleBridgeModel GetById(int id)
        {
          using IDbConnection db = _connectionFactory.GetConnection;
          var uiControlTypeById = db.Query<UiPageMetadataModuleBridgeModel>(@"Select upmmb.Id,upmmb.UiPageMetadataId,upmmb.UiPageTypeId,upmmb.ModuleId,
                                                                                        upt.Name as UiPageTypeName,
                                                                                        m.Name as ModuleName,
                                                                                        upmmb.ParentId,     
                                                                                        upmmb.Orders,
													                                    upmmb.UiControlDisplayName,
													                                    upmmb.MultiValueControl
                                                                                    From [UiPageMetadataModuleBridge] upmmb
                                                                                    inner join[UiPageType] upt on upmmb.UiPageTypeId = upt.Id
													                                inner join [Module] m on upmmb.ModuleId = m.Id
                                                                                where upmmb.id =@Id
                                                                                    And upmmb.IsDeleted = 0 
                                                                                    And upt.IsDeleted = 0
												                                    and m.IsDeleted = 0", new { Id = id }).FirstOrDefault(); ;
            return uiControlTypeById;
        }
        /// <summary>
        /// Update into  UiPageMetadataModuleBridge
        /// </summary>
        /// <returns></returns>
        public int Update(UiPageMetadataModuleBridgeModel uiPageMetadataModuleBridgeModel)
        {
            string query = @"update [UiPageMetadataModuleBridge] Set  
                               UiPageMetadataId=@UiPageMetadataId,
							   UiPageTypeId = @UiPageTypeId,
							   ModuleId = @ModuleId,
							   ParentId = @ParentId,
							  Orders =@Orders,
							  UiControlDisplayName = @UiControlDisplayName,
							  MultiValueControl =@MultiValueControl
                                Where id = @Id";

            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, uiPageMetadataModuleBridgeModel);
        }
        /// <summary>
        /// Delete into  UiPageMetadataModuleBridge
        /// </summary>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [UiPageMetadataModuleBridge] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }





}












