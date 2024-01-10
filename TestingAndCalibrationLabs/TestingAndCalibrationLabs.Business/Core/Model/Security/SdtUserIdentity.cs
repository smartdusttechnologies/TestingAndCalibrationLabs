using System.Collections.Generic;
using System.Security.Claims;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of SdtUserIdentity
    /// </summary>
    public class SdtUserIdentity : ClaimsIdentity
    {
        /// <summary>
        /// It Contains Oraganization Id
        /// </summary>
        public int OrganizationId { get; set; }
        /// <summary>
        /// It Contains Username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// It Contains Id Of User
        /// </summary>
        public int UserId { get; set; }

        




    }
}
