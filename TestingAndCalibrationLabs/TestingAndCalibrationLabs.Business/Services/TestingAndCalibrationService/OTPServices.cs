﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{
    public class OTPservice : IOTPServices
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly ISecurityParameterService _securityParameterService;
        private readonly ILoggerRepository _loggerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOTPServices _otpServices;
        private IOTPServices otpServices;
        private readonly IOrganizationService _organizationService;
        public OTPservice(IConfiguration configuration,
          IAuthenticationRepository authenticationRepository, IUserRepository userRepository, 
           ILogger logger,
          IEmailService emailservice,
          IWebHostEnvironment hostingEnvironment,
           ISecurityParameterService securityParameterService,
           ILoggerRepository loggerRepository,
            IRoleRepository roleRepository,
            IOTPServices otpServices, IOrganizationService organizationService)
        {
            _configuration = configuration;
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
            _logger = logger;
            _securityParameterService = securityParameterService;
            _loggerRepository = loggerRepository;
            _roleRepository = roleRepository;
            _emailService = emailservice;
            _hostingEnvironment = hostingEnvironment;
            _otpServices = otpServices;
            _organizationService = organizationService;
        }

        /// <summary>
        /// Method to Validate the Email
        /// </summary>
        public RequestResult<int> EmailValidateForgotPassword(OtpModel OtpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingUser = _authenticationRepository.GetLoginEmail(OtpModel.Email);
            if (existingUser == null)
            {
                var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error, SourceId = "Email" };
                validationMessages.Add(error);
                return new RequestResult<int>(0, validationMessages);
            }
            return new RequestResult<int>(existingUser.Id);
        }
        /// <summary>
        /// Method to validate OTP
        /// </summary>
        /// <param name="OtpModel"></param>
        /// <returns></returns>
        public RequestResult<int> ValidateOTP(OtpModel OtpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            OtpModel existingUser = _authenticationRepository.GetOTP(OtpModel.UserId);
            if (OtpModel.OTP == existingUser.OTP)
            {
                double OTPTime = double.Parse(_configuration["ValidateOTP:ValidityMinute"]);
                if (OtpModel.CreatedDate <= existingUser.CreatedDate.AddMinutes(OTPTime))
                {
                    OtpModel.EmailValidationStatus = 1;
                    return new RequestResult<int>(existingUser.UserId);
                }
                else
                {
                    var Error = new ValidationMessage { Reason = "Sorry!!! The OTP Time Out", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                    validationMessages.Add(Error);
                    return new RequestResult<int>(0, validationMessages);
                }
            }
            else
            {
                var Error = new ValidationMessage { Reason = "The OTP not match", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                validationMessages.Add(Error);
                return new RequestResult<int>(0, validationMessages);
            }
        }
        /// <summary>
        /// Method To Create OTP though user email 
        /// </summary>
        /// <param name="OtpModel"></param>
        /// <returns></returns>
        public RequestResult<int> CreateOtp(OtpModel otpModel, int userId)
        {
            var UserId = userId;
            string otp = GenerateOTP();
            string subject = "OTP Verification";
            string body = $"{otp}";
            EmailModel model = new EmailModel();
            model.EmailTemplate = _configuration["ForgotPassOTP:EmailTemplate"];
            model.Subject = _configuration["ForgotPassOTP:Subject"];
            model.BodyImage = _configuration["ForgotPassOTP:BodyImageLink"];
            model.LogoImage = _configuration["ForgotPassOTP:LogoLink"];
            model.Email = new List<string>();
            model.HtmlMsg = CreateBody(model.EmailTemplate);
            model.HtmlMsg = model.HtmlMsg.Replace("*OTP*", body);
            model.HtmlMsg = model.HtmlMsg.Replace("*BodyImageLink*", model.BodyImage);
            model.HtmlMsg = model.HtmlMsg.Replace("*LogoLink*", model.LogoImage);
            OtpModel OtpGenerate = _authenticationRepository.InsertOtp(body, UserId);
            try
            {
                _emailService.Sendemail(model);
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<int>(0);

            }
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Method To Generate OTP
        /// </summary>
        private string GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }
        /// <summary>
        /// To use the email Template to send OTP to the User participated.
        /// </summary>
        /// <param name="emailTemplate"></param>
        private string CreateBody(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["ForgotPassOTP:EmailTemplate"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}