using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository;

namespace TestingAndCalibrationLabs.Business.Services
{

    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IForgotPasswordRepository _ForgotPasswordRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;



        public ForgotPasswordService(IForgotPasswordRepository ForgotPasswordRepository, IWebHostEnvironment hostingEnvironment, IEmailService emailservice, IUserRepository userRepository, IConfiguration configuration)
        {
            _ForgotPasswordRepository = ForgotPasswordRepository;
            _emailService = emailservice;
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public RequestResult<int> Add(EmailModel emailmodel)
        {
            var emailsendTo = _userRepository.Get();

            //Read other values from Appsetting .Json 
            emailmodel.EmailTemplate = _configuration["TestingAndCalibrationSurvey:UserTemplate"];
            emailmodel.EmailTemplate = _configuration["TestingAndCalibrationSurvey:AdminMailTemplate"];
            emailmodel.LogoImage = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            emailmodel.BodyImage = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            emailmodel.EmailContact = _configuration["TestingAndCalibrationSurvey:emailID"];
            emailmodel.MobileNumber = _configuration["TestingAndCalibrationSurvey:Mobile"];
            emailmodel.Subject = _configuration["TestingAndCalibrationSurvey:Subject"];


            var isemailsendsuccessfully1 = _emailService.Sendemail(emailmodel);
            if ((bool)isemailsendsuccessfully1)
            {
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }


    }
}
