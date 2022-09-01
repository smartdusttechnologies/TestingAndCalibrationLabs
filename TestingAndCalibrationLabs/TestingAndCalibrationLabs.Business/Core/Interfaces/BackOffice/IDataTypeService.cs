using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IDataTypeService
    {
        List<DataTypeModel> Get();
        DataTypeModel GetById(int id);
        RequestResult<int> Create(DataTypeModel dataTypeModel);
        RequestResult<int> Edit(DataTypeModel dataTypeModel);
        bool Delete(int id);


    }
}
