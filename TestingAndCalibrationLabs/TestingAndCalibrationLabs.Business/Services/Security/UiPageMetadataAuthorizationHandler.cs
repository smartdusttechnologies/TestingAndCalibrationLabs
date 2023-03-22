using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Services.Security
{
    public class UiPageMetadataAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, UiPageMetadataModel>
    {
        private readonly IRoleService _roleService;
        public UiPageMetadataAuthorizationHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                    OperationAuthorizationRequirement requirement,
                                                    UiPageMetadataModel resource)
        {
            var user = context.User as SdtPrincipal;

            if (user == null) return Task.CompletedTask;

            var sdtUserIdentity = user.Identity as SdtUserIdentity;
            var userRoleClaims = _roleService.GetUserRoleClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            var userClaims = _roleService.GetUserClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            var groupClaim = _roleService.GetGroupClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            // Validate the requirement against the resource and identity.

            //if (user.HasClaim(p => p.Type == CustomClaimType.ApplicationPermission.ToString() && p.Value == requirement.Name))

            if (userRoleClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if (userClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if (groupClaim.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
