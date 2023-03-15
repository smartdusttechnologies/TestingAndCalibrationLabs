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
        public RequestResult<bool> ValidatePasswordPolicy(int orgId, string password)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var passwordPolicy = _securityParameterRepository.Get(orgId);
                var validatePasswordResult = ValidatePassword(password, passwordPolicy);
                return (validatePasswordResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateFirstName(int orgId, string FirstName)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var FirstNamePolicy = _securityParameterRepository.Get(orgId);
                var validateFirstNameResult = ValidateFirstName(FirstName, FirstNamePolicy);
                return (validateFirstNameResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateLastName(int orgId, string LastName)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var LastNamePolicy = _securityParameterRepository.Get(orgId);
                var validateLastNameResult = ValidateLastName(LastName, LastNamePolicy);
                return (validateLastNameResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateCountry(int orgId, string Country)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var CountryPolicy = _securityParameterRepository.Get(orgId);
                var validateCountryResult = ValidateCountry(Country, CountryPolicy);
                return (validateCountryResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateUserName(string UserName)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                //var UserNamePolicy = _securityParameterRepository.Get(orgId);
                var validateUserNameResult = ValidateUserName(UserName);
                return (validateUserNameResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateOrganizations(int orgId, string Organizations)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var OrganizationIdPolicy = _securityParameterRepository.Get(orgId);
                var validateOrganizationIdResult = ValidateOrganizations(Organizations, OrganizationIdPolicy);
                return (validateOrganizationIdResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateReEnterPasswordPolicy(int orgId, string ReEnterPassword, string password)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var passwordPolicy = _securityParameterRepository.Get(orgId);
                var validatePasswordResult = ValidateReEnterPassword(ReEnterPassword, password, passwordPolicy);
                return (validatePasswordResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateEmailPolicy(int orgId, string Email)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var EmailValidatePolicy = _securityParameterRepository.Get(orgId);
                var validationEmailResult = ValidateEmail(Email, EmailValidatePolicy);
                return (validationEmailResult);
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Validation failed!", Severity = ValidationSeverity.Error });
                return new RequestResult<bool>(false, validationMessages); ;

            }
        }
        public RequestResult<bool> ValidateMobilePolicy(int orgId, string Mobile)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var MobileValidatePolicy = _securityParameterRepository.Get(orgId);
                var validationMobileResult = ValidateMobile(Mobile, MobileValidatePolicy);
                return (validationMobileResult);
            }
            catch (Exception ex)
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

            if (password == null || password.Length < securityParameter.MinLength)
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum length of the password should be " + securityParameter.MinLength + "characters long", Severity = ValidationSeverity.Error, SourceId = "EnterPassword" });
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
            return new RequestResult<bool>(validationMessages);
        }
          private RequestResult<bool> ValidateReEnterPassword(string ReEnterPassword, string password, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

           if (ReEnterPassword == null || ReEnterPassword !=password)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please enter confirm password ", Severity = ValidationSeverity.Error, SourceId = "ReEnterPassword" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateEmail(string Email, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

           if (Email == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Email should have a fromat", Severity = ValidationSeverity.Error, SourceId = "Email" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            if (!Helpers.ValidateMinimumSpecialCharsemail(Email, securityParameter.MinSpecialChars))
            {
                validationMessages.Add(new ValidationMessage { Reason = "Minimum number of special characters the email should have is " + securityParameter.MinSpecialChars, Severity = ValidationSeverity.Error, SourceId = "Email" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateMobile(string Mobile, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (Mobile == null || Mobile.Length!=10 )
            {

                validationMessages.Add(new ValidationMessage { Reason = "Mobile number length is equal to 10", Severity = ValidationSeverity.Error, SourceId = "Mobile" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateFirstName(string FirstName, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (FirstName == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please enter first name", Severity = ValidationSeverity.Error, SourceId = "FirstName" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateLastName(string LastName, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (LastName == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please enter last name", Severity = ValidationSeverity.Error, SourceId = "LastName" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateCountry(string Country, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (Country == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please select a country", Severity = ValidationSeverity.Error, SourceId = "Country" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateOrganizations(string Organizations, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (Organizations == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please select a Organizations", Severity = ValidationSeverity.Error, SourceId = "Organizations" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
        private RequestResult<bool> ValidateUserName(string UserName, SecurityParameter securityParameter)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            if (UserName == null)
            {

                validationMessages.Add(new ValidationMessage { Reason = "Please enter user name", Severity = ValidationSeverity.Error, SourceId = "Username" });
                return new RequestResult<bool>(false, validationMessages); ;
            }
            return new RequestResult<bool>(validationMessages);

        }
    }
}

        

