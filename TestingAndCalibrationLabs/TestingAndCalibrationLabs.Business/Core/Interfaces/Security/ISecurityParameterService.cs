using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string Password);
        RequestResult<bool> ChangePasswordCondition(ForgotPasswordModel forgotPasswordModel);
    }
}