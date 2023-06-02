using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    
    public class LookupRepository : ILookupRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public LookupRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<LookupModel> GetByLookupCategoryId(int lookupCategoryId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<LookupModel>(@"select * from Lookup where LookupCategoryId = @LookupCategoryId and IsDeleted = 0", new { LookupCategoryId =lookupCategoryId}).ToList();
        }
        public List<LookupModel> GetBY(int lookupCategoryId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<LookupModel>(@"Select L.* From[Lookup] L INNER JOIN[LookupCategory] lc ON L.LookupCategoryId = lc.Id and lc.IsDeleted = 0 where LookupCategoryId = @LookupCategoryId and L.IsDeleted = 0", new { LookupCategoryId = lookupCategoryId }).ToList(); 

        }
    }
}
