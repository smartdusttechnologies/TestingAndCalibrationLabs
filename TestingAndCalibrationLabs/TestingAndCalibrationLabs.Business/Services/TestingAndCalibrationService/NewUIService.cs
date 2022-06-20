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
    public class NewUIService : INewUIService
    {
        private readonly INewUIRepository _newUIRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _hostingEnvironment;
        //private readonly IUserRepository _userRepository;

        public NewUIService(INewUIRepository newUIRepository)
        {
            _newUIRepository = newUIRepository;
        
        }

        public RequestResult<int> Add(NewUIModel newUIModel)
        {
            _newUIRepository.Insert(newUIModel);
            return new RequestResult<int>(1);
        }

        public bool servives(NewUIModel newUIModel)
        {

            return true;
        }

    }
}

