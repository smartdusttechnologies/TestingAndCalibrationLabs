using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = PermissionType.Create.ToString() };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = PermissionType.Read.ToString() };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = PermissionType.Update.ToString() };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = PermissionType.Delete.ToString() };
    }
}
