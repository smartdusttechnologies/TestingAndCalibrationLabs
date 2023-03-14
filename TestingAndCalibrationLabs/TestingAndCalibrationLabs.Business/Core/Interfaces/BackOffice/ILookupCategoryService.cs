using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for LookupCategory
    /// </summary>
    public interface ILookupCategoryService
    {
        /// <summary>
        /// Get All Records From LookupCategory
        /// </summary>
        /// <returns></returns>
        List<LookupCategoryModel> Get();
        /// <summary>
        /// Get All Records From LookupCategory
        /// </summary>
        /// <returns></returns>
       
        LookupCategoryModel GetById(int id);
        /// <summary>
        /// Insert Record In LookupCategory
        /// </summary>
        /// <param name="lookupCategoryModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(LookupCategoryModel lookupCategoryModel);
        /// <summary>
        /// Edit Record From LookupCategory
        /// </summary>
        /// <param name="lookupCategoryModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(LookupCategoryModel lookupCategoryModel);
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);


    }
}
