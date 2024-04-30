using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface Implementation For Authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Abstract Method For Login
        /// </summary>
        /// <param name="loginRequest"></param>
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        /// <summary>
        /// Interfaces to Add new and validate existing user for Registration
        /// </summary>
        //TODo: This should be moved to User service.
        RequestResult<bool> Add(UserModel user, string password);
        /// <summary>
        /// Interface to update user password 
        /// </summary>
        /// <param name="UserModel"></param>
        RequestResult<bool> UpdatePassword(UserModel UserModel);
        /// <summary>
        /// Interface for Email validation for FogetPassword.
        /// </summary>
        /// <param name="user"></param>
        RequestResult<(int UserId, string UserName)> EmailValidateForgotPassword(OtpModel OtpModel);
        /// <summary>
        /// Interface for verify Email with Existing Email using at the time of signup.
        /// </summary>
        /// <param name="user"></param>
        RequestResult<int> ExistingEmailVerify(UserModel user);
    }
}