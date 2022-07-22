using TestingAndCalibrationLabs.Business.Common;


namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface ISecurityParameterService
    {
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string password);
    }
}
