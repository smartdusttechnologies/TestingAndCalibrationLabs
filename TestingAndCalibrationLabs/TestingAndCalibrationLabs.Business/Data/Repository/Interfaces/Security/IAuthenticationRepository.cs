using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Interface To select User Login Password .
        /// </summary>
        /// <param name="userName"></param>
        PasswordLogin GetLoginPassword(string userName);
        /// <summary>
        /// Interface to select Password on the basis of userID
        /// </summary>
        /// <param name="userId"></param>
        PasswordLogin GetUserIdPassword(int userId);
        /// <summary>
        /// Interface for save login Token
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        int SaveLoginToken(LoginToken loginToken);
    }
}