using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        int SaveLoginToken(LoginToken loginToken);
        UserModel GetLoginEmail(string email);
        UserModel InsertOtp(string otp, int userId);
        UserModel GetOTP(int userId);
        PasswordLogin GetUserIdPassword(int userId);
    }
}