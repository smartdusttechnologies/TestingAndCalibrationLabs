using Microsoft.AspNetCore.Mvc;
using System.IO;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface DriveDownloadFile
    {
        string CreateFolder(string v1, string v2);
        void UploadFile(TestReportModel getbusinessModel);
        void UploadFileAndSendMail(TestReportModel testReportModel);
        void WebLinkMail(TestReportModel testReportModel, int Id);
    }
}