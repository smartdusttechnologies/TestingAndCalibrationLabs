using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class TestReportService : ITestReportService
    {
        private readonly ITestReportRepository _testReportRepository;

        public TestReportService(ITestReportRepository testReportRepository)
        {
            _testReportRepository = testReportRepository;
        }
        
        /// <summary>
        /// Inser test report data
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<int> Add(TestReportModel testReportModel)
        {
            _testReportRepository.Insert(testReportModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// List the test report
        /// </summary>
        /// <returns></returns>
        public List<TestReportModel> Get()
        {
            return _testReportRepository.Get();
        }

        /// <summary>
        /// Updat the test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, TestReportModel testReportModel)
        {
            _testReportRepository.Update(id, testReportModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestReportModel GetTestReport(int id)
        {
            return _testReportRepository.GetTestReport(id);
        }
    }
}