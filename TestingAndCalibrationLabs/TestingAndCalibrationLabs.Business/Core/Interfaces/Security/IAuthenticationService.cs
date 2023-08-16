using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        /// <summary>
        /// Interfaces to Add new and validate existing user for Registration
        /// </summary>
        RequestResult<bool> Add(UserModel user, string password);
        /// <summary>
        /// Interfaces to  Update Password for existing User 
        /// </summary>
        RequestResult<bool> UpdatePassword(ChangePasswordModel changePasswordModel);
    }
}