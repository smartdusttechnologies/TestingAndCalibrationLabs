using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        RequestResult<bool> Add(UserModel user, string password);
        RequestResult<int> EmailValidateForgotPassword(ForgotPasswordModel ForgotPasswordModel);
        RequestResult<int> CreateOtp(ForgotPasswordModel ForgotPasswordModel, int userId);
        RequestResult<int> ValidateOTP(ForgotPasswordModel ForgotPasswordModel);
        RequestResult<bool> UpdatePassword(ForgotPasswordModel ForgotPasswordModel);
    }
}