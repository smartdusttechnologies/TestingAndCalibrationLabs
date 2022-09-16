using TestingAndCalibrationLabs.Business.Common;


namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string password);
    }
}
