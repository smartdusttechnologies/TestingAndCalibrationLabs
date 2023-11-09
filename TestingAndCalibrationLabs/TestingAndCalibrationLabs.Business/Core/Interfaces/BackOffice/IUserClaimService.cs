using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IUserClaimService
    {
        /// <summary>
        /// Get All Record From UserClaim
        /// </summary>
        List<UserClaimModel> Get();

        /// <summary>
        /// Get Record By Id From UserClaim 
        /// </summary>
        /// <param name="id"></param>
        UserClaimModel GetById(int id);
        /// <summary>
        /// Insert Record From UserClaim 
        /// </summary>
        /// <param name="userClaimModel"></param>
        RequestResult<int> Create(UserClaimModel userClaimModel);
        /// <summary>
        /// Edit Record From UserClaim 
        /// </summary>
        /// <param name="userClaimModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, UserClaimModel userClaimModel);
        /// <summary>
        /// Delete Record From UserClaim 
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
