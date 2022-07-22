using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
//using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration;
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
        
        public RequestResult<int> Add(TestReportModel testReportModel)
        {
            _testReportRepository.Insert(testReportModel);
            return new RequestResult<int>(1);
        }

        public List<TestReportModel> Get()
        {
            return _testReportRepository.Get();
        }

        public RequestResult<int> Update(int id, TestReportModel testReportModel)
        {
            _testReportRepository.Update(id, testReportModel);
            return new RequestResult<int>(1);
        }

        public TestReportModel GetTestReport(int id)
        {
            return _testReportRepository.GetTestReport(id);
        }
    }
}