using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class UserRoleClaimRepository : IUserRoleClaimRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRoleClaimRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In UserRoleClaim
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        public int Create(UserRoleClaimModel userRoleClaimModel)
        {
            string query = @"Insert into [userRoleClaim] (RoleId,PermissionId,ClaimTypeId)
                                values (@RoleId,@PermissionId,@ClaimTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, userRoleClaimModel);
        }
        /// <summary>
        /// Getting all records from UserRoleClaim
        /// </summary>
        public List<UserRoleClaimModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserRoleClaimModel>(@"SELECT urc.Id, urc.RoleId, r.[Name] as RoleName, urc.PermissionId, p.[Name] as PermissionName, 
                                                    urc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[UserRoleClaim] urc
                                                    inner join[Role] r on urc.RoleId = r.Id
													inner join[Permission] p on urc.PermissionId = p.Id
													inner join[ClaimType] ct on urc.ClaimTypeId = ct.Id
                                                    where
                                                        urc.IsDeleted = 0
                                                    and r.IsDeleted = 0
                                                    and p.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For UserRoleClaim
        /// </summary>
        /// <param name="id"></param>
        public UserRoleClaimModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserRoleClaimModel>(@"SELECT urc.Id, urc.RoleId, r.[Name] as RoleName, urc.PermissionId, p.[Name] as PermissionName, 
                                                    urc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[UserRoleClaim] urc
                                                    inner join[Role] r on urc.RoleId = r.Id
													inner join[Permission] p on urc.PermissionId = p.Id
													inner join[ClaimType] ct on urc.ClaimTypeId = ct.Id
                                                    where
                                                        urc.Id=@Id
                                                    and urc.IsDeleted = 0
                                                    and r.IsDeleted = 0
                                                    and p.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From UserRoleClaim
        /// </summary>
        /// <param name=userRoleClaimModel"></param>
        public int Update(UserRoleClaimModel userRoleClaimModel)
        {
            string query = @"update [UserRoleClaim] Set 
                                    RoleId=@RoleId,
                                  PermissionId = @PermissionId,
                                  ClaimTypeId = @ClaimTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, userRoleClaimModel);
        }
    }
}
