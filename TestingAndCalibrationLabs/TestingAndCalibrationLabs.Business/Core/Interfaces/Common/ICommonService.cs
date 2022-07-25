using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these SampleService is implementing interface for ISampleService
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// We are Invoking a serevice of Add 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RequestResult<bool> Add(RecordModel record);

        /// <summary>
        /// We are Invoking a serevice of Update
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RequestResult<bool> Update(RecordModel record);

        /// <summary>
        /// We are Invoking a serevice of Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// We are Invoking a serevice of GetUiPageMetadata
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        RecordModel GetUiPageMetadata(int uiPageId);

        /// <summary>
        /// We are Invoking a serevice of GetRecords
        /// </summary>
        /// <returns></returns>
        RecordsModel GetRecords();

        /// <summary>
        /// We are Invoking a serevice of GetRecordById
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        RecordModel GetRecordById(int recordId);
    }
}
