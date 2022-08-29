using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IGoogleUploadDownloadService
    {
        /// <summary>
        /// It is used to upload the file to Google Drive
        /// </summary>
        /// <param name="getbusinessModel"></param>
        AttachmentModel UploadFile (AttachmentModel getbusinessModel);
        /// <summary>
        /// It is used to upload the file and send the email with web page link to access the data
        /// </summary>
        /// <param name="testReportModel"></param>
        //RequestResult<AttachmentModel> UploadUploadFileInternal (AttachmentModel attachmentModel);
        /// <summary>
        /// Used for downloading the data from the Google Drive
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        AttachmentModel DownLoadAttachment(string fileId);
    }
}