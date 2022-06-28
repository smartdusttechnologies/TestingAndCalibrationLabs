using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
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

        public bool servives(TestReportModel testReportModel)
        {
            return true;
        }
    }
}