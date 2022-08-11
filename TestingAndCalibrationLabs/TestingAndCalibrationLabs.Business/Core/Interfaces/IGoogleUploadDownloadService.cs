using Microsoft.AspNetCore.Mvc;
using System.IO;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IGoogleUploadDownloadService
    {
        /// <summary>
        /// It is used to upload the file to Google Drive
        /// </summary>
        /// <param name="getbusinessModel"></param>
        string UploadFile(AttachmentModel getbusinessModel);

        /// <summary>
        /// It is used to upload the file and send the email with web page link to access the data
        /// </summary>
        /// <param name="testReportModel"></param>
       // void UploadFileAndSendMail(AttachmentModel attachmentModel);

        /// <summary>
        /// Used for downloading the data from the Google Drive
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        AttachmentModel DownLoadAttachment(string fileId);
    }
}