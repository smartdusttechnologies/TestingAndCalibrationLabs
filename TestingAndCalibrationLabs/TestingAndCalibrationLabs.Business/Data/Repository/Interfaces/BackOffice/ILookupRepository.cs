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
     List<LookupModel> GetLookupCategoryId(int lookupCategoryId);
    }
}
