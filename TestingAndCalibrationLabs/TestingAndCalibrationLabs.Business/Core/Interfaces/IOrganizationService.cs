using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IOrganizationService
    {
        List<Organization> Get();
        //List<Organization> Get(SessionContext sessionContext);
        //Organization Get(SessionContext sessionContext, int id);

        /// <summary>
        /// Get Record By Id From Organization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Organization GetById(int id);
        /// <summary>
        /// Insert Record In Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>

        RequestResult<int> Create(Organization organization);
        /// <summary>
        /// Update Record In Organization
        /// </summary>    
        /// <param name="organization"></param>
        /// <returns></returns>
        RequestResult<int> Update(Organization organization);
        /// <summary>
        /// Delete Record Organization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
