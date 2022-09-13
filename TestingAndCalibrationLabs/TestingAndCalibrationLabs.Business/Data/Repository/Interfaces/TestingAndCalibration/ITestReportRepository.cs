using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.TestingAndCalibration
{
    /// <summary>
    /// This interface is to perform the differnt operation for the Test Report Upload Download and view.
    /// </summary>
    public interface ITestReportRepository
    {
        /// <summary>
        /// To insert the record in the database
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        int Insert(TestReportModel testReportModel);

        /// <summary>
        /// To get the Test Report latest first
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        int Get(TestReportModel testReportModel);
        
        /// <summary>
        /// To update the Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        int Update(int id, TestReportModel testReportModel);

        /// <summary>
        /// Get the 
        /// </summary>
        /// <returns></returns>
        List<TestReportModel> Get();

        /// <summary>
        /// Get the test report record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestReportModel Get(int id);

        /// <summary>
        /// Delete the Test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Insert the list to test report
        /// </summary>
        /// <param name="testReportModels"></param>
        /// <returns></returns>
        int InsertCollection(List<TestReportModel> testReportModels);

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestReportModel GetTestReport(int id);
    }
}