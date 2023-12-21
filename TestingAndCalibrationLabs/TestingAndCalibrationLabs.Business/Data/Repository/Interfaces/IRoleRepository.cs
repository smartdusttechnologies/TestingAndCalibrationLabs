using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Abstract Method to get Role By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<(int, string)> GetRole(int id);
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);


        //List<UserRoleClaim> GetRoleByOrganizationWithClaims(string userName);
        //List<UserClaim> GetUserByOrganizationWithClaims(string userName);
        //TODO: move this to user Repository.
        /// <summary>
        /// Abstract method to get User By Username
        /// </summary>
        UserModel GetUserByUserName(string userName);
        // List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType);
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
    }
}
