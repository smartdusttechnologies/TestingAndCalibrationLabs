using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        RequestResult<bool> Add(UserModel user, string password);

        RequestResult<bool> EmailValidateForgotPassword(ForgotPasswordModel forgotPasswordModel);
        RequestResult<int> Create(ForgotPasswordModel forgotPasswordModel);
        RequestResult<bool> ValidateOTP(ForgotPasswordModel forgotPasswordModel);

    }
}
