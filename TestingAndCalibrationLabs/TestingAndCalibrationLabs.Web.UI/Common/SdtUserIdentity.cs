using System.Collections.Generic;
using System.Security.Claims;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
    public class SdtUserIdentity : ClaimsIdentity
    {
        public string OrganizationId { get; set; }
        public string UserId { get; set; }
        public List<Claim> UserRoleClaims { get; set; }

    }
}
