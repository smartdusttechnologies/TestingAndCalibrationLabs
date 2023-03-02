using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
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

        public UserModel GetUserByUserName(string userName)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select * from [User] u 
                             where u.UserName=@userName and u.IsDeleted=0";

            return db.Query<UserModel>(query, new { userName }).FirstOrDefault();
        }


        ///// <summary>
        ///// Get Role by Orgnization including Claims
        ///// </summary>
        //public List<UserRoleClaim> GetRoleByOrganizationWithClaims(string userName)
        //{
        //    using IDbConnection db = _connectionFactory.GetConnection;
        //    string query = @"Select u.OrgId, r.Name as RoleName, ur.RoleId, ur.UserId, p.Name as PermissionName, pt.Name as ClaimName 
        //                    from [User] u 
        //                        inner join [UserRole] ur on u.id = ur.userId
        //                        inner join [Role] r on r.Id = ur.RoleId
        //                        inner join [UserRoleClaim] urc on urc.RoleId = ur.RoleId
        //                        inner join [Permission] p on p.Id = urc.PermissionId
        //                        inner join [PermissionType] pt on pt.Id = p.PermissionTypeId
        //                    where u.UserName=@userName 
        //                        and u.IsDeleted=0  
        //                        and r.IsDeleted=0 
        //                        and p.IsDeleted=0 
        //                        and urc.IsDeleted=0
        //                        and pt.IsDeleted=0
        //                        and ur.IsDeleted=0";

        //    return db.Query<UserRoleClaim>(query, new { userName }).ToList();
        //}

        ///// <summary>
        ///// Get Role by Orgnization including Claims
        ///// </summary>
        //public List<UserClaim> GetUserByOrganizationWithClaims(string userName)
        //{
        //    using IDbConnection db = _connectionFactory.GetConnection;
        //    string query = @"Select u.OrgId, uc.userId, p.Name as PermissionName, pt.Name as ClaimName 
        //                    from [User] u 
        //                        inner join [UserClaim] uc on uc.userId = u.Id
        //                        inner join [Permission] p on p.Id = uc.PermissionId
        //                        inner join [PermissionType] pt on pt.Id = p.PermissionTypeId
        //                    where u.UserName=@userName 
        //                        and u.IsDeleted=0  
        //                        and p.IsDeleted=0 
        //                        and uc.IsDeleted=0
        //                        and pt.IsDeleted=0";

        //    return db.Query<UserClaim>(query, new { userName }).ToList();
        //}

        public List<GroupClaim> GetGroupClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select gc.ClaimTypeId as claimType, pt.Name as ClaimValue
                            from [GroupUser] g
                                inner join [GroupClaim] gc on gc.GroupId = g.GroupId
                                inner join [Permission] p on p.Id = gc.PermissionId
                                inner join [PermissionType] pt on pt.Id = p.PermissionTypeId
                            where g.UserId=@userId
                                and gc.ClaimTypeId=@claimType
                                and p.PermissionModuleTypeId=@permissionModuleType
                                and gc.IsDeleted=0  
                                and p.IsDeleted=0 
                                and g.IsDeleted=0
                                and pt.IsDeleted=0";

            return db.Query<GroupClaim>(query, new { userId, organizationId, claimType, permissionModuleType }).ToList();
        }
        /// <summary>
        /// Get Role by Orgnization including Claims
        /// </summary>
        public List<UserClaim> GetUserClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select uc.ClaimTypeId as claimType, pt.Name as ClaimValue
                            from [User] u 
                                inner join [UserClaim] uc on uc.userId = u.Id
                                inner join [Permission] p on p.Id = uc.PermissionId
                                inner join [PermissionType] pt on pt.Id = p.PermissionTypeId
                            where u.Id=@userId 
                                and u.OrgId=@organizationId
                                and uc.ClaimTypeId=@claimType
                                and p.PermissionModuleTypeId=@permissionModuleType
                                and u.IsDeleted=0  
                                and p.IsDeleted=0 
                                and uc.IsDeleted=0
                                and pt.IsDeleted=0";

            return db.Query<UserClaim>(query, new { userId, organizationId, claimType, permissionModuleType }).ToList();
        }


        public List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"Select urc.ClaimTypeId as claimType, pt.Name as ClaimValue 
                            from [User] u 
                                inner join [UserRole] ur on u.id = ur.userId
                                inner join [UserRoleClaim] urc on urc.RoleId = ur.RoleId
                                inner join [Permission] p on p.Id = urc.PermissionId
                                inner join [PermissionType] pt on pt.Id = p.PermissionTypeId
                            where u.Id=@userId 
                                and u.OrgId=@organizationId
                                and urc.ClaimTypeId=@claimType
                                and p.PermissionModuleTypeId=@permissionModuleType
                                and u.IsDeleted=0  
                                and ur.IsDeleted=0 
                                and p.IsDeleted=0 
                                and urc.IsDeleted=0
                                and pt.IsDeleted=0";

            return db.Query<UserRoleClaim>(query, new { userId, organizationId, claimType, permissionModuleType }).ToList();
        }

        //List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
