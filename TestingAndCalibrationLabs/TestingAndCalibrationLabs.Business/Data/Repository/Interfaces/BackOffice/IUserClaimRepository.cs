using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IUserClaimRepository
    {
        /// <summary>
        /// Get All Records From UserClaim 
        /// </summary>
        List<UserClaimModel> Get();

        /// <summary>
        /// Get Record By Id From UserClaim
        /// </summary>
        /// <param name="id"></param>
        UserClaimModel GetById(int id);
        /// <summary>
        /// Insert Record In UserClaim
        /// </summary>
        /// <param name="userClaimModel"></param>
        int Create(UserClaimModel userClaimModel);
        /// <summary>
        /// Update Record In UserClaim
        /// </summary>
        /// <param name="userClaimModel"></param>
        int Update(UserClaimModel userClaimModel);
    }
}
