using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        int SaveLoginToken(LoginToken loginToken);

        ForgotPasswordModel GetLoginEmail(string Email);
        ForgotPasswordModel InsertOtp(string OTP, int userid);

        //ForgotPasswordModel SendMail(string Email);

        ForgotPasswordModel GetOTP(string OTP);



    }
}
