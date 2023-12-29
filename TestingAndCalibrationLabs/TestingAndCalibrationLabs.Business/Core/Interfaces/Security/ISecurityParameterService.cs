using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        /// <summary>
        /// Interfaces to validate Newuser Policy
        /// </summary>
        RequestResult<bool> ValidateNewuserPolicy(UserModel user);
        /// <summary>
        /// Interface to validate PasswordPolicy.
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="Password"></param>
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string Password);
        /// <summary>
        /// Interface to Change Password After Forget Password.
        /// </summary>
        /// <param name="UserModel"></param>
        RequestResult<bool> ChangePasswordCondition(UserModel UserModel);
    }
}