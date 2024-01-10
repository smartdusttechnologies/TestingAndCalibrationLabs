using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Authorization Handler For UiPageTypeModel
    /// </summary>
    public class UiPageTypeAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, UiPageTypeModel>
    {
        private readonly IRoleService _roleService;
        public UiPageTypeAuthorizationHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       UiPageTypeModel resource)
        {
            var user = context.User as SdtPrincipal;
            if (user == null) return Task.CompletedTask;

            var sdtUserIdentity = user.SdtUserIdentity;
            var userRoleClaims = _roleService.GetUserRoleClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, PermissionModuleType.UiPageTypePermission.ToString(), PermissionModuleType.UiPageTypePermission.ToString(), CustomClaimType.ApplicationPermission);
            var userClaims = _roleService.GetUserClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, PermissionModuleType.UiPageTypePermission.ToString(), PermissionModuleType.UiPageTypePermission.ToString(), CustomClaimType.ApplicationPermission);
            var groupClaims = _roleService.GetGroupClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, PermissionModuleType.UiPageTypePermission.ToString(), PermissionModuleType.UiPageTypePermission.ToString(), CustomClaimType.ApplicationPermission);
            var userRoles = _roleService.GetRole(sdtUserIdentity.UserId);
            // Validate the requirement against the resource and identity.
            //if (user.HasClaim(p => p.Type == CustomClaimType.ApplicationPermission.ToString() && p.Value == requirement.Name))
            if(userRoleClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if(userClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if(groupClaims.Any(p=>p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            bool role = userRoles.Any(x => x.Item2 == "Sysadmin");
            if (role)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }


}
