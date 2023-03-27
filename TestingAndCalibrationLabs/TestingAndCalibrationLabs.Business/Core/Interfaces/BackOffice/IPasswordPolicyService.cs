using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For PasswordPolicy
    /// </summary>
    public interface IPasswordPolicyService
    {
        /// <summary>
        /// Get All Record From PasswordPolicy
        /// </summary>
        List<PasswordPolicyModel> Get();
        /// <summary>
        /// Get Record By Id From PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PasswordPolicyModel GetById(int id);
        /// <summary>
        /// Update Record In PasswordPolicy
        /// </summary>    
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(PasswordPolicyModel lookupModel);
        /// <summary>
        /// Insert Record In PasswordPolicy
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(PasswordPolicyModel lookupModel);
        /// <summary>
        /// Delete Record In PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);



    }
}
