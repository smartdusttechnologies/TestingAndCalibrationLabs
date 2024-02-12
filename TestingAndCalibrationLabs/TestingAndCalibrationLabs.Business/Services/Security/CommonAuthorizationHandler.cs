using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Services.Security
{
    /// <summary>
    /// Authorization Handler For Common
    /// </summary>
    public class CommonAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, RecordModel>
    {
        private readonly IRoleService _roleService;
        private readonly IWorkflowStageService _workflowStageService;
        public CommonAuthorizationHandler(IRoleService roleService, IWorkflowStageService workflow)
        {
            _roleService = roleService;
            _workflowStageService = workflow;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            RecordModel resource)
        {
            var user = context.User as SdtPrincipal;
            if (user == null) return Task.CompletedTask;
            var workflow = _workflowStageService.GetStage(resource.ModuleId, resource.Id);
            var sdtUserIdentity = user.Identity as SdtUserIdentity;

            var userRoleClaims = _roleService.GetUserRoleClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, workflow.ModuleName, workflow.Name, CustomClaimType.ApplicationPermission);
            var userClaims = _roleService.GetUserClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, workflow.ModuleName, workflow.Name, CustomClaimType.ApplicationPermission);
            var groupClaim = _roleService.GetGroupClaims(sdtUserIdentity.OrganizationId, sdtUserIdentity.UserId, workflow.ModuleName, workflow.Name, CustomClaimType.ApplicationPermission);

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
