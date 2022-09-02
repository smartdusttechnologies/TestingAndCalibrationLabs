using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
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
        DataTypeModel GetById(int id);
        RequestResult<int> Create(DataTypeModel dataTypeModel);
        RequestResult<int> Edit(DataTypeModel dataTypeModel);
        bool Delete(int id);


    }
}
