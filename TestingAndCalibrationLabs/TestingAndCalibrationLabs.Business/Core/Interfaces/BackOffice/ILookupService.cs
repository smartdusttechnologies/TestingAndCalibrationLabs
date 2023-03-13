using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Lookup
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        List<LookupModel> Get();
        /// <summary>
        /// Get Record By Id From Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LookupModel GetById(int id);
        /// <summary>
        /// Update Record In Module
        /// </summary>    
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(LookupModel lookupModel);
        /// <summary>
        /// Insert Record In Module
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(LookupModel lookupModel);
        /// <summary>
        /// Delete Record In Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);



    }
}
