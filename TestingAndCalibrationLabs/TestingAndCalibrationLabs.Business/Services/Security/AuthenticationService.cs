using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using static System.Net.WebRequestMethods;
using Google.Apis.Drive.v3.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static TestingAndCalibrationLabs.Business.Core.Model.PolicyTypes;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration;
using AutoMapper;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class AuthenticationService : IAuthenticationService
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
        private readonly IOTPService _otpService;
        private readonly IMapper _mapper;

        public AuthenticationService(IConfiguration configuration,
            IAuthenticationRepository authenticationRepository, IUserRepository userRepository,
            ILogger logger,
            IEmailService emailservice,
            IWebHostEnvironment hostingEnvironment,
             ISecurityParameterService securityParameterService,
             ILoggerRepository loggerRepository,
              IRoleRepository roleRepository, IOTPService otpService,  IMapper mapper)
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
            _otpService = otpService;
            _mapper = mapper;
        }
        /// <summary>
        /// Method to Authenticate for Login
        /// </summary>
        public RequestResult<LoginToken> Login(LoginRequest loginRequest)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                LoginToken token = new LoginToken();
                var passwordLogin = _authenticationRepository.GetLoginPassword(loginRequest.UserName);

                string valueHash = string.Empty;
                if (passwordLogin != null && !Hasher.ValidateHash(loginRequest.Password, passwordLogin.PasswordSalt, passwordLogin.PasswordHash, out valueHash))
                {
                    validationMessages.Add(new ValidationMessage { Reason = "UserName or password mismatch.", Severity = ValidationSeverity.Error });
                    return new RequestResult<LoginToken>(validationMessages);
                }

                var user = _userRepository.Get(passwordLogin.UserId);
                if (!user.IsActive && user.Locked)
                {
                    validationMessages.Add(new ValidationMessage { Reason = "Access denied.", Severity = ValidationSeverity.Error });
                    return new RequestResult<LoginToken>(validationMessages);
                }
                #region this needs to be implemented once we have change password UI.
                //int changeIntervalDays = 30;
                //if (user.OrgId != 0)
                //{
                //    var passwordPolicy = _securityParameterService.Get(user.OrgId);
                //    changeIntervalDays = passwordPolicy.ChangeIntervalDays;
                //}
                //if (passwordLogin.ChangeDate.AddDays(changeIntervalDays) < DateTime.Today)
                //{
                //    validationMessages.Add(new ValidationMessage { Reason = "Password expired.", Severity = ValidationSeverity.Error });
                //    return new RequestResult<LoginToken>(validationMessages);
                //}
                #endregion

                loginRequest.Id = passwordLogin.UserId;
                token = GenerateTokens(loginRequest.UserName);

                //TODO: this should be a async operation and can be made more cross-cutting design feature rather than calling inside the actual feature.
                loginRequest.LoginDate = DateTime.Now;
                loginRequest.PasswordHash = valueHash;
                _logger.LoginLog(loginRequest);

                return new RequestResult<LoginToken>(token, validationMessages);
            }
            catch (Exception ex)
            {
                //_logger.LogException(new ExceptionLog
                // {
                //   ExceptionDate = DateTime.Now,
                //   ExceptionMsg = ex.Message,
                //  ExceptionSource = ex.Source,
                //   ExceptionType = "UserService",
                //  FullException = ex.StackTrace
                // });
                validationMessages.Add(new ValidationMessage { Reason = ex.Message, Severity = ValidationSeverity.Error, Description = ex.StackTrace });
                return new RequestResult<LoginToken>(validationMessages);
            }
        }
        /// <summary>
        /// Method to Generate Token
        /// </summary>
        private LoginToken GenerateTokens(string userName)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            DateTime now = DateTime.Now;
            var claims = GetTokenClaims(userName, now);
            var accessJwt = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                notBefore: now,
                expires: now.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedAccessJwt = new JwtSecurityTokenHandler().WriteToken(accessJwt);
            var refreshJwt = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                notBefore: now,
                expires: now.AddDays(30),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedRefreshJwt = new JwtSecurityTokenHandler().WriteToken(refreshJwt);
            var loginToken = new LoginToken
            {
                UserName = userName,
                AccessToken = encodedAccessJwt,
                AccessTokenExpiry = DateTime.Now.AddDays(1),
                RefreshToken = encodedRefreshJwt,
                RefreshTokenExpiry = DateTime.Now.AddDays(30),
            };
            _authenticationRepository.SaveLoginToken(loginToken);
            //TODO: this should be a async operation and can be made more cross-cutting design feature rather than calling inside the actual feature.
            _loggerRepository.LoginTokenLog(loginToken);
            return loginToken;
        }
        /// <summary>
        ///Method to Get Token Cliams
        /// </summary>
        private List<Claim> GetTokenClaims(string sub, DateTime dateTime)
        {
            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:

            var roleByOrganizationWithClaims = _roleRepository.GetRoleByOrganizationWithClaims(sub);
            var roleClaims = roleByOrganizationWithClaims.Select(x => new Claim(ClaimTypes.Role, x.RoleName));
            var userRoleClaim = roleByOrganizationWithClaims.Select(x => new Claim(CustomClaimTypes.Permission, x.ClaimName));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Helpers.ToUnixEpochDate(dateTime).ToString(), ClaimValueTypes.Integer64)
            }.Union(roleClaims).Union(userRoleClaim).ToList();

            var roles = _roleRepository.GetRoleWithOrg(sub);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Item2));
            }

            if (sub.ToLower() == "sysadmin")
                claims.Add(new Claim("OrganizationId", "0"));
            else
                claims.Add(new Claim("OrganizationId", roleByOrganizationWithClaims.FirstOrDefault().OrgId.ToString()));
            return claims;
        }

        /// <summary>
        /// Method to Add new and validate existing user for Registration
        /// </summary>
        public RequestResult<bool> Add(UserModel user, string password)
        {
            try
            {
                var validationResult = ValidateNewUserRegistration(user, password);
                if (validationResult.IsSuccessful)
                {
                    PasswordLogin passwordLogin = Hasher.HashPassword(user.Password);
                    user.IsActive = true;
                    _userRepository.Insert(user, passwordLogin);
                    OtpModel User = new OtpModel { userId = passwordLogin.UserId, Email = user.Email };
                    _otpService.CreateOtp(User, passwordLogin.UserId);
                    user.userId = User.userId;
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false, validationResult.ValidationMessages);
            }
            catch (Exception ex)
            {
                return new RequestResult<bool>(false);
            }
        }
        /// <summary>
        /// Method to Validate the New User Registation
        /// </summary>
        private RequestResult<bool> ValidateNewUserRegistration(UserModel user, string password)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            var validatePasswordResult = _securityParameterService.ValidatePasswordPolicy(user.OrgId, password);
            var validateUserfieldsResult = _securityParameterService.ValidateNewuserPolicy(user);

            var validateexistinguser = ExistingUservalidation(user);
            //UserModel existingUser = _userRepository.Get(user.UserName);
            //if (existingUser != null)
            //{
            //    var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error };
            //    validationMessages.Add(error);
            //    return new RequestResult<bool>(false, validationMessages);
            //}
            validationMessages.AddRange(validatePasswordResult.ValidationMessages);
            validationMessages.AddRange(validateexistinguser.ValidationMessages);
            validationMessages.AddRange(validateUserfieldsResult.ValidationMessages);

            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// Method to Validate the Existing User
        /// </summary>
        private RequestResult<bool> ExistingUservalidation( UserModel user)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingUser = _userRepository.Get(user.UserName);
            if (existingUser != null)
            {
                var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error , SourceId = "Username" };
                validationMessages.Add(error);
                return new RequestResult<bool>(false, validationMessages);
            }
            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// Method to Reset Password 
        /// </summary>
        /// <param name="UserModel"></param>
        /// <returns></returns>
        public RequestResult<bool> UpdatePassword(UserModel UserModel)
        {
            try
            {
                var passwordResult = _securityParameterService.ChangePasswordCondition(UserModel);
                if (passwordResult.IsSuccessful)
                {
                    var ValidationResult = _securityParameterService.ValidatePasswordPolicy( 0, UserModel.Password);
                    var PasswordLogin = _authenticationRepository.GetUserIdPassword(UserModel.userId);
                    List<ValidationMessage> validationMessages = new List<ValidationMessage>();
                    if (ValidationResult.IsSuccessful)
                    {
                        if (passwordResult.IsSuccessful)
                        {
                            PasswordLogin newPasswordLogin = Hasher.HashPassword(UserModel.Password);
                            UserModel passwordModel = new UserModel();
                            passwordModel.PasswordHash = newPasswordLogin.PasswordHash;
                            passwordModel.userId = UserModel.userId;
                            passwordModel.ChangeDate = DateTime.Now;
                            passwordModel.PasswordSalt = newPasswordLogin.PasswordSalt;
                            _userRepository.UpdatePassword(passwordModel);
                            return new RequestResult<bool>(true);
                        }
                    }
                    return new RequestResult<bool>(false, ValidationResult.ValidationMessages);
                }
                return new RequestResult<bool>(false, passwordResult.ValidationMessages);
            }
            catch (Exception ex)
            {
                return new RequestResult<bool>(false);
            }
        }
    }
}