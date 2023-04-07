using TestingAndCalibrationLabs.Business.Common;


namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        /// <summary>
        /// Interfaces to validate Password Policy
        /// </summary>
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string password);
        /// <summary>
        /// Interfaces to validate Email Policy
        /// </summary>

        RequestResult<bool> ValidateEmailPolicy(int orgId, string Email);
        /// <summary>
        /// Interfaces to validate Mobile Policy
        /// </summary>
        RequestResult<bool> ValidateMobilePolicy(int orgId, string Mobile);
        /// <summary>
        /// Interfaces to validate ReEnter Password Policy
        /// </summary>
        RequestResult<bool> ValidateReEnterPasswordPolicy(int orgId, string ReEnterPassword,string password);
        /// <summary>
        /// Interfaces to validate UserName
        /// </summary>
        RequestResult<bool> ValidateUserName(int orgId, string UserName);
        /// <summary>
        /// Interfaces to validate FirstName
        /// </summary>

        RequestResult<bool> ValidateFirstName(int orgId, string FirstName);
        /// <summary>
        /// Interfaces to validate LastName
        /// </summary>
        RequestResult<bool> ValidateLastName(int orgId, string LastName);
        /// <summary>
        /// Interfaces to validate Country
        /// </summary>

        RequestResult<bool> ValidateCountry(int orgId, string Country);
        /// <summary>
        /// Interfaces to validate Organizations
        /// </summary>

        RequestResult<bool> ValidateOrganizations(int orgId, string Organizations);
    }
}
