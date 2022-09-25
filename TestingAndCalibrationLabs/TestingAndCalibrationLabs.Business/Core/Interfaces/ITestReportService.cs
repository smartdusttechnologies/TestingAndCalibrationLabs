using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ITestReportService
    {
        /// <summary>
        /// Used to add the record using model.
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        RequestResult<bool> Add(TestReportModel testReportModel);

        /// <summary>
        /// Used to get all the records from Test Report Table.
        /// </summary>
        /// <returns></returns>
        List<TestReportModel> Get();

        /// <summary>
        /// Used to update the records by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        RequestResult<bool> Update(TestReportModel testReportModel);

        /// <summary>
        /// Used to get the test report record by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestReportModel Get(int id);

        /// <summary>
        /// To upload Test Report to Google Drive and send the mail.
        /// </summary>
        /// <param name="testReportModel"></param>
        bool UploadFileAndSendMail(TestReportModel testReportModel);

        /// <summary>
        /// To upload the Test Report to Google Drive.
        /// </summary>
        /// <param name="getbusinessModel"></param>
        bool UploadFile(TestReportModel getbusinessModel);

        /// <summary>
        /// Download the uploaded file from Google drive.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        AttachmentModel DownLoadAttachment(string fileId);

        /// <summary>
        /// To send the e-mail.
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool SendTestReportEmail(TestReportModel testReportModel);
    }
}