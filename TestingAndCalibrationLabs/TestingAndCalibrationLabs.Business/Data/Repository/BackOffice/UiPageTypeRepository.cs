
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UiPageTypeRepository : IUiPageTypeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record in Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public int Create(UiPageTypeModel uiPageTypeModel)
        {
            string query = @"Insert into [UiPageType] (Name)
                                values (@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageTypeModel);

        }
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"Update [UiPageType] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;
        }
        /// <summary>
        /// Getting All Record For Ui Page Type 
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>("Select * From [UiPageType] where IsDeleted=0").ToList();
        }
        /// <summary>
        /// Getting All Record Data Type 
        /// </summary>
        /// <returns></returns>

        public List<DataTypeModel> GetDataType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<DataTypeModel>("SELECT d.Name as Name, d.Id as Id from DataType d where IsDeleted=0").ToList();
      }
        
        /// <summary>
        /// Getting All Record Ui Page Validation Type 
        /// </summary>
        /// <returns></returns>

        public List<UiPageValidationTypeModel> GetUiPageValidationType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationTypeModel>("SELECT v.Name as Name, v.Id as Id from UiPageValidationType v where IsDeleted=0").ToList();
        }
        
        /// <summary>
        /// Get Record By Id For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>("Select top 1 * From [UiPageType] where id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public int Edit(UiPageTypeModel uiPageTypeModel)
        {
            string query = @"update [UiPageType] Set  
                                Name = @Name
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query,uiPageTypeModel);
        }
    }
}
