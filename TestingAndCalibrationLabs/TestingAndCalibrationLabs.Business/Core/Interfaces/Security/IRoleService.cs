using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);

        /// <summary>
        /// Abstract method to get Role by Organization including claims
        /// </summary>
        List<UserRoleClaim> GetRoleByOrganizationWithClaims(string userName);
    }
}
