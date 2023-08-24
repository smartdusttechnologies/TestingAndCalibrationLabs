using Microsoft.AspNetCore.Authorization.Infrastructure;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of Operations
    /// </summary>
    public static class Operations
    {
        /// <summary>
        /// It Contains Authorization Reuirement Of Create Method
        /// </summary>
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = PermissionType.Create.ToString() };
        /// <summary>
        /// It Contains Authorization Reuirement Of Read Method
        /// </summary>
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = PermissionType.Read.ToString() };
        /// <summary>
        /// It Contains Authorization Reuirement Of Update Method
        /// </summary>
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = PermissionType.Update.ToString() };
        /// <summary>
        /// It Contains Authorization Reuirement Of Delete Method
        /// </summary>
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = PermissionType.Delete.ToString() };
    }
}
