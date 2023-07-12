using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IDataTypeService
    {
        /// <summary>
        /// Get All Record From Data Type
        /// </summary>
        List<DataTypeModel> Get();
        /// <summary>
        /// Get Record From DataType By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTypeModel GetById(int id);
        /// <summary>
        /// Insert Record in DataType
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(DataTypeModel dataTypeModel);
        /// <summary>
        /// Edit Record in DataType
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Edit(DataTypeModel dataTypeModel);
        /// <summary>
        /// Delete Record From DataType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}