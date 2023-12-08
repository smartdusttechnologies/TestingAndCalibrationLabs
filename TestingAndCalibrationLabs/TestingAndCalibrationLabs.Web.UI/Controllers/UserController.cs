using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Otp;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    // User controller for User registration
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly IOtpEmailService _otpEmailService;
        private readonly IOtpMobileService _otpMobileService;
        public UserController(IAuthenticationService authenticationService, IMapper mapper, IOtpEmailService otpEmailService, IOtpMobileService otpMobileService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _otpEmailService = otpEmailService;
            _otpMobileService = otpMobileService;
        }
        /// <summary>
        /// Default Action of the User Controller
        /// </summary>
        public IActionResult Index()
        {
            return View(new UserDTO());
        }
        /// <summary>
        /// Method for User Registration
        /// </summary>
        [HttpPost]
        public IActionResult Add(UserDTO userRequest)
        {
            var userModel = _mapper.Map<UserDTO, UserModel>(userRequest);
            var result = _authenticationService.Add(userModel, userRequest.Password);
            if (result.IsSuccessful)
            {
                OtpModel otpModel = new OtpModel { UserId = userModel.userId, Email = userModel.Email,MobileNumber = userModel.Mobile };
                return Ok(otpModel);
            }
            return BadRequest(result.ValidationMessages);
        }
        #region Otp Email 
        /// <summary>
        /// Method for Sign-up OTP
        /// </summary>
        [HttpGet]
        public IActionResult EmailVerify()
        {
            var sdtUserIdentity = HttpContext.User.Identity as SdtUserIdentity;
            var userId = sdtUserIdentity.UserId;
            OtpDTO data = new OtpDTO { userId = userId };   
            var otpModel = _mapper.Map<OtpDTO, OtpModel>(data);
            _otpEmailService.SendOtp(otpModel);  
            return View(data);
        }
        ///// <summary>
        ///// Method to validate otp for Sign-up
        ///// </summary>
        ///// <param name="userDTO"></param>
        [HttpPost]
        public IActionResult EmailVerify(OtpDTO otpDTO)
        {
            var otpReturn = _mapper.Map<OtpDTO, OtpModel>(otpDTO);
            var user = _otpEmailService.VerifyOtp(otpReturn);
            if (user.IsSuccessful)
            {
                return Ok(user.RequestedObject);
            }
            return BadRequest(user.ValidationMessages);
        }
        /// <summary>
        /// Method To Resend OTP For Sign-Up Page
        /// </summary>
        /// <param name="otpDTO"></param>
        public IActionResult ResendOTP(OtpDTO otpDTO)
        {
            var sdtUserIdentity = HttpContext.User.Identity as SdtUserIdentity;
            var userId = sdtUserIdentity.UserId;
            var resendOtp = _mapper.Map<OtpDTO, OtpModel>(otpDTO);
            resendOtp.UserId = userId;
            _otpEmailService.ResendOtp(resendOtp);
            return Ok(otpDTO);
        }
        /// <summary>
        /// Method to VerifyEmail at the time of email varification.
        /// </summary>
        /// <param name="otpDTO"></param>
        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View(new UserDTO());
        }
        /// <summary>
        /// Method to Verify Email at the time of Email Varification
        /// </summary>
        /// <param name="userDTO"></param>
        [HttpPost]
        public IActionResult VerifyEmail(UserDTO userDTO)
        {
            var userModel = _mapper.Map<UserDTO, UserModel>(userDTO);
            var existingEmail = _authenticationService.ExistingEmailVerify(userModel);
            if (existingEmail.IsSuccessful)
            {
                return Ok(userModel.userId);
            }
            return BadRequest(existingEmail.ValidationMessages);
        }
        #endregion
        #region Phone Otp Logics
        [HttpGet]
        public IActionResult MobileVerify()
        {
            OtpDTO otpDTO = new OtpDTO { };
            return View(otpDTO);
        }
        [HttpPost]
        public IActionResult MobileVerify(string mobile)
        {
            var sdtUserIdentity = HttpContext.User.Identity as SdtUserIdentity;
            var userId = sdtUserIdentity.UserId;
            var result = _otpMobileService.MobileVerify(mobile, userId);
            if (result.IsSuccessful)
            {
                return Ok(result.RequestedObject);
            }
            return BadRequest(result.ValidationMessages);
        }
        ///// <summary>
        ///// Method to validate otp for Sign-up
        ///// </summary>
        ///// <param name="userDTO"></param>
        [HttpPost]
        public IActionResult MobileValidate()
        {
            var sdtUserIdentity = HttpContext.User.Identity as SdtUserIdentity;
            var userId = sdtUserIdentity.UserId;
            var result = _otpMobileService.MobileValidate(userId);
            if (result.IsSuccessful)
            {
                return Ok(result.RequestedObject);
            }
            return BadRequest(result.ValidationMessages);
        }
        #endregion
    }
}
