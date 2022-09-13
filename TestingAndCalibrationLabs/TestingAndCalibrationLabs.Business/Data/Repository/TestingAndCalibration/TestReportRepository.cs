using Dapper;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration
{
    /// <summary>
    /// Using the interface "ITestReportRepository" to perform the Crud Operation on Test Report table.
    /// </summary>
    public class TestReportRepository : ITestReportRepository
    {
        /// <summary>
        /// To establish the connection with the dataBase.
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;
        
        public TestReportRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// To insert the record in the Test Report table.
        /// /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public int Insert(TestReportModel testReportModel)
        {
            string query = @"Insert into[TestReport](Client, FilePath, JobId, Name, DateTime, Email)
                            values (@Client, @FilePath, @JobId, @Name, @DateTime, @Email)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, testReportModel);
        }


        /// <summary>
        /// To insert the record in the Test Report table.
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public int InsertCollection(List<TestReportModel> testReportModel)
        {
            string query = @"Insert into [TestReport](Client, FilePath, JobId, Name, DateTime, Email)
                            values (@Client, @FilePath, @JobId, @Name, @DateTime, @Email)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, testReportModel);
        }

        /// <summary>
        /// To get the record from the Test Report table by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestReportModel GetTestReport(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestReportModel>("Select top 1 * From [TestReport] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        /// <summary>
        /// To get the record from the Test Report table by Id.
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public int Get(TestReportModel testReportModel)
        {
            string query = @"Select * From [TestReport] ORDER BY Id DESC";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query);
        }

        /// <summary>
        /// To get all the record.
        /// </summary>
        /// <returns></returns>
        public List<TestReportModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var result = db.Query<TestReportModel>("Select * From [TestReport] where IsDeleted=0 ORDER BY Id DESC");
            return result.ToList();
        }

        /// <summary>
        /// To get the report by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestReportModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestReportModel>("Select top 1 * From [TestReport] where Id=id and and IsDeleted = 0", new { id }).FirstOrDefault();
        }

        /// <summary>
        /// To Update the record in the table by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public int Update(int id, TestReportModel testReportModel)
        {
            string query = @"update [TestReport] Set 
                              Name = @Name,
                              Client = @Client,
                              FilePath = @FilePath,
                              DateTime = @DateTime,
                              Email = @Email,
                              JobId = @JobId
                            Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, testReportModel);
        }

        /// <summary>
        /// To delete the record by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"update [TestReport] Set 
                                IsDeleted = @IsDeleted
                            Where Id = @Id and  Id=@id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { IsDeleted = true, Id = id });
            return true;
        }
    }
}