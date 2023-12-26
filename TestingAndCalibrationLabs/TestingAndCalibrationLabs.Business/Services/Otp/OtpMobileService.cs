using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Otp;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services.Otp
{


    public class OtpMobileService : IOtpMobileService
    {
        private readonly IConfiguration _configuration;

        private readonly IUserService _userService;
        public OtpMobileService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        #region Public Methods
        public RequestResult<bool> MobileValidate(int userId)
        {
            var data = _userService.MobileValidationStatus(userId);
            return new RequestResult<bool>(data.RequestedObject == 1 ? true : false);
        }
        public RequestResult<bool> MobileVerify(string mobile, int userId)
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();
            var user = _userService.Get(userId);
            if (user == null)
            {
                errors.Add(new ValidationMessage() { Reason = "Account Is Not available", Severity = ValidationSeverity.Error, Description = "User Cannot found", SourceId = "mobile" });
            }
            else if (user.Mobile == mobile)
            {
                return new RequestResult<bool>(true);
            }
            else if (user.Mobile != mobile)
            {
                errors.Add(new ValidationMessage() { Reason = "Unable To procced", Severity = ValidationSeverity.Error, Description = "Enter Correct Mobile Number", SourceId = "mobile" });
            }
            return new RequestResult<bool>(false, errors);
        }
        public async Task<RequestResult<bool>> VerifyOtp(OtpModel r)
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
        public async Task<RequestResult<bool>> SendOtp(OtpModel r)
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
        public async Task<RequestResult<bool>> ResendOtp(OtpModel r)
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
        /// <summary>
        /// Method To Generate OTP
        /// </summary>
        private string GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }
        #endregion
    }
}