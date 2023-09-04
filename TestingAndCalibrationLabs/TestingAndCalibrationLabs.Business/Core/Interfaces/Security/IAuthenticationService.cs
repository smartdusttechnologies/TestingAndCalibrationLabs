using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        /// <summary>
        /// Interfaces to Add new and validate existing user for Registration
        /// </summary>
        RequestResult<bool> Add(UserModel user, string password);
        /// <summary>
        /// Interface to update the user password when user forget password and reset password
        /// </summary>
        /// <param name="UserModel"></param>
        /// <returns></returns>
        RequestResult<bool> UpdatePassword(UserModel UserModel);
        /// <summary>
        /// Interface for Update EmailValidationStatus if user sign-up Successfully with OTP validation.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        RequestResult<int> EmailValidationStatus(UserModel user);
    }
}