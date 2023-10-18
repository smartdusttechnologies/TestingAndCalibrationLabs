using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using Microsoft.AspNetCore.Http;

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
        /// <summary>
        /// To Generate Template
        /// </summary>
        /// <param name="uiPageTypeId"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
		byte[] TemplateGenerate(int uiPageTypeId, int metadataId, string email, bool send, int FileId);
        /// <summary>
        /// To Get multi Value Records For Creating Grid
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        RecordsModel GetMultiControlValue(int recordId);
        /// <summary>
        /// To Delete Multi Value Records
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        RequestResult<bool> DeleteMultiValue(RecordModel record);
        /// <summary>
        /// Image Upload 
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        int ImageUpload(FileUploadModel fileUpload);
        /// <summary>
        /// Image Download
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        FileUploadModel DownloadImage(int ImageValue);

        /// <summary>
        /// This method to update file 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        bool FileUpdate(int Id, FileUploadModel fileUpload);
     }
}  