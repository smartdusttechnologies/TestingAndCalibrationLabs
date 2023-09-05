using Google.Apis.Drive.v3.Data;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
         RequestResult<bool> ValidatePasswordPolicy( int orgId, string password);
        /// <summary>
        /// Interfaces to  change  Password  policy  Method 
        /// </summary>
        RequestResult<bool> ChangePasswordPolicy(ChangePasswordModel changePasswordModel);
        RequestResult<bool> ValidateNewuserPolicy(UserModel user);
    }
}