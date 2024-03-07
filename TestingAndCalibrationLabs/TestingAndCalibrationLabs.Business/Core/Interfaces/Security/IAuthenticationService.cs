using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface Implementation For Authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Abstract Method For Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        /// <summary>
        /// Interfaces to Add new and validate existing user for Registration
        /// </summary>
        //TODo: This should be moved to User service.
        RequestResult<bool> Add(UserModel user, string password);
        RequestResult<LoginToken> ExternalAdd(UserModel userModel);
    }
}
