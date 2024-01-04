using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Role
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        /// <summary>
        /// Get Role Based On User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<(int, string)> GetRole(int id)
        {
            return _roleRepository.GetRole(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<(int, string)> GetRoleWithOrg(string userName)
        {
            return _roleRepository.GetRoleWithOrg(userName);
        }
        //TODO: All the methods here should be saperated based on single responsibility principle
        /// <summary>
        /// method to get User Claims Based on their Group
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="permissionModuleType"></param>
        /// <param name="subPermissionModuleType"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public List<GroupClaim> GetGroupClaims(int organizationId, int userId, string permissionModuleType, string subPermissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetGroupClaims(organizationId, userId, permissionModuleType, subPermissionModuleType, claimType);
        }
        /// <summary>
        /// Method to Get User By Username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserModel GetUserByUserName(string userName)
        {
            return _roleRepository.GetUserByUserName(userName);
        }
        /// <summary>
        /// method to get User Claim Based on User Role
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="permissionModuleType"></param>
        /// <param name="subPermissionModuleType"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, string permissionModuleType, string subPermissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetUserRoleClaims(organizationId,userId, permissionModuleType, subPermissionModuleType, claimType);
        }
        /// <summary>
        /// method to get User Claims Based on Their Profile
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="permissionModuleType"></param>
        /// <param name="subPermissionModuleType"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public List<UserClaim> GetUserClaims(int organizationId, int userId, string permissionModuleType, string subPermissionModuleType, CustomClaimType claimType)
        {
            return _roleRepository.GetUserClaims( organizationId,  userId, permissionModuleType, subPermissionModuleType,  claimType);
        }
        //public List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType)
        //{
        //    return _roleRepository.GetRequiredClaimsForModule(permissionModuleType);
        //}
    }
}
