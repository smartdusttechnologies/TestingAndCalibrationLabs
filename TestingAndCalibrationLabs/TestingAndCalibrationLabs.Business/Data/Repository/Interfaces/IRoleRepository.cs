using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model.Securities;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IRoleRepository
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
