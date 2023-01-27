using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these SampleService is implementing interface for ISampleService
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// Implimenting interface for Add Class, It is used for Insertion.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RequestResult<bool> Add(RecordModel record);

        /// <summary>
        /// Implimenting interface for  Update Class
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RequestResult<bool> Save(RecordModel record);

        /// <summary>
        /// Implimenting Delete for Class.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        
        /// <summary>
        /// Implimenting for  GetUiPageMetadata
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        RecordModel GetUiPageMetadataCreate(int uiPageId);

        
        /// <summary>
        /// Implimenting interface dor GetRecords
        /// </summary>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        RecordsModel GetRecords(int uiPageId);

        /// <summary>
        /// Implimenting interface for GetRecordById
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        RecordModel GetRecordById(int recordId);
		byte[] TemplateGenerate(int uiPageTypeId,int metadataId);
    }
}
