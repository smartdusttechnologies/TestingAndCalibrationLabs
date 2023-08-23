using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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

        public UserController(IAuthenticationService authenticationService,IOrganizationService organizationService, IMapper mapper, IOTPService otpService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _otpService = otpService;
            _organizationService = organizationService;
        }

        /// <summary>
        /// Default Action of the User Controller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(new UserDTO());
        }

        /// <summary>
        /// Method for User Registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(UserDTO userRequest)
        {
            var userModel = _mapper.Map<UserDTO, UserModel>(userRequest);

            var result = _authenticationService.Add(userModel, userRequest.Password);
            if (result.IsSuccessful && result.RequestedObject)
            {
                return Ok(result.RequestedObject);
                //return Ok(userRequest);
                //return RedirectToAction("SendOtp",userRequest);
            }
            return BadRequest(result.ValidationMessages);
        }
        /// <summary>
        /// Method for Sign-up OTP
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendOtp()
        {
            return View();
        }
        ///// <summary>
        ///// Method to validate otp for Sign-up
        ///// </summary>
        ///// <param name="userDTO"></param>
        ///// <returns></returns>
        [HttpPost]
        public IActionResult SendOtp(OtpDTO otpDTO)
        {
            var otpReturn = _mapper.Map<OtpDTO, OtpModel>(otpDTO);
            var user = _otpService.ValidateOTP(otpReturn);
            if (user.IsSuccessful)
            {
                return Ok(user.RequestedObject);
            }
            return BadRequest(user.ValidationMessages);
        }
    }
}
