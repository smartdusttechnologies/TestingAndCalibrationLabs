using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IGroupClaimService
    {
        /// <summary>
        /// Get All Record From GroupClaim
        /// </summary>
        List<GroupClaimModel> Get();

        /// <summary>
        /// Get Record By Id From GroupClaim 
        /// </summary>
        /// <param name="id"></param>
        GroupClaimModel GetById(int id);
        /// <summary>
        /// Insert Record From GroupClaim 
        /// </summary>
        /// <param name="groupClaimModel"></param>
        RequestResult<int> Create(GroupClaimModel groupClaimModel);
        /// <summary>
        /// Edit Record From GroupClaim 
        /// </summary>
        /// <param name="groupClaimModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, GroupClaimModel groupClaimModel);
        /// <summary>
        /// Delete Record From GroupClaim 
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
