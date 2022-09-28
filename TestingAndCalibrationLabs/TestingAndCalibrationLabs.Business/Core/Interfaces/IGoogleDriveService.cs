using Microsoft.AspNetCore.Mvc;
using System.IO;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IGoogleDriveService
    {
        /// <summary>
        /// It is used to upload the file to Google Drive
        /// </summary>
        /// <param name="getbusinessModel"></param>
        AttachmentModel Upload(AttachmentModel attachmentModel);

        /// <summary>
        /// Used for downloading the data from the Google Drive
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        AttachmentModel Download(string fileId);
    }
}