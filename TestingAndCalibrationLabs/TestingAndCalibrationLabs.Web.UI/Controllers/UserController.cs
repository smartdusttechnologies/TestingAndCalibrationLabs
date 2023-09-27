using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    // User controller for User registration
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly IOTPService _otpService;
        private readonly IOrganizationService _organizationService;
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserController(IAuthenticationService authenticationService,IOrganizationService organizationService, IMapper mapper, IOTPService otpService, IAuthenticationRepository authenticationRepository)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _otpService = otpService;
            _organizationService = organizationService;
            _authenticationRepository = authenticationRepository;
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
                OtpModel otpModel = new OtpModel {userId= userModel.userId ,Email = userModel.Email};
                return Ok(otpModel);
            }
            return BadRequest(result.ValidationMessages);
        }
        /// <summary>
        /// Method for Sign-up OTP
        /// </summary>
        [HttpGet]
        public IActionResult SendOtp(int userId)
        {
            OtpDTO otpDTO = new OtpDTO { userId = userId};
            return View(otpDTO);
        }
        ///// <summary>
        ///// Method to validate otp for Sign-up
        ///// </summary>
        ///// <param name="userDTO"></param>
        [HttpPost]
        public IActionResult SendOtp(OtpDTO otpDTO)
        {
            var otpReturn = _mapper.Map<OtpDTO, OtpModel>(otpDTO);
            var user = _otpService.ValidateOTP(otpReturn);
            if (user.IsSuccessful)
            {
               UserModel userModel = new UserModel { userId = otpReturn.userId, Email = otpReturn.Email };
                _authenticationService.EmailValidationStatus(userModel);
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
            var resendOtp = _mapper.Map<OtpDTO, OtpModel>(otpDTO);
            _otpService.ResendOTP(resendOtp);
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
    }
}
