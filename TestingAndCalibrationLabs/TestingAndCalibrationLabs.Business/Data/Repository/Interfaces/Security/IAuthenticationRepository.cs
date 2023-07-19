using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        int SaveLoginToken(LoginToken loginToken);
        UserModel GetLoginEmail(string Email);
        ForgotPasswordModel InsertOtp(string OTP, int UserId);
        ForgotPasswordModel GetOTP(int UserId);
       PasswordLogin GetUserIdPassword(int userId);
    }
}
