using System.Collections.Generic;
using Dapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using System.Data;
using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Linq;
using PagedList;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Connection between Database using ISampleRepository we Establing a connection
    /// </summary>
    public class SampleRepository : ISampleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public SampleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Fetching data from Database
        /// </summary>
        /// <returns></returns>
        public List<SampleModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SampleModel>("Select * From [SampleTable] where IsDeleted=0").ToList();
        }
        /// <summary>
        /// Connecting with database Via connectionfactory for displaying data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SampleModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SampleModel>("Select top 1 * From [SampleTable] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        /// <summary>
        /// Inserting data to Database
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int Insert(SampleModel sample)
        {
            string query = @"Insert into [SampleTable](Name, Description) 
                values (@Name, @Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, sample);
        }
        /// <summary>
        /// Inserting data to list
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public int InsertCollection(List<SampleModel> expenses)
        {
            string query = @"Insert into [SampleTable](Name, Description) 
                values (@Name, @Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, expenses);
        }

        /// <summary>
        /// Updating data in Database
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int Update(SampleModel sample)
        {
            string query = @"update [SampleTable] Set 
                              Name = @Name,
                              Description = @Description
                            Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, sample);
        }

        /// <summary>
        /// Delete Data  from database (Not deleting from database we just making its status is 1 mean deactivated)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"update [SampleTable] Set 
                                IsDeleted = @IsDeleted
                            Where Id = @Id and  Id=@id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { IsDeleted = true, Id = id });
            return true;
        }
        #endregion
    }
}
