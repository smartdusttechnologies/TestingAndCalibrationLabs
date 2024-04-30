using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;
namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For Ui Control Category Type
    /// </summary>
    public class UiControlCategoryTypeRepository : IUiControlCategoryTypeRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UiControlCategoryTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get All Record From UiControlCategoryType
        /// </summary>
        /// <returns></returns
        public List<UiControlCategoryTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlCategoryTypeModel>(@"select cct.Id,ct.[Name]as UiControlTypeName,cct.Name,cct.Template,cct.UiControlTypeId
                                                    From [UiControlCategoryType] cct
                                                    inner join [UiControlType] ct on ct.id = cct.UiControlTypeId
                                                    where 
                                                    cct.IsDeleted = 0 
                                                    and ct.IsDeleted = 0
                                                    ").ToList();
        }
        public List<UiControlCategoryTypeModel> GetControlCategoryType(int controlId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var ControlCategory= db.Query<UiControlCategoryTypeModel>(@" select cct.Id,cct.Name,cct.Template
                                                    From [UiControlType] uct
                                                    inner join [UiControlCategoryType] cct on uct.id = cct.UiControlTypeId
                                                    where uct.id=@ControlId
                                                   and  uct.IsDeleted = 0 
												   
                                                    and cct.IsDeleted = 0
                                                    ", new { ControlId = controlId }).ToList();

            return ControlCategory;
        }

        
        /// <summary>
        /// Insert Record in UiControlCategoryType
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        public int Create(UiControlCategoryTypeModel uiControlCategoryTypeModel)
        {
            string query = @"Insert into [UiControlCategoryType] (Name,Template,UiControlTypeId)
                                                  values (@Name,@Template,@UiControlTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, uiControlCategoryTypeModel);
        }
        /// <summary>
        /// Getting Record By Id  UiControlCategoryType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlCategoryTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var uiControlCategoryId = db.Query<UiControlCategoryTypeModel>(@"Select cct.Id,cct.Name,cct.Template,cct.UiControlTypeId,ct.[Name] as UiControlTypeName
                                                    From [UiControlCategoryType] cct 												
                                                   inner join [UiControlType] ct on ct.id = cct.UiControlTypeId                                             
                                                      where 
                                                        cct.Id= @Id
                                                     and cct.IsDeleted = 0 
                                                    and ct.IsDeleted = 0", new { Id = id }).FirstOrDefault();
            return uiControlCategoryId;
        }
        /// <summary>
        /// Edit Record For UiControlCategoryType 
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        public int Update(UiControlCategoryTypeModel uiControlCategoryTypeModel)
        {
            string query = @"update [UiControlCategoryType] Set  
                                Name = @Name,                                
                                Template = @Template,
                                UiControlTypeId=@UiControlTypeId
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiControlCategoryTypeModel);
        }
        /// <summary>
        /// Delete Record From UiControlCategoryType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [UiControlCategoryType] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }
}