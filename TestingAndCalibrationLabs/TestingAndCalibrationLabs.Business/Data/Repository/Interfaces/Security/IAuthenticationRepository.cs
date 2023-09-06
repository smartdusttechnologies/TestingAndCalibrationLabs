using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        PasswordLogin GetLoginPassword(string userName);
        PasswordLogin GetUserIdPassword(int userId);
        int SaveLoginToken(LoginToken loginToken);
        /// <summary>
        /// Interface to select Email for FogetPassword.
        /// </summary>
        /// <param name="email"></param>
        UserModel GetLoginEmail(string email);
        /// <summary>
        /// Interface to insert and update otp in DB.
        /// </summary>
        /// <param name="otp"></param>
        /// <param name="userId"></param>
        OtpModel InsertOtp(string otp, int userId);
        /// <summary>
        /// Inetface to Select Otp.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        OtpModel GetOTP(int userId);
        /// Interface for slect Email from DB
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        OtpModel GetEmail(int userId);
    }
}