using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.common;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Role
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IGenericRepository<RoleModel> _genericRepository;

        public RoleService(IRoleRepository roleRepository, IGenericRepository<RoleModel> genericRepository )
        {
            _roleRepository = roleRepository;
            _genericRepository = genericRepository;
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
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get All Records From Role Service
        /// </summary>
        public List<RoleModel> Get()
        {
            var pageNavigation = _genericRepository.Get();
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Role Service
        /// </summary>
        /// <param name="roleModel"></param>
        public RequestResult<int> Create(RoleModel roleModel)
        {
            _genericRepository.Insert(roleModel);

            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Role Service
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Role Service
        /// </summary>
        /// <param name="id"></param>
        public RoleModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Edit Record By Role Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleModel"></param>
        public RequestResult<int> Update(int id, RoleModel roleModel)
        {
            _genericRepository.Update(roleModel);
            return new RequestResult<int>(1);
        }
    }
}
