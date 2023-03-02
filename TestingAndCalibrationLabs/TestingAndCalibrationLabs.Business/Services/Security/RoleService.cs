using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetUserRoleClaims(organizationId, userId, permissionModuleType, claimType);
        }

        public List<(int, string)> GetRoleWithOrg(string userName)
        {
            return _roleRepository.GetRoleWithOrg(userName);
        }
        //TODO: All the methods here should be saperated based on single responsibility principle
        public List<UserClaim> GetUserClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetUserClaims(organizationId, userId, permissionModuleType, claimType);
        }
        
        public List<GroupClaim> GetGroupClaim(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetGroupClaims(organizationId, userId, permissionModuleType, claimType);
        }

        public UserModel GetUserByUserName(string userName)
        {
            return _roleRepository.GetUserByUserName(userName);
        }

        //public List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType)
        //{
        //    return _roleRepository.GetRequiredClaimsForModule(permissionModuleType);
        //}
    }
}
