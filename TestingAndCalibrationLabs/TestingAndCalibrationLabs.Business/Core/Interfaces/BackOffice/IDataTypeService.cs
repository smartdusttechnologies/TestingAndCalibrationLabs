using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Data Type
    /// </summary>
    public interface IDataTypeService
    {
        /// <summary>
        /// Get All Record From Data Type
        /// </summary>
        List<DataTypeModel> Get();
    }
}
