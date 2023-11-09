using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IGroupClaimRepository
    {
        /// <summary>
        /// Get All Records From GroupClaim 
        /// </summary>
        List<GroupClaimModel> Get();

        /// <summary>
        /// Get Record By Id From GroupClaim
        /// </summary>
        /// <param name="id"></param>
        GroupClaimModel GetById(int id);
        /// <summary>
        /// Insert Record In GroupClaim
        /// </summary>
        /// <param name="groupClaimModel"></param>
        int Create(GroupClaimModel groupClaimModel);
        /// <summary>
        /// Update Record In GroupClaim
        /// </summary>
        /// <param name="groupClaimModel"></param>
        int Update(GroupClaimModel groupClaimModel);
    }
}

