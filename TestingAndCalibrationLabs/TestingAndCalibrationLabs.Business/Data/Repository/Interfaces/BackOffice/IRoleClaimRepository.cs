using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IRoleClaimRepository
    {
        /// <summary>
        /// Get All Records From RoleClaim 
        /// </summary>
        List<RoleClaimModel> Get();

        /// <summary>
        /// Get Record By Id From RoleClaim
        /// </summary>
        /// <param name="id"></param>
        RoleClaimModel GetById(int id);
        /// <summary>
        /// Insert Record In RoleClaim
        /// </summary>
        /// <param name="roleClaimModel"></param>
        int Create(RoleClaimModel roleClaimModel);
        /// <summary>
        /// Update Record In RoleClaim
        /// </summary>
        /// <param name="roleClaimModel"></param>
        int Update(RoleClaimModel roleClaimModel);
    }
}
