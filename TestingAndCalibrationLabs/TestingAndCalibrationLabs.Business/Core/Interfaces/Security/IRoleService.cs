using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);

        /// <summary>
        /// Abstract method to get Role by Organization including claims
        /// </summary>
        
        //TODO: move this to user Repository.
        UserModel GetUserByUserName(string userName);
        //List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType);
        List<GroupClaim> GetGroupClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
        List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
        List<UserClaim> GetUserClaims(int organizationId, int userId, string moduleId, string stageId, CustomClaimType claimType);
    }
}
