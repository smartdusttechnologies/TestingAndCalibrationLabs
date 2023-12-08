﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services.Security
{


    public class OtpService : IOtpService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOtpRepsitory _otpRepsitory;
        private readonly IGenericRepository<OtpModel> _genericRepository;

        private readonly IUserService _userService;
        public OtpService(IConfiguration configuration,
           IAuthenticationRepository authenticationRepository,
           IEmailService emailservice, IOtpRepsitory otpRepsitory,
           IWebHostEnvironment hostingEnvironment, IUserService userService, IGenericRepository<OtpModel> genericRepository)
        {
            _configuration = configuration;
            _authenticationRepository = authenticationRepository;
            _emailService = emailservice;
            _otpRepsitory = otpRepsitory;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _genericRepository = genericRepository;
        }
        #region Common Public Methods
        public RequestResult<bool> MobileValidate(int userId)
        {
            var data = _userService.MobileValidationStatus(userId);
            return new RequestResult<bool>(data.RequestedObject == 1 ? true : false );
        }
        public RequestResult<bool> MobileVerify(string mobile,int userId)
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();
            var user = _userService.Get(userId);
            if (user == null)
            {
                errors.Add(new ValidationMessage() { Reason = "Account Is Not available", Severity = ValidationSeverity.Error, Description = "User Cannot found",SourceId="mobile" });
            }
            else if(user.Mobile == mobile)
            {
                return new RequestResult<bool>(true);
            }
            else if(user.Mobile != mobile)
            {
                errors.Add(new ValidationMessage() { Reason = "Unable To procced", Severity = ValidationSeverity.Error, Description = "Enter Correct Mobile Number", SourceId = "mobile" });
            }
            return new RequestResult<bool>(false,errors);
        }
        public RequestResult<bool> SendOtp(OtpModel r, bool isMobile)
        {
            if (isMobile) return SendMobileOtp(r).Result;
            return SendEmailOtp(r);
        }
        public RequestResult<bool> VerifyOtp(OtpModel r, bool isMobile)
        {
            if (isMobile) return VerifyMobileOtp(r).Result;
            return VerifyEmailOtp(r);
        }
        public RequestResult<bool> ResendOtp(OtpModel r, bool isMobile)
        {
            if (isMobile) return ResendMobileOtp(r).Result;
            return ResendEmailOtp(r);
        }
        #endregion
        #region Email Methods
        /// <summary>
        /// Method to validate OTP
        /// </summary>
        /// <param name="OtpModel"></param>
        private RequestResult<bool> VerifyEmailOtp(OtpModel r)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            OtpModel existingUser = _otpRepsitory.GetOTP(r.UserId);
            if (r.OTP == existingUser.OTP)
            {
                double validationTimeLimit = double.Parse(_configuration["ValidateOTP:ValidityMinute"]);
                if (r.CreatedDate <= existingUser.CreatedDate.AddMinutes(validationTimeLimit))
                {
                    _userService.EmailValidationStatus(r.UserId);
                    return new RequestResult<bool>(true);
                }
                else
                {
                    var Error = new ValidationMessage { Reason = "Sorry!!! The OTP Time Out", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                    validationMessages.Add(Error);
                    return new RequestResult<bool>(false, validationMessages);
                }
            }
            else
            {
                var Error = new ValidationMessage { Reason = "The OTP not match", Severity = ValidationSeverity.Error, SourceId = "OTP" };
                validationMessages.Add(Error);
                return new RequestResult<bool>(false, validationMessages);
            }
        }
        /// <summary>
        /// Method To Create OTP though user email 
        /// </summary>
        /// <param name="OtpModel"></param>
        private RequestResult<bool> SendEmailOtp(OtpModel otpModel)
        {
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
                return new RequestResult<bool>(false);
            }
            return new RequestResult<bool>(true);
        }
        /// <summary>
        /// Method To Creat OTP for Sign-up Page
        /// </summary>
        /// <param name="OtpModel"></param>
        public RequestResult<bool> ResendEmailOtp(OtpModel OtpModel)
        {
            var Email = _genericRepository.Get(OtpModel.UserId);
            var otp = SendEmailOtp(Email);
            return new RequestResult<bool>(true);
        }
        #endregion

        #region Phone Methods
        private async Task<RequestResult<bool>> VerifyMobileOtp(OtpModel r)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://control.msg91.com/api/v5/otp/verify?otp=${r.OTP}&mobile=${r.MobileNumber}"),
                Headers =
            {
                { "accept", "application/json" },
                { "authkey", _configuration["msg91:authkey"] },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = response.Content.ReadAsStringAsync();
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false);
            }
        }
        private async Task<RequestResult<bool>> SendMobileOtp(OtpModel r)
        {
            var client = new HttpClient();
            var template_id = _configuration["msg91:template_id"];
            var otp_length = _configuration["msg91:otp_length"];
            var otp_expiry = _configuration["msg91:otp_expiry"];
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://control.msg91.com/api/v5/otp?template_id=${template_id}&mobile=${r.MobileNumber}&otp_length=${otp_length}&otp_expiry=${otp_expiry}"),
                Headers =
                  {
                      { "accept", "application/json" },
                      { "authkey", _configuration["msg91:authkey"] },
                  },
                //Content = new StringContent("{\"Param1\":\"value1\",\"Param2\":\"value2\",\"Param3\":\"value3\"}")
                //{
                //    Headers =
                //    {
                //        ContentType = new MediaTypeHeaderValue("application/json")
                //    }
                //}
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false);
            }
        }
        private async Task<RequestResult<bool>> ResendMobileOtp(OtpModel r)
        {
            var rType = r.IsCall ? "Voice" : "text";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://control.msg91.com/api/v5/otp/retry?retrytype=${rType}&mobile=${r.MobileNumber}"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "authkey", _configuration["msg91:authkey"] },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false);

            }
        }
        #endregion
        #region Private Methods
        private async Task<RequestResult<bool>> OtpSend(OtpModel r)
        {
            var otp = GenerateOTP();
            String message = HttpUtility.UrlEncode("This is your message");
            var client = new HttpClient();
            var parameters = new Dictionary<string, string> {
                {"apikey" , "yourapiKey"},
                {"numbers" , "918123456789"},
                {"message" , message},
                {"sender" , "TXTLCL"} 
            };
            var encodedContent = new FormUrlEncodedContent(parameters);
            using (var response = await client.PostAsync("https://api.textlocal.in/send/", encodedContent).ConfigureAwait(false))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false);

            }
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
        #endregion
    }
}