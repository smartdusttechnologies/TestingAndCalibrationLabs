﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Services.Security
{
    /// <summary>
    /// Authorization Handler For UiPageMetadataModel
    /// </summary>
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
           var sdtUserIdentity = user.SdtUserIdentity;
            var userRoleClaims = _roleService.GetUserRoleClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            var userClaims = _roleService.GetUserClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            var groupClaim = _roleService.GetGroupClaims(sdtUserIdentity.OrganizationId,sdtUserIdentity.UserId, PermissionModuleType.UiPageMetadataPermission.ToString(), PermissionModuleType.UiPageMetadataPermission.ToString(), CustomClaimType.ApplicationPermission);
            var userRoles = _roleService.GetRole(sdtUserIdentity.UserId);
            // Validate the requirement against the resource and identity.
            //if (user.HasClaim(p => p.Type == CustomClaimType.ApplicationPermission.ToString() && p.Value == requirement.Name))
            if (userRoleClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if (userClaims.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            else if (groupClaim.Any(p => p.ClaimType == CustomClaimType.ApplicationPermission && p.ClaimValue == requirement.Name))
                context.Succeed(requirement);
            bool role = userRoles.Any(x => x.Item2 == "Sysadmin");
            if (role)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
