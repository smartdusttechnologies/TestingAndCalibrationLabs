using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.MetirialTest;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.MetirialTest;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.MetirialTest
{
    public class TestingCategoryLookupRepository : ITestingCategoryLookupRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public TestingCategoryLookupRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<TestingCategoryLookupModel> GetTests()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestingCategoryLookupModel>("SELECT * from TestingCategoryLookup where IsDeleted = 0").ToList();
          
        }

        public TestingCategoryLookupModel GetTests(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TestingCategoryLookupModel>("SELECT * from TestingCategoryLookup", new { id }).FirstOrDefault();
   
        }
        #endregion
    }

}
