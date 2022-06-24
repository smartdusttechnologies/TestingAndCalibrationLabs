using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.TestingAndCalibration
{
    public interface ITestReportRepository
    {
        int Insert(TestReportModel newUIModel);
        int Get(TestReportModel newUIModel);
        int Update(TestReportModel newUIModel);
        List<TestReportModel> Get();
        TestReportModel Get(int id);
        bool Delete(int id);
        int InsertCollection(List<TestReportModel> newUI);
        //object Insert(imageVal imageVal);
    }
}