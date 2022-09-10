using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Securities;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RoleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get Role with Orgnization based on UserName
        /// </summary>
        public List<(int, string)> GetRoleWithOrg(string userName)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select u.OrgId, r.Name from [User] u 
                                inner join [UserRole] ur on u.id = ur.userId
                                inner join [Role] r on r.Id = ur.RoleId
                             where u.UserName=@userName and u.IsDeleted=0 and r.IsDeleted=0 and ur.IsDeleted=0";

            return db.Query<(int, string)>(query, new { userName }).ToList();
        }

        /// <summary>
        /// Get Role by Orgnization including Claims
        /// </summary>
        public List<UserRoleWithClaim> GetRoleByOrganizationWithClaims(string userName)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select u.OrgId, r.Name as RoleName, ur.RoleId, ur.UserId, p.Name as ClaimName 
                            from [User] u 
                                inner join [UserRole] ur on u.id = ur.userId
                                inner join [Role] r on r.Id = ur.RoleId
                                inner join [UserRoleClaim] urc on urc.RoleId = ur.RoleId
                                inner join [Permission] p on p.Id = urc.PermissionId
                            where u.UserName=@userName and u.IsDeleted=0 and r.IsDeleted=0 and ur.IsDeleted=0";

            return db.Query<UserRoleWithClaim>(query, new { userName }).ToList();
        }
    }
}
