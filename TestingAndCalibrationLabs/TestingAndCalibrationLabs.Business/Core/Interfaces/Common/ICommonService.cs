using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these SampleService is implementing interface for ISampleService
    /// </summary>
    public interface ICommonService
    {
        RequestResult<bool> Add(RecordModel record);
        RequestResult<bool> Update(RecordModel record);
        bool Delete(int id);
        RecordModel GetUiPageMetadata(int uiPageId);
        RecordsModel GetRecords(int uiPageId);
        RecordModel GetRecordById(int recordId);
    }
}
