using TestingAndCalibrationLabs.Business.Common;


namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string password);
        RequestResult<bool> ValidateEmailPolicy(int orgId, string Email);
        RequestResult<bool> ValidateMobilePolicy(int orgId, string Mobile);
        RequestResult<bool> ValidateReEnterPasswordPolicy(int orgId, string ReEnterPassword);
        RequestResult<bool> ValidateUserName(int orgId, string UserName);

        RequestResult<bool> ValidateFirstName(int orgId, string FirstName);
        RequestResult<bool> ValidateLastName(int orgId, string LastName);

        RequestResult<bool> ValidateCountry(int orgId, string Country);

        RequestResult<bool> ValidateOrganizations(int orgId, string Organizations);
    }
}
