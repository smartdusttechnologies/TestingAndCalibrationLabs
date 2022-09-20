using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<LookupModel> Get();
    }
}
