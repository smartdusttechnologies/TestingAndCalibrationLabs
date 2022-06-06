﻿using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these SampleService is implementing interface for ISampleService
    /// </summary>
    public interface ISampleService
    {
        RequestResult<int> Add(RecordModel record);
        RequestResult<int> Update(RecordModel record);
        bool Delete(int id);
        RecordModel GetUiPageMetadata(int uiPageId);
        RecordsModel GetRecords();
        RecordModel GetRecordById(int recordId);
    }
}
