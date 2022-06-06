using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISurveyRepository surveyRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISurveyRepository _surveyRepository;

        public EmailService(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, ISurveyRepository surveyRepository)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _surveyRepository = surveyRepository;
        }

        /// <summary>
        /// Sends mail using the Survey model.
        /// </summary>
        /// <param name="surveyModel"></param>
        /// <returns></returns>
        public bool Sendemail(SurveyModel surveyModel)
        {
            //Read SMTP settings from AppSettings.json.
            string host = _configuration["Smtp:Server"];
            int port = int.Parse(_configuration["Smtp:Port"]);
            string fromAddress = _configuration["Smtp:FromAddress"];
            string userName = _configuration["Smtp:UserName"];
            string password = _configuration["Smtp:Password"];
            string emailto = string.Join(",", surveyModel.Email);
            
            using (MailMessage mm = new MailMessage(fromAddress, emailto))
            {
                mm.Subject = surveyModel.Subject;
                mm.Body = surveyModel.HtmlMsg;
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(mm);
                }
            }
            return true;
        }
    }
}    