using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);

        /// <summary>
        /// Abstract method to get Role by Organization including claims
        /// </summary>
        //List<UserRoleClaim> GetRoleByOrganizationWithClaims(string userName);
        //List<UserClaim> GetUserByOrganizationWithClaims(string userName);
        //TODO: move this to user Repository.
        UserModel GetUserByUserName(string userName);
        List<UserClaim> GetUserClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType);
        List<UserRoleClaim> GetUserRoleClaims(int organizationId, int userId, PermissionModuleType permissionModuleType, CustomClaimType claimType);
       // List<string> GetRequiredClaimsForModule(PermissionModuleType permissionModuleType);
    }
}
