using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ITestReportService
    {
        /// <summary>
        /// Used to add the data to Data base using model
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        RequestResult<int> Add(TestReportModel testReportModel);

        /// <summary>
        /// Used to get the data from the database
        /// </summary>
        /// <returns></returns>
        List<TestReportModel> Get();

        /// <summary>
        /// used to update the record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, TestReportModel testReportModel);

        /// <summary>
        /// Used to get the test report by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestReportModel GetTestReport(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        //void WebLinkMail(TestReportModel testReportModel, int Id);

        RequestResult<AttachmentModel> UploadFileAndSendMail(TestReportModel testReportModel);

        RequestResult<AttachmentModel> UploadFile(TestReportModel getbusinessModel);

        AttachmentModel DownLoadAttachment(string fileId);

        void EmailLinkMail(TestReportModel testReportModel, int Id);
    }
}