using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        public SecurityParameterService(ISecurityParameterRepository securityParameterRepository, ILogger logger)
        {
            _securityParameterRepository = securityParameterRepository;
            _logger = logger;
        }
        /// <summary>
        /// Method to validate Newuser Policy
        /// </summary>
        public RequestResult<bool> ValidatePasswordPolicy(int orgId, string password)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var passwordPolicy = _securityParameterRepository.Get(orgId);
                var validatePasswordResult = ValidatePassword(password, passwordPolicy);
                return validatePasswordResult;
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateNewuserPolicy(UserModel user)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var newuservalidation = Validatenewuser(user);
                return (newuservalidation);
            }
            catch (Exception)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;
            }
        }
        //}
        /// <summary>
        /// Method to validate the password like Length, Uppercaps, LowerCaps, Min and Max Digits
        /// </summary>
        private RequestResult<bool> ValidatePassword(string password, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (password == null || password.Length < securityParameter.MinLength)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum length of the password should be " + securityParameter.MinLength + "characters long", Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            if (!Helpers.ValidateMinimumSmallChars(password, securityParameter.MinSmallChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of small characters the password should have is " + securityParameter.MinSmallChars, Severity = ValidationSeverity.Error , SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumCapsChars(password, securityParameter.MinCaps))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of capital characters the password should have is " + securityParameter.MinCaps, Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumDigits(password, securityParameter.MinNumber))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of numeric characters the password should have is " + securityParameter.MinNumber, Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateMinimumSpecialChars(password, securityParameter.MinSpecialChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of special characters the password should have is " + securityParameter.MinSpecialChars, Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }

            if (!Helpers.ValidateDisallowedChars(password, securityParameter.DisAllowedChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Characters which are not allowed in password are " + securityParameter.DisAllowedChars, Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// Method to validate the Validatenewuser
        /// </summary>
        private RequestResult<bool> Validatenewuser(UserModel user )
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            if (user.FirstName == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please enter first name", Severity = ValidationSeverity.Error, SourceId = "FirstName" });
            }
            if (user.Mobile == null || user.Mobile.Length != 10)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Mobile number length is equal to 10", Severity = ValidationSeverity.Error, SourceId = "Mobile" });
            }
            if (user.Email == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Email should have a fromat", Severity = ValidationSeverity.Error, SourceId = "Email" });
            }
            if (user.Email != null && !Helpers.ValidateMinimumSpecialCharsemail(user.Email))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of special characters the email should have is 1 ", Severity = ValidationSeverity.Error, SourceId = "Email" });
            }
            if (user.LastName == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please enter last name", Severity = ValidationSeverity.Error, SourceId = "LastName" });
            }
            if (user.Country == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please select a country", Severity = ValidationSeverity.Error, SourceId = "Country" });
            }
            if (user.Organizations == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please select a Organizations", Severity = ValidationSeverity.Error, SourceId = "Organizations" });
            }
            if (user.UserName == null)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please enter user name", Severity = ValidationSeverity.Error, SourceId = "Username" });
            }
            if (user.ReEnterPassword == null || user.ReEnterPassword != user.Password)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please enter confirm password ", Severity = ValidationSeverity.Error, SourceId = "ReEnterPassword" });
            }
            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// method to Reset Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public RequestResult<bool> ChangePasswordCondition(ForgotPasswordModel forgotPasswordModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            if (forgotPasswordModel.NewPassword.IsNullOrEmpty())
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please Enter New Password.", Severity = ValidationSeverity.Error, SourceId = "NewPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            else if (forgotPasswordModel.ConfirmPassword.IsNullOrEmpty())
            {
                validationMessages.Add(new ValidationMessage { Reason = "Please Enter Confirm Password.", Severity = ValidationSeverity.Error, SourceId = "ConfirmPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            else if (forgotPasswordModel.NewPassword != forgotPasswordModel.ConfirmPassword)
            {
                validationMessages.Add(new ValidationMessage { Reason = "New password and confirm password fields must match.", Severity = ValidationSeverity.Error, SourceId = "ConfirmPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(true);
        }
    }
}

        

