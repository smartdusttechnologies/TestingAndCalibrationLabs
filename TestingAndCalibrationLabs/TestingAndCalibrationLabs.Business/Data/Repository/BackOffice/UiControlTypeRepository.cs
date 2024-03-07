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
    /// Repository Class For Ui UiControl  Type
    /// </summary> 
    public class UiControlTypeRepository : IUiControlTypeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiControlTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record in UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public int Create(UiControlTypeModel uiControlTypeModel)
        {
            string query = @"Insert into [UiControlType] (ControlCategoryId,DisplayName,Name)
                                                  values (@ControlCategoryId,@DisplayName,@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiControlTypeModel);
        }
        /// <summary>
        /// GET ALL Record from UiControlType
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public List<UiControlTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlTypeModel>(@" Select uct.Id,
                                                       uct.Name,
													   uct.DisplayName,
                                                       uct.ControlCategoryId,
                                                       L.Name as ControlCategoryName
                                                    From [Lookup] l
                                                    inner join [UiControlType]uct on uct.ControlCategoryId = L.Id
													
                                                where l.LookupCategoryId = 4
                                                   And uct.IsDeleted = 0 
                                                   And L.IsDeleted = 0
												   
                                                                        ").ToList();
        }
        /// <summary>
        /// GET ALL Control in Lookup
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> GetControl()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
             var controlname  = db.Query<UiControlTypeModel>(@"Select L.Id as ControlCategoryId,
                                                       L.Name as ControlCategoryName
                                                    From [Lookup]L
                                                    inner join [LookupCategory]Lc on Lc.Id = L.LookupCategoryId
                                                where   Lc.Id = 4
                                                   And Lc.IsDeleted = 0 
                                                   And L.IsDeleted = 0").ToList();
            return controlname ;
        }
        /// <summary>
        /// GET ALL Record in UiControlType based on id
        /// </summary>
        /// <returns></returns>
        public UiControlTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiControlTypeById = db.Query<UiControlTypeModel>(@"Select uct.Id,
                                                       uct.Name,
													   uct.DisplayName,
                                                       uct.ControlCategoryId,
                                                       L.Name as ControlCategoryName
                                                    From [UiControlType] uct
                                                    inner join [Lookup]L on uct.ControlCategoryId = L.Id
                                                where uct.id = @Id
                                                   And uct.IsDeleted = 0 
                                                   And L.IsDeleted = 0", new { Id = id }).FirstOrDefault(); ;

            return uiControlTypeById;
        }
        /// <summary>
        /// Update Record in UiControlType
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        public int Update(UiControlTypeModel uiControlTypeModel)
        {
            string query = @"update [UiControlType] Set  
                                Name = @Name,
                                DisplayName = @DisplayName,
                                ControlCategoryId = @ControlCategoryId
                                Where id = @Id";
												
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiControlTypeModel);
        }
        /// <summary>
        /// Delete Record in UiControlType
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(@"update [UiControlType] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }
}
