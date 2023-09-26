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
        /// To Get All Records Of Lookup
        /// </summary>
        /// <returns></returns>
        List<LookupModel> GetLookup();
        /// <summary>
        /// Get All records for Lookup and LookupCategory
        /// </summary>
        /// <returns></returns>
        List<LookupModel> Get();
        /// <summary>
        /// Get Record In Lookup Based on lookupCategoryId
        /// </summary>
        /// <returns></returns>
        List<LookupModel> GetLookupCategoryId(int lookupCategoryId);
        /// <summary>
        /// Get Record By Id From Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LookupModel GetById(int id);
        /// <summary>
        /// Update Record In Lookup
        /// </summary>    
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(LookupModel lookupModel);
        /// <summary>
        /// Insert Record In Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(LookupModel lookupModel);
        /// <summary>
        /// Delete Record In Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
