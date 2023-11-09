using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IUserRoleClaimRepository
    {
        /// <summary>
        /// Get All Records From UserRoleClaim 
        /// </summary>
        List<UserRoleClaimModel> Get();

        /// <summary>
        /// Get Record By Id From UserRoleClaim
        /// </summary>
        /// <param name="id"></param>
        UserRoleClaimModel GetById(int id);
        /// <summary>
        /// Insert Record In UserRoleClaim
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        int Create(UserRoleClaimModel userRoleClaimModel);
        /// <summary>
        /// Update Record In UserRoleClaim
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        int Update(UserRoleClaimModel userRoleClaimModel);
    }
}
