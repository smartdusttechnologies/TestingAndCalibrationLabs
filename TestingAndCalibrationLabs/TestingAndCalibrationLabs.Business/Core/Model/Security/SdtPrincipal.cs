using System.Security.Claims;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class SdtPrincipal : ClaimsPrincipal
    {
        public SdtPrincipal(SdtUserIdentity userIdentity) : base(userIdentity)
        {

        }
    }
}
