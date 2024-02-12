using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface for Password Policy Service
    /// </summary>
    public interface IPasswordPolicyService
    {
        /// <summary>
        /// Create a new Password Policy
        /// </summary>
        RequestResult<int> Create(PasswordPolicyModel passwordPolicyModel);  
        /// <summary>
        /// Delete a Password Policy by ID
        /// </summary>
        bool Delete(int id);
        /// <summary>
        /// Update an existing Password Policy
        /// </summary>
        RequestResult<int> Update(PasswordPolicyModel passwordPolicyModel);
        /// <summary>
        /// Get a list of all Password Policies
        /// </summary>
        List<PasswordPolicyModel> Get();
        /// <summary>
        /// Get a Password Policy by ID
        /// </summary>
        PasswordPolicyModel GetById(int id);
    }
}