using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ITestReportService
    {
        RequestResult<int> Add(TestReportModel testReportModel);
        List<TestReportModel> Get();
        RequestResult<int> Update(int id, TestReportModel testReportModel);
        TestReportModel GetTestReport(int id);
    }
}