using System.Security.Claims;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class SdtPrincipal : ClaimsPrincipal
    {
        public SdtPrincipal(ClaimsIdentity userIdentity) : base(userIdentity)
        {

        }
        public SdtUserIdentity SdtUserIdentity { get; set; }
    }
}
