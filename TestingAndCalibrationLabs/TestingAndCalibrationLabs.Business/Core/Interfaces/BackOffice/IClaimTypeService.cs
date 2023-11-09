using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    /// <summary>
    /// Service interface for Claim Type Service
    /// </summary>
    public interface IClaimTypeService
    {
        /// <summary>
        /// Get All Record From Claim Type Service
        /// </summary>
        List<ClaimTypeModel> Get();

        /// <summary>
        /// Insert Record In Claim Type Service
        /// </summary>
        /// <param name="claimTypeModel"></param>
        RequestResult<int> Create(ClaimTypeModel claimTypeModel);

        /// <summary>
        /// Delete Record In Claim Type Service
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From Claim Type Service
        /// </summary>
        /// <param name="id"></param>
        ClaimTypeModel GetById(int id);

        /// <summary>
        /// Edit Record From Claim Type Service
        /// </summary>
        /// <param name="claimTypeModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, ClaimTypeModel claimTypeModel);
    }
}
