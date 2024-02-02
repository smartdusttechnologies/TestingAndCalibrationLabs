using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IUserRoleClaimService
    {
        /// <summary>
        /// Get All Record From UserRoleClaim
        /// </summary>
        List<UserRoleClaimModel> Get();

        /// <summary>
        /// Get Record By Id From UserRoleClaim 
        /// </summary>
        /// <param name="id"></param>
        UserRoleClaimModel GetById(int id);
        /// <summary>
        /// Insert Record From UserRoleClaim 
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        RequestResult<int> Create(UserRoleClaimModel userRoleClaimModel);
        /// <summary>
        /// Edit Record From UserRoleClaim 
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, UserRoleClaimModel userRoleClaimModel);
        /// <summary>
        /// Delete Record From UserRoleClaim 
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
