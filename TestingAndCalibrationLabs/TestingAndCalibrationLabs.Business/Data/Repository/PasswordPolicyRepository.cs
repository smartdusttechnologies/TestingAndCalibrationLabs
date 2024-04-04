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
    /// Repository To acess Data of Password Policy
    /// </summary>
    public class PasswordPolicyRepository : IPasswordPolicyRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PasswordPolicyRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        /// <summary>
        /// Get All Policy
        /// </summary>
        public List<PasswordPolicyModel> Get()
        {
            var query = @"select p.*,o.OrgName from PasswordPolicy p
                            inner join Organization o on o.Id = p.OrgId where p.IsDeleted = 0 and o.IsDeleted = 0";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordPolicyModel>(query).ToList();
        }
        /// <summary>
        /// Get Policy Based On id
        /// </summary>
        public PasswordPolicyModel Get(int id)
        {
            var query = @"select p.*,o.OrgName from PasswordPolicy p
                            inner join Organization o on o.Id = p.OrgId where p.IsDeleted = 0 and o.IsDeleted = 0 and p.Id = @id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordPolicyModel>(query, new { id }).FirstOrDefault();
        }
    }
}
