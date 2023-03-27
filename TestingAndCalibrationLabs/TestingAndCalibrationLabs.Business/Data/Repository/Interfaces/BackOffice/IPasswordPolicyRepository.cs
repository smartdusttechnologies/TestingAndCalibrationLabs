using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IPasswordPolicyRepository
    {
        /// <summary>
        /// Get All Records From PasswordPolicy
        /// </summary>
        /// <returns></returns>
        List<PasswordPolicyModel> GetByOrgId(int OrgId);
        /// <summary>
        /// Get All Records From PasswordPolicy
        /// </summary>
        /// <returns></returns>
        List<PasswordPolicyModel> Get();
        /// <summary>
        /// Get Record By Id From PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PasswordPolicyModel GetById(int id);
        /// <summary>
        /// Insert Record In PasswordPolicy
        /// </summary>
        /// <param name="passwordPolicyModel"></param>
        /// <returns></returns>
        int Create(PasswordPolicyModel passwordPolicyModel);
        /// <summary>
        /// Update Record In PasswordPolicy
        /// </summary>
        /// <param name="passwordPolicyModel"></param>
        /// <returns></returns>
        int Update(PasswordPolicyModel passwordPolicyModel);
        /// <summary>
        /// Delete Record From PasswordPolicy By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);


    }
}
