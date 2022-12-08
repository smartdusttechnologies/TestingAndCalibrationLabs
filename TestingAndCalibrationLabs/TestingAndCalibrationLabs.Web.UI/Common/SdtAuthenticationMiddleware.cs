using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
    public class SdtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly RoleService _roleService;

        public SdtAuthenticationMiddleware(RequestDelegate requestDelegate,
            IConfiguration configuration,
            RoleService roleservice)
        {
            _configuration = configuration;
            _next = requestDelegate;
            _roleService = roleservice;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            JwtSecurityToken validatedToken;
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
            else if (context.Request.Path.Value.Equals("Security/Login", System.StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("Security/RefreshToken", System.StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.Equals("Security/RevokeToken", System.StringComparison.OrdinalIgnoreCase)
                || context.Request.Path.Value.StartsWith("/Swagger", System.StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
            }
            return;
        }

        private SdtUserIdentity GetUserIdentity(JwtSecurityToken jwtSecurityToken)
        {
            SdtUserIdentity userIdentity = new SdtUserIdentity
            {
                UserId = jwtSecurityToken.Claims.First(x => x.Type == CustomClaimTypes.UserId).Value,
                OrganizationId = jwtSecurityToken.Claims.First(x => x.Type == CustomClaimTypes.OrganizationId).Value
            };

            var roleByOrganizationWithClaims = _roleService.GetRoleByOrganizationWithClaims(userIdentity.UserId);
            var roleClaims = roleByOrganizationWithClaims.Select(x => new Claim(ClaimTypes.Role, x.RoleName)).ToList();
            var userRoleClaim = roleByOrganizationWithClaims.Select(x => new Claim(CustomClaimTypes.Permission, x.ClaimName)).ToList();

            userIdentity.UserRoleClaims.AddRange(roleClaims);
            userIdentity.UserRoleClaims.AddRange(userRoleClaim);

            return userIdentity;
        }

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
                    ValidateIssuer = true,
                    ValidateAudience = true,
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
