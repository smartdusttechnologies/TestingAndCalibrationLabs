using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class SecurityParameterService : ISecurityParameterService
    {

        private readonly ISecurityParameterRepository _securityParameterRepository;
        private readonly ILogger _logger;

        public SecurityParameterService()
        {

        }
        public SecurityParameterService(ISecurityParameterRepository securityParameterRepository, ILogger logger)
        {
            _securityParameterRepository = securityParameterRepository;
            _logger = logger;

        }

        /// <summary>
        /// Method to validate Password Policy
        /// </summary>
        public RequestResult<bool> ValidatePasswordPolicy( int orgId, string password)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var passwordPolicy = _securityParameterRepository.Get(orgId);
                var validatePasswordResult = ValidatePassword(password, passwordPolicy);
                return validatePasswordResult;
            }
            catch (Exception)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        /// <summary>
        /// Method to validate the password like Length, Uppercaps, LowerCaps, Min and Max Digits
        /// </summary>
        private RequestResult<bool> ValidatePassword(string password, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (password.Length < securityParameter.MinLength)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum length of the password should be " + securityParameter.MinLength + "characters long", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            if (!Helpers.ValidateMinimumSmallChars(password, securityParameter.MinSmallChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of small characters the password should have is " + securityParameter.MinSmallChars, Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumCapsChars(password, securityParameter.MinCaps))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of capital characters the password should have is " + securityParameter.MinCaps, Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumDigits(password, securityParameter.MinNumber))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of numeric characters the password should have is " + securityParameter.MinNumber, Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumSpecialChars(password, securityParameter.MinSpecialChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of special characters the password should have is " + securityParameter.MinSpecialChars, Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateDisallowedChars(password, securityParameter.DisAllowedChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Characters which are not allowed in password are " + securityParameter.DisAllowedChars, Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(true);
        }
        /// <summary>
        /// method to Reset Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public RequestResult<bool> ChangePasswordPolicy(ForgotPasswordModel ForgotPasswordModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            if (ForgotPasswordModel.NewPassword.IsNullOrEmpty())
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please Enter New Password.", Severity = ValidationSeverity.Error, SourceId = "NewPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            else if (ForgotPasswordModel.ConfirmPassword.IsNullOrEmpty())
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please Enter Confirm Password.", Severity = ValidationSeverity.Error, SourceId = "ConfirmPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            else if (ForgotPasswordModel.NewPassword != ForgotPasswordModel.ConfirmPassword)
            {
                validationMessages.Add(new ValidationMessage { Reason = "New password and confirm password fields must match.", Severity = ValidationSeverity.Error, SourceId = "ConfirmPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(true);
        }
    }
}