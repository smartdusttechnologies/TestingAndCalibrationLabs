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

        

        public List<(int, string)> GetRoleWithOrg(string userName)
        {
            return _roleRepository.GetRoleWithOrg(userName);
        }
        //TODO: All the methods here should be saperated based on single responsibility principle
        
        public List<GroupClaim> GetGroupClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType)
        {
            return _roleRepository.GetGroupClaims(organizationId, userId,moduleId, stageId, claimType);
        }

        public UserModel GetUserByUserName(string userName)
        {
            return _roleRepository.GetUserByUserName(userName);
        }

        public List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType)
        {
            return _roleRepository.GetUserRoleClaims(organizationId,userId, moduleId,stageId, claimType);
        }

        public List<UserClaim> GetUserClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType)
        {
            return _roleRepository.GetUserClaims( organizationId,  userId,  moduleId, stageId,  claimType);
        }

        //public List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType)
        //{
        //    return _roleRepository.GetRequiredClaimsForModule(permissionModuleType);
        //}
    }
}
