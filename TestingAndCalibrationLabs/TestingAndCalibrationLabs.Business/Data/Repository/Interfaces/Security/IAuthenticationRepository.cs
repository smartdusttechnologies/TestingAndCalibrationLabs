using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        int SaveLoginToken(LoginToken loginToken);
        UserModel GetLoginEmail(string email);
        OtpModel InsertOtp(string otp, int userId);
        OtpModel GetOTP(int userId);
        PasswordLogin GetUserIdPassword(int userId);
        OtpModel GetEmail(int userId);
    }
}