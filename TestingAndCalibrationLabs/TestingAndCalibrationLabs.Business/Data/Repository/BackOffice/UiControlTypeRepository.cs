using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UiControlTypeRepository : IUiControlTypeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiControlTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Connecting with database Via connectionfactory for displaying data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlTypeModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlTypeModel>("Select top 1 * From [UiControlType] where id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }
        /// <summary>
        /// Editing Data for Ui Control Type columns 
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public int Edit(UiControlTypeModel uiControlTypeModel)
        {
            string query = @"update [UiControlType] Set  
                                Name = @Name,
                                DisplayName = @DisplayName
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiControlTypeModel);
        }
        /// <summary>
        /// inserting Data in Ui Control Type Table 
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public int Create(UiControlTypeModel uiControlTypeModel)
        {
            string query = @"Insert into [UiControlType] (Name,DisplayName)
                                values (@Name, @DisplayName)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiControlTypeModel);
        }
        /// <summary>
        /// Deleting Data From Ui Control Type Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"Update [UiControlType] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;

        }
        /// <summary>
        /// Getting All The Data Of Ui Control Type Table
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlTypeModel>("Select * From [UiControlType] where IsDeleted=0").ToList();


        }



    }
}
