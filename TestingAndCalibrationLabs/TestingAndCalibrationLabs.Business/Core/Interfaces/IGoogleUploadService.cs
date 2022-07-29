using Microsoft.AspNetCore.Mvc;
using System.IO;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IDriveDownloadFile
    {
        /// <summary>
        /// It is used to create the new folder on the google drive
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        string CreateFolder(string v1, string v2);

        /// <summary>
        /// It is used to upload the file to Google Drive
        /// </summary>
        /// <param name="getbusinessModel"></param>
        void UploadFile(TestReportModel getbusinessModel);

        /// <summary>
        /// It is used to upload the file and send the email with web page link to access the data
        /// </summary>
        /// <param name="testReportModel"></param>
        void UploadFileAndSendMail(TestReportModel testReportModel);

        /// <summary>
        /// It is used to send the mail by TestReport Id 
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        void WebLinkMail(TestReportModel testReportModel, int Id);

        
    }
}