using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IRoleClaimService
    {
        /// <summary>
        /// Get All Record From RoleClaim
        /// </summary>
        List<RoleClaimModel> Get();

        /// <summary>
        /// Get Record By Id From RoleClaim 
        /// </summary>
        /// <param name="id"></param>
        RoleClaimModel GetById(int id);
        /// <summary>
        /// Insert Record From RoleClaim 
        /// </summary>
        /// <param name="roleClaimModel"></param>
        RequestResult<int> Create(RoleClaimModel roleClaimModel);
        /// <summary>
        /// Edit Record From RoleClaim 
        /// </summary>
        /// <param name="roleClaimModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, RoleClaimModel roleClaimModel);
        /// <summary>
        /// Delete Record From RoleClaim 
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
