using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Otp;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Implementation For Authentication Class
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly ISecurityParameterService _securityParameterService;
        private readonly ILoggerRepository _loggerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOtpEmailService _otpEmailService;
        private readonly IOtpRepsitory _otpRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IConfiguration configuration,
            IAuthenticationRepository authenticationRepository, IUserRepository userRepository,
            IOtpRepsitory otpRepository,
            ILogger logger,
             ISecurityParameterService securityParameterService,
             ILoggerRepository loggerRepository,
              IRoleRepository roleRepository, IOtpEmailService otpEmailService, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
            _logger = logger;
            _securityParameterService = securityParameterService;
            _loggerRepository = loggerRepository;
            _roleRepository = roleRepository;
            _otpEmailService = otpEmailService;
            _otpRepository = otpRepository;
            _httpContextAccessor = httpContextAccessor;

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
            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            DateTime now = DateTime.Now;
            var claims = GetTokenClaims(userName, now);
            var accessJwt = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                notBefore: now,
                expires: now.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
            );
            var encodedAccessJwt = new JwtSecurityTokenHandler().WriteToken(accessJwt);
            var refreshJwt = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                notBefore: now,
                expires: now.AddDays(30),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
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
        ///Method to Get Token Cliams From here We Can Update Whatever data we want to store in claim
        /// </summary>
        private List<Claim> GetTokenClaims(string sub, DateTime dateTime)
        {
            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:

            var userModel = _roleRepository.GetUserByUserName(sub);
            //var roleClaims = roleByOrganizationWithClaims.Select(x => new Claim(ClaimTypes.Role, x.RoleName));
            //var userRoleClaim = roleByOrganizationWithClaims.Select(x => new Claim(CustomClaimTypes.Permission, x.ClaimName));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Helpers.ToUnixEpochDate(dateTime).ToString(), ClaimValueTypes.Integer64)
            };
            //.Union(roleClaims).Union(userRoleClaim).ToList(); 

            //var roles = _roleRepository.GetRoleWithOrg(sub);
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Item2));
            //}

            claims.Add(new Claim(CustomClaimType.UserId.ToString(), userModel.Id.ToString()));

            if (sub.ToLower() == "sysadmin")
                claims.Add(new Claim(CustomClaimType.OrganizationId.ToString(), "0"));
            else
                claims.Add(new Claim(CustomClaimType.OrganizationId.ToString(), userModel.OrgId.ToString()));

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
        /// Method to Validate the Email
        /// </summary>
        public RequestResult<(int UserId, string UserName)> EmailValidateForgotPassword(OtpModel OtpModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingUser = _otpRepository.GetLoginEmail(OtpModel.Email);
            if (existingUser == null)
            {
                var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error, SourceId = "Email" };
                validationMessages.Add(error);
                return new RequestResult<(int, string)>(default, validationMessages);
            }
            return new RequestResult<(int, string)>((existingUser.Id, existingUser.FirstName));
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
            var validateexistingEmail = ExistingEmailvalidation(user);
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
            validationMessages.AddRange(validateexistingEmail.ValidationMessages);
            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// Method to Validate the Existing User Email.
        /// </summary>
        private RequestResult<bool> ExistingUservalidation(UserModel user)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingUser = _userRepository.Get(user.UserName);
            if (existingUser != null)
            {
                var error = new ValidationMessage { Reason = "The UserName not available", Severity = ValidationSeverity.Error, SourceId = "Username" };
                validationMessages.Add(error);
                return new RequestResult<bool>(false, validationMessages);
            }
            return new RequestResult<bool>(validationMessages);
        }
        /// <summary>
        /// Method to Validate Existing Email
        /// </summary>
        /// <param name="user"></param>
        private RequestResult<string> ExistingEmailvalidation(UserModel user)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            UserModel existingEmail = _userRepository.GetEmail(user.Email);
            if (existingEmail != null)
            {
                var error = new ValidationMessage { Reason = "Already! Email Exist!", Severity = ValidationSeverity.Error, SourceId = "Email" };
                validationMessages.Add(error);
                return new RequestResult<string>(user.Email, validationMessages);
            }
            return new RequestResult<string>(validationMessages);
        }
        /// <summary>
        /// Methodt to Verify Email if user did not validate OTP
        /// </summary>
        /// <param name="user"></param>
        public RequestResult<int> ExistingEmailVerify(UserModel user)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            var User = _httpContextAccessor.HttpContext.User;
            var sdtUserIdentity = User.Identity as SdtUserIdentity;
            user.userId = sdtUserIdentity.UserId;
            UserModel existingEmailUser = _userRepository.SelectEmail(user.userId);
            if (existingEmailUser != null)
            {
                if (existingEmailUser.Email == user.Email)
                {
                    OtpModel otpModel = new OtpModel { Email = user.Email, UserId = user.userId, Name = user.UserName,MobileNumber = user.Mobile };
                    _otpEmailService.SendOtp(otpModel);
                    return new RequestResult<int>(1, validationMessages);
                }
                else
                {
                    var errorMessage = new ValidationMessage { Reason = "Existing Email not Match!", Severity = ValidationSeverity.Error, SourceId = "Email" };
                    validationMessages.Add(errorMessage);
                    return new RequestResult<int>(0, validationMessages);
                }
            }
            return new RequestResult<int>(1, validationMessages);
        }
        /// <summary>
        /// Method to Reset Password 
        /// </summary>
        /// <param name="UserModel"></param>
        public RequestResult<bool> UpdatePassword(UserModel UserModel)
        {
            try
            {
                var passwordResult = _securityParameterService.ChangePasswordCondition(UserModel);
                if (passwordResult.IsSuccessful)
                {
                    var ValidationResult = _securityParameterService.ValidatePasswordPolicy(0, UserModel.Password);
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