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
        RequestResult<int> EmailValidateForgotPassword(UserModel UserModel);
        RequestResult<int> CreateOtp(UserModel UserModel, int userId);
        RequestResult<int> ValidateOTP(UserModel UserModel);
        RequestResult<bool> UpdatePassword(UserModel UserModel);
    }
}