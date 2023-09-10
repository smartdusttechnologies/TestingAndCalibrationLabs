﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services.Security
{
    public class OTPservice : IOTPService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OTPservice(IConfiguration configuration,
           IAuthenticationRepository authenticationRepository, 
           IEmailService emailservice,
           IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _authenticationRepository = authenticationRepository;
            _emailService = emailservice;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// Method to Validate the Email
        /// </summary>
        public RequestResult<(int UserId, string UserName)> EmailValidateForgotPassword(OtpModel OtpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingUser = _authenticationRepository.GetLoginEmail(OtpModel.Email);
            if (existingUser == null)
            {
                var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error, SourceId = "Email" };
                validationMessages.Add(error);
                return new RequestResult<(int, string)>(default, validationMessages);
            }
            return new RequestResult<(int, string)>((existingUser.Id, existingUser.FirstName));
        }
        /// <summary>
        /// Method to validate OTP
        /// </summary>
        /// <param name="OtpModel"></param>
        /// <returns></returns>
        public RequestResult<int> ValidateOTP(OtpModel OtpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            OtpModel existingUser = _authenticationRepository.GetOTP(OtpModel.userId);
            if (OtpModel.OTP == existingUser.OTP)
            {
                double OTPTime = double.Parse(_configuration["ValidateOTP:ValidityMinute"]);
                if (OtpModel.CreatedDate <= existingUser.CreatedDate.AddMinutes(OTPTime))
                {
                  return new RequestResult<int>(existingUser.Id);
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
        public RequestResult<int> CreateOtp(OtpModel otpModel, int userId ,string name )
        {
            string otp = GenerateOTP();
            EmailModel model = new EmailModel
            {
                EmailTemplate = _configuration["ForgotPassOTP:EmailTemplate"],
                Subject = _configuration["ForgotPassOTP:Subject"],
                BodyImage = _configuration["ForgotPassOTP:BodyImageLink"],
                LogoImage = _configuration["ForgotPassOTP:LogoLink"],
                Email = new List<string> { otpModel.Email }
            };
            model.HtmlMsg = CreateBody(model.EmailTemplate);
            model.HtmlMsg = model.HtmlMsg.Replace("*Name*", name);
            model.HtmlMsg = model.HtmlMsg.Replace("*OTP*", otp);
            model.HtmlMsg = model.HtmlMsg.Replace("*BodyImageLink*", model.BodyImage);
            model.HtmlMsg = model.HtmlMsg.Replace("*LogoLink*", model.LogoImage);
            OtpModel OtpGenerate = _authenticationRepository.InsertOtp(otp, userId);
            try
            {
                _emailService.Sendemail(model);
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
        /// <summary>
        /// Method To Creat OTP for Sign-up Page
        /// </summary>
        /// <param name="OtpModel"></param>
        /// <returns></returns>
        public RequestResult<int> ResendOTP(OtpModel OtpModel)
        {
           var Email =  _authenticationRepository.GetEmail(OtpModel.userId);
            var userId = OtpModel.userId;
            var name = OtpModel.Name;
            var otp = CreateOtp(Email ,userId,name);
            return new RequestResult<int>(0);
        }
    }
}