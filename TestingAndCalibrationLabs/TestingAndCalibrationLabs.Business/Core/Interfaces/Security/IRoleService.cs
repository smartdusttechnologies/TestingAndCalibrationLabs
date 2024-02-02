using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Role
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);

        /// <summary>
        /// Abstract method to get User By Username
        /// </summary>
        
        //TODO: move this to user Repository.
        UserModel GetUserByUserName(string userName);
        //List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType);
        /// <summary>
        /// Abstract method to get User Claims Based on their Group
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <param name="stageId"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        List<GroupClaim> GetGroupClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
        /// <summary>
        /// Abstract method to get User Claim Based on User Role
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <param name="stageId"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
        /// <summary>
        /// Abstract method to get User Claims Based on Their Profile
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <param name="stageId"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        List<UserClaim> GetUserClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
        /// <summary>
        /// Get All Record From Role Service
        /// </summary>
        List<RoleModel> Get();
        /// <summary>
        /// Insert Record In Role Service
        /// </summary>
        /// <param name="roleModel"></param>
        RequestResult<int> Create(RoleModel roleModel);

        /// <summary>
        /// Delete Record In Role Service
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From Role Service
        /// </summary>
        /// <param name="id"></param>
        RoleModel GetById(int id);

        /// <summary>
        /// Edit Record From Role Service
        /// </summary>
        /// <param name="roleModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, RoleModel roleModel);
    }

}
