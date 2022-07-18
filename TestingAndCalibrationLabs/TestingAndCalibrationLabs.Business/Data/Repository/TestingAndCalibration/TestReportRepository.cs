using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration
{
    public class TestReportRepository : ITestReportRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public TestReportRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public int Insert(TestReportModel testReportModel)
        {
            string query = @"Insert into[TestReport](Client, FilePath, JobId, Name, DateTime, Email)
                            values (@Client, @FilePath, @JobId, @Name, @DateTime, @Email)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, testReportModel);
        }

        public int InsertCollection(List<TestReportModel> testReportModel)
        {
            string query = @"Insert into [TestReport](Client, FilePath, JobId, Name, DateTime, Email)
                            values (@Client, @FilePath, @JobId, @Name, @DateTime, @Email)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, testReportModel);
        }

        public TestReportModel GetTestReport(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestReportModel>("Select top 1 * From [TestReport] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        public int Get(TestReportModel testReportModel)
        {
            string query = @"Select * From [TestReport] ORDER BY Id DESC";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query);
        }

        public List<TestReportModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var result = db.Query<TestReportModel>("Select * From [TestReport] where IsDeleted=0 ORDER BY Id DESC");
            return result.ToList();
        }

        public TestReportModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestReportModel>("Select top 1 * From [TestReport] where Id=id and and IsDeleted = 0", new { id }).FirstOrDefault();
        }

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

        //public int Update(TestReportModel testReportModel)
        //{
        //    string query = @"update [TestReportModel] Set 
        //                      JobId = @JobId,
        //                      Email = @Email,
        //                      Client = @Client,
        //                      Name = @Name                                
        //                      Where Id = @Id";
        //    using IDbConnection db = IConnectionFactory.GetConnection;
        //    return db.Execute(query, testReportModel);
        //}

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