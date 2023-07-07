using System.Collections.Generic;
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
        List<LookupModel> Get();
        
   
        List<LookupModel> GetByLookupCategoryId(int lookupCategoryId);
        /// <summary>
        /// To Get All Records Of Lookup
        /// </summary>
        /// <returns></returns>
        List<LookupModel> GetLookupCategoryId(int lookupCategoryId);

    }

}
