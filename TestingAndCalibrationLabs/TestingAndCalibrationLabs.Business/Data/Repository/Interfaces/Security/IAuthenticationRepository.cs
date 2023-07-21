using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        int SaveLoginToken(LoginToken loginToken);
        UserModel GetLoginEmail(string emaiL);
        ForgotPasswordModel InsertOtp(string Otp, int userId);
        ForgotPasswordModel GetOTP(int userId);
        PasswordLogin GetUserIdPassword(int userId);
    }
}