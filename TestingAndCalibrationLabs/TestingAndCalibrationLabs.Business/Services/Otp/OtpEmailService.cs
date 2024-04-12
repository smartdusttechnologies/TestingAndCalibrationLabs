using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Otp;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.Otp
{


    public class OtpEmailService : IOtpEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOtpRepsitory _otpRepsitory;
        private readonly IGenericRepository<OtpModel> _genericRepository;

        private readonly IUserService _userService;
        public OtpEmailService(IConfiguration configuration,
           IEmailService emailservice, IOtpRepsitory otpRepsitory,
           IWebHostEnvironment hostingEnvironment, IUserService userService, IGenericRepository<OtpModel> genericRepository)
        {
            _configuration = configuration;
            _emailService = emailservice;
            _otpRepsitory = otpRepsitory;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _genericRepository = genericRepository;
        }

        #region Public Methods
        /// <summary>
        /// Method to validate OTP
        /// </summary>
        /// <param name="otpmodel"></param>
        public RequestResult<bool> VerifyOtp(OtpModel otpmodel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            OtpModel existingUser = _otpRepsitory.GetOTP(otpmodel.UserId);
            if (otpmodel.OTP == existingUser.OTP)
            {
                double validationTimeLimit = double.Parse(_configuration["ValidateOTP:ValidityMinute"]);
                if (otpmodel.CreatedDate <= existingUser.CreatedDate.AddMinutes(validationTimeLimit))
                {
                    _userService.EmailValidationStatus(otpmodel.UserId);
                    return new RequestResult<bool>(true);
                }
                else
                {
                    var error = new ValidationMessage { Reason = "Sorry!!! The OTP Time Out", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                    validationMessages.Add(error);
                    return new RequestResult<bool>(false, validationMessages);
                }
            }
            else
            {
                var error = new ValidationMessage { Reason = "The OTP not match", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                validationMessages.Add(error);
                return new RequestResult<bool>(false, validationMessages);
            }
        }
        /// <summary>
        /// Method To Create OTP though user email 
        /// </summary>
        /// <param name="OtpModel"></param>
        public RequestResult<bool> SendOtp(OtpModel otpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            var user = _userService.Get(otpModel.UserId);
            otpModel.Email = user.Email;
            otpModel.Name = user.FirstName;
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
            model.HtmlMsg = model.HtmlMsg.Replace("*Name*", otpModel.Name);
            model.HtmlMsg = model.HtmlMsg.Replace("*OTP*", otp);
            model.HtmlMsg = model.HtmlMsg.Replace("*BodyImageLink*", model.BodyImage);
            model.HtmlMsg = model.HtmlMsg.Replace("*LogoLink*", model.LogoImage);
            OtpModel OtpGenerate = _otpRepsitory.InsertOtp(otp, otpModel.UserId);
            try
            {
                _emailService.Sendemail(model);
            }
            catch (Exception ex)
            {
                var Error = new ValidationMessage { Reason = "Email format is invalid. Please provide a valid email address.", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                validationMessages.Add(Error);
                return new RequestResult<bool>(false, validationMessages);
            }
            return new RequestResult<bool>(true);
        }
        /// <summary>
        /// Method To Creat OTP for Sign-up Page
        /// </summary>
        /// <param name="otpmodel"></param>
        public RequestResult<bool> ResendOtp(OtpModel otpmodel)
        {
            var emaildetail = _genericRepository.Get(otpmodel.UserId);
            var otp = SendOtp(emaildetail);
            return new RequestResult<bool>(true);
        }
        #endregion

        #region Private Methods
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
        #endregion
    }
}