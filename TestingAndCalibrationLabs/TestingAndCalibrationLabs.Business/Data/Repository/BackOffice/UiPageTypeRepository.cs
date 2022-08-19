
using Dapper;
using System;
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
        /// Inserting Data in Ui Page Type Table
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
        /// Deleting Data From Ui Page Type
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
        /// Getting All List Of Data From Ui Page Type Table 
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>("Select * From [UiPageType] where IsDeleted=0").ToList();
        }
        /// <summary>
        /// Fetching List data Of Data Type Table
        /// </summary>
        /// <returns></returns>
        
        public List<DataTypeModel> GetDataType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<DataTypeModel>("SELECT d.Name as Name, d.Id as Id from DataType d where IsDeleted=0").ToList();
      }
        
        public List<UiControlTypeModel> GetUiControlType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlTypeModel>("SELECT c.Name as Name, c.Id as Id from UiControlType c where IsDeleted=0").ToList();
        }
        
        public List<UiPageValidationTypeModel> GetUiPageValType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageValidationTypeModel>("SELECT v.Name as Name, v.Id as Id from UiPageValidationType v where IsDeleted=0").ToList();
        }
        
        public List<UiPageMetadataModel> GetUiPageMetadataType()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageMetadataModel>("SELECT m.UiControlDisplayName as UiControlDisplayName, m.Id as Id from UiPageMetadata m where IsDeleted=0").ToList();
        }

        public UiPageTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>("Select top 1 * From [UiPageType] where id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

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
