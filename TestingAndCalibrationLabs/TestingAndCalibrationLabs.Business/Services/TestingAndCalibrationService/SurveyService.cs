﻿using MailKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        #region public methods

        public SurveyService(ISurveyRepository surveyRepository, IWebHostEnvironment hostingEnvironment, IEmailService emailservice, IUserRepository userRepository, IConfiguration configuration)
        {
            _surveyRepository = surveyRepository;
            _emailService = emailservice;
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public RequestResult<int> Add(SurveyModel surveymodel)
        {
            var emailsendTo = _userRepository.Get();

            //Read other values from Appsetting .Json 
            surveymodel.EmailTemplate = _configuration["TestingAndCalibration:UserTeplet"];
            surveymodel.EmailTemplate = _configuration["TestingAndCalibration:AdminMail"];
            surveymodel.LogoImage = _configuration["TestingAndCalibration:LogoImage"];
            surveymodel.BodyImage = _configuration["TestingAndCalibration:BodyImage"];
            surveymodel.EmailContact = _configuration["TestingAndCalibration:emailID"];
            surveymodel.MobileNumber = _configuration["TestingAndCalibration:Mobile"];

            //Create User Mail
            surveymodel.HtmlMsg = CreateBody(surveymodel.EmailTemplate);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*name*", surveymodel.Name);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*contactmail*", surveymodel.EmailContact);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*mob*", surveymodel.MobileNumber);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*LogoLink*", surveymodel.LogoImage);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*BodyImageLink*", surveymodel.BodyImage);
            var isemailsendsuccessfully = _emailService.Sendemail(surveymodel);

            _surveyRepository.Insert(surveymodel);

            //create msg for admins
            surveymodel.HtmlMsg = CreateBodyAdmin(surveymodel.EmailTemplate);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*name*", surveymodel.Name);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*mobilenumber*", surveymodel.Mobile);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Emailid*", surveymodel.Email.FirstOrDefault());
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*TestingType*", surveymodel.TestingType);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Address*", surveymodel.Address);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*City*", surveymodel.City);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*State*", surveymodel.State);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Pin*", surveymodel.PinCode);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Comment*", surveymodel.Comments);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*contactmail*", surveymodel.EmailContact);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Mob*", surveymodel.MobileNumber);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*LogoLink*", surveymodel.LogoImage);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*BodyImageLink*", surveymodel.BodyImage);

            surveymodel.Email.RemoveAt(0);

            foreach (var item in emailsendTo)
            {
                surveymodel.Email.Add(item);
            }

            var isemailsendsuccessfully1 = _emailService.Sendemail(surveymodel);
            if (isemailsendsuccessfully)
            {
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }
        private string CreateBody(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibration:UserTemplet"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
        private string CreateBodyAdmin(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibration:AdminMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}
#endregion