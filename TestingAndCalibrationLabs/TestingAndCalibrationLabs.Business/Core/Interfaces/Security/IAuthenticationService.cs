using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        RequestResult<bool> Add(UserModel user, string password);
        RequestResult<int> EmailValidateForgotPassword(ForgotPasswordModel forgotPasswordModel);
        RequestResult<int> CreateOtp(ForgotPasswordModel forgotPasswordModel, int userId);
        RequestResult<int> ValidateOTP(ForgotPasswordModel forgotPasswordModel);
        RequestResult<bool> UpdatePassword(ForgotPasswordModel forgotPasswordModel);
    }
}