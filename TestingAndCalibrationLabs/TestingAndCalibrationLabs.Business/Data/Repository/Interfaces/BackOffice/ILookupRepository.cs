using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface ILookupRepository
    {
        /// <summary>
        /// Get All Records From 
        /// </summary>
        /// <returns></returns>
        List<LookupModel> GetByLookupCategoryId(int lookupCategoryId);
        /// <summary>
        /// Get All Records From Lookup
        /// </summary>
        /// <returns></returns>
        List<LookupModel> GetLookupCategoryId(int lookupCategoryId);
        /// <summary>
        /// Get All Records From Lookup based on LookupCategoryId
        /// </summary>
        /// <returns></returns>

        List<LookupModel> Get();
        /// <summary>
        /// Get Record By Id From Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LookupModel GetById(int id);
        /// <summary>
        /// Insert Record In Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        int Create(LookupModel lookupModel);
        /// <summary>
        /// Update Record In Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        int Update(LookupModel lookupModel);
        /// <summary>
        /// Delete Record From Lookup By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}