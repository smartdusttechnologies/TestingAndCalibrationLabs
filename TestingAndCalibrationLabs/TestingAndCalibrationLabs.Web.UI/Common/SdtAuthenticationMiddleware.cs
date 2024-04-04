using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
    /// <summary>
    /// Authentication Middlerware To handle Authentication Of this Application
    /// </summary>
    public class SdtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        //TODO: need to pass the roleService instead of creting it local
        //private IRoleService _roleService;

        public SdtAuthenticationMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = requestDelegate;
        }
        /// <summary>
        /// When Authentication Invoked This method will be called
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            //_roleService = roleservice;
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            JwtSecurityToken validatedToken;
            
            //TODO: token validation should also consider the logged out token not only expired tokens.
            if (token != null && ValidateToken(context, token, out validatedToken))
            {
                // attach user to context on successful jwt token validation
                var userIdentity = GetUserIdentity(validatedToken);
                if (userIdentity != null)
                {
                    context.User = new SdtPrincipal(userIdentity);
                    await _next(context);
                }
            }
            else if (context.Request.Path.Value.Equals("/Security/Index", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/Login", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/User/Add", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/User/SendOtp", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/User/ResendOTP", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/User/VerifyEmail", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/ForgotPassword", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/ValidateOTP", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/ResendOTP", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/ResetPassword", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/RefreshToken", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Security/RevokeToken", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.StartsWith("/Swagger", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Login/Login", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Login/GoogleResponse", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Login/LoginWithMicrosoft", StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("/Login/MicrosoftResponse", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
            }
            return;
        }
        /// <summary>
        /// To Get User Identity Based On JWT Security Token
        /// </summary>
        /// <param name="jwtSecurityToken"></param>
        /// <returns></returns>
        private SdtUserIdentity GetUserIdentity(JwtSecurityToken jwtSecurityToken)
        {
            var organisations = jwtSecurityToken.Claims.Select(x => x.Type == CustomClaimType.OrganizationId.ToString());
            SdtUserIdentity userIdentity = new SdtUserIdentity
            {
                UserName = jwtSecurityToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value,
                OrganizationId = int.Parse(jwtSecurityToken.Claims.Single(x => x.Type == CustomClaimType.OrganizationId.ToString()).Value),
                UserId = int.Parse(jwtSecurityToken.Claims.Single(x => x.Type == CustomClaimType.UserId.ToString()).Value),
            };
            var userNameClaim = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userNameClaim != null)
            {
                // Set the context.User to the new ClaimsPrincipal
                userIdentity.AddClaim(new Claim(ClaimTypes.Name, userNameClaim.Value));
            }
            //var roleByOrganizationWithClaims = _roleService.GetRoleByOrganizationWithClaims(userIdentity.UserName).Where(x => x.OrgId == userIdentity.OrganizationId);
            //var roleClaims = roleByOrganizationWithClaims.Select(x => new Claim(ClaimTypes.Role, x.RoleName)).Distinct().ToList();
            //var userRoleClaim = roleByOrganizationWithClaims.Select(x => new Claim(CustomClaimTypes.Permission, x.ClaimName)).Distinct().ToList();

            //var userByOrganizationWithClaims = _roleService.GetUserByOrganizationWithClaims(userIdentity.UserName).Where(x => x.OrgId == userIdentity.OrganizationId);
            //var userClaims = userByOrganizationWithClaims.Select(x => new Claim(CustomClaimTypes.Permission, x.ClaimName));

            //userIdentity.AddClaims(roleClaims);
            //userIdentity.AddClaims(userRoleClaim);
            //userIdentity.AddClaims(userClaims);

            return userIdentity;
        }
        /// <summary>
        /// Validate Token Either JWT Token Is valid or its expired or not 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="token"></param>
        /// <param name="validatedToken"></param>
        /// <returns></returns>
        private bool ValidateToken(HttpContext context, string token, out JwtSecurityToken validatedToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = _configuration["JWT:Secret"];
                var encodedKey = Encoding.ASCII.GetBytes(key);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(encodedKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero. So, tokens expire exactly at token expiration time.
                    ClockSkew = TimeSpan.Zero
                };
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken tokenAfterValidation);
                validatedToken = (JwtSecurityToken)tokenAfterValidation;
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                context.Response.StatusCode = 401;
                context.Response.WriteAsync("Token Expired.");
                validatedToken = null;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
