using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ITestReportService
    {
        RequestResult<int> Add(TestReportModel testReportModel);
        bool servives(TestReportModel testReportModel);
    }
}
