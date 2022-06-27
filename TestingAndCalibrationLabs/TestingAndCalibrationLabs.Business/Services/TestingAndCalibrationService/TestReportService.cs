using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class TestReportService : ITestReportService
    {
        private readonly ITestReportRepository _newUIRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _hostingEnvironment;
        //private readonly IUserRepository _userRepository;

        public TestReportService(ITestReportRepository newUIRepository)
        {
            _newUIRepository = newUIRepository;
        }

        public RequestResult<int> Add(TestReportModel newUIModel)
        {
            _newUIRepository.Insert(newUIModel);
            return new RequestResult<int>(1);
        }

        public bool servives(TestReportModel newUIModel)
        {
            return true;
        }
    }
}