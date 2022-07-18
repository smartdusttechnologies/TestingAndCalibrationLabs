using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.TestingAndCalibration
{
    public interface ITestReportRepository
    {
        int Insert(TestReportModel testReportModel);
        int Get(TestReportModel testReportModel);
        int Update(int id, TestReportModel testReportModel);
        List<TestReportModel> Get();
        TestReportModel Get(int id);
        bool Delete(int id);
        int InsertCollection(List<TestReportModel> testReportModels);
        TestReportModel GetTestReport(int id);


        //object Insert(imageVal imageVal);
    }
}